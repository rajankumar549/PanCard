using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PanCard.Models
{
    public class sql
    {
        protected static SqlConnection con;
        static protected  void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["PancardDB"].ToString();
            con = new SqlConnection(constr);

        }
        public static string insert(RegisterData obj,string serverIP,string reg_add_doc,string reg_pan_doc,string reg_photo)
        {
            try
            {



                connection();
                SqlCommand com = new SqlCommand("RegisterUser", con);
                
               
              
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.AddWithValue("@reg_fullname", obj.reg_fullname);
                com.Parameters.AddWithValue("@reg_father_name", obj.reg_father_name);
                com.Parameters.AddWithValue("@reg_dob", obj.reg_dob);
                com.Parameters.AddWithValue("@reg_addhar_no", obj.reg_addhar_no);
                com.Parameters.AddWithValue("@reg_pan_no", obj.reg_pan_no);
                com.Parameters.AddWithValue("@reg_mob1", obj.reg_mob1);
                com.Parameters.AddWithValue("@reg_mob2", obj.reg_mob2);
                com.Parameters.AddWithValue("@reg_whatsapp", obj.reg_whatsapp);
                com.Parameters.AddWithValue("@reg_email",obj.reg_email);
                com.Parameters.AddWithValue("@reg_shop", obj.reg_shop);


                com.Parameters.AddWithValue("@reg_add", obj.reg_add);
                com.Parameters.AddWithValue("@reg_city", obj.reg_city);
                com.Parameters.AddWithValue("@reg_state", obj.reg_state);
                com.Parameters.AddWithValue("@reg_pin", obj.reg_pin);


                com.Parameters.AddWithValue("@reg_acc_name", obj.reg_acc_name);
                com.Parameters.AddWithValue("@reg_acc_no", obj.reg_acc_no);
                com.Parameters.AddWithValue("@reg_bank_name", obj.reg_bank_name);
                com.Parameters.AddWithValue("@reg_ifsc", obj.reg_ifsc);


                com.Parameters.AddWithValue("@reg_add_doc", reg_add_doc);
                com.Parameters.AddWithValue("@reg_pan_doc", reg_pan_doc);
                com.Parameters.AddWithValue("@reg_pan_photo", reg_photo);

                com.Parameters.AddWithValue("@server_ip", serverIP);
                com.Parameters.AddWithValue("@verified_at", DateTime.Now.ToString("s"));
                

                con.Open();
                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                return e.Message;
            }

            finally
            {
                con.Close();
            }
            return "true";
        }



    }
}