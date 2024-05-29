// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using TheCleanArch.Core;

namespace TheCleanArch.CoreTests;

[Trait("target", nameof(ArchLayerNames))]
public class ArchLayerNamesTest

{
    [Fact(DisplayName = "Nome \"Enterprise\" aponta para ArchLayerId.Enterprise")]
    public void NameEnterprisePointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.Enterprise, ArchLayerNames.Enterprise.Id);
        Assert.Equal("Enterprise", ArchLayerNames.Enterprise.Name);
    }

    [Fact(DisplayName = "Nome \"Domain\" aponta para ArchLayerId.Enterprise")]
    public void NameDomainPointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.Enterprise, ArchLayerNames.Domain.Id);
        Assert.Equal("Domain", ArchLayerNames.Domain.Name);
    }

    [Fact(DisplayName = "Nome \"Application\" aponta para ArchLayerId.Application")]
    public void NameApplicationPointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.Application, ArchLayerNames.Application.Id);
        Assert.Equal("Application", ArchLayerNames.Application.Name);
    }

    [Fact(DisplayName = "Nome \"UseCases\" aponta para ArchLayerId.Application")]
    public void NameUseCasesPointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.Application, ArchLayerNames.UseCases.Id);
        Assert.Equal("UseCases", ArchLayerNames.UseCases.Name);
    }

    [Fact(DisplayName = "Nome \"InterfaceAdapter\" aponta para ArchLayerId.InterfaceAdapter")]
    public void NameInterfaceAdapterPointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.InterfaceAdapter, ArchLayerNames.InterfaceAdapter.Id);
        Assert.Equal("InterfaceAdapter", ArchLayerNames.InterfaceAdapter.Name);
    }

    [Fact(DisplayName = "Nome \"Infrastructure\" aponta para ArchLayerId.InterfaceAdapter")]
    public void NameInfrastructurePointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.InterfaceAdapter, ArchLayerNames.Infrastructure.Id);
        Assert.Equal("Infrastructure", ArchLayerNames.Infrastructure.Name);
    }

    [Fact(DisplayName = "Nome \"External\" aponta para ArchLayerId.External")]
    public void NameExternalPointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.External, ArchLayerNames.External.Id);
        Assert.Equal("External", ArchLayerNames.External.Name);
    }

    [Fact(DisplayName = "Nome \"Drivers\" aponta para ArchLayerId.External")]
    public void NameDriversPointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.External, ArchLayerNames.Drivers.Id);
        Assert.Equal("Drivers", ArchLayerNames.Drivers.Name);
    }

    [Fact(DisplayName = "Nome \"Frameworks\" aponta para ArchLayerId.External")]
    public void NameFrameworksPointsToArchLayerIdEnterpriseEnum()
    {
        Assert.Equal(ArchLayerId.External, ArchLayerNames.Frameworks.Id);
        Assert.Equal("Frameworks", ArchLayerNames.Frameworks.Name);
    }
}