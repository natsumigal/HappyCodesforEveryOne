using ComfortHealthCare.API.Queries;
using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Commands.Handlers
{
    public class CreateDoctorCommandHandler
    {
        EfCoreDoctorRepository repository;
        public CreateDoctorCommandHandler(EfCoreDoctorRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DoctorCommandResponse> HandleDoctor(DoctorCommand doctor)
        {
            DoctorCommandResponse response = new DoctorCommandResponse();

            // Map with the context Doctor Model//
            DataLayer.HealthCare.DataModels.Doctor createDoctor = new DataLayer.HealthCare.DataModels.Doctor();
            createDoctor.Id = Guid.NewGuid();
            createDoctor.Password = doctor.Password;
            createDoctor.Specility = doctor.Specility;
            createDoctor.Others = doctor.Others;
            createDoctor.Contact = doctor.Contact;
            createDoctor.DoctorEmail = doctor.DoctorEmail;
            createDoctor.DoctorName = doctor.DoctorName;
            createDoctor.DoctorIdentity = doctor.DoctorIdentity;
            await repository.Add(createDoctor).ConfigureAwait(false);
            response.Information = "Created Successfully for the record";
            response.Name = doctor.DoctorName;
            return response;

        }
    }
}
