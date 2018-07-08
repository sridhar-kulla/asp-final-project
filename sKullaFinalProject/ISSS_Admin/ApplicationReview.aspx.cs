using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ISSS_Admin_ApplicationReview : System.Web.UI.Page
{
    string applicationsConString =
     WebConfigurationManager.ConnectionStrings["applicationsConString"].ConnectionString;
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {        
        // Define the Select statement.
        // Select offer letter from table

        string studentID = GridView1.SelectedValue.ToString();
        string selectQuery = string.Format(@"Select [offer_letter] From [Applications] Where student_id={0}"
                                    ,studentID);

        SqlConnection con = new SqlConnection(applicationsConString);

        // Read File content from Sql Table 
        SqlCommand selectCommand = new SqlCommand(selectQuery, con);
                              

        // Try to open database and read information.
        try
        {
            con.Open();

            // All the information is transferred with one command
            reader = selectCommand.ExecuteReader();
        }
        catch (Exception err)
        {
            statusLabel.Text = "Error reading region table. ";
            statusLabel.Text += err.Message;
        }        

        if (reader.Read())
        {
            byte[] fileData = (byte[])reader[0];
           
            MemoryStream ms = new MemoryStream(fileData);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=OfferLetter.pdf");
            Response.Buffer = true;

            ms.WriteTo(Response.OutputStream);
            Response.End();
        }
        con.Close();

    }
    protected void Application_Status(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        DropDownList duty = (DropDownList)gvr.FindControl("DropDownList1");
                
        string text = duty.SelectedItem.Text;
        string value = duty.SelectedItem.Value;

        if (value == "Approved")
            statusLabel.Text = "Approved nana";
        else
            statusLabel.Text = "gone";
    }
        
}