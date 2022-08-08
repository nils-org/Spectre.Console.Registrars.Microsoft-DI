using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using Spectre.Console.Cli;

namespace Spectre.Console.Registrars.MicrosoftDi.Tests;

internal class RegistrarFixture
{
    private readonly List<Action<ServiceCollection>> serviceCollectionActions = new List<Action<ServiceCollection>>();
    private readonly List<Action<ITypeRegistrar>> registrarActions = new List<Action<ITypeRegistrar>>();


    internal void GivenOnServiceCollection(Action<ServiceCollection> action)
    {
        serviceCollectionActions.Add(action);
    }

    internal void GivenOnRegistrar(Action<ITypeRegistrar> action)
    {
        registrarActions.Add(action);
    }

    internal ITypeResolver GetResolver()
    {
        var serviceCollection = new ServiceCollection();
        foreach (var action in serviceCollectionActions)
        {
            action(serviceCollection);
        }

        var registrar = new ServiceCollectionRegistrar(serviceCollection);
        foreach (var action in registrarActions)
        {
            action(registrar);
        }

        return registrar.Build();
    }
}
