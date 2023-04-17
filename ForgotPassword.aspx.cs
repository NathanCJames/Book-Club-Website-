using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AddService;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmailCheckPanel.Visible = true; ;
        UpdatePasswordPanel.Visible = false;
        SecurityCheckPanel.Visible = false;
        lblCheckEmailError.Visible = false;
        lblCheckAnswerError.Visible = false;
        lblUpdatePasswordError.Visible = false;
        
    }

    protected void btnCheckEmail_Click(object sender, EventArgs e)
    {
        string Email = txtCheckEmail.Text;
        BookStoreWebService Connect = new BookStoreWebService();
        bool Exists = Connect.CheckUserExists(Email);
        if (Exists)
        {
            lblCheckEmailError.Visible = false;
            SecurityCheckPanel.Visible = true;
            lblQuestionShow.Text = Connect.getQuestion(Email);
        }
        else
        {
            EmailCheckPanel.Visible = true;

            lblCheckEmailError.Visible = true;
            lblCheckEmailError.Text = "Email Does not Exists Enter a Valid Email";


        }
    }

    protected void btnCheckAnswer_Click(object sender, EventArgs e)
    {
        SecurityCheckPanel.Visible = true;
        lblCheckAnswerError.Visible = false;
        string Email = txtCheckEmail.Text ;
        string Answer = txtSecAnswer.Text;
        

        BookStoreWebService Connect = new BookStoreWebService();
        bool CorrectAnswer = Connect.AnswerCorrect(Email, Answer);
        if (CorrectAnswer)
        {
            lblCheckAnswerError.Visible = false;
            UpdatePasswordPanel.Visible = true;

        }
        else
        {
            SecurityCheckPanel.Visible = true;
            lblCheckAnswerError.Visible = true;
            lblCheckAnswerError.Text = "Answer is Incorrect Please Try Again....";
            UpdatePasswordPanel.Visible = false;

        }
    }

    protected void btnUpdatePassword_Click(object sender, EventArgs e)
    {
        string Email = txtCheckEmail.Text;
        lblUpdatePasswordError.Visible = false;
        string Password = txtNewPassword.Text;
        
        BookStoreWebService Connect = new BookStoreWebService();
        bool PasswordChange = Connect.forgotPassword(Email,Password);
        if(PasswordChange)
        {
            HttpCookie LoggedInCookie = new HttpCookie("LoggedIn", "false");
            Response.Cookies.Add(LoggedInCookie);
            Session["Email"] = Email;
            Response.Redirect("Login.aspx");
            
        }
        else
        {
            lblUpdatePasswordError.Visible = true;
            UpdatePasswordPanel.Visible = true;
            lblUpdatePasswordError.Text = "An Error has Occured Please Try Again...";
        }
    }
}