// <copyright file="GetDataUsingSql.cs" company="NA">
//     All rights reserved.
// </copyright>
namespace SQLPractice
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Manages and fetches data from SQL server
    /// </summary>
    public class GetDataUsingSql
    {
        /// <summary>
        /// Gets or sets connection string 
        /// </summary>
        public string ConnectionStr { get; set; }

        /// <summary>
        /// Gets all products 
        /// </summary>
        /// <returns> Returns dataTable </returns>
        public DataTable GetProducts()
        {
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlConnection conn = null;

            if (string.IsNullOrEmpty(this.ConnectionStr))
            {
                throw new ArgumentNullException("Connection string can not be empty");
            }

            try
            {
                DataSet ds = new DataSet();
                //// Create the connection obj
                conn = new SqlConnection(this.ConnectionStr);

                //// create a command object
                cmd = new SqlCommand("Select * from Products", conn);
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                ////Executes the query
                conn.Open();
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Gets data using DataReader
        /// </summary>
        /// <returns> Returns datatable</returns>
        public DataTable GetProductsUsingSqlDataReader()
        {
            SqlCommand cmd;
            SqlConnection conn = null;

            if (string.IsNullOrEmpty(this.ConnectionStr))
            {
                throw new ArgumentNullException("Connection string can not be empty");
            }

            try
            {
                DataTable dt = new DataTable();
                //// Create the connection obj
                conn = new SqlConnection(this.ConnectionStr);

                //// create a command object
                cmd = new SqlCommand("Select * from Products", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                var reader = cmd.ExecuteReader();
                dt.Load(reader);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
