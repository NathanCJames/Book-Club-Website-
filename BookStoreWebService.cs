using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.Services.Protocols;

using System.IO;//For streamwritter files 

/// <summary>
/// Summary description for BookStoreWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BookStoreWebService : System.Web.Services.WebService
{

    OleDbCommand Cmd;
    OleDbConnection Con;
    OleDbDataReader Reader;
    string dbPath = "C:/Users/f9f6qth22/Desktop/BookClubProject (2)/BookClubProject/BookClubProject/App_Data/BookClubDB.accdb";
    public BookStoreWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Creating Connection To DB
    [WebMethod(Description = "Creating a Connection to the Database")]
    public bool ConnectToDB()
    {
        try
        {
            string ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + dbPath;
            Con = new OleDbConnection(ConString);
            //THE FILE PATH FOR THE DATABASE WILL NEED TO BE CHANGED WHEN USING ANOTHER PC TO WHERE IT WILL BE LOCATED 

            Con.Open();
            return true;
            //Opening the connection to the Database
        }
        catch (OleDbException)
        {
            return false;
        }

    }
    #endregion
    #region Testing Connnection
    [WebMethod(Description = "Testing the Database Connection")]
    public bool TestDB()
    {
        //Testing If the Connection Works if not An Error will pop up Stating False

        bool Status;
        try
        {
            ConnectToDB();
            Status = true;

        }
        catch (OleDbException)
        {
            Status = false;
        }
        return Status;
    }
    #endregion
    #region Closing Connection to DB
    [WebMethod(Description = "Closing/disconnecting the Database")]
    public bool DisconnectDB()
    {
        try
        {
            ConnectToDB();
            Con.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        //Closes the connection to the Database
    }
    #endregion
    #region Checks if User email Exists
    [WebMethod(Description = "Checking if email exists")]
    public bool CheckUserExists(string Email)
    {

        try
        {
            //Checking If user exists by Receiving Data from the Database and Matching It with the values Entered by the User 

            ConnectToDB();
            string QueryString = "SELECT * FROM [User] WHERE Email='" + Email + "';";
            Cmd = new OleDbCommand(QueryString, Con);
            Cmd.Connection = Con;
            Reader = Cmd.ExecuteReader();

            if (Reader.HasRows && Reader != null)
            {
                //Email Exists
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception)
        {
            return false;
        }

    }
    #endregion
    #region Creating Register

    //Web method used to register a new user

    [WebMethod(Description = "Regsitering a new user to the DB")]

    //Declaring the variables used in the DB

    public bool Register(string Email,string Name,string Surname,string SecurityQ,string SecurityA,string Password)
    {
        try
        {
            //The following Code allows Data to be Entered into the database also known as Registration
            ConnectToDB();

            Cmd = Con.CreateCommand();

            //Creating a Small string Value where the insert Statment is Created 
            string StrCmdTxt = "INSERT INTO [User] VALUES('" + Email + "','" + Name + "','" + Surname + "','" + SecurityQ + "','" + SecurityA + "','" + Password + "')";

            Cmd = new OleDbCommand(StrCmdTxt, Con);

            Cmd.Connection = Con;

            Cmd.CommandText = StrCmdTxt;

            Cmd.ExecuteNonQuery();

            return true;
        }
        catch(Exception)
        {
            return false;
        }
       
        
  
        
        
       

    }
    #endregion
    #region Checking Login
    [WebMethod(Description = "Creating a Login")]
    public bool Login(string Email, string Password)
    {
        bool Result = false;
        try
        {
            //
            int counter = 0;
            ConnectToDB();
            Cmd = new OleDbCommand();
            Cmd.Connection = Con;
            Con.CreateCommand();

            //The Selecct Statement will recieve The Specfic User info and match it if true the User logs in Else an Error message will pop up 

            string QueryString = "SELECT * FROM [User] WHERE Email ='";
            QueryString += Email + "'AND Password ='";
            QueryString += Password + "'";
            Cmd.CommandText = QueryString;
            Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                counter++;

            }
            if (counter == 1)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
            Con.Close();
        }
        catch (OleDbException)
        {
            return false;
        }
        return Result;
    }
    #endregion
    #region Checking if a Book Exists 
    [WebMethod(Description = "Checking if book exists ")]
    public bool BookExists(string Name, string Author, string Genre)
    {
        ConnectToDB();
        try
        {
            
            Cmd = new OleDbCommand();
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "SELECT * FROM Books WHERE BookName ='" + Name + "'AND [BookAuthor] = '" + Author + "' AND [BookGenre] = '" + Genre + "'";
            Reader = Cmd.ExecuteReader();

            if (Reader.Read() && Reader != null)
            {
                return true;

            }
            else
            {
                return false;

            }

        }
        catch (OleDbException)
        {
            return false;
        }
    }
    #endregion
    #region Adding a new Book 
    [WebMethod(Description = "Adding a new Book")]
    public bool AddBook(string Name, string Author, string Genre)
    {
        ConnectToDB();
        try
        {
            Cmd = new OleDbCommand();
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "INSERT INTO Books(BookName,BookAuthor,BookGenre) VALUES ('" + Name + "','" + Author + "','" + Genre + "')";
            Cmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }
        catch (OleDbException)
        {
            return false;
        }
    }
    #endregion
    #region Checking if BookID Exists
    [WebMethod]
    public bool BookIDExists(int ID)
    {
        ConnectToDB();

        try
        {
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "SELECT * FROM Books WHERE BookID = " + ID + "";
            Reader = Cmd.ExecuteReader();

            if (Reader.Read() && Reader != null)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    #endregion//This test is All Commented out 
    #region Checking if User Already Rated 
    [WebMethod(Description = "Already Rated ")]
    public bool AlreadyRated(string Email, int ID)
    {
            ConnectToDB();
            string StrEmail = Email;
            Cmd = new OleDbCommand();
            Cmd = Con.CreateCommand();
            string strCmdQuery = @"SELECT * FROM [Ratings] WHERE [bookID] = " + ID + " and [Email] = '" + StrEmail + "';"; 
            Cmd.CommandText = strCmdQuery;
            Reader = Cmd.ExecuteReader();
            if (Reader.Read() && Reader != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        //}
        //catch (Exception)
        //{
        //    return false;
        //}
    }
    #endregion
    #region Adding a Rating 
    [WebMethod(Description ="Adding a Rating")]
    public bool Rating(string Email,int BookID, int Rating )
    {
        ConnectToDB();


            string StrEmail = Email;
            Cmd = Con.CreateCommand();
            Cmd.Connection = Con;
            string strRatingText = "INSERT INTO [Ratings] VALUES('" + BookID + "','" + StrEmail+ "','" + Rating + "')";
            Cmd.CommandText = strRatingText;
            Cmd = new OleDbCommand(strRatingText, Con);
            Cmd.ExecuteNonQuery();
            Con.Close();

            //if the Rating was successful it will be stored in the Database then copied into a TextFile
            FileStream fs = new FileStream("C:/Users/f9f6qth22/Desktop/BookClubProject (2)/BookClubProject/SteamWritter.txt", FileMode.Append);
            BufferedStream bs = new BufferedStream(fs);
            fs.Close();

            StreamWriter sw = new StreamWriter("C:/Users/f9f6qth22/Desktop/BookClubProject (2)/BookClubProject/StreamWritter.txt",true);
            sw.WriteLine("Email:" + Session["Email"] + ",BookID : " + BookID + ", Rating : " + Rating);
            sw.Close();

            return true;
        
       
    }
    #endregion
    #region Getting Ammount Rated 
    [WebMethod(Description = "getting Amount Rated")]
    public int GetAmountRated(int ID )
    {
        ConnectToDB();
        
        int AmountRated =0;
        Cmd = Con.CreateCommand();
        Cmd.CommandText = "SELECT AmountRated FROM [Books] WHERE BookID =" + ID;
        
        Reader = Cmd.ExecuteReader();
        if (Reader.Read() && Reader != null)
        {
            //try
            //{

                AmountRated = Reader.GetInt32(0);
                


                
               
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        return AmountRated;
    }
    #endregion
    #region Getting Sum Rated
    [WebMethod(Description ="getting Sum of rating ")]
    public int GetSum(int ID )
    {
        ConnectToDB();
       
        int sum = 1;
        Cmd = Con.CreateCommand();
        Cmd.CommandText = @"SELECT [SumRated] FROM [Books] WHERE BookID =" + ID;
        
        Reader = Cmd.ExecuteReader();
        if(Reader.Read()&& Reader != null)
        {
            //try
            //{

                sum = Reader.GetInt32(0);
                return sum++;

            //}
            //catch(Exception)
            //{
            //    throw;
            //}
        }
        return sum;
        
    }
    #endregion
    #region UpdateSumRated
    [WebMethod(Description ="Updating Sum")]
    public bool UpdateSum(int ID, int Sum)
    {
        ConnectToDB();
        //try
        //{
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "UPDATE [Books] SET SumRated = " + Sum + " WHERE (BookID =" + ID +")";
           
            Cmd.ExecuteNonQuery();
            Con.Close();
            

            return true;
        //}
        //catch(Exception)
        //{
        //    return false;
        //}
    }
    #endregion
    #region UpdateAmountRated
    [WebMethod(Description ="Updating the Amount Rated")]
    public bool UpdateAmountRated(int ID, int Amount)
    {
        ConnectToDB();
        //try
        //{
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "UPDATE [Books] SET AmountRated = " + Amount + " WHERE (BookID =" + ID +")" ;
            Cmd.ExecuteNonQuery();
            Con.Close();
            return true;
        //}
        //catch(Exception)
        //{
        //    return false;
        //}
    }
    #endregion
    #region UpdateAverageRating 
    [WebMethod(Description = "Updating Average Rating ")]
    public bool UpdateAverageRating(int ID, int Average)
    {
        ConnectToDB();
        
        
            //Once the Server collects the total Amount Rated plus the of Ratings The Update for the Average will happen
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "UPDATE [Books] SET AverageRating = " + Average + " WHERE (BookID =" + ID +")";
            Cmd.ExecuteNonQuery();
            Con.Close();
            return true;
        
        //catch(Exception)
        //{
        //    return false;
        //}
    }
    #endregion
    #region Viewing Profile
    [WebMethod(Description ="Viewing User Details")]
    public DataTable Profiles(string email)
    {
        ConnectToDB();
        try
        {
            //A dataSet is Created with a Datatable that recieves the User (LoggedIn) Details and displays it 

            string strEmail = email;
            DataSet ds = new DataSet();
            OleDbDataAdapter dba = new OleDbDataAdapter("SELECT * FROM [User] WHERE Email ='" + strEmail + "'",Con);
            dba.Fill(ds, "User");
            DataTable dt = ds.Tables["User"];
            return dt;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion
    #region Updating Name 
    [WebMethod(Description = "Updating Name")]
    public bool UpdateName(string Email, string Name)
    {
        ConnectToDB();
        try
        {
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "UPDATE [User] SET [Name] = '" + Name + "' WHERE (Email ='" + Email+"');";
            Cmd.ExecuteNonQuery();
            Con.Close();
            return true;

        }
        catch(Exception)
        {
            return false;
        }
       
    }
    #endregion
    #region UpdateSurname
    [WebMethod(Description = "Updating Surname")]
    public bool UpdateSurname(string Email, string Surname)
    {
        ConnectToDB();
        try
        {
            Cmd = Con.CreateCommand();
            Cmd.CommandText = "UPDATE [User] SET [Surname] ='" + Surname + "' WHERE (Email ='" +Email+"');" ;
            Cmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }
        catch(Exception)
        {
            return false;
        }
    }
    #endregion
    #region Retrieving User Question
    [WebMethod]
    public string getQuestion(string Email)
    {
        ConnectToDB();

        string question = "null";
        //For the User to be able to update Their Details(password)Data will be Selected from the Database only if the User Email Exists and if The Answer Matches the Question 
        Cmd = Con.CreateCommand();
        Cmd.CommandText = @"SELECT SecurityQ FROM [User] WHERE Email = '" + Email + "'";
        Reader = Cmd.ExecuteReader();

        if (Reader.Read()&&Reader!=null)
        {
            try
            {
                question = Reader.GetString(0);
            }
            catch (Exception)
            {

                throw;
            }
        }

        return question;
    }
    #endregion
    #region Retreiving User Answer
    [WebMethod]
    public bool AnswerCorrect(string Email, string answer)
    {
        ConnectToDB();

        try
        {
            //Once the User Recieves there Question and gives an Answer the Select Statement will Check the Database
            //Check if the Answer Matches what the user has Written Down Else an Error will Pop up

            Cmd = Con.CreateCommand();
            Cmd.Connection = Con;
            string QueryTest = @"SELECT * FROM [User] WHERE Email ='";
            QueryTest+= Email +"'AND SecurityA ='";
            QueryTest += answer + "'";
            Cmd.CommandText = QueryTest;

            Reader = Cmd.ExecuteReader();

            if (Reader.Read()&&Reader!=null)
            {
                //If Password Matches the User can Change their password 
                return true;

            }
            else
            {
                //if Password does not Match an Error will return false

             return false;
            }
        }
        catch (SoapException)
        {
            return
                false;
        }
    }
    #endregion
    #region Forgot/Update Password
    [WebMethod(Description = "Forgot Password")]

    public bool forgotPassword(string Email, string password)
    {
       
        try
        {
            ConnectToDB();
            //if the user wants to change /forgot their password the update statements allows them to do so and if fails an Error will pop up

            Cmd = Con.CreateCommand();
            Cmd.CommandText = "UPDATE [User] SET [Password] = '" + password + "' WHERE (Email = '" + Email + "');";
            Cmd.ExecuteNonQuery();
            Con.Close();
            return true;
        }
        catch(Exception)
        {
            return false;
        }
            
        
    }
    #endregion






}
