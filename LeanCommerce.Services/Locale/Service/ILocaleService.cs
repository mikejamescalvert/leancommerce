using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Locale.Service
{
    interface ILocaleService
    {
        string GetLocaleOverride(string BaseString, string OverrideReference, string LocaleId);
        string GetNativeCurrency(decimal BaseValue, string CurrendyId);
    }
}
