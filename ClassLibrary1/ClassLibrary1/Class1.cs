using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrary1
{
    public class Class1 : MarshalByRefObject
    {
        static String connectionString = "server=DESKTOP-A57A7BM; Database=CSP_geterogen_sys; Integrated Security=SSPI;";
        SqlConnection con = new SqlConnection(connectionString);

        public int addNumbers(int x, int y)
        {
        return x + y;
        }

        public int subNumbers(int x, int y)
        {
        return x - y;
        }

        public void SaveOperation(int x, int y, int result, string operation)
        {
            try
            {
                Console.WriteLine("Мы внутри");
                con.Open();
                string query = "INSERT INTO CSP_geterogen_sys (X, Y, Result, Operation) VALUES (@X, @Y, @Result, @Operation)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@X", x);
                cmd.Parameters.Add("@Y", y);
                cmd.Parameters.Add("@Result", result);
                cmd.Parameters.Add("@Operation", operation);
                cmd.ExecuteNonQuery();
                
                con.Close();
                
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

    }

}
