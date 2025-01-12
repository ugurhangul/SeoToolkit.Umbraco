﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Html;
using SeoToolkit.Umbraco.MetaFields.Core.Common.SeoFieldEditEditors;
using SeoToolkit.Umbraco.MetaFields.Core.Common.SeoFieldEditors;
using SeoToolkit.Umbraco.MetaFields.Core.Constants;
using SeoToolkit.Umbraco.MetaFields.Core.Interfaces.SeoField;
using SeoToolkit.Umbraco.MetaFields.Core.Models.SeoFieldEditors;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace SeoToolkit.Umbraco.MetaFields.Core.Models.SeoField
{
    [Weight(500)]
    public class OpenGraphImageField : SeoField<IPublishedContent>
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        public override string Title => "Open Graph Image";
        public override string Alias => SeoFieldAliasConstants.OpenGraphImage;
        public override string Description => "Image for Open Graph";
        public override string GroupAlias => SeoFieldGroupConstants.OpenGraphGroup;
      

        public override ISeoFieldEditor Editor => new SeoFieldFieldsEditor(new[] { "Umbraco.MediaPicker", "Umbraco.MediaPicker3" });
        public override ISeoFieldEditEditor EditEditor => new SeoImageEditEditor(_umbracoContextFactory);

        public OpenGraphImageField(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
       
        
        }
     

        protected override HtmlString Render(IPublishedContent value)
        {
            string url;
            string height = string.Empty;
            string width = string.Empty;
            string type = string.Empty;
            if (value is { } media)
            {
                url = media.Url(mode: UrlMode.Absolute);
                width =  media.Value<string>("umbracoWidth");
                height = media.Value<string>("umbracoHeight");
                type = media.Value<string>("umbracoExtension");
            }
            else
            {
                url = value?.ToString();
            }

            var html = $"<meta property=\"og:image\" content=\"{url}\"/>";
            if (!string.IsNullOrEmpty(width))
            {
                html += $"<meta property=\"og:image:width\" content=\"{width}\"/>";
            }
            if (!string.IsNullOrEmpty(height))
            {
                html += $"<meta property=\"og:image:height\" content=\"{height}\"/>";
            }
            if (!string.IsNullOrEmpty(type))
            {
                html += $"<meta property=\"og:image:type\" content=\"{type}\"/>";
            }
            

            return new HtmlString(html);
        }
    }
}