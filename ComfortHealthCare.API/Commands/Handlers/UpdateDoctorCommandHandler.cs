using ComfortHealthCare.API.Queries;
using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Commands.Handlers
{
    public class UpdateDoctorCommandHandler
    {
        EfCoreDoctorRepository repository;
        public UpdateDoctorCommandHandler(EfCoreDoctorRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DoctorCommandResponse> HandleDoctor(DoctorCommand doctor)
        {
            DoctorCommandResponse response = new DoctorCommandResponse();

            // Map with the context Doctor Model//
            DataLayer.HealthCare.DataModels.Doctor updateDoctor = new DataLayer.HealthCare.DataModels.Doctor();
           // updateDoctor.Id = doctor.Id;
           //updateDoctor.Password = doctor.Password;
            updateDoctor.Specility = doctor.Specility;
            updateDoctor.Others = doctor.Others;
            updateDoctor.Contact = doctor.Contact;
            updateDoctor.DoctorEmail = doctor.DoctorEmail;
            updateDoctor.DoctorName = doctor.DoctorName;
            updateDoctor.DoctorIdentity = doctor.DoctorIdentity;
            await repository.Update(updateDoctor).ConfigureAwait(false);
            response.Information = "updated Successfully for the record";
            response.Name = doctor.DoctorName;
            return response;

        }
    }
}
