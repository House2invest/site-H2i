namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using House2Invest.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    public class EnableAuthenticatorModel : PageModel
    {
        private readonly UserManager<UsuarioApp> _userManager;
        private readonly ILogger<EnableAuthenticatorModel> _logger;
        private readonly UrlEncoder _urlEncoder;
        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        public EnableAuthenticatorModel(UserManager<UsuarioApp> userManager, ILogger<EnableAuthenticatorModel> logger, UrlEncoder urlEncoder)
        {
            this._userManager = userManager;
            this._logger = logger;
            this._urlEncoder = urlEncoder;
        }

        private string FormatKey(string unformattedKey)
        {
            StringBuilder builder = new StringBuilder();
            int startIndex = 0;
            while ((startIndex + 4) < unformattedKey.Length)
            {
                builder.Append(unformattedKey.Substring(startIndex, 4)).Append(" ");
                startIndex += 4;
            }
            if (startIndex < unformattedKey.Length)
            {
                builder.Append(unformattedKey.Substring(startIndex));
            }
            return builder.ToString().ToLowerInvariant();
        }

        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format("otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6", this._urlEncoder.Encode("House2Invest"), this._urlEncoder.Encode(email), unformattedKey);
        }
    }
}

