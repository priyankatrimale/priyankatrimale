using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using HRFunctions;

namespace HRModel
{
    class Department
    {
        public int Dept_ID
        {
            get;
            set;
        }
        public string Dept_Name
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }



        //DeptDAL dal = new DeptDAL();
        //public int Dept_ID
        //{
        //    get;
        //    set;
        //}

        //public string Dept_Name
        //{
        //    get;
        //    set;
        //}

        //public string location
        //{
        //    get;
        //    set;
        //}

      

       // Connection1.GetDepartment();

        //public void PrintDepartmentData()
        //{
        //    SqlDataReader reader = GetDeptDta();
        //    Console.WriteLine("Deptno\tDname\tLocation");
        //    while (reader.Read())
        //    {
        //        Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2]);
        //    }
        //}

        




    }
}
