using System;
using System.Collections.Generic;
using System.Text;
using LeanCommerce.Services.Cms.Model;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace LeanCommerce.Services.Cms.Service
{
    public class CmsPageService : ICmsPageService
    {
        private Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        public CmsPageService(Services.MongoSettings.Service.IMongoSettingsService mongoService)
        {
            _mongoService = mongoService;
            _cmsPages = _mongoService.GetMongoCollection<CmsPage>("cmspage");
        }
        private IMongoCollection<CmsPage> _cmsPages;
        public IMongoCollection<CmsPage> CmsPages
        {
            get
            {
                if (_cmsPages == null)
                    _cmsPages = _mongoService.GetMongoCollection<CmsPage>("cmspage");
                return _cmsPages;
            }
        }
        public CmsPage GetCmsPageById(ObjectId cmsPageId)
        {
            return CmsPages.AsQueryable<CmsPage>().FirstOrDefault(x => x.Id == cmsPageId);
        }
        public async Task SaveCmsPage(CmsPage cmsPage)
        {
            CmsPage result = CmsPages.AsQueryable().FirstOrDefault<CmsPage>(x => x.Id == cmsPage.Id);
            if (result != null)
                await CmsPages.FindOneAndReplaceAsync(x => x.Id == cmsPage.Id, cmsPage);
            else
                await CmsPages.InsertOneAsync(cmsPage);
        }
        public async Task DeleteCmsPage(ObjectId cmsPageId)
        {
            await CmsPages.DeleteOneAsync(x => x.Id == cmsPageId);
        }
    }
}
