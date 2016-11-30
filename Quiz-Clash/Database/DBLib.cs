using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Quiz_Clash
{
  public  class DBLib
    {
     public   string conn_string = ConfigurationManager.ConnectionStrings["QuizClash"].ConnectionString;
	public DBLib()
	{ 	
	}

    public DataTable SelectQuery(string query)
    {

        DataTable dt = new DataTable();
        try
        {
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            conn.Close();
        }
        catch 
        {
           
           
        }
        return dt;
    }

    public int InsertQuery(string query)
    {

        DataTable dt = new DataTable();
        int result = 0;
        try
        {
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            conn.Close();
            result = 1;
        }
        catch
        {
            result = 0;
        }
        return result;
    }


  

    }
}
