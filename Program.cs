using System;
using System.Data.SqlClient;
using System.Data;
using HRFunctions;
using HRModel;

namespace Proj_HRMS
{
    class Program
    {
        static void Main(string[] args)
        {





            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "Data Source=.;Initial Catalog=HRMS; Integrated Security =true";
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "LoginProc";

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Connection = con;
            //Console.WriteLine("\nEnter The UserName  :");
            //string user = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("\nEnter The Password :");
            //ConsoleKeyInfo key; string pass = "";

            //do
            //{
            //    key = Console.ReadKey(true);
            //    if (key.Key != ConsoleKey.Backspace)
            //    {
            //        pass += key.KeyChar;
            //        Console.Write("*");
            //    }
            //} while (key.Key != ConsoleKey.Enter);

            //cmd.Parameters.AddWithValue("UserName", user);
            //cmd.Parameters.AddWithValue("Password", pass.TrimEnd());

            //SqlDataReader reader = cmd.ExecuteReader();





            //while(reader.Read())
            //{
            //    Console.WriteLine("{0},{1}",reader[0],reader[1]);
            //    if(reader[0]==user && reader[1]==pass)
            //    {
            //        Console.WriteLine("Valid User name and Password");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Username And Password");
            //    }
            //}







            Connection1.createconnection();

            int choice;
            char ch;
            do
            {

            Console.WriteLine("Department Menu");
            Console.WriteLine("1.Print All Departments");
            Console.WriteLine("2.Print Department based on deptno");
            Console.WriteLine("3.Insert Department");
            Console.WriteLine("4.Update Department");
            Console.WriteLine("5.Delete Department");

                Console.WriteLine("Employee Menu");
                Console.WriteLine("6.Print All Employees");
                Console.WriteLine("7.Print Employees based on Emp_ID");
                Console.WriteLine("8.Insert Employee");
                Console.WriteLine("9.Update Employee");
                Console.WriteLine("10.Delete Employee");
                Console.WriteLine("Enter your Choice");
            choice = Convert.ToInt32(Console.ReadLine());


            
            switch (choice)
            {
                case 1:
                    Connection1.GetDepartment();
                    break;

                case 2:
                        
                    Console.WriteLine("Enter department no to view details");
                     int Dept_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.GetDepartmentUsingDno(Dept_ID);

                    break;



                    case 3:
                        
                        Console.WriteLine("Enter Department Details to Enter Deptno,dname,location");
                        Department d = new Department();
                        d.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        d.Dept_Name = Console.ReadLine();

                        while (string.IsNullOrEmpty(d.Dept_Name))
                        {
                            Console.WriteLine("Department name Can ot be blank");
                            Console.WriteLine("Enter Department Name");
                            d.Dept_Name = Console.ReadLine();
                        }
                        d.Location = Console.ReadLine();
                        while (string.IsNullOrEmpty(d.Location))
                        {
                            Console.WriteLine("Department name Can ot be blank");
                            Console.WriteLine("Enter Department Location");
                            d.Location = Console.ReadLine();
                        }

                        Connection1.InsertDepartment(d.Dept_ID,d.Dept_Name,d.Location);
                        break;

                    case 4:
                       
                        Console.WriteLine("Enter Department Details to Update Deptno,dname,location");
                        Department d1 = new Department();
                        d1.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        d1.Dept_Name = Console.ReadLine();
                        d1.Location = Console.ReadLine();
                        

                        Connection1.UpdateDepartment(d1.Dept_ID, d1.Dept_Name, d1.Location);
                        break;

                    case 5:
                        Department d2 = new Department();
                        Console.WriteLine("Enter Department no to delete");
                        d2.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.DeleteDepartment(d2.Dept_ID);
                        Console.WriteLine("Record Deleted");
                        break;



                    case 6:
                        Connection1.GetEmployee();
                        break;

                    case 7:

                        Console.WriteLine("Enter Employee no to view details");
                        int Emp_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.GetEmployeeUsingEno(Emp_ID);

                        break;

                    case 8:

                        Console.WriteLine("Enter Employee Details to Enter Emp_ID,Dept_ID,Name,Designation,Salary,Mobile_No,Email_ID");
                        Employee e= new Employee();
                        e.Emp_ID= Convert.ToInt32(Console.ReadLine());
                        e.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        e.Name = Console.ReadLine();
                        while (string.IsNullOrEmpty(e.Name))
                        {
                            Console.WriteLine("Employee name Can ot be blank");
                            Console.WriteLine("Enter Employee Name");
                            e.Name = Console.ReadLine();
                        }
                        e.Designation = Console.ReadLine();
                        while (string.IsNullOrEmpty(e.Designation))
                        {
                            Console.WriteLine("Employee Designation Can ot be blank");
                            Console.WriteLine("Enter Employee Designation");
                            e.Designation = Console.ReadLine();
                        }
                        e.Salary = Convert.ToInt32(Console.ReadLine());
                        e.Mobile_No= Console.ReadLine();
                        e.Email_ID = Console.ReadLine();
                        while (string.IsNullOrEmpty(e.Email_ID))
                        {
                            Console.WriteLine("Employee Email_ID Can ot be blank");
                            Console.WriteLine("Enter Employee Email_ID");
                            e.Email_ID = Console.ReadLine();
                        }

                        Connection1.InsertEmployee(e.Emp_ID,e.Dept_ID, e.Name, e.Designation, e.Salary, e.Mobile_No, e.Email_ID);
                        break;

                    case 9:

                        Console.WriteLine("Enter Employee Details to Update Emp_ID,Dept_ID,Name,Designation,Salary,Mobile_No,Email_ID");
                        Employee e1 = new Employee();
                        e1.Emp_ID = Convert.ToInt32(Console.ReadLine());
                        e1.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        e1.Name = Console.ReadLine();
                        e1.Designation = Console.ReadLine();
                        e1.Salary = Convert.ToInt32(Console.ReadLine());
                        e1.Mobile_No = Console.ReadLine();
                        e1.Email_ID = Console.ReadLine();

                        Connection1.UpdateEmployee(e1.Emp_ID, e1.Dept_ID, e1.Name, e1.Designation, e1.Salary, e1.Mobile_No, e1.Email_ID);
                        break;

                    case 10:
                        Employee e3 = new Employee();
                        Console.WriteLine("Enter Employee no to delete");
                        e3.Emp_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.DeleteEmployee(e3.Emp_ID);
                        break;


                    default:
                    Console.WriteLine("Invalid Case");
                    break;
            }

            Console.WriteLine("Enter y r Y to continue");
            ch = Convert.ToChar(Console.ReadLine());

        }
            while (ch == 'Y' || ch == 'y');
           
            Console.ReadLine();
        }
    }

}
