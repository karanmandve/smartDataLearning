using App.core.Apps.Department.Command;
using App.core.Apps.Department.Query;
using App.core.Apps.Employee.Command;
using App.core.Apps.Employee.Query;
using App.core.Models;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentManagementController : ControllerBase
    {



        private readonly IMediator _mediator;

        public DepartmentManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var allDepartment = await _mediator.Send(new GetDepartmentQuery());
            return Ok(allDepartment);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _mediator.Send(new GetDepartmentByIdQuery { Id = id });

            if (department == null)
            {
                return NotFound("Department Not Found");
            }


            return Ok(department);
        }



        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto model)
        {
            var isDepartmentAdded = await _mediator.Send(new CreateDepartmentCommand { Department = model });

            if (isDepartmentAdded == false)
            {
                return BadRequest("Department Aleady Exist");
            }


            return Ok("Department Successfully Added");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentById(DepartmentDto model, int id)
        {
            var IsUpdated = await _mediator.Send(new UpdateDepartmentByIdCommand { Department = model, Id = id });

            if (IsUpdated == false)
            {
                return NotFound("Department Not Found");
            }

            return Ok("Department Updated Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentById(int id)
        {
            var isDeleted = await _mediator.Send(new DeleteDepartmentByIdCommand { Id = id });

            if(isDeleted == false)
            {
                return NotFound("Department Not Found");
            }

            return Ok("Department Deleted Successfully");
        }





    }
}
