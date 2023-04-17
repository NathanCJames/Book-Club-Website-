/*Name: Nathan James 
 * BookClub Project
 * F9F6QTH22
 * Register Page 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Collections;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AddService;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblRegistrationError.Visible = false;
    }



    protected void btnRegister_Click(object sender, EventArgs e)
    {
        BookStoreWebService Connection = new BookStoreWebService();
        BookStoreWebService Connect = new BookStoreWebService();
        if (Page.IsValid)
        {
          
            try
            {
                //Getting the data by user in  the text fields
                string Email = txtEmail.Text;
                string Name = txtName.Text;
                string Surname = txtSurname.Text;
                string SecurityQ = @DropDownList1SQ.SelectedValue;
                string SecurityA = txtSecurityA.Text;
                string Password = txtPassword.Text;
                bool Result = Connect.Register(Email, Name, Surname, SecurityQ, SecurityA, Password);


                if (Result == true)
                {
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    //Checks if there are any errors
                    lblRegistrationError.Visible = true;
                    lblRegistrationError.Text = "Email Already Exists";
                }

            }
            catch (OleDbException ex)
            {
                lblRegistrationError.Visible = true;
                lblRegistrationError.Text = ex.Message;
            }
        }
    }
}