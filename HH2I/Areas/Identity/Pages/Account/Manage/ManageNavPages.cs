namespace House2Invest.Areas.Identity.Pages.Account.Manage
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.IO;

    public static class ManageNavPages
    {
        public static string ChangePasswordNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, ChangePassword);
        }

        public static string DeletePersonalDataNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, DeletePersonalData);
        }

        public static string DownloadPersonalDataNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, DownloadPersonalData);
        }

        public static string ExternalLoginsNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, ExternalLogins);
        }

        public static string IndexNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, Index);
        }

        public static string MeusDocumentosNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, MeusDocumentos);
        }

        public static string PageNavClass(ViewContext viewContext, string page)
        {
           return (string.Equals((viewContext.ViewData["ActivePage"] as string) ?? Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName), page, (StringComparison) StringComparison.OrdinalIgnoreCase) ? "btn-primary" : "btn-dark");
        }

        public static string PersonalDataNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, PersonalData);
        }

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, TwoFactorAuthentication);
        }

        public static string Index
        {
            get
            {
                return "Index";
            }
        }

        public static string ChangePassword
        {
            get
            {
                return "ChangePassword";
            }
        }

        public static string DownloadPersonalData
        {
            get
            {
                return "DownloadPersonalData";
            }
        }

        public static string DeletePersonalData
        {
            get
            {
                return "DeletePersonalData";
            }
        }

        public static string ExternalLogins
        {
            get
            {
                return "ExternalLogins";
            }
        }

        public static string PersonalData
        {
            get
            {
                return "PersonalData";
            }
        }

        public static string TwoFactorAuthentication
        {
            get
            {
                return "TwoFactorAuthentication";
            }
        }

        public static string MeusDocumentos
        {
            get
            {
                return "PerfilMeusDocumentos";
            }
        }
    }
}

