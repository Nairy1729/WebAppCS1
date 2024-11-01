using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        static List<Department> departments = new List<Department>()
        {
            new Department(){DepartmentId = 1 , Name = "HR" , Location = "Pune"} ,
            new Department(){DepartmentId = 2 , Name = "Admin" , Location = "blr"} ,
            new Department(){DepartmentId = 3 , Name = "IT" , Location = "delhi"} ,
            new Department(){DepartmentId = 4 , Name = "Finance" , Location = "noida"} ,


        };
        public DepartmentsController() { }
        public IActionResult Index()
        {
            return View(departments);
        }
        public IActionResult Detail(int id)
        {
			var department = departments.Where(d => d.DepartmentId == id).FirstOrDefault();
			if (department == null)
			{
				return NotFound();
			}
			return View(department);
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departments.Add(department);

            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) { 
            var department = departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            if(department == null)
            {
                return View(department);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Edit(Department updepartment) {
            if (ModelState.IsValid) { 
                var department = departments.Where(x => x.DepartmentId == updepartment.DepartmentId).FirstOrDefault();
                department.Name = updepartment.Name; 
                department.Location = updepartment.Location;

            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var department = departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            if (department != null)
            {
                return View(department);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // Using ActionName("Delete") to match the form submission in the Delete view
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            if (department != null)
            {
                departments.Remove(department);
            }

            return RedirectToAction("Index");
        }



    }
}
