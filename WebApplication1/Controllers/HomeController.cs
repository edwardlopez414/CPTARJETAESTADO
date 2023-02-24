using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string postransNumber(ulong i) {

          
            string respuesta;
            Conversion.NumberConversionSoapTypeClient oComNumb = new Conversion.NumberConversionSoapTypeClient("NumberConversionSoap");

            respuesta = oComNumb.NumberToWords(i);

            return respuesta;
        }
        [HttpPost]
        public JsonResult Name(ulong i)
        {
            string respuesta;
            respuesta = postransNumber(i);
               
         
            return Json(respuesta);


        }
    }
}