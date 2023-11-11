using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace BasicCRUDOpration.DbOprations
{
    public partial class ViewCategory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-GHNFMQT;database=BasicCrud;uid=admin;pwd=root");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllDetails();
                pagination();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetAllDetails();
            pagination();
        }

        private void GetAllDetails()
        {
            string qry = "SELECT P.ProductId, P.ProductName, P.CategoryId, C.CategoryName FROM Products P " +
    "JOIN Categories C ON P.CategoryId = C.CategoryId";
            SqlDataAdapter adapter = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        private void pagination()
        {
            int pageSize = 10; // Adjust this value as needed
            int currentPage = 1; // Set the initial page number
            Repeater productList = new Repeater();
            con.Open();
            string s = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(s, con);
            int totalRecords = (int)cmd.ExecuteScalar();
            int numberOfPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            string str = "SELECT * FROM Products ORDER BY ProductName OFFSET @startRowIndex ROWS FETCH NEXT @pageSize ROWS ONLY";
            SqlCommand ncmd = new SqlCommand(str, con);
            ncmd.Parameters.AddWithValue("@startRowIndex", (currentPage - 1) * pageSize);
            ncmd.Parameters.AddWithValue("@pageSize", pageSize);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(ncmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            con.Close();
            productList.DataSource = dataTable;
            productList.DataBind();
        }
    }
}