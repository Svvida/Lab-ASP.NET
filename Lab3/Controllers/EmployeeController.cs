using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class EmployeeController : Controller
    {
     

        private static List<EmployeeModel> employeeList = new List<EmployeeModel>
{
    new EmployeeModel { Id = 1, FirstName = "John", LastName = "Doe", PESEL = "12345678901", Position = "Developer", Department = "IT", HireDate = DateTime.Now, TerminationDate = null },
    new EmployeeModel { Id = 2, FirstName = "Jane", LastName = "Smith", PESEL = "98765432109", Position = "Manager", Department = "HR", HireDate = DateTime.Now, TerminationDate = null },
};

        
        public IActionResult Index()
        {
            return View(employeeList);
        }

        
        public IActionResult Details(int id)
        {
            
            var employee = employeeList.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(); 
            }

            return View(employee);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

       
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

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            var employee = employeeList.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(); 
            }

            return View(employee);
        }

       
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
          
            var employee = employeeList.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(); 
            }

           
            employeeList.Remove(employee);

            return RedirectToAction("Index");
        }
    }
}
