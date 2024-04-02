using System.Security.Claims;

namespace WebApi.Extensions;

public static class ClaimExtensions
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        
        // the line of code is attempting to get the given name (most likely the first name) of the user, as specified in the claims.
        return user.Claims
            .SingleOrDefault(x => 
                x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
        
    }
}