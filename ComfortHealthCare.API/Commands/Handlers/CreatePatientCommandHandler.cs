using ComfortHealthCare.API.Queries;
using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Commands.Handlers
{
    public class CreatePatientCommandHandler
    {
        EfCorePatientRepository repository;
        public CreatePatientCommandHandler(EfCorePatientRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PatientCommandResponse> HandlePatient(PatientCommand Patient)
        {
            PatientCommandResponse response = new PatientCommandResponse();

            // Map with the context Patient Model//
            DataLayer.HealthCare.DataModels.Patient createPatient = new DataLayer.HealthCare.DataModels.Patient();
            createPatient.Id = Guid.NewGuid();
            createPatient.Age = Patient.Age;
            createPatient.BirthDate = Patient.BirthDate;
            createPatient.Contact = Patient.Contact;
            createPatient.CreatedDate = Patient.CreatedDate;
            createPatient.DoctorId = Patient.DoctorId;
            createPatient.Nrc = Patient.Nrc;
            createPatient.PatientAddress = Patient.PatientAddress;
            createPatient.PatientName = Patient.PatientName;
            createPatient.Sex = Patient.Sex;
            await repository.Add(createPatient).ConfigureAwait(false);
            response.Information = "Created Successfully for the record";
            response.Name = Patient.PatientName;
            return response;

        }
    }
}
