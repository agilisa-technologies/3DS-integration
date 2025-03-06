using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using ThreeDS.Models;

namespace ThreeDS.Pages
{
    [IgnoreAntiforgeryToken]
    public class ThreeDSHandlerModel : PageModel
    {
        [BindProperty]
        public required string AuthResponse { get; set; }

        [BindProperty]
        public required ThreeDSResponse ThreeDSResponse { get; set; }

        [BindProperty(Name = "successUrl")]
        public required string TargetUrl { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(AuthResponse))
            {
                ModelState.AddModelError(string.Empty, "AuthResponse cannot be empty.");
                return Page();
            }

            try
            {
                ThreeDSResponse = JsonSerializer.Deserialize<ThreeDSResponse>(AuthResponse)
                                  ?? throw new JsonException("Invalid JSON format.");
            }
            catch (JsonException)
            {
                ModelState.AddModelError(string.Empty, "Invalid JSON format.");
                return Page();
            }

            return Page();
        }
    }
}
