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
    /// <summary>
    /// Home控制器
    /// </summary>
    [EnableCors("*", "*", "*"), RoutePrefix("api")]
    public class HomeController : ApiController
    {
        private readonly ITestService _testService;

        public HomeController(ITestService testService)
        {
            this._testService = testService;
        }

        /// <summary>
        /// 获取所有Test
        /// </summary>
        /// <returns>IEnumerable</returns>
        [HttpGet, Route("alltest")]
        public IEnumerable<Test> GetAllTests()
        {
            return _testService.GetAll();
        }

        /// <summary>
        /// 添加Test
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>bool</returns>
        [HttpPost, Route("addtest")]
        public bool AddTest(string name)
        {
            return this._testService.Add(new Test { Name = name });
        }
    }
}
