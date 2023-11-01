using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hippodrome.Tables;

namespace Hippodrome.Services
{
    class HorseServise
    {
        Horse horse;
        public void HorseIns(  string id, string name , string father, string mother ,string breed , string gender ,int age ,
                                                        DateTime dateIn , DateTime dateOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ins_horse";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@klient", SqlDbType.Int).Value = Client.Id  ;
            cmd.Parameters.Add("@chip", SqlDbType.NChar, 10).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NChar, 10).Value = name;
            cmd.Parameters.Add("@chipF", SqlDbType.NChar, 10).Value = father;
            cmd.Parameters.Add("@chipM", SqlDbType.NChar, 10).Value = mother;
            cmd.Parameters.Add("@breed", SqlDbType.SmallInt, 10).Value = breed;
            cmd.Parameters.Add("@gender", SqlDbType.NChar, 10).Value = gender;
            cmd.Parameters.Add("@age", SqlDbType.SmallInt, 10).Value = age;
            cmd.Parameters.Add("@target", SqlDbType.SmallInt, 10).Value = 0;
            cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = dateIn;
            cmd.Parameters.Add("@endDate", SqlDbType.Date).Value =dateOut;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void HorseDlt(string id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dlt_horse";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@horse", SqlDbType.NChar, 10).Value = id;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void HorseAvR(string id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "available_racing";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@horse", SqlDbType.NChar, 10).Value = id;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void HorseUpdData(string id, DateTime dateIn, DateTime dateOut)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "upd_date_horse";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@klient", SqlDbType.Int).Value = Client.Id;
            cmd.Parameters.Add("@horse", SqlDbType.NChar, 10).Value = id;
            cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = dateIn;
            cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = dateOut;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void HorseInsRacing(string horse, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ins_racing";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@racing", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@horse", SqlDbType.NChar, 10).Value = horse;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void HorseDltRacing(string horse, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dlt_rating";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@racing", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@horse", SqlDbType.NChar, 10).Value = horse;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void HorseUpdRacing(int racing)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "upd_racing";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@racing", SqlDbType.Int).Value = racing;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}
