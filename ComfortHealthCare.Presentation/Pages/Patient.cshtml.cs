using ApiClient.ComfortHealthApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComfortHealthCare.Presentation.Pages
{
    public class PatientModel : PageModel
    {
        [BindProperty]
        public PatientCommand Patient { get; set; } = default!;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ApiClient.ComfortHealthApiClient.ApiClient apiCall = new ApiClient.ComfortHealthApiClient.ApiClient("", new HttpClient());
            var jsonString = await apiCall.CreatepatientAsync(Patient, (new CancellationTokenSource()).Token);
            return Page();
        }
    }

}
