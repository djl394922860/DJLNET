using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DJLNET.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeController : ApiController
    {
        private readonly ITestService _testService;

        public HomeController(ITestService testService)
        {
            this._testService = testService;
        }

        [HttpGet]
        public IEnumerable<Test> GetAllTests()
        {
            return _testService.GetAll();
        }

        [HttpPost]
        public bool AddTest(string name)
        {
            return this._testService.Add(new Test { Name = name });
        }
    }
}
