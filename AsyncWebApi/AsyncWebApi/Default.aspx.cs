using AsyncWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsyncWebApi
{
    public partial class _Default : Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var empData = new WebClient().DownloadString("http://localhost:13516/api/Data/");
        //        List<Employee> emps = DeserializeEmployees(empData);
        //        Employees.DataSource = emps;
        //        Employees.DataBind();
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                try
                {
                    var empData = await new WebClient().DownloadStringTaskAsync("http://localhost:13516/api/Data/");
                    List<Employee> emps = DeserializeEmployees(empData);
                    Employees.DataSource = emps;
                    Employees.DataBind();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }));
        }

        private List<Employee> DeserializeEmployees(string empData)
        {
            List<Employee> employees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(empData);
            return employees;
        }
    }
}