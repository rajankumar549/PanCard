using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PanCard.Models;
using System.IO;

namespace PanCard.Controllers
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
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterData form )
        {      string fnamepan="", fnameadd="", fnamephoto="",pan="",add="",photo="";
            Random random = new Random();
           // random.Next(1000,100000).ToString();
            ViewBag.Message = "Your contact page.";
            LogFileWrite.write(form.reg_acc_name);
            try
            {
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfilespan = form.reg_pan_doc.FileName.Split(new char[] { '\\' });
                    string[] testfilesadd = form.reg_add_doc.FileName.Split(new char[] { '\\' });
                    string[] testfilesphoto = form.reg_photo.FileName.Split(new char[] { '\\' });
                    fnamepan = DateTime.Now.ToString("yyyyMMddHHmmss")+random.Next(1000, 100000).ToString() + "_" + testfilespan[testfilespan.Length - 1] + DateTime.Now;
                    fnameadd = DateTime.Now.ToString("yyyyMMddHHmmss") +random.Next(1000, 100000).ToString() + "_" + testfilespan[testfilesadd.Length - 1];
                    fnamephoto = DateTime.Now.ToString("yyyyMMddHHmmss")+ random.Next(1000, 100000).ToString() + "_" + testfilespan[testfilesphoto.Length - 1];
                }
                else
                {
                    fnamepan = DateTime.Now.ToString("yyyyMMddHHmmss")+random.Next(1000, 100000).ToString() + "_" + form.reg_pan_doc.FileName;
                    fnameadd = DateTime.Now.ToString("yyyyMMddHHmmss")+ random.Next(1000, 100000).ToString() + "_" + form.reg_photo.FileName;
                    fnamephoto = DateTime.Now.ToString("yyyyMMddHHmmss")+ random.Next(1000, 100000).ToString() + "_" + form.reg_add_doc.FileName;

                }
                 photo = fnamephoto;
                add = fnameadd;
                 pan = fnamepan;

                // Get the complete folder path and store the file inside it.  
                fnamepan = Path.Combine(Server.MapPath("~/Uploads/"), fnamepan);
                fnameadd = Path.Combine(Server.MapPath("~/Uploads/"), fnameadd);
                fnamephoto = Path.Combine(Server.MapPath("~/Uploads/"), fnamephoto);
                LogFileWrite.write(fnamepan + fnameadd + fnamephoto);
                form.reg_pan_doc.SaveAs(fnamepan);
                form.reg_add_doc.SaveAs(fnameadd);
                form.reg_photo.SaveAs(fnamephoto);
            }
            catch(Exception ex)
            {
                LogFileWrite.write(ex.Message);
            }
            string ip = Request.ServerVariables["REMOTE_ADDR"];

          string result=sql.insert(form, ip, add, pan, photo);
            if(result=="true")
            {   //LogFileWrite.write()
                LogFileWrite.write("form submitted Sucessfull.......");
                Response.Redirect("http://localhost/pancard");
            }
            else
            {
                LogFileWrite.write(result);
                
            }
           

            return View();
        }
    }
}