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

namespace CPPESTADOT.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> API(string Variable)
        {

            bool status = false;
            string respuesta = string.Empty;

            using (var client = new HttpClient())
            {
                //var usarname = "";
                //var passwd = "";

                client.BaseAddress = new Uri("https://www.banguat.gob.gt");


                var intent = new APIDATA()
                {

                    Envelope = new Envelope()
                    {
                        Body = new Body()
                        {
                            Variables = new Variables()
                            {
                                variable = ""
                            }
                        }
                    }
                };
                var json = JsonConvert.SerializeObject(intent);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/variables/ws/TipoCambio.asmx", data);

                status = response.IsSuccessStatusCode;

                if (status) { 
                respuesta = response.Content.ReadAsStringAsync().Result;
                }

                return Json(new { status = status, respuesta = respuesta }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
