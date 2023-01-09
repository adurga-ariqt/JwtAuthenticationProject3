using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationProject3
{
    public class TokenAuthenticateOrNot
    {
        public void Mymethod()
        {

            
            Console.WriteLine("Enter issuer token:");
            string jwt = Console.ReadLine();
            string secretKey = "the secret key for  Durga Authentication";
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            // Set up the JWT handler
            var handler = new JwtSecurityTokenHandler();
            var validationparams = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            JwtSecurityToken token = handler.ReadJwtToken(jwt);

            DateTime exp = token.ValidTo;
            if (exp > DateTime.Now.AddMinutes(10))
            {
                Console.WriteLine("JWT has expired");
            }
            else
            {
                Console.WriteLine("JWT is valid");
            }

            // Validate the JWT and process the result
            ClaimsPrincipal claimsPrincipal = handler.ValidateToken(jwt, validationparams, out SecurityToken validatedToken);
            if (validatedToken != null)
            {
                Console.WriteLine("JWT signature is valid");
            }
            else
            {
                Console.WriteLine("JWT signature is invalid");
            }


            
        }
    }
}
       
    

