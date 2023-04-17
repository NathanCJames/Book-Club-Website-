/*NATHAN JAMES 
 * BOOK CLUB PROJECT 
 * BOOK PAGE 
 * DATE DESIGNED 19/01/2022
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AddService;

public partial class BookPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["LoggedIn"]==null||(Request.Cookies["LoggedIn"] !=null &&Request.Cookies["LoggedIn"].Value!="true"))
        {
            Response.Redirect("Login.aspx");
        }
        //All Panels will not be visible until a certain action is met 

        PanelCheckBookID.Visible = false;
        PanelAddRating.Visible = false;
    }

    protected void btnAddBook_Click(object sender, EventArgs e)
    {
        //the button will take the user to the add books Page 

        Response.Redirect("AddBook.aspx");
    }

    protected void btnRate_Click(object sender, EventArgs e)
    {
        //Once the User chooses to Rate a Book The CheckBook ID Panel Will be Shown

        PanelCheckBookID.Visible = true;
    }

    protected void btnBookID_Click(object sender, EventArgs e)
    {
        //Checks if the TextBox is not Empty 
        if (txtBookID.Text != "")
        {
            //The following Code will Check if a Book Exists if not an Error will pop up Stating That (Book Does Not Exists)
            int ID = int.Parse(txtBookID.Text);
            //Connecting To the WebService To Collect The BookID 

            BookStoreWebService Connect = new BookStoreWebService();
            bool Result = Connect.BookIDExists(ID);
            if (Result == true)
            {
                PanelAddRating.Visible = true;
                lblBookIDError.Visible = false;
                

            }
            else
            {
                PanelCheckBookID.Visible = true;
                lblBookIDError.Visible = true;
                lblBookIDError.Text = "Book ID Does Not Exists";
                
            }
        }
        else
        {
            lblBookIDError.Visible = true;
        }
       

    }

    protected void btnAddRating_Click(object sender, EventArgs e)
    {
        //Once a BookID exists The Add Ratings Panel will Appear And the user will be able to add a Rating 

        int Rate = DropDownList1.SelectedIndex + 1;
        int ID = int.Parse(txtBookID.Text);
        
        string strEmail = Session["Email"].ToString();
        BookStoreWebService Connect = new BookStoreWebService();
        //Checks if User(Email) has already rated the Book
        bool AlreadyRated = Connect.AlreadyRated(strEmail,ID);
        if(AlreadyRated)
        {
            PanelCheckBookID.Visible = true;
            PanelAddRating.Visible = false;
            lblRatingError.Visible = true ;
            lblRatingError.Text = "You have already Rated this book Please Choose another one";
            


        }
        else
        {
            //If the Rating is Successful the database + GridView will Update displaying the Average of The Book that was Rated 
            PanelCheckBookID.Visible = true;
            lblRatingError.Visible = false;
            bool Result = Connect.Rating(strEmail,ID, Rate);
            int Sum = Connect.GetSum(ID);
            int People = Connect.GetAmountRated(ID);
            People = People + 1;
            Sum = Sum += Rate;
            if (Result)
            {
                lblRatingError.Visible = false;
                
               
                int Average = Sum / People;
                
                bool SumUpdate = Connect.UpdateSum(ID, Sum);
                bool UpdatePeople = Connect.UpdateAmountRated(ID, People);
                bool UpdateAverage = Connect.UpdateAverageRating(ID,Average);

                Response.Redirect("BookPage.aspx");

            }
            else
            {
                //If the Rating Was Unsuccessful an Error will pop Up
                lblRatingError.Visible = true;
                lblRatingError.Text = "An Error Has Occured Please Try Again";
            }
        }
    }

    protected void btnViewProfile_Click(object sender, EventArgs e)
    {
        //If the User wants to view their Profile the View Profile Button is Clicked 
        Response.Redirect("ProfilePage.aspx");
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        //If the User wishes to Log Out the Log Out Button is Clicked 

        if(Response.Cookies["LoggedIn"]!=null)
        {
            HttpCookie LoggedInCookie = new HttpCookie("LoggedInCookie", "false");
            Response.SetCookie(LoggedInCookie);

            Response.Redirect("Login.aspx");
        }
        
    }
}