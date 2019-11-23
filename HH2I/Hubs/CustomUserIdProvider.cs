namespace House2Invest.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Security.Claims;

    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            ClaimsPrincipal principal1 = connection.get_User();
            if (principal1 == null)
            {
                ClaimsPrincipal local1 = principal1;
                return null;
            }
            Claim claim1 = principal1.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            if (claim1 != null)
            {
                return claim1.Value;
            }
            Claim local2 = claim1;
            return null;
        }
    }
}

