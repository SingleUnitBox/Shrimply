using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Data;
using Shrimply.Models.Domain;
using Shrimply.Repositories;

namespace Shrimply.Pages
{
    public class TagsModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;
        private readonly ITagRepository _tagRepository;

        public Tag Tag { get; set; }
        public List<Shrimp> Shrimps { get; set; }
        public TagsModel(IShrimpRepository shrimpRepository,
            ITagRepository tagRepository)
        {
            _shrimpRepository = shrimpRepository;
            _tagRepository = tagRepository;
        }
        public async Task<IActionResult> OnGet(string tagName)
        {
            Shrimps = (await _shrimpRepository.GetAllAsync(tagName)).ToList();
            Tag = await _tagRepository.GetAsync(tagName);
            return Page();
        }
    }
}
