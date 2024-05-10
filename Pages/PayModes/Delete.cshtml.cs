using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
	public class DeleteModel : PageModel
	{
		private readonly SupermarketContext _context;

		public DeleteModel(SupermarketContext context)
		{
			_context = context;
		}
		[BindProperty]

		public payMode PayMode { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.payMode == null)
			{
				return NotFound();
			}

			var payMode = await _context.payMode.FirstOrDefaultAsync(m => m.id == id);

			if (payMode == null)
			{
				return NotFound();
			}
			else
			{
				PayMode = payMode;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.payMode == null)
			{
				return NotFound();
			}
			var payModes = await _context.payMode.FindAsync(id);

			if (payModes != null)
			{
				PayMode = payModes;
				_context.payMode.Remove(PayMode);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}