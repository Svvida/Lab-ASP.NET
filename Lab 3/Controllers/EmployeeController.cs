using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class EmployeeController : Controller
    {
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(EmployeeModel employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Code to process the valid data
        //        // For example, save to the database, redirect to a success page, etc.
        //        // return RedirectToAction("SuccessAction");
        //        return Content("Data is valid. Processing logic goes here.");
        //    }
        //    else
        //    {
        //        // If data is not valid, return the view with validation errors
        //        return View(employee);
        //    }
        //}

        private static List<EmployeeModel> employeeList = new List<EmployeeModel>
{
    new EmployeeModel { Id = 1, FirstName = "John", LastName = "Doe", PESEL = "12345678901", Position = "Developer", Department = "IT", HireDate = DateTime.Now, TerminationDate = null },
    new EmployeeModel { Id = 2, FirstName = "Jane", LastName = "Smith", PESEL = "98765432109", Position = "Manager", Department = "HR", HireDate = DateTime.Now, TerminationDate = null },
};

        // MAIN VIEW
        // GET: /Employee
        public IActionResult Index()
        {
            return View(employeeList);
        }

        // DETAILS
        // GET: /Employee/Details/1
        public IActionResult Details(int id)
        {
            // Find the employee with the given id in the list
            var employee = employeeList.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(); // Employee with the specified id was not found
            }

            return View(employee);
        }

        // ADDING
        // GET: /Employee/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

        // POST: /Employee/Create
        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = employeeList.Count + 1;
                employeeList.Add(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", model);
            }
        }

        // EDITING
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeList.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View("Edit", employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var index = employeeList.FindIndex(e => e.Id == model.Id);

                if (index != -1)
                {
                    employeeList[index] = model;
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", model);
            }
        }

        // DELETING
        // GET: /Employee/Delete/1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the employee with the given id in the list
            var employee = employeeList.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(); // Employee with the specified id was not found
            }

            return View(employee);
        }

        // POST: /Employee/DeleteConfirmed/1
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Find the employee with the given id in the list
            var employee = employeeList.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(); // Employee with the specified id was not found
            }

            // Remove the employee from the list
            employeeList.Remove(employee);

            return RedirectToAction("Index");
        }
    }
}
