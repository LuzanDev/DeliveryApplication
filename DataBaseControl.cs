using System;
using System.Collections;
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

        public static int GetCityIDByName(string cityName)
        {
            int result = 0;
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT city_Id FROM City WHERE city_Name = @cityName", connection))
                {
                    command.Parameters.Add("@cityName", SqlDbType.NVarChar, 50).Value = cityName;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader.GetInt32(0);
                        }
                    }
                }
            }
            return result;
        }

        public static DataTable GetData(string qry)
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить данные " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GetConnection().Close();
            }
            return table;
        }
        public async  static Task LoadCompaniesAsync(List<Company> companies)
        {
            DataTable dt = new DataTable();
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("SELECT * FROM Companies", connection))
                {
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        await Task.Run(() =>
                        {
                            adapter.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                Company company = new Company 
                                {
                                ID = Convert.ToInt32(row["com_Id"]),
                                Name = row["com_Name"].ToString(),
                                Code = Convert.ToInt32(row["com_Number"])
                                };
                                companies.Add(company);
                            }
                        });
                    }
                }
            }
        }

        public static Company FindCompanyByNameAndCode(string nameCompany, string codeCompany)
        {
            Company company = null;

            string qry = "SELECT * FROM Companies WHERE com_Name = @Name AND com_Number = @Number";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(qry, connection))
                {
                    command.Parameters.AddWithValue("@Name", nameCompany);
                    command.Parameters.AddWithValue("@Number", codeCompany);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            company = new Company
                            {
                                ID = (int)reader["com_Id"],
                                Name = (string)reader["com_Name"],
                                Code = (int)reader["com_Number"],
                            };
                        }
                    }
                }
            }
            return company;
        }

        public static List<PackagingMaterial> GetPackagings()
        {
            List<PackagingMaterial> packagings = new List<PackagingMaterial>();

            string qry = "SELECT * FROM Packaging";
            DataTable dt = GetData(qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["PackagingHeight"] != DBNull.Value)
                {
                    Container container = new Container
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["PackagingID"]),
                        Name = dt.Rows[i]["PackagingName"].ToString(),
                        Price = Convert.ToDecimal(dt.Rows[i]["PackagingPrice"]),
                        Volume = Convert.ToSingle(dt.Rows[i]["PackagingVolume"]),
                        Width = Convert.ToSingle(dt.Rows[i]["PackagingWidth"]),
                        Length = Convert.ToSingle(dt.Rows[i]["PackagingLength"]),
                        Height = Convert.ToSingle(dt.Rows[i]["PackagingHeight"]),
                    };
                    packagings.Add(container);
                }
                else
                {
                    PackagingMaterial material = new PackagingMaterial
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["PackagingID"]),
                        Name = dt.Rows[i]["PackagingName"].ToString(),
                        Price = Convert.ToDecimal(dt.Rows[i]["PackagingPrice"])
                    };
                    packagings.Add(material);
                }
            }


            return packagings;
        }
        /// <summary>
        /// Проверить существование
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public static int CheckExistence(string qry, Hashtable ht)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(qry, connection);
                    foreach (DictionaryEntry item in ht)
                    {
                        command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    }
                    result = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        public static int Add(string qry, Hashtable ht)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, GetConnection());
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                if (GetConnection().State == ConnectionState.Closed) { GetConnection().Open(); }
                result = cmd.ExecuteNonQuery();
                if (GetConnection().State == ConnectionState.Open) { GetConnection().Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GetConnection().Close();
            }
            return result;
        }

        public static int GetPriceDelivery(string nameColumn, int localID)
        {
            int price = 0;
            string qry = $"SELECT {nameColumn} FROM CostOfDelivery WHERE LocalityID = {localID}";
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(qry, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value && result is IConvertible)
                    {
                         price = Convert.ToInt32(result);
                    }
                }
            }
            return price;
        }

        /// <summary>
        /// Добавить данные и вернуть ID строки результата
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="ht"></param>
        /// <returns>ID последней добавленной строки</returns>
        public static int AddWithReturnID(string qry, Hashtable ht)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, GetConnection());
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                if (GetConnection().State == ConnectionState.Closed) { GetConnection().Open(); }
                result = Convert.ToInt32(cmd.ExecuteScalar());
                if (GetConnection().State == ConnectionState.Open) { GetConnection().Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GetConnection().Close();
            }
            return result;
        }
    }
}
