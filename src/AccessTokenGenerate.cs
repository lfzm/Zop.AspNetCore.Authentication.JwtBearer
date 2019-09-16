using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Zop.AspNetCore.Authentication.JwtBearer
{
    public class AccessTokenGenerate : IAccessTokenGenerate
    {
        private readonly AccessTokenOptions _options;

        public AccessTokenGenerate(AccessTokenOptions options)
        {
            _options = options;
        }

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        public AccessToken Generate(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var expires = DateTime.UtcNow.AddMinutes(_options.Expires);
            var issuer = _options.Issuer;
            var audience = _options.Audience;
            var signingCredentials = _options.SigningCredentials;

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims.ToArray(),
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new AccessToken(encodedJwt, "Bearer", expires);
        }
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        public AccessToken Generate(Dictionary<string, string> claims)
        {
            List<Claim> claimList = new List<Claim>();
            foreach (var claim in claims)
            {
                claimList.Add(new Claim(claim.Key, claim.Value));
            }
            return this.Generate(claims);
        }


    }
}
