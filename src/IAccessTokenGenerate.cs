using System.Collections.Generic;
using System.Security.Claims;

namespace Zop.AspNetCore.Authentication.JwtBearer
{
    public interface IAccessTokenGenerate 
    {
        /// <summary>
        /// 生成授权访问Tokan
        /// </summary>
        /// <param name="claims">Token 声明</param>
        /// <returns></returns>
        AccessToken Generate(Dictionary<string,string> claims);

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        AccessToken Generate(IEnumerable<Claim> claims);
    }
}
