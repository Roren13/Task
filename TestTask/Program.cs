using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SQLite;
using System.Linq;

namespace ConsApp1
{

    // класс и его члены объявлены как public
    [Serializable]
    public class dbConfiguration
    {
        public string ConnectionString { get; set; }
        public string TargetFolder { get; set; }
        public TableSettings TableSettings { get; set; }


        // стандартный конструктор без параметров
        public dbConfiguration()
        {

        }

        public dbConfiguration(string connectionString, string targetFolder, TableSettings ts)
        {
            ConnectionString = connectionString;
            TargetFolder = targetFolder;
            TableSettings = ts;

        }

    }
    [Serializable]
    public class TableSettings
    {
        public string TableName { get; set; }
        public Columns Columns { get; set; }
        [XmlAttribute("deleteAfter")]
        public bool deleteAfter { get; set; }

        // стандартный конструктор без параметров
        public TableSettings()
        {

        }

        public TableSettings(string tableName, Columns col)
        {
            TableName = tableName;
            Columns = col;

        }
    }
    [Serializable]
    public class Columns
    {
        [XmlElement]
        public string[] Column { get; set; }

        public Columns()
        {

        }
        public Columns(string[] column)
        {

        }
    }

    [Serializable]
    public class String
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }

        public String()
        {

        }
        public String(string column1, string column2, string column3)
        {
            Column1 = column1;
            Column2 = column2;
            Column3 = column3;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string[] a = new string[10];
            string[] b = new string[10];
            string[] c = new string[10];

            XmlSerializer formatter = new XmlSerializer(typeof(dbConfiguration));
            using (FileStream fss = new FileStream("settings.xml", FileMode.OpenOrCreate))
            {
                dbConfiguration newDbconfiguration = (dbConfiguration)formatter.Deserialize(fss);

                int n = newDbconfiguration.TableSettings.Columns.Column.Count();
                string[] g = new string[n];
                int n1 = 0;

                while (n1 < n)
                {
                    g[n1] = newDbconfiguration.TableSettings.Columns.Column[n1];
                    n1 = n1 + 1;
                }

                SQLiteConnection.CreateFile("MyDatabase.sqlite");

                SQLiteConnection m_dbConnection = new SQLiteConnection(newDbconfiguration.ConnectionString);
                m_dbConnection.Open();

                string sql = "CREATE TABLE test (id INTEGER PRIMARY KEY, name varchar(20), surname varchar(30), age varchar(20))";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                sql = "INSERT INTO test (id, name, surname, age) values ('1', 'Иван', 'Петров' ,'19')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('2', 'Богдан', 'Петров' ,'19')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('3', 'Евгений', 'Сидоров' ,'19')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('4', 'Николай', 'Петров' ,'19')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('5', 'Кирилл', 'Николаев' ,'19')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('6', 'Петр', 'Петров' ,'19')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('7', 'Алексей', 'Сидоров' ,'11')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('8', 'Тимофей', 'Петров' ,'20')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('9', 'Валерий', 'Иванов' ,'33')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('10', 'Александр', 'Петров' ,'18')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('11', 'Геннадий', 'Петров' ,'13')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('12', 'Данил', 'Сидоров' ,'12')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('13', 'Андрей', 'Петров' ,'14')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('14', 'Сергей', 'Иванов' ,'11')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('15', 'Олег', 'Сидоров' ,'29')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('16', 'Борис', 'Петров' ,'16')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('17', 'Никита', 'Иванов' ,'20')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('18', 'Дмитрий', 'Николаев' ,'25')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('19', 'Вениамин', 'Сидоров' ,'24')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "INSERT INTO test (id, name, surname, age) values ('20', 'Артём', 'Иванов' ,'21')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                string ssql = "SELECT " + (g[0]) + "," + (g[1]) + "," + (g[2]) + " FROM " + (newDbconfiguration.TableSettings.TableName);
                SQLiteCommand ccommand = new SQLiteCommand(ssql, m_dbConnection);
                SQLiteDataReader reader = ccommand.ExecuteReader();



                string c1 = "";
                string c2 = "";
                string c3 = "";
                while (reader.Read())
                {
                    c1 = reader.GetValue(0).ToString();
                    a[i] = c1;
                    c2 = reader.GetValue(1).ToString();
                    b[i] = c2;
                    c3 = reader.GetValue(2).ToString();
                    c[i] = c3;

                    if (i == 9)
                    {

                        String s1 = new String(a[0], b[0], c[0]);
                        String s2 = new String(a[1], b[1], c[1]);
                        String s3 = new String(a[2], b[2], c[2]);
                        String s4 = new String(a[3], b[3], c[3]);
                        String s5 = new String(a[4], b[4], c[4]);
                        String s6 = new String(a[5], b[5], c[5]);
                        String s7 = new String(a[6], b[6], c[6]);
                        String s8 = new String(a[7], b[7], c[7]);
                        String s9 = new String(a[8], b[8], c[8]);
                        String s10 = new String(a[9], b[9], c[9]);
                        String[] Strings = new String[] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };

                        string NameFile = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9];

                        XmlSerializer format = new XmlSerializer(typeof(String[]));
                        using (FileStream fs = new FileStream(newDbconfiguration.TargetFolder + NameFile + ".xml", FileMode.OpenOrCreate))
                        {
                            format.Serialize(fs, Strings);
                        }
                        

                        i = 0;
                    }
                    i = i + 1;
                }
                if (newDbconfiguration.TableSettings.deleteAfter == true)
                {
                    sql = "DELETE FROM " + (newDbconfiguration.TableSettings.TableName) + " WHERE id";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();

                }



                m_dbConnection.Close();
            }



            Console.ReadLine();

        }
    }
}

