﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using LeanCommerce.Abstract.Controllers;
using Microsoft.AspNet.Authorization;
using LeanCommerce.ViewModels.Admin;
using LeanCommerce.Services.Catalog.Model;
using System.Collections;
using LeanCommerce.Services.Cms.Model;
using LeanCommerce.Services.Site.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeanCommerce.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : AbstractSetupRequiredController
    {
        Services.Catalog.Service.ICategoryService _categoryService;
        Services.Site.Service.ISiteSettingsService _siteSettingsService;
        Services.Catalog.Service.IProductService _productService;
        Services.Cms.Service.ICmsPageService _cmsPageService;
        Services.Cms.Service.ICmsWidgetContentService _cmsWidgetContentService;
        Services.Cms.Service.IMungeUrlService _mungeUrlService;
        public AdminController(Services.MongoSettings.Service.IMongoSettingsService mongoService,
                    Services.Site.Service.ISiteSettingsService siteSettingsService,
                    Services.Catalog.Service.ICategoryService categoryService,
                    Services.Catalog.Service.IProductService productService,
                    Services.Cms.Service.ICmsWidgetContentService cmsWidgetContentService,
                    Services.Cms.Service.ICmsPageService cmsPageService,
                    Services.Cms.Service.IMungeUrlService mungeUrlService) : base(mongoService)
        {
            _siteSettingsService = siteSettingsService;
            _categoryService = categoryService;
            _productService = productService;
            _cmsWidgetContentService = cmsWidgetContentService;
            _cmsPageService = cmsPageService;
            _mungeUrlService = mungeUrlService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/SiteSettings
        public IActionResult SiteSettings()
        {
            return View(new SiteSettingsViewModel(_siteSettingsService.CurrentSiteSettings));
        }

        // POST: /<controller>/SiteSettings
        [HttpPost]
        public IActionResult SiteSettings(SiteSettingsViewModel model)
        {
            try
            {
                model.CopyToSiteSettings(_siteSettingsService.CurrentSiteSettings);
                _siteSettingsService.InsertUpdateSite(_siteSettingsService.CurrentSiteSettings);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "There was an error updating the site information: " + ex.Message);
            }
            return View();
        }

        public IActionResult CategorySetup()
        {
            
            return View(_categoryService.Categories);
        }
        public IActionResult EditCategory(string objectId)
        {
            Category result = null;
            //load category if available
            if (string.IsNullOrEmpty(objectId) == false)
            {
                result = _categoryService.GetCategoryById(new MongoDB.Bson.ObjectId(objectId));
            }


            CategoryViewModel viewModel;
            
            if (result != null)
            {
                viewModel = new CategoryViewModel()
                {
                    Active = result.Active,
                    Name = result.Name,
                    ObjectId = result.Id.ToString()
                };
            }
            else
            {
                viewModel = new CategoryViewModel();
            }
            
            
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category result = null;
                //load category if available
                if (string.IsNullOrEmpty(model.ObjectId) == false)
                {
                    result = _categoryService.GetCategoryById(new MongoDB.Bson.ObjectId(model.ObjectId));
                }

                if (result == null)
                    result = new Category();

                result.Name = model.Name;
                result.Active = model.Active;

                await _categoryService.SaveCategory(result);

                return RedirectToAction("CategorySetup");
            }
            return View();
        }


        public IActionResult CmsPages()
        {

            return View(_cmsPageService.CmsPages);
        }
        public IActionResult EditCmsPage(string objectId)
        {
            CmsPage result = null;
            //load category if available
            if (string.IsNullOrEmpty(objectId) == false)
            {
                result = _cmsPageService.GetCmsPageById(new MongoDB.Bson.ObjectId(objectId));
            }

            return View(new CmsPageViewModel(result));
        }
        [HttpPost]
        public async Task<IActionResult> EditCmsPage(CmsPageViewModel model)
        {
            if (ModelState.IsValid)
            {
                CmsPage result = null;
                //load category if available
                if (string.IsNullOrEmpty(model.ObjectId) == false)
                {
                    result = _cmsPageService.GetCmsPageById(new MongoDB.Bson.ObjectId(model.ObjectId));
                }

                if (result == null)
                    result = new CmsPage();

                result.PageContents = model.PageContents;
                result.PageName = model.PageName;
                result.UrlName = model.UrlName;
                if (string.IsNullOrEmpty(result.UrlName))
                    result.UrlName = result.PageName;
                result.UrlName = _mungeUrlService.MungeUrl(result.UrlName);

                await _cmsPageService.SaveCmsPage(result);

                return RedirectToAction("CmsPages");
            }
            return View();
        }
    }
}
