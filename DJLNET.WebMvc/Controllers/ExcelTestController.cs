using AutoMapper;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.WebCore;
using DJLNET.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJLNET.WebMvc.Controllers
{
    public class ExcelTestController : ExcelController
    {
        private ITestService _testService;
        private IMapper _mapper;

        public ExcelTestController(ITestService testService, IMapper mapper)
        {
            this._testService = testService;
            this._mapper = mapper;
        }


        // GET: ExcelTest
        public ActionResult Index()
        {
            var tests = this._testService.GetAll();
            var models = this._mapper.Map<IEnumerable<TestViewModel>>(tests);
            return Excel<TestViewModel>(models);
        }
    }
}