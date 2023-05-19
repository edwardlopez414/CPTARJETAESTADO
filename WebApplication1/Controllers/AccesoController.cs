using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace WebApplication1.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult error()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string header, string user, string pwd)
        {

            bool respuesta = false;

            LOGIN.ValidarLoginRequest login = new LOGIN.ValidarLoginRequest();
            LOGIN.ServiceClient service = new LOGIN.ServiceClient();

            string StrCodigo = header;
            string StrUsuario = user;
            string pwd_Login = pwd;
            string error = string.Empty;
            login.DataUser = new DataTable();
            DataTable dataTable = new DataTable { TableName = "DataTable" };

            System.Data.DataTable DataUser = new System.Data.DataTable();
            string StrError = "";

            DataTable dt = JsonConvert.DeserializeObject<DataTable>(
                @"[
                    { col1: 'value1', col2: 'value2' },
                    { col1: 'value3', col2: 'value4' },
                    { col1: 'value5', col2: 'value6' },
                ]");
            dt.TableName = "TableName";



            try
            {
                respuesta = service.ValidarLogin(StrCodigo, StrUsuario, pwd_Login, ref dt, ref StrError);

            }
            catch
            {
                try
                {
                    respuesta = false;
                }
                catch
                {


                }
            }

            if (respuesta == false)
            {
                ViewBag.Error = "Las credenciales no son correctas";
                return View();
            }
            else {
                FormsAuthentication.SetAuthCookie(user, false);
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
    }
}