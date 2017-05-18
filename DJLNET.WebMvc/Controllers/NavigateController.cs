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
            return View(navigateViewModels);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
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