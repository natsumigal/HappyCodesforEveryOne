using ApiClient.ComfortHealthApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComfortHealthCare.Presentation.Pages
{
    public class DoctorModel : PageModel
    {
        [BindProperty]
        public DoctorCommand Doctor { get; set; } = default!;
        public IList<DoctorCommand> Doctors { get; set; } = default!;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ApiClient.ComfortHealthApiClient.ApiClient apiCall = new ApiClient.ComfortHealthApiClient.ApiClient("", new HttpClient());
            var jsonString = await apiCall.CreatedoctorAsync(Doctor, (new CancellationTokenSource()).Token);
            return Page();
        }
    }
}
