/*Name : Nathan James 
 * F9f6QTH22
 * BookClub Project 
 * Date : 19/01/2022
 * Profile Page 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AddService;

public partial class ProfilePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["LoggedIn"] == null || (Request.Cookies["LoggedIn"] != null && Request.Cookies["LoggedIn"].Value == "false"))
        {
            Response.Redirect("Login.aspx");
        }
        //Ensuring that the update panel is not shown until the user clicks on the update Details Button

        UpdatePanel.Visible = false;
        lblEmail1.Text = "";
        lblName1.Text = "";
        lblSurname1.Text = "";

        BookStoreWebService Connect = new BookStoreWebService();
        DataTable dt = new DataTable();
        string emailProfile = Session["Email"].ToString();
        dt = Connect.Profiles(emailProfile);
        foreach (DataRow User in dt.Rows)
        {
            lblEmail1.Text = lblEmail1.Text +  User["Email"];
            lblName1.Text = lblName1.Text +  User["Name"];
            lblSurname1.Text = lblSurname1.Text +  User["Surname"];

        }

    }

    protected void btnUpdateDetails_Click(object sender, EventArgs e)
    {
        UpdatePanel.Visible = true;//Ensures that the next Panel is Shown when the user clicks the button 


    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string fName = txtName.Text;
        string SName = txtSurname.Text;
        string Email = lblEmail1.Text;
        if (fName!="")
        {
            //Updating an Individual Section for the Name 
            BookStoreWebService connection = new BookStoreWebService();
            bool Result = connection.UpdateName(Email,fName);
            if(Result)
            {
                
                
                    BookStoreWebService Connect = new BookStoreWebService();
                    DataTable dt = new DataTable();
                    string emailProfile = Session["Email"].ToString();
                    dt = Connect.Profiles(emailProfile);

                    foreach (DataRow User in dt.Rows)
                    {
                        lblEmail1.Text = lblEmail1.Text + User["Email"];
                        lblName1.Text = lblName1.Text + User["Name"];
                        lblSurname1.Text = lblSurname1.Text + User["Surname"];
                    }
                
               
               
            }
            if (SName != "")
            {
                //Updating individual Section for the Surname 
                //Calling the Webservice 
               
                    BookStoreWebService Connection = new BookStoreWebService();
                    //Calling The Update Section from the webService 
                    bool Result1 = Connection.UpdateSurname(Email, SName);
                    if (Result1)
                    {
                        BookStoreWebService Connect = new BookStoreWebService();
                        DataTable dt = new DataTable();
                        string emailProfile = Session["Email"].ToString();
                        dt = Connect.Profiles(emailProfile);
                        foreach (DataRow User in dt.Rows)
                        {
                            lblEmail1.Text = lblEmail1.Text + "<br>" + User["Email"];
                            lblName1.Text = lblName1.Text + "<br>" + User["Name"];
                            lblSurname1.Text = lblSurname1.Text + "<br>" + User["Surname"];
                        }
                    }
                   
                  

                }
                //Added this because there was a glitch so that the Page refreshes every time the user Updates 
                Response.Redirect("ProfilePage.aspx");
            }
            else
            {
                UpdatePanel.Visible = true;
                lblUpdateError.Visible = true;
                lblUpdateError.Text = "Unable to update";
               
            }

                
        
        


    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        
        
            //if the user chooses to log out after either viewing or updating their details 
            HttpCookie LoggedInCookie = new HttpCookie("LoggedIn", "false");
            Response.SetCookie(LoggedInCookie);

            Response.Redirect("Login.aspx");

        

    }

    protected void btnViewBooks_Click(object sender, EventArgs e)
    {
        //once User view Profile and updates any details has the option to either log out or go back to viewing the Books

        Response.Redirect("BookPage.aspx");
    }
}