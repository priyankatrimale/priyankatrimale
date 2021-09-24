using System;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using HRModel;


namespace HRFunctions
{
    public class Connection1
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;
        public string Constr;
        public static void createconnection()

        {


            try
            {

                con = new SqlConnection();
                string constr = "server=.;database=HRMS;trusted_connection=true";
                con.ConnectionString = constr;
                con.Open();
                //Console.WriteLine("Connection Opened");
                //Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }



        //  Department.PrintDepartmentData();


        public static SqlDataReader GetDepartment()
        {
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("GetDeptDta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2]);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return reader;


        }


        public static SqlDataReader GetDepartmentUsingDno(int Dept_ID)
        {
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Get_Dept_Using_Dept_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("dno", Dept_ID);
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2]);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return reader;
        }





        public static void InsertDepartment(int Dept_ID, string Dept_Name, string Location)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Insert_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("dno", Dept_ID);
                cmd.Parameters.AddWithValue("dnm", Dept_Name);
                

               
                cmd.Parameters.AddWithValue("location", Location);
                no = cmd.ExecuteNonQuery();

                if (no > 0)
                {
                    Console.WriteLine("Data Inserted Successfully");
                }
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            // return no;
        }




        public static void UpdateDepartment(int Dept_ID, string Dept_Name, string Location)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Update_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("dno", Dept_ID);
                cmd.Parameters.AddWithValue("dnm", Dept_Name);
                cmd.Parameters.AddWithValue("location", Location);


                no = cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            // return no;
        }

        public static void DeleteDepartment(int Dept_ID)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("dno",Dept_ID );
                no = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
                //return no;

            }
        }



        public static SqlDataReader GetEmployee()
        {
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("GetEmpDta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t" + reader[4] + "\t" + reader[5] + "\t" + reader[6]);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return reader;
        }


        public static SqlDataReader GetEmployeeUsingEno(int Emp_ID)
        {
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Get_Emp_Using_Emp_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("eno", Emp_ID);
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t" + reader[4] + "\t" + reader[5] + "\t" + reader[6]);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return reader;
        }


        public static void InsertEmployee(int Emp_ID,int Dept_ID,string Name,string Designation,decimal Salary, string Mobile_no,string Email_ID)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Insert_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("eno", Emp_ID);
                cmd.Parameters.AddWithValue("dno", Dept_ID);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("designation",Designation);
                cmd.Parameters.AddWithValue("salary", Salary);
                cmd.Parameters.AddWithValue("mobileno", Mobile_no);
                cmd.Parameters.AddWithValue("emailid", Email_ID);


                no = cmd.ExecuteNonQuery();

                if (no > 0)
                {
                    Console.WriteLine("Data Inserted Successfully");
                }
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            // return no;
        }


        public static void UpdateEmployee(int Emp_ID, int Dept_ID, string Name, string Designation, decimal Salary, string Mobile_no, string Email_ID)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Update_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("eno", Emp_ID);
                cmd.Parameters.AddWithValue("dno", Dept_ID);
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("designation", Designation);
                cmd.Parameters.AddWithValue("salary", Salary);
                cmd.Parameters.AddWithValue("mobileno", Mobile_no);
                cmd.Parameters.AddWithValue("emailid", Email_ID);


                no = cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            // return no;
        }


        public static void DeleteEmployee(int Emp_ID)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Database=HRMS;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("eno", Emp_ID);
                no = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
                //return no;

            }
        }

    }
}

















        
        
