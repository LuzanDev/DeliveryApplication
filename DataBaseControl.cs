using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryApplication
{
    internal class DataBaseControl
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliveryDB"].ConnectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключиться к базе данных " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

        public static DataTable GetClient(string qry)
        {
            DataTable tableClient = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tableClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить данные " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                GetConnection().Close();
            }
            return tableClient;
        }


    }
}
