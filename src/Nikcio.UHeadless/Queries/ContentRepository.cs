﻿using AutoMapper;
using Nikcio.UHeadless.Dtos.Content;
using Nikcio.UHeadless.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Queries
{
    public class ContentRepository
    {
        private readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;
        private readonly IMapper mapper;
        private readonly IPropertyFactory propertyFactory;

        public ContentRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IMapper mapper, IUmbracoContextFactory umbracoContextFactory, IPropertyFactory propertyFactory)
        {
            umbracoContextFactory.EnsureUmbracoContext();
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
            this.mapper = mapper;
            this.propertyFactory = propertyFactory;
        }

        public IPublishedContentGraphType GetContent(Func<IPublishedContentCache, IPublishedContent> fetch, string culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var content = fetch(publishedSnapshot?.Content);
                if (culture == null || content != null && content.IsInvariantOrHasCulture(culture))
                {
                    return GetConvertedContent(content);
                }
            }

            return null;
        }

        public IEnumerable<IPublishedContentGraphType> GetContentList(Func<IPublishedContentCache, IEnumerable<IPublishedContent>> fetch)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var contentList = fetch(publishedSnapshot?.Content);
                if (contentList != null)
                {
                    return contentList.Select(content => GetConvertedContent(content));
                }
            }

            return new List<IPublishedContentGraphType>();
        }

        private IPublishedContentGraphType GetConvertedContent(IPublishedContent content)
        {
            var mappedObject = mapper.Map<PublishedContentGraphType>(content);
            AddProperties(mappedObject, content);
            return mappedObject;
        }

        private void AddProperties(PublishedContentGraphType mappedObject, IPublishedContent content)
        {
            var properties = content.Properties;
            foreach (var property in properties)
            {
                propertyFactory.AddProperty(mappedObject, property);
            }
        }
    }
}