using Microsoft.AspNetCore.Mvc;
using WebCache.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using WebCache.Helper;

namespace WebCache.Controllers
{
    public class HomeController : Controller
    {
        private ICacheFactory _cacheFactory;

        public HomeController(ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
        }

        public IActionResult Index()
        {
            var response = _cacheFactory.RetrieveOrUpdateRedis<IEnumerable<ProductItem>>();

            TempData["DataLoadTime"] = response.ElapsedMilliseconds;
            TempData["DataLoadType"] = response.DataLoadType;

            return View(response.DeserializedCachedContent);
        }
   

        public IActionResult Error()
        {
            return View();
        }
    }
}
