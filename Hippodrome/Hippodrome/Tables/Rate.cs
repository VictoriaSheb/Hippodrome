﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hippodrome.Tables
{
    class Rate
    {
        public int typeR { get; set; }

        public DataTable RateLook(int type, int racing)
        {
            string guery = "";
            switch (type)
            {
                //победитель
                case 1:
                    guery = (@"SELECT     Коэффициент.Номер, Лошадь.Имя, Коэффициент.Победитель
                FROM Коэффициент INNER JOIN
                     [Участники скачек] ON Коэффициент.Номер = [Участники скачек].Номер INNER JOIN
                      Лошадь ON[Участники скачек].Лошадь = Лошадь.[Чип-номер]
                       WHERE [Участники скачек].Скачки=@racing");
                    break;
                //Не первая
                case 2:
                    guery = (@" SELECT  Коэффициент.Номер, Лошадь.Имя, Коэффициент.[Не призер]
                      FROM Коэффициент INNER JOIN
                      [Участники скачек] ON Коэффициент.Номер = [Участники скачек].Номер INNER JOIN
                      Лошадь ON [Участники скачек].Лошадь = Лошадь.[Чип-номер]
                      WHERE [Участники скачек].Скачки=@racing");
                    break;
                //Призовое место
                case 3:
                    guery = (@"SELECT Коэффициент.Номер, Лошадь.Имя, Коэффициент.Призер
                      FROM  Коэффициент INNER JOIN
                      [Участники скачек] ON Коэффициент.Номер = [Участники скачек].Номер INNER JOIN
                      Лошадь ON [Участники скачек].Лошадь = Лошадь.[Чип-номер]
                      WHERE [Участники скачек].Скачки=@racing");
                    break;
                //Победитель и призер
                case 4:
                    guery = (@" SELECT Коэффициент.Номер, Лошадь.Имя , Коэффициент.[Победитель+], Коэффициент.[Призер+] 
                      FROM  Коэффициент INNER JOIN
                      [Участники скачек] ON Коэффициент.Номер = [Участники скачек].Номер INNER JOIN
                      Лошадь ON [Участники скачек].Лошадь = Лошадь.[Чип-номер]
                      WHERE [Участники скачек].Скачки=@racing");
                    break;
                //3 победителя
                default:
                    guery = (@"SELECT Коэффициент.Номер, Лошадь.Имя , Коэффициент.Победители
                      FROM Коэффициент INNER JOIN
                      [Участники скачек] ON Коэффициент.Номер = [Участники скачек].Номер INNER JOIN
                      Лошадь ON [Участники скачек].Лошадь = Лошадь.[Чип-номер]
                      WHERE [Участники скачек].Скачки=@racing");
                    break;

            }
    
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd_SQL = new SqlCommand(guery, connection);
            cmd_SQL.Parameters.Add("@racing", SqlDbType.Int).Value = racing;
      
            cmd_SQL.ExecuteNonQuery();
            DataTable rate = new DataTable();
            SqlDataAdapter bd = new SqlDataAdapter(cmd_SQL);
            bd.Fill(rate);
            connection.Close();

        
            return rate;
            

        }
        public void InsRate( int racing, decimal money, string horse, int type)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ins_rate";
            connection.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
            { MessageBox.Show(Convert.ToString(e.Message)); };
            cmd.Parameters.Add("@klient", SqlDbType.Int).Value = Client.Id;
            cmd.Parameters.Add("@racing", SqlDbType.Int).Value = racing;
            cmd.Parameters.Add("@money", SqlDbType.Money).Value = money;
            cmd.Parameters.Add("@horse", SqlDbType.NChar, 10).Value = horse;
            cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
            cmd.ExecuteNonQuery();
            connection.Close();


        }



































































    }
}
