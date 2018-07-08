using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_Application : System.Web.UI.Page
{
     string applicationsConString =
     WebConfigurationManager.ConnectionStrings["applicationsConString"].ConnectionString;
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        
            string studentName = studentNameTextBox.Text;
            DateTime dateOfBirth = dobCalendar.SelectedDate;
            long studentID = long.Parse(studentIDTextBox.Text);
            string phoneNumber =phoneTextBox.Text;
            string programName = programDropDownList.SelectedValue;
            double gpa = double.Parse(gpaTextBox.Text);
            string employer = employerTextBox.Text;
            byte[] offerletter = offerLetterFileUpload.FileBytes;
            string degree = RadioButton1.Checked ? "Bachelors" : "Masters";

        string query = @"INSERT INTO dbo.Applications(student_name,date_of_birth,student_id,phone_number,degree_level,program_name,gpa,employer_name,offer_letter) 
                   VALUES (@studentName, @dateOfBirth, @studentID, @phoneNumber,@degree, @programName,@gpa,@employer,@offerletter)";

        SqlConnection con = new SqlConnection(applicationsConString);
        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@studentName", studentName);
        cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
        cmd.Parameters.AddWithValue("@studentID", studentID);
        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
        cmd.Parameters.AddWithValue("@degree", degree);
        cmd.Parameters.AddWithValue("@programName", programName);
        cmd.Parameters.AddWithValue("@gpa", gpa);
        cmd.Parameters.AddWithValue("@employer", employer);
        cmd.Parameters.AddWithValue("@offerletter", offerletter);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

        }
        catch (Exception err)
        {
            statusLabel.Text = "Error Inserting Data";
            statusLabel.Text += err.Message;
        }
        finally
        {
            con.Close();
        }

    }
}