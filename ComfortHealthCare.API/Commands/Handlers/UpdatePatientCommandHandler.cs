using ComfortHealthCare.API.Queries;
using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Commands.Handlers
{
    public class UpdatePatientCommandHandler
    {
        EfCorePatientRepository repository;
        public UpdatePatientCommandHandler(EfCorePatientRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PatientCommandResponse> HandlePatient(PatientCommand Patient)
        {
            PatientCommandResponse response = new PatientCommandResponse();

            // Map with the context Patient Model//
            DataLayer.HealthCare.DataModels.Patient updatePatient = new DataLayer.HealthCare.DataModels.Patient();
            updatePatient.Id = new Guid();
            updatePatient.Age = Patient.Age;
            updatePatient.BirthDate = Patient.BirthDate;
            updatePatient.Contact = Patient.Contact;
            updatePatient.CreatedDate = Patient.CreatedDate;
            updatePatient.DoctorId = Patient.DoctorId;
            updatePatient.Nrc = Patient.Nrc;
            updatePatient.PatientAddress = Patient.PatientAddress;
            updatePatient.PatientName = Patient.PatientName;
            updatePatient.Sex = Patient.Sex;
            await repository.Update(updatePatient).ConfigureAwait(false);
            response.Information = "updated Successfully for the record";
            response.Name = Patient.PatientName;
            return response;

        }
    }
}
