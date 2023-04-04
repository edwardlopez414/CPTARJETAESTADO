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

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        string headers;
        private object args;

        public ActionResult Index()
        {

            //var builder = WebApplication1.CreateBuilder(args);

            //builder.Services.AddRazorPages();
            //builder.Services.AddControllersWithViews();

            //builder.Services.AddDistributedMemoryCache();

            //builder.Services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});

            //var app = builder.Build();

            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseSession();

            //app.MapRazorPages();
            //app.MapDefaultControllerRoute();

            //app.Run();
            return View();
        }
        public ActionResult login()
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
            res.header.agent_account = "ANU022335";
            res.header.operator_id = "Rlopez249744598.163736";
            res.header.terminal_id = "POSNI0014061";
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
        public JsonResult Monitor( string header)
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
            res.header.agent_account = "ANU022335";
            res.header.operator_id = "Rlopez249744598.163736";
            res.header.terminal_id = "POSNI0014061";
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

        public JsonResult Loginvalidation(string header,string user ,string pwd )
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
            respuesta =    service.ValidarLogin( StrCodigo,  StrUsuario, pwd_Login, ref dt, ref  StrError);

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

      
    }
}