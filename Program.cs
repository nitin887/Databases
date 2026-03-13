/*






🔥 DATABASE MINI PROJECT

Student Management System

Add student

View students

Search by ID

Update marks

Delete student

Use SQL + C# + Exception handling
*/
using MySql.Data.MySqlClient;
using System;

class Databases
{
    /*
    🟢 BASIC
1️⃣4️⃣ Insert Data

Problem:
Insert student data into a database using C#.

5️⃣1️⃣ Read Data

Problem:
Fetch all students from a table and display in console.

🟡 INTERMEDIATE
1️⃣6️⃣ Parameterized Query

Problem:
Search student by ID using SQL parameters (prevent SQL injection).
1️⃣7️⃣ Update & Delete

Problem:
Update student marks and delete student by ID.

 ADVANCED
1️⃣8️⃣ Stored Procedure Call

Problem:
Call a stored procedure from C# and read results.



    */
    static void Main(string[] args)
    {
        string connectionString = "server=localhost;user=root;password=abc@123;database=practice";
        using (MySqlConnection mySqlConnection = new(connectionString))
        {
            try
            {
                mySqlConnection.Open();
                string createTable = @"Create Table IF NOT EXISTS users
            (id int Auto_Increment Primary Key,
            name varchar(100) NOT NULL,
            Age int NOT NULL

            );";
                MySqlCommand mySqlCommand = new MySqlCommand(createTable, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("Enble table users exist");


                //Insert
                string insertQuery = "insert into users(name,age) values ('john',25),('rohan',32)";
                mySqlCommand = new MySqlCommand(insertQuery, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("data insrted properly");

                //read
                string readQuery = "select * from users";
                mySqlCommand = new MySqlCommand(readQuery, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine(mySqlDataReader["name"] + "-" + mySqlDataReader["age"]);
                }
                mySqlDataReader.Close();

                //Sql injection
                Console.WriteLine("enter the id to search");
                int id = Convert.ToInt32(Console.ReadLine());
                string Query = "select * from users where id =@id";
                mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@id", id);
                MySqlDataReader mySqlDataReader1 = mySqlCommand.ExecuteReader();
                Console.WriteLine("users list");
                while (mySqlDataReader1.Read())
                {
                    Console.WriteLine(mySqlDataReader1["name"] + "-" + mySqlDataReader1["age"]);

                }
                mySqlDataReader1.Close();

                //update
                string updateQuery = "Update users set age =32 where name='john'";
                mySqlCommand = new MySqlCommand(updateQuery, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("data updated successfully");

                //delete
                string deleteQuery = "delete from users where name='john'";
                mySqlCommand = new MySqlCommand(deleteQuery, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("data deleted successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
