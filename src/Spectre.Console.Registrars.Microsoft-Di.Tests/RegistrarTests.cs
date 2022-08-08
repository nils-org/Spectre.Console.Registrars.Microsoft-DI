using System;

using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Spectre.Console.Testing;

using Xunit;

namespace Spectre.Console.Registrars.MicrosoftDi.Tests;

public class RegistrarTests
{
    [Fact]
    public void Should_Pass_Base_Tests()
    {
        var baseTests = new TypeRegistrarBaseTests(() =>
        {
            var container = new ServiceCollection();
            return new ServiceCollectionRegistrar(container);
        });

        baseTests.RunAllTests();
    }

    [Fact]
    public void Resolver_Should_Return_Registration_From_Container()
    {
        var fixture = new RegistrarFixture();
        fixture.GivenOnServiceCollection(c => c.AddScoped<ISomeInterface, SomeDependency>());

        var actual = fixture.GetResolver().Resolve(typeof(ISomeInterface));

        actual.ShouldNotBeNull();
        actual.ShouldBeOfType<SomeDependency>();
    }

    [Fact]
    public void Resolver_Should_Return_Registration_From_Registrar()
    {
        var fixture = new RegistrarFixture();
        fixture.GivenOnRegistrar(r => r.Register(typeof(ISomeInterface), typeof(SomeDependency)));

        var actual = fixture.GetResolver().Resolve(typeof(ISomeInterface));

        actual.ShouldNotBeNull();
        actual.ShouldBeOfType<SomeDependency>();
    }

    [Fact]
    public void Resolver_Should_Return_Instance_From_Registrar()
    {
        var fixture = new RegistrarFixture();
        var expected = new SomeDependency();
        fixture.GivenOnRegistrar(r => r.RegisterInstance(typeof(ISomeInterface), expected));

        var actual = fixture.GetResolver().Resolve(typeof(ISomeInterface));

        actual.ShouldNotBeNull();
        ReferenceEquals(expected, actual).ShouldBeTrue();
    }

    [Fact]
    public void Resolver_Should_Return_Lazy_From_Registrar()
    {
        var fixture = new RegistrarFixture();
        var expected = new SomeDependency();
        fixture.GivenOnRegistrar(r => r.RegisterLazy(typeof(ISomeInterface), () => expected));

        var actual = fixture.GetResolver().Resolve(typeof(ISomeInterface));

        actual.ShouldNotBeNull();
        ReferenceEquals(expected, actual).ShouldBeTrue();
    }

    [Fact]
        public void Resolver_Should_Throw_If_Lazy_Is_Null()
        {
            var fixture = new RegistrarFixture();
            fixture.GivenOnRegistrar(r => r.RegisterLazy(typeof(ISomeInterface), null!));

            var action = () => fixture.GetResolver();

            action.ShouldThrow<ArgumentNullException>();
        }

    [Fact]
    public void Resolver_Should_Not_Call_Lazy_Factory_If_Not_Needed()
    {
        var fixture = new RegistrarFixture();
        var factoryCalled = false;
        fixture.GivenOnRegistrar(r => r.RegisterLazy(typeof(ISomeInterface), () =>
        {
            factoryCalled = true;
            return new SomeDependency();
        }));

        fixture.GetResolver();

        factoryCalled.ShouldBeFalse();
    }

    private interface ISomeInterface
    {
    }

    private class SomeDependency : ISomeInterface
    {
    }
}
