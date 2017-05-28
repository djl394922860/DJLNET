using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebCore.Mvc;
using DJLNET.WebCore.Security;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DJLNET.Model.Entities;
using DJLNET.Core.Extension;
using AutoMapper;

namespace DJLNET.WebMvc.Controllers
{
    /// <summary>
    /// 网站全局菜单导航管理
    /// </summary>
    public class NavigateController : BaseController
    {
        private readonly INavigateService _service;
        private readonly IMapper _mapper;
        public NavigateController(INavigateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var navigateViewModels = _mapper.Map<IEnumerable<NavigateViewModel>>(_service.GetAll());
            var sortedNavigates = SortNavigate(navigateViewModels);
            return View(sortedNavigates);
        }

        private IEnumerable<NavigateViewModel> SortNavigate(IEnumerable<NavigateViewModel> source)
        {
            var result = new List<NavigateViewModel>();
            var orders = source.OrderBy(x => x.SortOrder);
            var roots = orders.Where(x => x.ActionName.IsNullOrEmpty() && x.ControllerName.IsNullOrEmpty() && !x.ParentID.HasValue);
            foreach (var root in roots)
            {
                result.Add(root);
                if (source.Any(x => x.ParentID.HasValue && x.ParentID.Value == root.ID))
                    LoadChildren(result, root, orders);
            }
            return result;
        }

        private void LoadChildren(List<NavigateViewModel> result, NavigateViewModel item, IEnumerable<NavigateViewModel> orders)
        {
            var childs = orders.Where(x => x.ParentID.HasValue && x.ParentID.Value == item.ID);
            if (childs.Any())
            {
                foreach (var child in childs)
                {
                    result.Add(child);
                    LoadChildren(result, child, orders);
                }
            }
        }

        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView("~/Views/Navigate/_AddEditPage.cshtml");
        }

        [HttpPost, ActionAuthorization("NavigateAdd")]
        public ActionResult Add(NavigateModel model)
        {
            return null;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost, ActionAuthorization("NavigateEdit")]
        public ActionResult Edit(NavigateModel model)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return null;
        }
    }
}