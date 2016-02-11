using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LeanCommerce.Services.Cms.Service
{
    public class MungeUrlService : IMungeUrlService
    {
        public MungeUrlService()
        {

        }
        public string MungeUrl(string originalName)
        {
            string newUrl = originalName;
            if (string.IsNullOrEmpty(newUrl) == false)
            {
                newUrl = newUrl.Trim();
                if (string.IsNullOrEmpty(newUrl) == false)
                {
                    newUrl = newUrl.Replace("+", " ").Replace("&", " ").Replace("  ", "-").Replace(" ", "-");
                }
            }
            
            
            return WebUtility.UrlEncode(newUrl);
        }
    }
}
