using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dever
{
    public class Database
    {


        private static MySqlConnection Connect()
        {
            var con = new MySqlConnection();


            var user = "root";
            var password = "";
            //try
            //{


                con.ConnectionString = "server = localhost; User Id = " + user + "; " +
                    "Persist Security Info = True; database = Dever; Password = " + password;
                con.Open();
            return con;
                //Console.WriteLine("Succesfully connected!");

            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine("Not Successful! due to " + e.ToString());
            //}
        }

        public static void CreateTable()
        {
            var con = Connect();
            var text = @"CREATE TABLE IF NOT EXISTS Students(
                id int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
                name varchar(30),
                fatherName varchar(30),
                motherName varchar(30),
                birthdate varchar(20),
                brothersCount int(11),
                sex char(1)
            );";
            var cmd = new MySqlCommand(text, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Insert(Student student)
        {
            var con = Connect();

            var text = @"insert into Students
                (name, fatherName, motherName, birthdate, brothersCount, sex)
                    values
                (@name, @fatherName, @motherName, @birthdate, @brothersCount, @sex)
            ;";
            var cmd = new MySqlCommand(text, con);
            cmd.Parameters.AddWithValue("name", student.name);
            cmd.Parameters.AddWithValue("fatherName", student.fatherName);
            cmd.Parameters.AddWithValue("motherName", student.motherName);
            cmd.Parameters.AddWithValue("birthdate", student.birthdate);
            cmd.Parameters.AddWithValue("brothersCount", student.brothersCount);
            cmd.Parameters.AddWithValue("sex", student.sex);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void Update(Student student)
        {
            var con = Connect();

            var text = @"UPDATE Students SET
                name = @name,
                fatherName = @fatherName,
                motherName = @motherName,
                birthdate = @birthdate,
                brothersCount = @brothersCount,
                sex = @sex
            WHERE id = @id;
            ;";
            var cmd = new MySqlCommand(text, con);
            cmd.Parameters.AddWithValue("name", student.name);
            cmd.Parameters.AddWithValue("fatherName", student.fatherName);
            cmd.Parameters.AddWithValue("motherName", student.motherName);
            cmd.Parameters.AddWithValue("birthdate", student.birthdate);
            cmd.Parameters.AddWithValue("brothersCount", student.brothersCount);
            cmd.Parameters.AddWithValue("sex", student.sex);
            cmd.Parameters.AddWithValue("id", student.id);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void DeleteById(string id)
        {
            var con = Connect();

            var text = @"delete from Students where id =  @id";
            var cmd = new MySqlCommand(text, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static Student SelectById(string id)
        {
            var con = Connect();

            var comando = new MySqlCommand("SELECT * FROM Students WHERE id = @id;", con);
            

            comando.Parameters.AddWithValue("id", id);

            

            var reader = comando.ExecuteReader();

            Student student = null;
            while (reader.Read())
            {
                student = new Student{
                   id = reader.GetInt32(0),
                   name = reader.GetString(1),
                   fatherName = reader.GetString(2),
                   motherName = reader.GetString(3),
                   birthdate = reader.GetString(4),
                   brothersCount = reader.GetInt32(5),
                   sex = reader.GetString(6),
                };

                
            }

            con.Close();

            return student;
        }
    }
}
