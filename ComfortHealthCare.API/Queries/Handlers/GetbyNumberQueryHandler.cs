using DataLayer.HealthCare.DataModels;
using DataLayer.HealthCare.Repositories;
using Newtonsoft.Json;

namespace ComfortHealthCare.API.Queries.Handlers
{
    public class GetbyNumberQueryHandler
    {
        private readonly EfCoreDoctorRepository doctorRepo;
        private readonly EfCorePatientRepository patientRepo;
        private readonly EfCorePatientHistoryRepository patientHistoryRepo;
        public GetbyNumberQueryHandler(EfCoreDoctorRepository doctorRepo, EfCorePatientRepository patientRepo, EfCorePatientHistoryRepository patientHistoryRepo)
        {
                this.doctorRepo = doctorRepo;
                this.patientRepo = patientRepo;
                this.patientHistoryRepo = patientHistoryRepo;
        }
        public async Task<GetPatientResponse> HandlePatient(int num)
        {
            GetPatientResponse response = new GetPatientResponse();
            response.Result= patientRepo.GetAllbyNumber(num).Result;
            return  response;
          
        }
        public async Task<GetDoctorResponse> HandleDoctor(int num)
        {
            GetDoctorResponse response = new GetDoctorResponse();
            response.Result = doctorRepo.GetAllbyNumber(num).Result;
            return response;

        }
        public async Task<GetPatientHistoryResponse> HandlePatientHistory(int num)
        {
            GetPatientHistoryResponse response = new GetPatientHistoryResponse();
            response.Result = patientHistoryRepo.GetAllbyNumber(num).Result;
            return response;

        }
        public async Task<GetPatientHistoryResponse> HandlePatientHistorybyPatient(int num,string pid)
        {
            GetPatientHistoryResponse response = new GetPatientHistoryResponse();
            response.Result = patientHistoryRepo.GetPatientHistorybyPatient(num,pid).Result;
            return response;

        }
        

    }
}
