using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.HealthCare.DataModels;
using ComfortHealthCare.API.Commands.Handlers;
using ComfortHealthCare.API.Commands;
using ComfortHealthCare.API.Queries.Handlers;
using ComfortHealthCare.API.Queries;
using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : BaseController<Patient, EfCorePatientRepository>
    {
        private readonly EfCorePatientRepository repository;

        public PatientsController(EfCorePatientRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("getpatientbynumber")]
        public async Task<GetPatientResponse> GetPatientbyNumber(int num)
        {

            var handler = new GetbyNumberQueryHandler(null,repository,null);
            return await handler.HandlePatient(num);
        }
        //gettotalcount
        [HttpGet]
        [Route("gettotalcount")]
        public async Task<GetPatientResponse> gettotalcount()
        {

            var handler = new GetTotalCountQueryHandler(null, repository, null);
            return await handler.HandlePatient();
        }

        [HttpPost]
        [Route("createpatient")]
        public async Task<PatientCommandResponse> CreatePatient(PatientCommand patient)
        {

            var handler = new CreatePatientCommandHandler(repository);
            return await handler.HandlePatient(patient);
        }


        [HttpPost]
        [Route("updaterpatient")]
        public async Task<PatientCommandResponse> UpdatePatient(PatientCommand patient)
        {

            var handler = new UpdatePatientCommandHandler(repository);
            return await handler.HandlePatient(patient);
        }
    }
}
