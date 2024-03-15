using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityCrud.Models;

namespace EntityCrud.Controllers
{
    public class EmployeeController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        // GET: Employee
        public ActionResult DisplayEmployees()
        {
            var Emps = dc.Employees.Where(E => E.Status == true);
            return View(Emps);
        }

        public ActionResult DisplayEmployee(int Eid)
        {
            var Emp = dc.Employees.Find(Eid);
            return View(Emp);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            ViewBag.Did = new SelectList(dc.Departments,"Did","Dname");
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddEmployee(Employee Emp)
        {
            Emp.Status = true;
            dc.Employees.Add(Emp);
            dc.SaveChanges();
           return RedirectToAction("DisplayEmployees");
        }

       public ActionResult EditEmployee(int Eid)
        {
            var Emp = dc.Employees.Find(Eid);
            ViewBag.Did = new SelectList(dc.Departments, "Did", "Dname", Emp.Did);
            return View(Emp);
        }

        public RedirectToRouteResult UpdateEmployee(Employee Emp)
        {
            Emp.Status = true;
            dc.Entry(Emp).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int Eid)
        {
            var Emp = dc.Employees.Find(Eid);
            return View(Emp);
        }
        [HttpPost]
        public RedirectToRouteResult DeleteEmployee(Employee Emp)
        {
            Emp.Status = true;
            dc.Entry(Emp).State = System.Data.Entity.EntityState.Deleted;
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }

    }
}