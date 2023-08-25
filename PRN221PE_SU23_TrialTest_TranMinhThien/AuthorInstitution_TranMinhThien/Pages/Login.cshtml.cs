using DataAccessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Repository.Repo;

namespace AuthorInstitution_TranMinhThien.Pages
{
    public class LoginModel : PageModel
    {
        IAuthorInstitutionRepo _authorInstitutionRepo = new AuthorInstitutionRepo();

        [BindProperty]
        public MemberAccount MemberAccount { get; set; } = default!;

        public IActionResult OnPostLogin()
        {
            MemberAccount? loginAccount = _authorInstitutionRepo.Login(MemberAccount.MemberId, MemberAccount.MemberPassword);
            if (loginAccount == null)
            {
                ViewData["notification"] = "Email or Password is wrong!";
                return Page();
            }
            else
            if (loginAccount.MemberRole == 1)
            {
                HttpContext.Session.SetString("User", loginAccount.MemberId);
                return RedirectToPage("./Manage/Index");
            }
            else
            {
                ViewData["notification"] = "You do not have permission to do this function!";
                return Page();
            }

        }
        public IActionResult OnPostLogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }

    }
}
