﻿using Umbraco.Cms.Core.Models.PublishedContent;
using uSeoToolkit.Umbraco.MetaFields.Core.Interfaces;
using uSeoToolkit.Umbraco.MetaFields.Core.Interfaces.Services;
using uSeoToolkit.Umbraco.MetaFields.Core.Models.SeoService;

namespace uSeoToolkit.Umbraco.MetaFields.Core.Services.SeoService
{
    public class SeoService : ISeoService
    {
        private readonly IMetaTagsProvider _metaTagsProvider;

        public SeoService(IMetaTagsProvider metaTagsProvider)
        {
            _metaTagsProvider = metaTagsProvider;
        }

        public MetaTagsModel Get(IPublishedContent content)
        {
            return _metaTagsProvider.Get(content);
        }
    }
}