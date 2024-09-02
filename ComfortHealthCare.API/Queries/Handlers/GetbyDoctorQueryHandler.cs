using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Queries.Handlers
{
    public class GetDoctorIdandNameQueryHandler
    {
        private readonly EfCoreDoctorRepository doctorRepo;
        private readonly EfCorePatientRepository patientRepo;
        private readonly EfCorePatientHistoryRepository patientHistoryRepo;
        public GetDoctorIdandNameQueryHandler(EfCoreDoctorRepository doctorRepo, EfCorePatientRepository patientRepo, EfCorePatientHistoryRepository patientHistoryRepo)
        {
            this.doctorRepo = doctorRepo;
            this.patientRepo = patientRepo;
            this.patientHistoryRepo = patientHistoryRepo;
        }

        public async Task<GetDoctorResponse> HandleDoctor()
        {
            GetDoctorResponse response = new GetDoctorResponse();
            response.Result = doctorRepo.GetDoctorIdandName().Result;
            return response;

        }
    }
}
