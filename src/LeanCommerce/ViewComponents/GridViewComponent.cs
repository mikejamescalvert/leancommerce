using Microsoft.AspNet.Mvc;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(GridSettings settings, IEnumerable model)
        {
            
            GridViewModel viewModel = new GridViewModel()
            {
                Model = model,
                Settings = settings
            };
            return View(viewModel);
        }
        public class GridViewModel
        {
            public GridSettings Settings;
            public IEnumerable Model;
            
        }
        public class GridSettings
        {
            public List<GridColumnInfo> Columns = new List<GridColumnInfo>();
            public bool GenerateColumns = false;
            public bool AllowNew = true;
            public bool AllowDelete = true;
            public bool AllowEdit = true;
            public int PageSize = 20;
            public string EditViewName;

            public class GridColumnInfo
            {
                public string FieldName;
                public bool Sortable;
            }

        }
    }
}
