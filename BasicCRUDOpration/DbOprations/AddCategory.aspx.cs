using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BasicCRUDOpration.DbOprations
{
    public partial class AddCategory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-GHNFMQT;database=BasicCrud;uid=admin;pwd=root");
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindMaxUserID();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Normal query or concatinated query
            //for numeric data  '"+controlvalues+"'
            //for string values '"+controlvalues+"'
            string qry = "insert into Categories (CategoryName) values('" + CategoryName.Text+"') ";
            cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Category Details saved successfully!!!!";
            ClearText(); //to reset textboxes of current values
            BindMaxUserID();
        }

        private void BindMaxUserID() //method to get max userId
        {
            string qry = "select max(CategoryID)+1 from Categories";
            cmd= new SqlCommand(qry,con);
            con.Open();
            object id = cmd.ExecuteScalar();
            con.Close();
            if (CategoryID.ReadOnly)
            {
                CategoryID.ReadOnly = false;
            }
            CategoryID.Text=id.ToString();
            CategoryID.ReadOnly = true;
        }

        private void ClearText()
        {
            CategoryID.Text = "";
            CategoryName.Text = "";
        }
    }
}