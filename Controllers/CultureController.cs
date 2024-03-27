/*using Microsoft.AspNetCore.Components;*/
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging.Console;
using System.Globalization;
using System.Net;


namespace DemoLocalizationBlazorServer6.Controllers;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        Console.WriteLine("Controller");
        if (culture != null)
        {
            var requestCulture = new RequestCulture(culture, culture);
            var cookieName = CookieRequestCultureProvider.DefaultCookieName;
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);

            HttpContext.Response.Cookies.Append(cookieName, cookieValue);
            // Console.WriteLine(cookieValue);
        }

        return LocalRedirect(redirectUri);
    }
}
