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
        public PatientCommand Patient { get; set; } = default!;
        private readonly ApiClient.ComfortHealthApiClient.ApiClient _apiClient;

        public PatientModel()
        {
            _apiClient = new ApiClient.ComfortHealthApiClient.ApiClient("", new HttpClient());
        }

        public async Task OnGetAsync()
        {
            var jsonString = await _apiClient.GetpatientbynumberAsync(10, new CancellationTokenSource().Token);
            if (!string.IsNullOrEmpty(jsonString?.Result?.ToString()))
            {
                Patients = JsonConvert.DeserializeObject<List<PatientCommand>>(jsonString.Result.ToString()) ?? new List<PatientCommand>();
            }
        }

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
