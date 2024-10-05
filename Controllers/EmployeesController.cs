using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApiPrueba.Context;
using CrudApiPrueba.Entities;

namespace CrudApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("consultar/{id}")]
        public async Task<ActionResult<Employees>> Consulta(int id)
        {
            var empleadoDB = await _context.Employees.FindAsync(id);
            return Ok(empleadoDB);
        }

        [HttpPost]
        [Route("guardar/{FirstName},{LastFirst},{Salario}")]
        public async Task<ActionResult<Employees>> Guardar(string fn, string lf, decimal sal)
        {
            var empleadoDB = new Employees
            {
                FirstName = fn,
                LastName = lf,
                Salary = sal
            };
            await _context.Employees.AddAsync(empleadoDB);
            await _context.SaveChangesAsync();
            return Ok("Empleado agregado");
        }

        [HttpPut]
        [Route("editar/{id},{FirstName},{LastFirst},{Salario}")]
        public async Task<ActionResult<Employees>> Editar(int id, string fn, string lf, decimal sal)
        {
            var empleadoDB = await _context.Employees.FindAsync(id);
            empleadoDB.FirstName = fn;
            empleadoDB.LastName = lf;
            empleadoDB.Salary = sal;

            _context.Employees.Update(empleadoDB);
            await _context.SaveChangesAsync();

            return Ok("Empleado modificado");
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<ActionResult<Employees>> Eliminar(int id)
        {
            var empleadoDB = await _context.Employees.FindAsync(id);
            if (empleadoDB != null)
                _context.Employees.Remove(empleadoDB);
            if (empleadoDB is null) return NotFound("empleado no encontrado");
            {

            }
            return Ok("Empleado eliminado");
        }
    }
}
