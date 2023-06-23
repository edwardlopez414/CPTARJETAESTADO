using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using WebApplication1.CUSTOMERSEARCH;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Ajax.Utilities;
using WebApplication1.ServiceReference1;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        string headers;
        private object args;

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

        public ActionResult error()
        {

            return View();
        }

        public string XMLTRAMARESPONSE(string header)
        {

            string respuesta;

            CREDENTIAL.WebRequestClient response = new CREDENTIAL.WebRequestClient("BasicHttpBinding_IWebRequest");

            respuesta = response.GetResponse(header);

            return respuesta;

        }




        public JsonResult Monitorinfo(string header)
        {


            //string respuesta;
            string anexo = string.Empty;

            CustomerSearchRequest res = new CUSTOMERSEARCH.CustomerSearchRequest();
            CustomerSearchRequest HEAD = new CUSTOMERSEARCH.CustomerSearchRequest();
            MonitorCashPakClient SEND = new CUSTOMERSEARCH.MonitorCashPakClient("BasicHttpBinding_IMonitorCashPak");

            DateTime myDate = DateTime.Now;
            string longDateString = myDate.ToLongDateString();
            res.header = new request_header();
            res.search_parameters = new customer_parameters();
            res.header.agent_account = ConfigurationManager.AppSettings["agent_account"];
            res.header.operator_id = ConfigurationManager.AppSettings["operator_id"];
            res.header.terminal_id = ConfigurationManager.AppSettings["terminal_id"];
            res.header.agent_country_code = "NI";
            res.header.agent_id = null;
            res.header.param1 = null;
            res.header.param2 = null;
            res.header.param3 = null;
            res.header.param4 = null;
            res.header.param5 = null;
            res.search_parameters = new customer_parameters();
            res.search_parameters.channel = null;
            res.search_parameters.document_number = header;
            res.search_parameters.customer_name = new customer_name();
            res.search_parameters.customer_name.first_name1 = "";
            res.search_parameters.customer_name.first_name2 = null;
            res.search_parameters.customer_name.last_name1 = "";
            res.search_parameters.customer_name.last_name2 = null;
            res.search_parameters.date_of_birth = myDate;

       
           
            return Json(SEND.CustomerSearch(res));



        }
        public JsonResult Monitor(string header)
        {
            string respuesta;
            string anexo = string.Empty;

            CUSTOMERSEARCH.CustomerSearchRequest res = new CUSTOMERSEARCH.CustomerSearchRequest();
            CUSTOMERSEARCH.CustomerSearchRequest HEAD = new CUSTOMERSEARCH.CustomerSearchRequest();
            CUSTOMERSEARCH.MonitorCashPakClient SEND = new CUSTOMERSEARCH.MonitorCashPakClient("BasicHttpBinding_IMonitorCashPak");

            DateTime myDate = DateTime.Now;
            string longDateString = myDate.ToLongDateString();
            res.header = new request_header();
            res.search_parameters = new customer_parameters();
            res.header.agent_account = ConfigurationManager.AppSettings["agent_account"];
            res.header.operator_id = ConfigurationManager.AppSettings["operator_id"];
            res.header.terminal_id = ConfigurationManager.AppSettings["terminal_id"];
            res.header.agent_country_code = "NI";
            res.header.agent_id = null;
            res.header.param1 = null;
            res.header.param2 = null;
            res.header.param3 = null;
            res.header.param4 = null;
            res.header.param5 = null;
            res.search_parameters = new customer_parameters();
            res.search_parameters.channel = null;
            res.search_parameters.document_number = header;
            res.search_parameters.customer_name = new customer_name();
            res.search_parameters.customer_name.first_name1 = "";
            res.search_parameters.customer_name.first_name2 = null;
            res.search_parameters.customer_name.last_name1 = "";
            res.search_parameters.customer_name.last_name2 = null;
            res.search_parameters.date_of_birth = myDate;

            try
            {

                headers = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"><soapenv:Header /><soapenv:Body><header><agency_id>3639</agency_id><agency_account>CAS00001</agency_account><user>DgadeaH2H</user><password>Cashpak20192</password><terminal_id>POSNI0014935</terminal_id><operation_id>card-status-query-request</operation_id></header><card-status-query-request><platform>IVR</platform><id_product>K640</id_product><account_number>" + SEND.CustomerSearch(res).error.error_code.ToString() +
              "</account_number></card-status-query-request></soapenv:Body></soapenv:Envelope>";

            }
            catch
            {
                try
                {
                    string st = SEND.CustomerSearch(res).customer_form.customer.customer_accounts[0].account_number;

                    headers = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"><soapenv:Header /><soapenv:Body><header><agency_id>3639</agency_id><agency_account>CAS00001</agency_account><user>DgadeaH2H</user><password>Cashpak20192</password><terminal_id>POSNI0014935</terminal_id><operation_id>card-status-query-request</operation_id></header><card-status-query-request><platform>IVR</platform><id_product>K640</id_product><account_number>" + st +
                       "</account_number></card-status-query-request></soapenv:Body></soapenv:Envelope>";

                    anexo = st;

                }
                catch {

                    headers = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"><soapenv:Header /><soapenv:Body><header><agency_id>3639</agency_id><agency_account>CAS00001</agency_account><user>DgadeaH2H</user><password>Cashpak20192</password><terminal_id>POSNI0014935</terminal_id><operation_id>card-status-query-request</operation_id></header><card-status-query-request><platform>IVR</platform><id_product>K640</id_product><account_number>" + "1111" +
            "</account_number></card-status-query-request></soapenv:Body></soapenv:Envelope>";



                }
            }

            respuesta = XMLTRAMARESPONSE(headers);

            return Json(respuesta);

        }

        public JsonResult Loginvalidation(string header, string user, string pwd)
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


            return Json(respuesta.ToString());

        }

        public JsonResult Reference()
        {
        

            CASA_SRTMX_CuentaPortTypeClient Ccredential = new CASA_SRTMX_CuentaPortTypeClient("CASA_SRTMX_CuentaPort", "https://10.70.10.85:8000/CASA_SRTMX_CuentaService?wsdl");
            CASA_SRTMX_CuentaPortType csc = new CASA_SRTMX_CuentaPortTypeClient();
          

            ConsultarResponse consultar1 = new ConsultarResponse();

           

            ConsultarRequest consulta = new ConsultarRequest
            
            {
                Autenticacion = new Autenticacion
                {
                    Usuario = ConfigurationManager.AppSettings["usuario"],
                    Password = ConfigurationManager.AppSettings["password"]
                },
                Originador = new Originador
                {
                    Solicitante = ConfigurationManager.AppSettings["solicitante"],
                    ZonaHoraria = ConfigurationManager.AppSettings["ZonaH"]
                },
                Cuenta = "558548754"
            };

            input3 ds = new input3(consulta)
            {
                ConsultarRequest = consulta
            };
            

            ServicePointManager.ServerCertificateValidationCallback = delegate
                    (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            Ccredential.ClientCredentials.Windows.ClientCredential.UserName = ConfigurationManager.AppSettings["usuario"];
            Ccredential.ClientCredentials.Windows.ClientCredential.Password = ConfigurationManager.AppSettings["password"];

            Ccredential.Open();
           
            Ccredential.Close();    
            return Json(ds, JsonRequestBehavior.AllowGet);




        }


    }
}