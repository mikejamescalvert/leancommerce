using LeanCommerce.Services.Cms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewModels.Admin
{
    public class CmsWidgetContentViewModel
    {
        public CmsWidgetContentViewModel()
        {

        }
        public CmsWidgetContentViewModel(CmsWidgetContent content)
        {
            CodeName = content.CodeName;
            WidgetContents = content.WidgetContents;
            ObjectId = content.Id.ToString();
        }
        public string CodeName { get; set; }
        public string WidgetContents { get; set; }
        public string ObjectId { get; set; }
    }
}
