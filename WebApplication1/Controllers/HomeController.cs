using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows;
using System.Xml.Linq;

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

        public string XMLTRAMARESPONSE(string header)
        {

            string respuesta;

            CREDENTIAL.WebRequestClient response = new CREDENTIAL.WebRequestClient ("BasicHttpBinding_IWebRequest");

            respuesta = response.GetResponse(header);

            return respuesta;
        


        }
        [HttpPost]
        public JsonResult Name(ulong i)
        {
            string respuesta;
            respuesta = postransNumber(i);
               
         
            return Json(respuesta);


        }


        public JsonResult Credenciales(string header)
        {

            

            string respuesta;
          
            string headers = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"><soapenv:Header /><soapenv:Body><header><agency_id>3639</agency_id><agency_account>CAS00001</agency_account><user>DgadeaH2H</user><password>Cashpak20192</password><terminal_id>POSNI0014935</terminal_id><operation_id>card-status-query-request</operation_id></header><card-status-query-request><platform>IVR</platform><id_product>K640</id_product><account_number>" +header+
                "</account_number></card-status-query-request></soapenv:Body></soapenv:Envelope>";
            //XCData cdata = new XCData(@headers);
            ////CData string
            //string cdataString = cdata.ToString();


            respuesta = XMLTRAMARESPONSE(headers);




            return Json(respuesta);


        }
    }
}