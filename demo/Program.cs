using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var collection = new ServiceCollection();
var registrar = new ServiceCollectionRegistrar(collection);
collection.AddTransient<CoolResultReturner>();
var app = new CommandApp<ResultCodeCommand>(registrar);
return app.Run(args);


internal class CoolResultReturner
{
    public int Return(int input)
    {
        Console.WriteLine($"Demo returning result code: {input}");
        return input;
    }
}

internal sealed class ResultCodeCommand : Command<ResultCodeCommand.Settings>
{
    private readonly CoolResultReturner _returner;

    public ResultCodeCommand(CoolResultReturner returner)
    {
        _returner = returner;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("Set the result code. Defaults to 0.")]
        [CommandOption("-r|--result")]
        public int ResultCode { get; init; } = 0;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        return _returner.Return(settings.ResultCode);
    }
}
