using App.Core.Apps.Student.Command;
using App.Core.Apps.Student.Query;
using App.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace ExampleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCQRSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsCQRSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto model)
        {
            var studentId = await _mediator.Send(new CreateStudentCommand { Student = model });
            return Ok(studentId);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatingStudentById(StudentDto model)
        {
            var message = await _mediator.Send(new  UpdateStudentByIdCommand(model));
            return Ok(message);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allStudent = await _mediator.Send(new GetStudentsQuery());
            return Ok(allStudent);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(student);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            var message = await _mediator.Send(new DeleteStudentByIdCommand(id));
            return Ok(message);
        }


    }
}
