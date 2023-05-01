using Artsofte.Service.Dtos.Accounts;
using Artsofte.Service.Interfaces.Accounts;
using Artsofte.Service.Interfaces.Languages;
using Microsoft.AspNetCore.Mvc;

namespace Artsofte.Mvc.Controllers
{
    [Route("employees")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILanguageService _languageService;
        private readonly string _rootPath;

        public AccountController(IAccountService accountService, ILanguageService languageService, IWebHostEnvironment webHostEnvironment)
        {
            this._rootPath = webHostEnvironment.WebRootPath;
            this._accountService = accountService;
            this._languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var teachers = await _accountService.GetAllAsync();
            return View("Index", teachers);
        }

        #region Update
        [HttpGet("edit")]
        public async Task<IActionResult> UpdateAccountAsync(int accountId)
        {
            ViewBag.Landuage = _languageService.GetLanguageAsync();
            var account = await _accountService.GetByIdAsync(accountId);
            var dto = new AccountUpdateDto()
            {
                Id = accountId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Age = account.Age,
                Department = account.Department,
                Language = account.Language,
            };

            return View("Update", dto);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(int accountId, AccountUpdateDto dto)
        {
            var res = await _accountService.UpdateAsync(accountId, dto);
            return RedirectToAction("index", "employees", new { area = "" });
        }
        #endregion

        #region AddAccount

        [HttpGet("add")]
        public ViewResult Register()
        {
            ViewBag.Landuage = _languageService.GetLanguageAsync();
            return View("Register");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(AccountCreateDto accountCreateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterAccountAsync(accountCreateDto);
                if (result)
                {
                    return RedirectToAction("index", "employees", new { area = "" });
                }
                else
                {
                    return Register();
                }
            }
            else return Register();
        }
        #endregion

        #region Delete
        [HttpGet("deleteId")]
        public async Task<IActionResult> DeleteAsync(int accountId)
        {
            var account = await _accountService.GetByIdAsync(accountId);
            var dto = new AccountViewDto()
            {
                Id = accountId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Age = account.Age,
                Department = account.Department,
                Language = account.Language,
            };

            return View("Delete", dto);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAccountAsync(int accountId)
        {
            var res = await _accountService.DeleteAsync(accountId);
            if (res) return RedirectToAction("index", "employees", new { area = "" });
            return View();
        }
        #endregion


    }
}
