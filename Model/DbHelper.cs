using APIAssignment1.EFCore;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIAssignment1.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context; 
        }

        public List<EmployeeModel> GetEmployee()
        {
            List<EmployeeModel> response = new List<EmployeeModel>();
            var dataList = _context.Employees.ToList();
            dataList.ForEach(row => response.Add(new EmployeeModel()
            {
                id = row.id,
                Emp_Name = row.Emp_Name,
                Emp_Gender=row.Emp_Gender,
                Emp_Salary=row.Emp_Salary,
                Emp_Mobile=row.Emp_Mobile
            }));
            return response;
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            EmployeeModel response = new EmployeeModel();
            var row = _context.Employees.Where(d => d.id.Equals(id)).FirstOrDefault();
            if(row != null)
            {
                response.id = row.id;
                response.Emp_Name = row.Emp_Name;
                response.Emp_Gender = row.Emp_Gender;
                response.Emp_Salary = row.Emp_Salary;
                response.Emp_Mobile = row.Emp_Mobile;


            }
            return response;

        }
        /// <summary>
        /// It serves the POST/PUT/PATCH
        /// </summary>
        public HttpResponseMessage SaveEmployee(EmployeeModel employeeModel)
        {
            Employee dbTable = new Employee();
            var employee = _context.Employees.Where(d => d.Emp_Mobile.Equals(employeeModel.Emp_Mobile)).FirstOrDefault();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            if (employeeModel.id > 0)
            {
                //PUT
                dbTable = _context.Employees.Where(d => d.id.Equals(employeeModel.id)).FirstOrDefault();
                
                if (dbTable != null)
                {
                    dbTable.Emp_Name = employeeModel.Emp_Name;
                    dbTable.Emp_Salary = employeeModel.Emp_Salary;
                    dbTable.Emp_Mobile = employeeModel.Emp_Mobile;
                    return response = new HttpResponseMessage(HttpStatusCode.OK);
                }

                else
                {
                    return response = new HttpResponseMessage(HttpStatusCode.NotFound);
                }

            }
            else
            {
                //POST
                
                if (employee != null)
                {
                    return response = new HttpResponseMessage(HttpStatusCode.Conflict);
                }
                else
                {
                    dbTable.Emp_Name = employeeModel.Emp_Name;
                    dbTable.Emp_Gender = employeeModel.Emp_Gender;
                    dbTable.Emp_Salary = employeeModel.Emp_Salary;
                    dbTable.Emp_Mobile = employeeModel.Emp_Mobile;

                    _context.Employees.Add(dbTable);
                    _context.SaveChanges();
                    return response = new HttpResponseMessage(HttpStatusCode.OK);
                    
                }
                
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage DeleteEmployee(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var employee = _context.Employees.Where(d => d.id.Equals(id)).FirstOrDefault();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            if (employee != null)
            {
                
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return response = new HttpResponseMessage(HttpStatusCode.OK);

            }
            else
            {
                return response = new HttpResponseMessage(HttpStatusCode.NotFound); 
            }
        }
        /// <summary>
        /// PATCH
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage UpdateEmployeePatch(int id, JsonPatchDocument EmployeeModel)
        {
            var employee =  _context.Employees.Find(id);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            if (employee != null)
            {
                EmployeeModel.ApplyTo(employee);
                 _context.SaveChanges();
                return response = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
        
    }

}

