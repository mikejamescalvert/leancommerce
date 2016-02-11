using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Cms.Service
{
    public interface IMungeUrlService
    {
        string MungeUrl(string OriginalName);
    }
}
