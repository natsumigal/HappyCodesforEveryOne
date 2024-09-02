using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiClient.ComfortHealthApiClient;
using Microsoft.AspNetCore.Mvc;

namespace ComfortHealthCare.Presentation.Pages
{
    public class PatientModel : PageModel
    {
        public List<PatientCommand> Patients { get; set; } = new List<PatientCommand>();
        public List<DoctorCommand> Doctors { get; set; } = new List<DoctorCommand>();
        public PatientCommand Patient { get; set; } = default!;
        private readonly ApiClient.ComfortHealthApiClient.ApiClient _apiClient;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public PatientModel()
        {
            _apiClient = new ApiClient.ComfortHealthApiClient.ApiClient("http://localhost:5000/", new HttpClient());
        }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            const int pageSize = 10;
            CurrentPage = pageNumber;

            var jsonString = await _apiClient.GetpatientbynumberAsync(pageNumber, new CancellationTokenSource().Token);
            if (!string.IsNullOrEmpty(jsonString?.Result?.ToString()))
            {
                Patients = JsonConvert.DeserializeObject<List<PatientCommand>>(jsonString.Result.ToString()) ?? new List<PatientCommand>();
            }

            // Assuming the API provides a way to get the total count of doctors
            var totalCnt = await _apiClient.Gettotalcount2Async(new CancellationTokenSource().Token);
            TotalPages = (int)Math.Ceiling(Convert.ToDouble(totalCnt.Result) / (double)10);
        }

        //public async Task OnGetDoctorAsync()
        //{

        //    var jsonString = await _apiClient.GetDoctor(pageNumber, new CancellationTokenSource().Token);
        //    if (!string.IsNullOrEmpty(jsonString?.Result?.ToString()))
        //    {
        //        Patients = JsonConvert.DeserializeObject<List<PatientCommand>>(jsonString.Result.ToString()) ?? new List<PatientCommand>();
        //    }

        //    TotalPages = (int)Math.Ceiling(20 / (double)10);
        //}

        public async Task<IActionResult> OnPostCreatePatientAsync(PatientCommand patient)
        {
            var response = await _apiClient.CreatepatientAsync(patient, new CancellationTokenSource().Token);
            if (response != null) // Assuming response indicates success
            {
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdatePatientAsync(PatientCommand patient)
        {
            var response = await _apiClient.UpdaterpatientAsync(patient, new CancellationTokenSource().Token);
            if (response != null) // Assuming response indicates success
            {
                return RedirectToPage();
            }
            return Page();
        }

        // Uncomment and implement if delete functionality is needed
        // public async Task<IActionResult> OnPostDeletePatientAsync(int id)
        // {
        //     var response = await _apiClient.DeletepatientAsync(id, new CancellationTokenSource().Token);
        //     if (response != null && response.Success) // Assuming response.Success indicates success
        //     {
        //         return RedirectToPage();
        //     }
        //     return Page();
        // }
    }
}
