using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static MySqlConnection conn;
    static void Main(string[] args)
    {
        conn = new MySqlConnection("server=localhost;User Id = root;passwrod=;Database=studmysql;Charset=utf8");
        conn.Open();
        //增
        //Add();

        //删
        Delete();

        //改
        //Updata();

        //查
        //Query();

        Console.ReadKey();
        conn.Close();
    }

    static void Add()
    {
        MySqlCommand cmd = new MySqlCommand("insert into userinfo set name='aa',age=696", conn);
        cmd.ExecuteNonQuery();
        int id = (int)cmd.LastInsertedId;
        Console.WriteLine("sql insert key{0}",id);
    }

    static void Delete()
    {
        MySqlCommand cmd = new MySqlCommand("delete from userinfo where id = 1", conn);
        cmd.ExecuteNonQuery();
        Console.WriteLine("de");
    }

    static void Updata()
    {
        MySqlCommand cmd = new MySqlCommand("update userinfo set name = @name,age=@age where id=@id", conn);
        cmd.Parameters.AddWithValue("name", "233");
        cmd.Parameters.AddWithValue("age", "332");
        cmd.Parameters.AddWithValue("id", "2");


        cmd.ExecuteNonQuery();
        Console.WriteLine("update done");
    }

    static void Query()
    {
        //MySqlCommand cmd = new MySqlCommand("select * from userinfo", conn);
        MySqlCommand cmd = new MySqlCommand("select * from userinfo where age = 696", conn);

        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string name = reader.GetString("name");
            int age = reader.GetInt32("age");

            Console.WriteLine("sql result: id:" + id );
            Console.WriteLine("sql result: name:" + name);
            Console.WriteLine("sql result: age:" + age);
        }
    }
}
