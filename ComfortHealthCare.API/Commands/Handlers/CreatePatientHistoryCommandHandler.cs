using ComfortHealthCare.API.Queries;
using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Commands.Handlers
{
    public class CreatePatientHistoryCommandHandler
    {
        EfCorePatientHistoryRepository repository;
        public CreatePatientHistoryCommandHandler(EfCorePatientHistoryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PatientHistoryCommandResponse> HandlePatientHistory(PatientHistoryCommand PatientHistory)
        {
            PatientHistoryCommandResponse response = new PatientHistoryCommandResponse();

            // Map with the context PatientHistory Model//
            DataLayer.HealthCare.DataModels.PatientHistoryDetail createPatientHistory = new DataLayer.HealthCare.DataModels.PatientHistoryDetail();
            createPatientHistory.Id = Guid.NewGuid();
            createPatientHistory.Pid = PatientHistory.Pid;
            createPatientHistory.Email = PatientHistory.Email;
            createPatientHistory.AdmissionDate = PatientHistory.AdmissionDate;
            createPatientHistory.AllergiesHistory = PatientHistory.AllergiesHistory;
            createPatientHistory.BloodGroup = PatientHistory.BloodGroup;
            createPatientHistory.Bmi = PatientHistory.Bmi;
            createPatientHistory.CurrentMedicineTaking = PatientHistory.CurrentMedicineTaking;
            createPatientHistory.Diagnosis = PatientHistory.Diagnosis;
            createPatientHistory.Gpefindings = PatientHistory.Gpefindings;
            createPatientHistory.Height = PatientHistory.Height;
            createPatientHistory.IllnessHistory = PatientHistory.IllnessHistory;
            createPatientHistory.Investigation = PatientHistory.Investigation;
            createPatientHistory.MaritalStatus = PatientHistory.MaritalStatus;
            createPatientHistory.Occupation = PatientHistory.Occupation;
            createPatientHistory.Others = PatientHistory.Others;
            createPatientHistory.PastMedicineTaking = PatientHistory.PastMedicineTaking;
            createPatientHistory.Religion = PatientHistory.Religion;
            createPatientHistory.Treatment = PatientHistory.Treatment;
            createPatientHistory.Weight = PatientHistory.Weight;
            createPatientHistory.UpdateDate = PatientHistory.UpdateDate;
            createPatientHistory.CreateDate = PatientHistory.CreateDate;
            await repository.Add(createPatientHistory).ConfigureAwait(false);
            response.Information = "Created Successfully for the record";
            // response.Name = PatientHistory.PatientHistoryName;
            return response;

        }
    }
}
