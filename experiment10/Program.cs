using System.Data;
using System.Data.SqlClient;

const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=College;Integrated Security=True;TrustServerCertificate=True";

try
{
    using var adapter = new SqlDataAdapter("SELECT Id, Name FROM Student ORDER BY Id", connectionString);
    var collegeData = new DataSet();
    adapter.Fill(collegeData, "Students");

    DataTable students = collegeData.Tables["Students"]!;
    Console.WriteLine("ID\tName");
    foreach (DataRow student in students.Rows)
        Console.WriteLine($"{student.Field<int>("Id")}\t{student.Field<string>("Name")}");
}
catch (SqlException error)
{
    Console.WriteLine("Could not read the College database.");
    Console.WriteLine(error.Message);
}
