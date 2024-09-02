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
    public class DoctorModel : PageModel
    {
        public List<DoctorCommand> Doctors { get; set; } = new List<DoctorCommand>();
        public DoctorCommand Doctor { get; set; }= default!;
        private readonly ApiClient.ComfortHealthApiClient.ApiClient _apiClient;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public DoctorModel()
        {
            _apiClient = new ApiClient.ComfortHealthApiClient.ApiClient("http://localhost:5000/", new HttpClient());
        }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            CurrentPage = pageNumber;
            var jsonString = await _apiClient.GetdoctorbynumberAsync(pageNumber, new CancellationTokenSource().Token);
            if (!string.IsNullOrEmpty(jsonString?.Result?.ToString()))
            {
                Doctors = JsonConvert.DeserializeObject<List<DoctorCommand>>(jsonString.Result.ToString()) ?? new List<DoctorCommand>();
            }

            // Assuming the API provides a way to get the total count of doctors
            var totalCnt = await _apiClient.GettotalcountAsync(new CancellationTokenSource().Token);
            TotalPages = (int)Math.Ceiling(Convert.ToDouble(totalCnt.Result) / (double)10);
        }

        public async Task<IActionResult> OnPostCreateDoctorAsync(DoctorCommand doctor)
        {
         //   doctor = this.Doctor;
            var response = await _apiClient.CreatedoctorAsync(doctor, new CancellationTokenSource().Token);
            if (response != null) // Assuming Success indicates success
            {
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateDoctorAsync(DoctorCommand doctor)
        {
            doctor.Password = "test";
            var response = await _apiClient.UpdaterdoctorAsync(doctor, new CancellationTokenSource().Token);
            if (response != null) // Assuming Success indicates success
            {
                return RedirectToPage();
            }
            return Page();
        }

        //public async Task<IActionResult> OnPostDeleteDoctorAsync(int id)
        //{
        //    var response = await _apiClient.DeletedoctorAsync(id, new CancellationTokenSource().Token); // Assuming DeletedoctorAsync is the correct method name
        //    if (response != null && response.Success) // Assuming Success indicates success
        //    {
        //        return RedirectToPage();
        //    }
        //    return Page();
        //}
    }
}
