using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching
{
    class SqlRepository : IRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK128;Initial Catalog=ProductDetails;User ID=sa;Password=test123!@#";
            con = new SqlConnection(constr);

        }
        public List<Product> GetAllProducts()
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dadapter = new SqlDataAdapter(command);
            DataTable dtable = new DataTable();
            con.Open();
            dadapter.Fill(dtable);
            con.Close();
            foreach (DataRow datarow in dtable.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(datarow["Id"]),
                        Name = Convert.ToString(datarow["Name"]),
                        Price = Convert.ToInt32(datarow["Price"])
                    }
                );

            }
            return productList;
        }

        public Product GetProductById(int id)
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Products where Id=" + id;
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dadapter = new SqlDataAdapter(command);
            DataTable dtable = new DataTable();
            con.Open();
            dadapter.Fill(dtable);
            con.Close();
            foreach (DataRow datarow in dtable.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(datarow["Id"]),
                        Name = Convert.ToString(datarow["Name"]),
                        Price = Convert.ToInt32(datarow["Price"])
                    }
                );

            }
            return productList[0];
        }
    }
}
