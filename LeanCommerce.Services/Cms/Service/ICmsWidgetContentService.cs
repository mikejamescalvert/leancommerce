using LeanCommerce.Services.Cms.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Cms.Service
{
    public interface ICmsWidgetContentService
    {
        IMongoCollection<CmsWidgetContent> CmsWidgetContents { get; }
        CmsWidgetContent GetCmsWidgetContentById(ObjectId CmsWidgetContentId);
        Task SaveCmsWidgetContent(CmsWidgetContent CmsWidgetContent);
        Task DeleteCmsWidgetContent(ObjectId CmsWidgetContentId);
    }
}
