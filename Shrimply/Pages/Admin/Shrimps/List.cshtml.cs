using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shrimply.Models.Domain;
using Shrimply.Repositories;

namespace Shrimply.Pages.Admin.Shrimps
{
    public class ListModel : PageModel
    {
        private readonly IShrimpRepository _shrimpRepository;
        public List<Shrimp> Shrimps { get; set; }
        public ListModel(IShrimpRepository shrimpRepository)
        {
            _shrimpRepository = shrimpRepository;
        }
        public async Task OnGet()
        {
            Shrimps = (await _shrimpRepository.GetAllAsync()).ToList();
        }
    }
}
