using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;

namespace ComfortHealthCare.Presentation.Pages
{
    public class PatientHistoryModel : PageModel
    {
        public void OnGetAsync(string pid)
        {
			ViewData["pid"] =pid;

        }
    }
}
