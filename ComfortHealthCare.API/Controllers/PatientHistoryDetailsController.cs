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
    public class PatientHistoryDetailsController : BaseController<PatientHistoryDetail, EfCorePatientHistoryRepository>
    {
        private readonly EfCorePatientHistoryRepository repository;

        public PatientHistoryDetailsController(EfCorePatientHistoryRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("getpatientHistorybynumber")]
        public async Task<GetPatientHistoryResponse> GetPatientHistorybyNumber(int num)
        {

            var handler = new GetbyNumberQueryHandler(null,null,repository);
            return await handler.HandlePatientHistory(num);
        }
        //HandlePatientHistorybyDoctor


        [HttpGet]
        [Route("getpatientHistorybypatient")]
        public async Task<GetPatientHistoryResponse> GetPatientHistorybyPatient(int num,string pid)
        {

            var handler = new GetbyNumberQueryHandler(null, null, repository);
            return await handler.HandlePatientHistorybyPatient(num,pid);
        }

        [HttpPost]
        [Route("createpatientHistory")]
        public async Task<PatientHistoryCommandResponse> CreateDocter(PatientHistoryCommand patientHistory)
        {

            var handler = new CreatePatientHistoryCommandHandler(repository);
            return await handler.HandlePatientHistory(patientHistory);
        }

        [HttpPost]
        [Route("updaterpatientHistory")]
        public async Task<PatientHistoryCommandResponse> UpdateDocter(PatientHistoryCommand patientHistory)
        {

            var handler = new UpdatePatientHistoryCommandHandler(repository);
            return await handler.HandlePatientHistory(patientHistory);
        }
    }
}
