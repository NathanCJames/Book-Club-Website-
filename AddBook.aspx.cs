/*Name : Nathan James
 * BookClub Project 
 * F9F6QTH22
 * AddBook Page 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AddService;

public partial class AddBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblAddBookError.Visible = false;
        lblSuccess.Visible = false;
       
    }


    protected void btnAddBook_Click(object sender, EventArgs e)
    {
        //Declaring the Variables
        string Name = txtName.Text;
        string Author = txtAuthor.Text;
        string Genre = DropDownList1Genre.SelectedValue;
        //Connecting To the Webserice
        BookStoreWebService Connect = new BookStoreWebService(); 
        bool Exists = Connect.BookExists(Name,Author,Genre);
        if (Exists)
        {
            //Checks if Book Exists 
            lblAddBookError.Visible = true;
            lblAddBookError.Text = "Book Already Exists";

        }
        else
        {
            lblAddBookError.Visible = false;
            //Connecting To the Add Book Section in the Webservice 
            bool Result = Connect.AddBook(Name,Author,Genre);
            if (Result)
            {
                //Adds Book Successfully 
                lblSuccess.Visible = true;
                lblSuccess.Text = "Book Added Successfully ";
                Response.Redirect("BookPage.aspx");
            }
            else
            {
                //Prints an error If book was not Added Successfully 
                
                lblAddBookError.Visible = true;
                lblAddBookError.Text = "An Error Has Occured Please Try Again....";
            }
        }
    }
}