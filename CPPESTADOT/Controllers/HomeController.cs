using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CPPESTADOT.Models.API;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;

namespace CPPESTADOT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  JsonResult Name(int i)
        {
           
            var name = i+5;
            return Json(i);

           
        }
    }
}
