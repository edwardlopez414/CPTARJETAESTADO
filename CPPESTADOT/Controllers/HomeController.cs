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
        public async Task<JsonResult> API()
        {
          
            using (var client = new HttpClient())
            {
                
                string url = "https://jsonplaceholder.typicode.com/posts";

                client.DefaultRequestHeaders.Clear();   

                string paramtros = "{'title': 'foo','body': 'bar de prueba', 'userId': 1,}";

                dynamic jsonstring = JObject.Parse(paramtros);

                var httpConten = new StringContent(jsonstring.ToString(), Encoding.UTF8, "application/json");
               
                var response = client.PostAsJsonAsync(url, httpConten).Result;

                var response2 = response.Content.ReadAsStringAsync().Result;

                dynamic r2= JObject.Parse(response2);
                //var json = JsonConvert.SerializeObject(intent);
                

                //HttpResponseMessage response = await client.PostAsync("/variables/ws/TipoCambio.asmx", data);

                //status = response.IsSuccessStatusCode;

                //if (status) { 
                ////respuesta = response.Content.ReadAsStringAsync().Result;
                //}

                return Json(new { respuesta = r2 }, JsonRequestBehavior.AllowGet);
            }

            
        }
    }
}
