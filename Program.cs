/*
DATABASE MINI PROJECT

Student Management System

Add student

View students

Search by ID

Update marks

Delete student

Use SQL + C# + Exception handling
*/
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.ComponentModel;

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
    private static string connectionString = "server=localhost;user=root;password=abc@123;database=student_management_system";
    static void Main(string[] args)
    {
        Console.WriteLine("the operation you want to perform:\n 0.Add student \n 1.view students \n 2.search by id \n 3.update marks \n 4.Delete marks");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 0:
                AddStudent();
                break;

            case 1:
                ViewStudent();
                break;

            case 2:
                SearchStudent();
                break;

            case 3:
                UpdateMarks();
                break;

            case 4:
                DeleteMarks();
                break;

            default:
                Console.WriteLine("invalid criteria");
                break;

        }
    }
    public static void AddStudent()
    {
        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

        try
        {
            mySqlConnection.Open();
            Console.WriteLine("database has been connected");
            string createTable = @"Create Table IF NOT EXISTS students
                         (id int Auto_Increment Primary Key,
                          name varchar(100) NOT NULL,
                         marks int NOT NULL);";
            MySqlCommand mySqlCommand = new MySqlCommand(createTable, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("table created");
            //ADD RECORD

            Console.WriteLine("enter the details of student:");
            string name = Console.ReadLine() ?? "null";
            int marks = Convert.ToInt32(Console.ReadLine());
            string AddRecord = "insert into students(name,marks) values(@name,@marks)";
            mySqlCommand = new MySqlCommand(AddRecord, mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@name", name);
            mySqlCommand.Parameters.AddWithValue("@marks", marks);
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("record added");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            mySqlConnection.Close();
        }

    }
    public static void ViewStudent()
    {
        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        try
        {
            mySqlConnection.Open();
            Console.WriteLine("database has been connected");

            string viewQuery = "select * from students";
            MySqlCommand mySqlCommand = new MySqlCommand(viewQuery, mySqlConnection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                Console.WriteLine(mySqlDataReader["name"] + "-" + mySqlDataReader["marks"]);

            }



        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            mySqlConnection.Close();
        }




    }
    public static void SearchStudent()
    {
        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        try
        {
            mySqlConnection.Open();
            Console.WriteLine("database has been connected");

            Console.WriteLine("enter the id to search:");
            int id = Convert.ToInt32(Console.ReadLine());
            string searchQuery = @"select * from students where id =@id";
            MySqlCommand mySqlCommand = new MySqlCommand(searchQuery, mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@id", id);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                Console.WriteLine(mySqlDataReader["name"] + "-" + mySqlDataReader["marks"]);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            mySqlConnection.Close();


        }

    }
    public static void UpdateMarks()
    {
        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        try
        {
            mySqlConnection.Open();
            Console.WriteLine("database has been connected");

            Console.WriteLine("enter the marks to update with the studentname");
            int marks = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine() ?? "null";
            string updateQuery = "update students set marks=@marks where name=@name";
            MySqlCommand mySqlCommand = new MySqlCommand(updateQuery, mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@marks", marks);
            mySqlCommand.Parameters.AddWithValue("@name", name);
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("marks updated");



        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        finally
        {
            mySqlConnection.Close();
        }

    }
    public static void DeleteMarks()
    {
        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        try
        {
            mySqlConnection.Open();
            Console.WriteLine("database connected");


            Console.WriteLine("enter the studet name to delete record");
            string name = Console.ReadLine() ?? "null";
            string deleteQuery = "delete from student where name=@name";
            MySqlCommand mySqlCommand = new MySqlCommand(deleteQuery, mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@name", name);
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("data deleted");


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            mySqlConnection.Close();
        }

    }

}









// string connectionString = "server=localhost;user=root;password=abc@123;database=practice";
// using (MySqlConnection mySqlConnection = new(connectionString))
// {
//     try
//     {
//         mySqlConnection.Open();
//         string createTable = @"Create Table IF NOT EXISTS users
//     (id int Auto_Increment Primary Key,
//     name varchar(100) NOT NULL,
//     Age int NOT NULL

//     );";
//         MySqlCommand mySqlCommand = new MySqlCommand(createTable, mySqlConnection);
//         mySqlCommand.ExecuteNonQuery();
//         Console.WriteLine("Enble table users exist");


//         //Insert
//         string insertQuery = "insert into users(name,age) values ('john',25),('rohan',32)";
//         mySqlCommand = new MySqlCommand(insertQuery, mySqlConnection);
//         mySqlCommand.ExecuteNonQuery();
//         Console.WriteLine("data insrted properly");

//         //read
//         string readQuery = "select * from users";
//         mySqlCommand = new MySqlCommand(readQuery, mySqlConnection);
//         MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
//         while (mySqlDataReader.Read())
//         {
//             Console.WriteLine(mySqlDataReader["name"] + "-" + mySqlDataReader["age"]);
//         }
//         mySqlDataReader.Close();

//         //Sql injection
//         Console.WriteLine("enter the id to search");
//         int id = Convert.ToInt32(Console.ReadLine());
//         string Query = "select * from users where id =@id";
//         mySqlCommand = new MySqlCommand(Query, mySqlConnection);
//         mySqlCommand.Parameters.AddWithValue("@id", id);
//         MySqlDataReader mySqlDataReader1 = mySqlCommand.ExecuteReader();
//         Console.WriteLine("users list");
//         while (mySqlDataReader1.Read())
//         {
//             Console.WriteLine(mySqlDataReader1["name"] + "-" + mySqlDataReader1["age"]);

//         }
//         mySqlDataReader1.Close();

//         //update
//         string updateQuery = "Update users set age =32 where name='john'";
//         mySqlCommand = new MySqlCommand(updateQuery, mySqlConnection);
//         mySqlCommand.ExecuteNonQuery();
//         Console.WriteLine("data updated successfully");

//         //delete
//         string deleteQuery = "delete from users where name='john'";
//         mySqlCommand = new MySqlCommand(deleteQuery, mySqlConnection);
//         mySqlCommand.ExecuteNonQuery();
//         Console.WriteLine("data deleted successfully");

//     }
//     catch (Exception e)
//     {
//         Console.WriteLine(e.Message);
//     }

