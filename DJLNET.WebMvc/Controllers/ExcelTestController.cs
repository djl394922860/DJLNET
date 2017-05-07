using AutoMapper;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    [AllowAnonymous]
    public class ExcelTestController : ExcelController
    {
        private IUserService _userService;
        private IMapper _mapper;

        public ExcelTestController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }


        [ActionName("TestExportExcel")]
        public ActionResult Index()
        {
            var users = this._userService.GetAll();
            var models = this._mapper.Map<IEnumerable<UserViewModel>>(users);
            return Excel(models);
        }
    }
}