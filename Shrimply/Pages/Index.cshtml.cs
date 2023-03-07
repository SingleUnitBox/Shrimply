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
        private readonly ITagRepository _tagRepository;

        public List<Shrimp> Shrimps { get; set; }
        public List<Tag> Tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IShrimpRepository shrimpRepository,
            ITagRepository tagRepository)
        {
            _logger = logger;
            _shrimpRepository = shrimpRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Shrimps = (await _shrimpRepository.GetAllAsync()).ToList();
            Tags = (await _tagRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}