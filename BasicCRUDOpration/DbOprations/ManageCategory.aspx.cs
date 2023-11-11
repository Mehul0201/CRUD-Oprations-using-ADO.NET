using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace BasicCRUDOpration.DbOprations
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-GHNFMQT;database=BasicCrud;uid=admin;pwd=root");
        SqlCommand cmd;
        SqlDataReader dtr;
        SqlDataAdapter adapter;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string qry = "select CategoryName from Categories where CategoryID=@id";
            cmd = new SqlCommand(qry,con);
            cmd.Parameters.AddWithValue("@id", CategoryID.Text);
            con.Open();
            dtr = cmd.ExecuteReader(); //getting datareader reference
            if (dtr.Read())
            {
                CategoryName.Text = dtr[0].ToString();
                Label1.Text = "";
            }
            else 
            {
                Label1.Text = "No Record Found!!!!!";
            }
            con.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = "update Categories set CategoryName=@name";
            cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@name", CategoryName.Text);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                Label1.Text = "Record Updated Successfully!!!!";
            }
            else
            {
                Label1.Text = "Record Not Updated Successfully!!!!";
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string qry = "select * from Categories";
            SqlDataAdapter adapter = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string deleteqry = "delete from Categories WHERE CategoryID = @categoryId";
            cmd = new SqlCommand(deleteqry, con);
            cmd.Parameters.AddWithValue("@categoryId", CategoryID.Text);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                Label1.Text = "Record Deleted Successfully!!!!";
            }
            else
            {
                Label1.Text = "Record not found or no changes made.";
            }
        }
    }
}