using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.Domain;
using Shrimply.Repositories;

namespace Shrimply.Pages.Shrimps
{
    public class DetailsModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;
        public Shrimp Shrimp { get; set; }
        public DetailsModel(IShrimpRepository shrimpRepository)
        {
            _shrimpRepository = shrimpRepository;
        }
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            Shrimp = await _shrimpRepository.GetAsync(urlHandle);
            return Page();
        }
    }
}
