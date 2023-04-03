using Microsoft.AspNetCore.Mvc;
using ProductsMarket.Service.Interfaces.Common;
using ProductsMarket.Service.ViewModels.StudentViewModels;

namespace ProductsMarket.Mvc.ViewComponents
{
    public class IdentityViewComponent : ViewComponent
    {
        private readonly IIdentityService _identityService;
        public IdentityViewComponent(IIdentityService identity)
        {
            this._identityService = identity;
        }
        public IViewComponentResult Invoke()
        {
            UserViewModel accountBaseViewModel = new UserViewModel()
            {
                Id = (int)_identityService.Id!.Value,
                PhoneNumber = _identityService.PhoneNumber,
                FullName = _identityService.FullName

            };
            return View(accountBaseViewModel);
        }
    }
}
