using LeanCommerce.Services.Cms.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Cms.Service
{
    public interface ICmsPageService
    {
        IMongoCollection<CmsPage> CmsPages { get; }
        CmsPage GetCmsPageById(ObjectId CmsPageId);
        Task SaveCmsPage(CmsPage CmsPage);
        Task DeleteCmsPage(ObjectId CmsPageId);
    }
}
