﻿using App.Core.Apps.Patient.Command;
using App.Core.Apps.Patient.Query;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientEmployeePatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {


        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetActivePatient()
        {
            var allPatient = await _mediator.Send(new GetActivePatientQuery());
            return Ok(allPatient);
        }

        [HttpGet("allPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var allPatient = await _mediator.Send(new GetAllPatientQuery());
            return Ok(allPatient);
        }



        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPatientById(int id)
        //{
        //    var patient = await _mediator.Send(new GetPatientByIdQuery { Id = id });

        //    if (patient == null)
        //    {
        //        return NotFound("Patient Not Found");
        //    }


        //    return Ok(patient);
        //}



        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient model)
        {
            var isPatientAdded = await _mediator.Send(new CreatePatientCommand { Patient = model });

            if (!isPatientAdded)
            {
                return NotFound(new { message = "Patient Not Added" });
            }

            return Ok(new { message = "Patient Added Successfully" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientById(Patient model, int id)
        {
            var isUpdated = await _mediator.Send(new UpdatePatientByIdCommand { Patient = model, Id = id });

            if (!isUpdated)
            {
                return NotFound(new { message = "Patient Not Found" });
            }

            return Ok(new { message = "Update Patient Successfully" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientById(int id)
        {
            var isDeleted = await _mediator.Send(new DeletePatientByIdPermanentCommand { Id = id });

            if (!isDeleted)
            {
                return NotFound(new { message = "Patient Not Found" });
            }

            return Ok(new { message = "Patient Deleted Successfully" });
        }




    }
}
