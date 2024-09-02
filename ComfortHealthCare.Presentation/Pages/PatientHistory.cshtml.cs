using ApiClient.ComfortHealthApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ComfortHealthCare.Presentation.Pages
{
    public class PatientHistoryModel : PageModel
    {
        public PatientHistoryCommand PatientHistory { get; set; } = default!;
        public List<PatientHistoryCommand> PatientHistories { get; set; } = new List<PatientHistoryCommand>();
        private readonly ApiClient.ComfortHealthApiClient.ApiClient _apiClient;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public string Pid { get; set; }

        public PatientHistoryModel()
        {
            _apiClient = new ApiClient.ComfortHealthApiClient.ApiClient("http://localhost:5000/", new HttpClient());
        }
        public async Task OnGetAsync(string pid, int pageNumber = 1)
        {

            if (pid != null)
            {
                Pid = pid;
                const int pageSize = 10;
                CurrentPage = pageNumber;
                var jsonString = await _apiClient.GetpatientHistorybypatientAsync(10, pid.ToString(), (new CancellationTokenSource()).Token);
                if (!string.IsNullOrEmpty(jsonString?.Result?.ToString()))
                {
                    PatientHistories= JsonConvert.DeserializeObject<List<PatientHistoryCommand>>(jsonString.Result.ToString());
                }
                // Assuming the API provides a way to get the total count of doctors
                var totalCnt = await _apiClient.Gettotalcount3Async(new CancellationTokenSource().Token);
                TotalPages = (int)Math.Ceiling(Convert.ToDouble(totalCnt.Result) / (double)10);
            }


        }
        public async Task<IActionResult> OnPostCreatePatientHistoryAsync(PatientHistoryCommand patientHistory)
        {
          

            var response = await _apiClient.CreatepatientHistoryAsync(patientHistory, new CancellationTokenSource().Token);
            if (response != null) // Assuming response indicates success
            {
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdatePatientHistoryAsync(PatientHistoryCommand patientHistory)
        {

            var response = await _apiClient.UpdaterpatientHistoryAsync(patientHistory, new CancellationTokenSource().Token);
            if (response != null) // Assuming response indicates success
            {
                return RedirectToPage();
               // return RedirectToPage(new { pid = patientHistory.Pid });
            }
            return Page();
        }

        // Uncomment and implement if delete functionality is needed
        // public async Task<IActionResult> OnPostDeletePatientHistoryAsync(int id)
        // {
        //     var response = await _apiClient.DeletepatienthistoryAsync(id, new CancellationTokenSource().Token);
        //     if (response != null && response.Success) // Assuming response.Success indicates success
        //     {
        //         return RedirectToPage();
        //     }
        //     return Page();
        // }
    }
}
