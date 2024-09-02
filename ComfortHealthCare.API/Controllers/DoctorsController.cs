using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.HealthCare.DataModels;
using DataLayer.HealthCare.Repositories;
using ComfortHealthCare.API.Queries;
using ComfortHealthCare.API.Queries.Handlers;
using NuGet.Protocol.Core.Types;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ComfortHealthCare.API.Commands;
using ComfortHealthCare.API.Commands.Handlers;

namespace ComfortHealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : BaseController<Doctor, EfCoreDoctorRepository>
    {
        private readonly EfCoreDoctorRepository repository;

        public DoctorsController(EfCoreDoctorRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("getdoctorbynumber")]
        public async Task<GetDoctorResponse> GetDoctorbyNumber(int num)
        {

           var handler = new GetbyNumberQueryHandler(repository,null,null);
            return await handler.HandleDoctor(num); 
        }

        [HttpGet]
        [Route("gettotalcount")]
        public async Task<GetDoctorResponse> GetTotalCount()
        {

            var handler = new GetTotalCountQueryHandler(repository, null, null);
            return await handler.HandleDoctor();
        }


        [HttpGet]
        [Route("getdoctoridandname")]
        public async Task<GetDoctorResponse> GetDoctorIdandName()
        {

            var handler = new GetDoctorIdandNameQueryHandler(repository, null, null);
            return await handler.HandleDoctor();
        }

        [HttpPost]
        [Route("createdoctor")]
        public async Task<DoctorCommandResponse> CreateDocter(DoctorCommand doctor)
        {

            var handler = new CreateDoctorCommandHandler(repository);
            return await handler.HandleDoctor(doctor);
        }

        [HttpPost]
        [Route("updaterdoctor")]
        public async Task<DoctorCommandResponse> UpdateDocter(DoctorCommand doctor)
        {

            var handler = new UpdateDoctorCommandHandler(repository);
            return await handler.HandleDoctor(doctor);
        }



    }
}
