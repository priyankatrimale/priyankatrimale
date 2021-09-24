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





            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.;Initial Catalog=HRMS; Integrated Security =true";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "LoginProc";

            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            while (true)
            {
                Console.WriteLine("*********************HR Management System********************");

                Console.WriteLine("\nEnter The UserName  :");
                string user = Convert.ToString(Console.ReadLine());
                Console.WriteLine("\nEnter The Password :");
                string pass = Console.ReadLine();
                if (user == "priya" && pass == "1234")
                {
                    Console.WriteLine("\nYou are a valid user");
                    Console.ReadLine();
                    break;
                }

                else
                {
                    Console.WriteLine("\n\nInvalid user");
                    Console.WriteLine("Enter the Username and Password Again");
                    continue;
                }
            }
            


            Connection1.createconnection();

            int choice;
            char ch;
            do
            {

            Console.WriteLine("\n\n*************Department Menu***************");
            Console.WriteLine("1.Print All Departments");
            Console.WriteLine("2.Print Department based on deptno");
            Console.WriteLine("3.Insert Department");
            Console.WriteLine("4.Update Department");
            Console.WriteLine("5.Delete Department");

                Console.WriteLine("\n\n******************Employee Menu******************");
                Console.WriteLine("6.Print All Employees");
                Console.WriteLine("7.Print Employees based on Emp_ID");
                Console.WriteLine("8.Insert Employee");
                Console.WriteLine("9.Update Employee");
                Console.WriteLine("10.Delete Employee");
                Console.WriteLine("\n\nEnter your Choice");
            choice = Convert.ToInt32(Console.ReadLine());


            
            switch (choice)
            {
                case 1:
                    Connection1.GetDepartment();
                    break;

                case 2:
                        
                    Console.WriteLine("\nEnter department no to view details");
                     int Dept_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.GetDepartmentUsingDno(Dept_ID);

                    break;



                    case 3:
                        
                        Console.WriteLine("\nEnter Department Details to Enter Deptno,dname,location");
                        Department d = new Department();
                        Console.WriteLine("\nEnter Dept_ID Please");
                        d.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter Department Name Please");
                        d.Dept_Name = Console.ReadLine();

                        while (string.IsNullOrEmpty(d.Dept_Name))
                        {
                            Console.WriteLine("\nDepartment name Can ot be blank");
                            Console.WriteLine("\nEnter Department Name");
                            d.Dept_Name = Console.ReadLine();
                        }
                        Console.WriteLine("\nEnter Department Location Name Please");
                        d.Location = Console.ReadLine();
                        while (string.IsNullOrEmpty(d.Location))
                        {
                            Console.WriteLine("\nDepartment name Can ot be blank");
                            Console.WriteLine("\nEnter Department Location");
                            d.Location = Console.ReadLine();
                        }

                        Connection1.InsertDepartment(d.Dept_ID,d.Dept_Name,d.Location);
                        break;

                    case 4:
                       
                        Console.WriteLine("\nEnter Department Details to Update Deptno,dname,location");
                        Department d1 = new Department();
                        d1.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        d1.Dept_Name = Console.ReadLine();
                        d1.Location = Console.ReadLine();
                        

                        Connection1.UpdateDepartment(d1.Dept_ID, d1.Dept_Name, d1.Location);
                        break;

                    case 5:
                        Department d2 = new Department();
                        Console.WriteLine("\nEnter Department ID to delete");
                        d2.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.DeleteDepartment(d2.Dept_ID);
                        Console.WriteLine("\nRecord Deleted");
                        break;



                    case 6:
                        Connection1.GetEmployee();
                        break;

                    case 7:

                        Console.WriteLine("\nEnter Employee no to view details");
                        int Emp_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.GetEmployeeUsingEno(Emp_ID);

                        break;

                    case 8:

                        Console.WriteLine("\nEnter Employee Details to Enter Emp_ID,Dept_ID,Name,Designation,Salary,Mobile_No,Email_ID");
                        Employee e= new Employee();
                        Console.WriteLine("Emp_Id Please");
                        
                        e.Emp_ID= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Department ID Please");
                        e.Dept_ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Name Please");
                        e.Name = Console.ReadLine();
                        while (string.IsNullOrEmpty(e.Name))
                        {
                            Console.WriteLine("Employee name Can ot be blank");
                            Console.WriteLine("Enter Employee Name");
                            e.Name = Console.ReadLine();
                        }
                        Console.WriteLine("\nDesignation Please");
                        e.Designation = Console.ReadLine();
                        while (string.IsNullOrEmpty(e.Designation))
                        {
                            Console.WriteLine("\nEmployee Designation Can ot be blank");
                            Console.WriteLine("\nEnter Employee Designation");
                            e.Designation = Console.ReadLine();
                        }
                        Console.WriteLine("\nSalary Please");
                        e.Salary = Convert.ToInt32(Console.ReadLine());
                        
                        while (true)
                        {

                            Console.WriteLine("\nMobile NUmber Please");
                            e.Mobile_No = Convert.ToInt64(Console.ReadLine());



                            bool check = Connection1.IsValidMobileNo(e.Mobile_No);
                            if (check == true)
                            {
                               
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nMobile Number is Invalid 10 digit please");
                                Console.WriteLine("\nPlase enter Again");
                                continue;
                            }
                        }
                       
                        while (true)
                        {

                            Console.WriteLine("\nEmail_Id Please");
                            e.Email_ID = Console.ReadLine();



                            bool check = Connection1.IsValidEmail(e.Email_ID);
                            if (check == true)
                            {
                               
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nEmail is Invalid ");
                                Console.WriteLine("\nPlease enter Again");
                                continue;
                            }
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
                        e1.Mobile_No =Convert.ToInt64(Console.ReadLine());
                        e1.Email_ID = Console.ReadLine();

                        Connection1.UpdateEmployee(e1.Emp_ID, e1.Dept_ID, e1.Name, e1.Designation, e1.Salary, e1.Mobile_No, e1.Email_ID);
                        break;

                    case 10:
                        Employee e3 = new Employee();
                        Console.WriteLine("\nEnter Employee no to delete");
                        e3.Emp_ID = Convert.ToInt32(Console.ReadLine());
                        Connection1.DeleteEmployee(e3.Emp_ID);
                        break;


                    default:
                    Console.WriteLine("\nInvalid Case");
                    break;
            }

            Console.WriteLine("\n\nEnter y r Y to continue");
            ch = Convert.ToChar(Console.ReadLine());

        }
            while (ch == 'Y' || ch == 'y');
           
            Console.ReadLine();
        }
    }

}
