using LeanCommerce.Services.Cms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanCommerce.Services.Cms.Service;

namespace LeanCommerce.ViewModels.Admin
{
    public class CmsPageViewModel
    {
        IMungeUrlService _mungeUrlService;
        public CmsPageViewModel(IMungeUrlService mungeUrlService)
        {

        }
        public CmsPageViewModel(CmsPage content)
        {
            ObjectId = content.Id.ToString();
            PageContents = content.PageContents;
            PageName = content.PageName;
            UrlName = content.UrlName;
        }
        private string _PageName;
        public string PageName {
            get
            {
                return _PageName;
            }
            set
            {
                _PageName = value;
            }
        }
        public string UrlName { get; set; }
        public string PageContents { get; set; }
        public string ObjectId { get; set; }
    }
}
