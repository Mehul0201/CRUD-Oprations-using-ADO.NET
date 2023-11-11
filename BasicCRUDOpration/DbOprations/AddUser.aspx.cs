using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BasicCRUDOpration.DbOprations
{
    public partial class AddUser : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-GHNFMQT;database=BasicCrud;uid=admin;pwd=root");
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindMaxProductID();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string checkCategoryQuery = "SELECT COUNT(*) FROM Categories WHERE CategoryID = @CategoryID";
            cmd = new SqlCommand(checkCategoryQuery, con);
            cmd.Parameters.AddWithValue("@CategoryID", CategoryID.Text);
            con.Open();
            int categoryCount = (int)cmd.ExecuteScalar();
            if (categoryCount == 0)
            {
                // The category doesn't exist, handle accordingly
                Label1.Text = "Category does not exist. Cannot add product.";
            }
            else
            {
                string qry = "insert into Products (ProductName,CategoryID) values('" + ProductName.Text + "','" + CategoryID.Text + "') ";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@ProductName", ProductName.Text);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID.Text);
                cmd.ExecuteNonQuery();
                Label1.Text = "Product Details saved successfully!";
            }
            con.Close();
            ClearText(); // Reset textboxes of current values
            BindMaxProductID();
        }
        private void BindMaxProductID() //method to get max userId
        {
            string qry = "select max(ProductID)+1 from Products";
            cmd = new SqlCommand(qry, con);
            con.Open();
            object id = cmd.ExecuteScalar();
            con.Close();
            if (ProductID.ReadOnly)
            {
                ProductID.ReadOnly = false;
            }
            ProductID.Text = id.ToString();
            ProductID.ReadOnly = true;

        }

        private void ClearText()
        {
            ProductID.Text = "";
            ProductName.Text = "";
            CategoryID.Text = "";
        }
    }
}