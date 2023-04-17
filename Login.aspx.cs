/*Name: Nathan James
 * BookClub Project
 * F9F6QTH22
 * Login Page 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AddService;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        lblLogInError.Visible = false;//Ensuring the label is hidden 
      
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Once the Register button is clicked the user will be redirected to the Register Page 

        Response.Redirect("Register.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        string Email = txtEmail.Text;
        string Password = txtPassword.Text;
        BookStoreWebService Connect = new BookStoreWebService();
        BookStoreWebService Connection = new BookStoreWebService();
        bool EmailCheck = Connection.CheckUserExists(Email);
        if (EmailCheck == true)
        {
            
            bool Login = Connect.Login(Email, Password);
            if (Login == true)
            {
                lblLogInError.Visible = false;
                HttpCookie LoggedInCookie = new HttpCookie("LoggedIn", "true");
                Response.Cookies.Add(LoggedInCookie);
                Session["Email"] = Email;
                Response.Redirect("BookPage.aspx");
            }
            else
            {
                lblLogInError.Visible = true;
                lblLogInError.Text = "Password is Incorrect";
            }
          
        }
        else
        {
            lblLogInError.Visible = true;
            lblLogInError.Text = "Email Does not Exits";
        }

        


    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnForgotPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }
}