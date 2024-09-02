using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Queries.Handlers
{
    public class GetTotalCountQueryHandler
    {
        private readonly EfCoreDoctorRepository doctorRepo;
        private readonly EfCorePatientRepository patientRepo;
        private readonly EfCorePatientHistoryRepository patientHistoryRepo;
        public GetTotalCountQueryHandler(EfCoreDoctorRepository doctorRepo, EfCorePatientRepository patientRepo, EfCorePatientHistoryRepository patientHistoryRepo)
        {
            this.doctorRepo = doctorRepo;
            this.patientRepo = patientRepo;
            this.patientHistoryRepo = patientHistoryRepo;
        }
        public async Task<GetPatientResponse> HandlePatient()
        {
            GetPatientResponse response = new GetPatientResponse();
            response.Result = patientRepo.GetTotalCount().Result;
            return response;

        }
        public async Task<GetDoctorResponse> HandleDoctor()
        {
            GetDoctorResponse response = new GetDoctorResponse();
            response.Result = doctorRepo.GetTotalCount().Result;
            return response;

        }
        public async Task<GetPatientHistoryResponse> HandlePatientHistory()
        {
            GetPatientHistoryResponse response = new GetPatientHistoryResponse();
            response.Result = patientHistoryRepo.GetTotalCount().Result;
            return response;

        }
        public async Task<GetPatientHistoryResponse> HandlePatientHistorybyPatient()
        {
            GetPatientHistoryResponse response = new GetPatientHistoryResponse();
            response.Result = patientHistoryRepo.GetTotalCount().Result;
            return response;

        }
    }
}
