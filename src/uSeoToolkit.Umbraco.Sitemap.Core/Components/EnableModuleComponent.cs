﻿using Umbraco.Cms.Core.Composing;
using uSeoToolkit.Umbraco.Core.Collections;

namespace uSeoToolkit.Umbraco.Sitemap.Core.Components
{
    internal class EnableModuleComponent : IComponent
    {
        private readonly ModuleCollection _collection;

        public EnableModuleComponent(ModuleCollection collection)
        {
            _collection = collection;
        }

        public void Initialize()
        {
            _collection.EnableModule("sitemap");
        }

        public void Terminate()
        {
        }
    }
}
