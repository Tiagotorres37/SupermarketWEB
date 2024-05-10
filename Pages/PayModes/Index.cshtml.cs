using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
	public class IndexModel : PageModel
	{
		private readonly SupermarketContext _context;

		public IndexModel(SupermarketContext context)
		{
			_context = context;
		}

		public IList<payMode> PayModes { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.payMode != null)
			{
				PayModes = await _context.payMode.ToListAsync();
			}
		}
	}
}