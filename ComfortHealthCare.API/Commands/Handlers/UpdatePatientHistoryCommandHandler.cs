using ComfortHealthCare.API.Queries;
using DataLayer.HealthCare.Repositories;

namespace ComfortHealthCare.API.Commands.Handlers
{
 public class UpdatePatientHistoryCommandHandler
    {
        EfCorePatientHistoryRepository repository;
        public UpdatePatientHistoryCommandHandler(EfCorePatientHistoryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PatientHistoryCommandResponse> HandlePatientHistory(PatientHistoryCommand PatientHistory)
        {
            PatientHistoryCommandResponse response = new PatientHistoryCommandResponse();

            // Map with the context PatientHistory Model//
            DataLayer.HealthCare.DataModels.PatientHistoryDetail updatePatientHistory = new DataLayer.HealthCare.DataModels.PatientHistoryDetail();
            updatePatientHistory.Id = PatientHistory.Id;
            updatePatientHistory.Pid = PatientHistory.Pid;
            updatePatientHistory.Email = PatientHistory.Email;
            updatePatientHistory.AdmissionDate = PatientHistory.AdmissionDate;
            updatePatientHistory.AllergiesHistory = PatientHistory.AllergiesHistory;
            updatePatientHistory.BloodGroup = PatientHistory.BloodGroup;
            updatePatientHistory.Bmi = PatientHistory.Bmi;
            updatePatientHistory.CurrentMedicineTaking = PatientHistory.CurrentMedicineTaking;
            updatePatientHistory.Diagnosis = PatientHistory.Diagnosis;
            updatePatientHistory.Gpefindings = PatientHistory.Gpefindings;
            updatePatientHistory.Height = PatientHistory.Height;
            updatePatientHistory.IllnessHistory = PatientHistory.IllnessHistory;
            updatePatientHistory.Investigation = PatientHistory.Investigation;
            updatePatientHistory.MaritalStatus = PatientHistory.MaritalStatus;
            updatePatientHistory.Occupation = PatientHistory.Occupation;
            updatePatientHistory.Others = PatientHistory.Others;
            updatePatientHistory.PastMedicineTaking = PatientHistory.PastMedicineTaking;
            updatePatientHistory.Religion = PatientHistory.Religion;
            updatePatientHistory.Treatment = PatientHistory.Treatment;
            updatePatientHistory.Weight = PatientHistory.Weight;
            updatePatientHistory.CreateDate = PatientHistory.CreateDate;
            updatePatientHistory.UpdateDate = DateTime.Now;
            await repository.Update(updatePatientHistory).ConfigureAwait(false);
            response.Information = "updated Successfully for the record";
            // response.Name = PatientHistory.PatientHistoryName;
            return response;

        }
    }
}

