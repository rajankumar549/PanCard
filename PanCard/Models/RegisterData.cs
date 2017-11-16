using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanCard.Models
{
    public class RegisterData
    {
        public string reg_fullname { get; set; }
        public string reg_father_name { get; set; }
        public string reg_dob { get; set; }
        public string reg_addhar_no { get; set; }
        public string reg_pan_no { get; set; }
        public string reg_mob1 { get; set; }
        public string reg_mob2 { get; set; }
        public string reg_whatsapp { get; set; }
        public string reg_email { get; set; }
        public string reg_shop { get; set; }


        public string reg_add { get; set; }
        public string reg_city { get; set; }
        public string reg_state { get; set; }
        public string reg_pin { get; set; }


        public string reg_acc_name { get; set; }
        public string reg_acc_no { get; set; }
        public string reg_bank_name { get; set; }
        public string reg_ifsc { get; set; }

        public HttpPostedFileBase reg_add_doc { get; set; }
        public HttpPostedFileBase reg_pan_doc { get; set; }
        public HttpPostedFileBase reg_photo { get; set; }
    }
}