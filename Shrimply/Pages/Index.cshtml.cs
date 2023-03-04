using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.Domain;
using Shrimply.Repositories;

namespace Shrimply.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IShrimpRepository _shrimpRepository;
        public List<Shrimp> Shrimps { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IShrimpRepository shrimpRepository)
        {
            _logger = logger;
            _shrimpRepository = shrimpRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Shrimps = (await _shrimpRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}