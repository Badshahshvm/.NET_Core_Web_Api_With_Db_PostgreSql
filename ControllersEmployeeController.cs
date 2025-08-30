
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using WebApplicationWithDB.Data;
// using WebApplicationWithDB.Models.Entities;

// namespace WebApplicationWithDB.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class EmployeeController : ControllerBase
//     {
//         private readonly DbContextApplication _context;

//         public EmployeeController(DbContextApplication context)
//         {
//             _context = context;
//         }

//         // GET: api/employee
//         [HttpGet]
//         public async Task<IActionResult> GetEmployees()
//         {
//             var employees = await _context.employees.ToListAsync();
//             return Ok(employees);
//         }

//         // GET: api/employee/{id}
//         [HttpGet("{id:guid}")]
//         public async Task<IActionResult> GetEmployee(Guid id)
//         {
//             var employee = await _context.employees.FindAsync(id);
//             if (employee == null)
//                 return NotFound();

//             return Ok(employee);
//         }

//         // POST: api/employee
//         [HttpPost]
//         public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
//         {
//             employee.Id = Guid.NewGuid();
//             await _context.employees.AddAsync(employee);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
//         }

//         // PUT: api/employee/{id}
//         [HttpPut("{id:guid}")]
//         public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] Employee updatedEmployee)
//         {
//             var employee = await _context.employees.FindAsync(id);
//             if (employee == null)
//                 return NotFound();

//             employee.Name = updatedEmployee.Name;
//             employee.Email = updatedEmployee.Email;
//             employee.Phone = updatedEmployee.Phone;
//             employee.Salary = updatedEmployee.Salary;

//             await _context.SaveChangesAsync();
//             return Ok(employee);
//         }

//         // DELETE: api/employee/{id}
//         [HttpDelete("{id:guid}")]
//         public async Task<IActionResult> DeleteEmployee(Guid id)
//         {
//             var employee = await _context.employees.FindAsync(id);
//             if (employee == null)
//                 return NotFound();

//             _context.employees.Remove(employee);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }
//     }
// }
