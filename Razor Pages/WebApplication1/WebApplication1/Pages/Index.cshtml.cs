using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public string Promt { get; set; } = "Hello";
        public int Age { get; set; } = 22;
        public void OnGet()
        {

        }
    }
}
