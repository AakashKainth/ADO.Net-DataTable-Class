using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace ADO_Net_DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataTable employees = new DataTable("employees");

                DataColumn id = new DataColumn("id");
                id.Caption = "Emp_Id";
                //id.DataType = typeof(int);
                id.DataType = System.Type.GetType("System.Int32");
                id.AllowDBNull = false;
                id.AutoIncrement = true;
                id.AutoIncrementSeed = 1;
                id.AutoIncrementStep = 1;
                employees.Columns.Add(id);

                //DataColumn id = new DataColumn("id")
                //{

                //    Caption = "Emp_Id",
                //    DataType = typeof(int),
                //    AllowDBNull = false,

                //};
                //employees.Columns.Add(id);

                DataColumn name = new DataColumn("name");
                name.Caption = "Emp_Name";
                name.DataType = typeof(string);
                name.AllowDBNull = false;
                name.MaxLength = 50;
                name.DefaultValue = "Anonymous";
                name.Unique = true;
                employees.Columns.Add(name);

                DataColumn gender = new DataColumn("gender");
                gender.Caption = "Emp_Gender";
                gender.DataType = typeof(string);
                gender.AllowDBNull = false;
                gender.MaxLength = 20;
                employees.Columns.Add(gender);

                DataRow row1 = employees.NewRow();
                //row1["id"] = 1;
                //row1["name"] = "Bob";
                row1["gender"] = "Male";
                employees.Rows.Add(row1);

                employees.Rows.Add(null, "Jennifer", "Female");
                employees.Rows.Add(null, "Ann", "Male");

                employees.PrimaryKey = new DataColumn[] { id };

                foreach (DataRow row in employees.Rows)
                {

                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}