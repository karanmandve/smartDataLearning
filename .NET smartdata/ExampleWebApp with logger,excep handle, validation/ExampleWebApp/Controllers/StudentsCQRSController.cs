﻿using App.Core.Apps.Student.Command;
using App.Core.Apps.Student.Query;
using App.Core.Models;
using ExampleWebApp.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExampleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCQRSController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentsCQRSController> _logger;

        public StudentsCQRSController(IMediator mediator, ILogger<StudentsCQRSController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto model)
        {
            var studentId = await _mediator.Send(new CreateStudentCommand { Student = model });
            return Ok(studentId);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get Method");


            var studentId = await _mediator.Send(new GetStudentsQuery());
            return Ok(studentId);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExceptionTest()
        {
            var test = await Task.FromResult(0);

            throw new Exception("Test");

            return Ok();
        }

        //[action] take method name
        [HttpPost("[action]")]
        public async Task<IActionResult> ValidationTest(TestModelDto model, IValidator<TestModelDto> validator)
        {
            var test = await Task.FromResult(0);
            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors[0].ErrorMessage;
                return BadRequest(errorMessage);
            }

            return Ok();
        }
    }
}
