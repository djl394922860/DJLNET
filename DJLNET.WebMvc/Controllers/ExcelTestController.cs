using AutoMapper;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebCore.Mvc;
using DJLNET.WebMvc.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class ExcelTestController : ExcelController
    {
        private IUserService _userService;
        private IMapper _mapper;

        public ExcelTestController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }


        [NonAction]
        public ActionResult Index()
        {
            var cities = this._userService.GetAll();
            var models = this._mapper.Map<IEnumerable<UserViewModel>>(cities);
            return Excel(models);
        }
    }
}