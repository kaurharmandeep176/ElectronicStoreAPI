using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Models;
namespace ElectronicStore.Controllers
{
    public class HomeController : Controller
    {
        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=DESKTOP-17CKR5L;Initial Catalog=ElectronicStore;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;


        public void QueryRecord(String query)
        {
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
            sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
        }



        public ActionResult Index()
        {
            return View();
        }

        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable srchRecord(String qry)
        {
            DataTable tbl = new DataTable();

            sqlCon = new SqlConnection(conStr);

            sqlCon.Open();
            sqlcmd = new SqlCommand(qry, sqlCon);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlCon.Close();

            return tbl;
        }
        public ActionResult AdminLogin() {
            return View();
        }

        public ActionResult Pannel()
        {
            return View();
        }
        public ActionResult  wrong()
        {
            return View();
        }


        public ActionResult Admin(Admin adm){
            string qry = "select * from Admin_Table where User_Name='"+adm.User_Email+"' and User_Password='"+adm.User_Password+"'";
            DataTable tbl = new DataTable();
            tbl = srchRecord(qry);
            if (tbl.Rows.Count>0) {

                return View("pannel");
            }
            else {
                return View("wrong");
            }

        }

        public ActionResult feed() {
            return View();
        }
        public ActionResult passMsg(Conact msg) {

            String qry = "insert into Contact_Table(Name,Email,Message) values ('"+msg.User_Name+"','"+msg.User_Email+"','"+msg.User_Message+"')";
            QueryRecord(qry);
            return View("feed");

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
    }
}