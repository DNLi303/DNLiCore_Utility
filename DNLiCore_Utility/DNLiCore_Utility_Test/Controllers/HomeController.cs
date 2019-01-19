using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DNLiCore_Utility_Test.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Data;

namespace DNLiCore_Utility_Test.Controllers
{
    public class HomeController : Controller
    {
        public IHostingEnvironment hostingEnvironment;
        public HomeController(IHostingEnvironment _hostingEnvironment) {
            hostingEnvironment = _hostingEnvironment;
        }
        public IActionResult Index()
        {
            string sWebRootFolder = hostingEnvironment.WebRootPath;
            string realPath = Path.Combine(sWebRootFolder, "Upload/1.xlsx");
            DataSet ds = DNLiCore_Utility.Excel.ExcelHelper.GetExcelToTable(realPath);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
