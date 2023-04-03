using Microsoft.AspNetCore.Http;
using ProductsMarket.Service.Interfaces.Common;

namespace ProductsMarket.Service.Services.Common
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _accessor;
        public IdentityService(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }
        public long? Id
        {
            get
            {
                var res = _accessor.HttpContext!.User.FindFirst("Id");
                return res is not null ? long.Parse(res.Value) : null;
            }
        }
        public string FullName
        {
            get
            {
                var result = _accessor.HttpContext!.User.FindFirst("FullName");
                return (result is null) ? String.Empty : result.Value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                var res = _accessor.HttpContext!.User.FindFirst("PhoneNumber");
                return res is not null ? res.Value : string.Empty;
            }
        }
    }
}
