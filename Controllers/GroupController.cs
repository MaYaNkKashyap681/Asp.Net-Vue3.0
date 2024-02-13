using vue3.Models;
using Microsoft.AspNetCore.Mvc;

namespace vue3.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();

            // Add employees to the list
            employees.Add(new Employee
            {
                EmployeeID = 5,
                FullName = "John Doe",
                Position = "Manager",
                TitleOfCourtesy = "Mr.",
                BirthDate = new DateTime(1980, 5, 10),
                HireDate = new DateTime(2005, 9, 15),
                Address = "123 Main St.",
                City = "Anytown",
                Region = "Region",
                PostalCode = "12345",
                Country = "USA",
                HomePhone = "(123) 456-7890",
                Extension = "100",
                Photo = "https://images.unsplash.com/photo-1706391740145-19c93b1cda9a?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw0M3x8fGVufDB8fHx8fA%3D%3D",
                Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ReportsTo = null 
            });
            employees.Add(new Employee
            {
                EmployeeID = 6,
                FullName = "Jane Smith",
                Position = "Developer",
                TitleOfCourtesy = "Ms.",
                BirthDate = new DateTime(1985, 8, 20),
                HireDate = new DateTime(2010, 7, 1),
                Address = "456 Elm St.",
                City = "Smallville",
                Region = "Region",
                PostalCode = "54321",
                Country = "USA",
                HomePhone = "(987) 654-3210",
                Extension = "200",
                Photo = "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fHBlb3BsZXxlbnwwfHwwfHx8MA%3D%3D",
                Notes = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                ReportsTo = 5
            });
            employees.Add(new Employee
            {
                EmployeeID = 7,
                FullName = "Alice Johnson",
                Position = "Sales Associate",
                TitleOfCourtesy = "Ms.",
                BirthDate = new DateTime(1990, 3, 15),
                HireDate = new DateTime(2018, 4, 20),
                Address = "789 Oak St.",
                City = "Village",
                Region = "Region",
                PostalCode = "67890",
                Country = "USA",
                HomePhone = "(111) 222-3333",
                Extension = "300",
                Photo = "https://images.unsplash.com/photo-1522556189639-b150ed9c4330?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTh8fHBlb3BsZXxlbnwwfHwwfHx8MA%3D%3D",
                Notes = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                ReportsTo = 5 
            });     

            // Assign the list of employees to ViewData
            ViewData["employees"] = employees;
            return View();
        }
    }
}
