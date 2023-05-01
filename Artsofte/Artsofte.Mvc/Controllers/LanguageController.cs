using Artsofte.Service.Dtos.Accounts;
using Artsofte.Service.Dtos.Languages;
using Artsofte.Service.Interfaces.Accounts;
using Artsofte.Service.Interfaces.Languages;
using Artsofte.Service.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace Artsofte.Mvc.Controllers
{
    [Route("languages")]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly string _rootPath;

        public LanguageController(ILanguageService languageService, IWebHostEnvironment webHostEnvironment)
        {
            this._rootPath = webHostEnvironment.WebRootPath;
            this._languageService = languageService;
        }


        public async Task<IActionResult> Index()
        {
            var language = await _languageService.GetAllAsync();
            return View("Index", language);
        }

        #region AddLanguage

        [HttpGet("add")]
        public ViewResult Register()
        {
            return View("Register");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(LanguageCreateDto languageCreateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _languageService.AddLanguageAsync(languageCreateDto);
                if (result)
                {
                    return RedirectToAction("index", "languages", new { area = "" });
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
        public async Task<IActionResult> DeleteAsync(int languageId)
        {
            var account = await _languageService.GetByIdAsync(languageId);
            var dto = new LanguageViewDto()
            {
                Id = languageId,
                Name = account.Name
            };

            return View("Delete", dto);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAccountAsync(int languageId)
        {
            var res = await _languageService.DeleteAsync(languageId);
            if (res) return RedirectToAction("index", "languages", new { area = "" });
            return View();
        }
        #endregion

        #region Update
        [HttpGet("edit")]
        public async Task<IActionResult> UpdateAccountAsync(int languageId)
        {
            var account = await _languageService.GetByIdAsync(languageId);
            var dto = new LanguageUpdateDto()
            {
                Id = languageId,
                Name = account.Name,
            };

            return View("Update", dto);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(int languageId, LanguageUpdateDto dto)
        {
            var res = await _languageService.UpdateAsync(languageId, dto);
            return RedirectToAction("index", "languages", new { area = "" });
        }
        #endregion

    }
}
