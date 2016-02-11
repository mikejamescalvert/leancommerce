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
    public class CmsWidgetContentService : ICmsWidgetContentService
    {
        private Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        public CmsWidgetContentService(Services.MongoSettings.Service.IMongoSettingsService mongoService)
        {
            _mongoService = mongoService;
            _cmsWidgetContents = _mongoService.GetMongoCollection<CmsWidgetContent>("cmswidgetcontent");
        }
        private IMongoCollection<CmsWidgetContent> _cmsWidgetContents;
        public IMongoCollection<CmsWidgetContent> CmsWidgetContents {
            get
            {
                if (_cmsWidgetContents == null)
                    _cmsWidgetContents = _mongoService.GetMongoCollection<CmsWidgetContent>("cmswidgetcontent");
                return _cmsWidgetContents;
            }
        }
        public CmsWidgetContent GetCmsWidgetContentById(ObjectId cmsWidgetContentId)
        {
            return CmsWidgetContents.AsQueryable<CmsWidgetContent>().FirstOrDefault(x => x.Id == cmsWidgetContentId);
        }
        public async Task SaveCmsWidgetContent(CmsWidgetContent cmsWidgetContent)
        {
            CmsWidgetContent result = CmsWidgetContents.AsQueryable().FirstOrDefault<CmsWidgetContent>(x => x.Id == cmsWidgetContent.Id);
            if (result != null)
                await CmsWidgetContents.FindOneAndReplaceAsync(x => x.Id == cmsWidgetContent.Id, cmsWidgetContent);
            else
                await CmsWidgetContents.InsertOneAsync(cmsWidgetContent);
        }
        public async Task DeleteCmsWidgetContent(ObjectId cmsWidgetContentId)
        {
            await CmsWidgetContents.DeleteOneAsync(x => x.Id == cmsWidgetContentId);
        }
    }
}
