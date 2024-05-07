using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketWEB.Pages.Products
{
	public class CreateModel : PageModel
	{
		private readonly SupermarketContext _context;

		public CreateModel(SupermarketContext context)
		{
			_context = context;
		}

		public List<SelectListItem> Categories { get; set; }

		public void OnGet()
		{
			Categories = _context.Categories
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = c.Name
				}).ToList();
		}

		[BindProperty]
		public Product Product { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				// Si hay errores de validaci�n, establece la lista desplegable de categor�as y vuelve a la p�gina
				ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
				return Page();
			}

			// Comprueba que se han rellenado todos los campos necesarios
			if (string.IsNullOrEmpty(Product.Name) || Product.Price <= 0 || Product.Stock < 0 || Product.CategoryId <= 0)
			{
				ModelState.AddModelError("", "Please fill in all required fields.");
				ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
				return Page();
			}

			// Recupera la categor�a seleccionada
			var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == Product.CategoryId);

			if (category == null)
			{
				// Si la categor�a no existe, establece la lista desplegable de categor�as y muestra un mensaje de error
				ModelState.AddModelError("", "Invalid category selected.");
				ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
				return Page();
			}

			// A�ade el nuevo producto a la base de datos y guarda los cambios
			_context.Products.Add(Product);
			await _context.SaveChangesAsync();

			// Establece la lista desplegable de categor�as y vuelve a la p�gina Index
			ViewData["Categories"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
			return RedirectToPage("./Index");
		}

	}
}