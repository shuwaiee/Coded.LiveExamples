using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
   
    public class EmployeeController : Controller
    {
        public class AddStudentForm
        {
            public string Name { get; set; }
        }
        [HttpGet]
        public IActionResult AddStudent(int id)
        {
            return View();
        }
        public class University
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Student> Students { get; set; }
        }
        [HttpGet]
        
        [HttpPost]
        public IActionResult AddStudent(int id, AddStudentForm form )
        {
            if (ModelState.IsValid)
            {
                var database = new MyDatabaseDbContext();
                var university = database.Universities.Find(id);
                var newStudent = new Student();
                
                newStudent.Name = form.Name;
               
                university.Students.Add(newStudent);
               // bankBranch.Employee.Add(newEmp)
             
                database.Students.Add(newStudent);


                database.SaveChanges();
                
            }
            return View(form);
        }

        public IActionResult Index(string search = "")
        {
            var db = new MyDatabaseDbContext();
            var newEmployee = new Employee();
           
            var employees = db.Employees.AsQueryable();
            if (search != "")
            {
                employees = employees.Where(r => r.Name.ToLower().StartsWith(search));
            }
            ViewBag.Search = search;
            ViewBag.EmployeeCount = employees.Count();
            return View(employees.ToList());
        }
        //[Route("/Bank/{id}/Employee")]
        public IActionResult Details(int id)
        {
            var db = new MyDatabaseDbContext();

            var employee = db.Universities.Include(r=> r.Students).SingleOrDefault(r=> r.Id == id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var db = new MyDatabaseDbContext();
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            var myForm = new EditFormModel();
            myForm.Email = employee.Email;
            myForm.Name = employee.Name;
            return View(myForm);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditFormModel form)
        {
            if (ModelState.IsValid)
            {
                var name = form.Name;
                var email = form.Email;

                var db = new MyDatabaseDbContext();
                var employee = db.Employees.Find(id);
                employee.Name = form.Name;
                employee.Email = form.Email;
                db.SaveChanges();

//                db.Employees.Add(new Employee { Name = name, Email = email, Id = 10 });
                //    employeeList.Add();
                return RedirectToAction("Index");
            }
            return this.View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AddEmployeeForm form)
        {
            if (ModelState.IsValid)
            {
                var name = form.Name;
                var email = form.Email;

                var db = new MyDatabaseDbContext();
                if (db.Employees.Any(r=> r.Email == form.Email))
                {
                    ModelState.AddModelError("Email", "Email is already system");
                    return View(form);
                }

                db.Employees.Add(new Employee { Name = name, Email = email, Id = 10 });
                //    employeeList.Add();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.View();
        }
       
    }
}
