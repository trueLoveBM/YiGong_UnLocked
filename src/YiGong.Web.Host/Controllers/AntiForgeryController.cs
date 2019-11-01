using Microsoft.AspNetCore.Antiforgery;
using YiGong.Controllers;

namespace YiGong.Web.Host.Controllers
{
    public class AntiForgeryController : YiGongControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
