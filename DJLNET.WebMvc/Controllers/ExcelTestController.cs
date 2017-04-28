using AutoMapper;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebCore;
using DJLNET.WebMvc.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class ExcelTestController : ExcelController
    {
        private ICityService _cityService;
        private IMapper _mapper;

        public ExcelTestController(ICityService cityService, IMapper mapper)
        {
            this._cityService = cityService;
            this._mapper = mapper;
        }


        // GET: ExcelTest
        public ActionResult Index()
        {
            var cities = this._cityService.GetAll();
            var models = this._mapper.Map<IEnumerable<PlatformViewModel>>(cities);
            return Excel(models);
        }
    }
}