﻿using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Members.Factories;

/// <inheritdoc/>
public class MemberFactory<TMember> : IMemberFactory<TMember>
    where TMember : IMember
{
    /// <summary>
    /// A factory for creating object with DI
    /// </summary>
    protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

    /// <summary>
    /// A published snapshot
    /// </summary>
    protected readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;

    /// <summary>
    /// The logger
    /// </summary>
    protected readonly ILogger<MemberFactory<TMember>> logger;

    /// <inheritdoc/>
    public MemberFactory(IDependencyReflectorFactory dependencyReflectorFactory, IPublishedSnapshotAccessor publishedSnapshotAccessor, ILogger<MemberFactory<TMember>> logger)
    {
        this.dependencyReflectorFactory = dependencyReflectorFactory;
        this.publishedSnapshotAccessor = publishedSnapshotAccessor;
        this.logger = logger;
    }

    /// <inheritdoc/>
    public virtual TMember? CreateMember(Umbraco.Cms.Core.Models.IMember member)
    {
        if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
        {
            if (publishedSnapshot is null)
            {
                logger.LogError("Unable to get publishedSnapShot");
                return default;
            }
            var publishedMember = publishedSnapshot.Members?.Get(member);

            var createElementCommand = new CreateElement(publishedMember, null, null, null);
            var createMemberCommand = new CreateMember(createElementCommand);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IMember>(typeof(TMember), new object[] { createMemberCommand });
            return createdContent == null ? default : (TMember) createdContent;
        }
        logger.LogError("Unable to get publishedSnapShot");
        return default;
    }
}
