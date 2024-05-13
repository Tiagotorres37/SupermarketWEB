using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SupermarketWEB.Pages.Users
{
    [Authorize]
    public class UsersModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
