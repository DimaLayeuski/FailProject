using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace NetTestFramework.Services;

public class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    public static IConfiguration Configuration => s_configuration.Value;
    public static string BaseUrl => Configuration[nameof(BaseUrl)];
    public static string Username => Configuration[nameof(Username)];
    public static string Password => Configuration[nameof(Password)];
    public static string BrowserType => Configuration[nameof(BrowserType)];
    public static string FileName => Configuration[nameof(FileName)];
    public static string InputText => Configuration[nameof(InputText)];
    public static string InputNewText => Configuration[nameof(InputNewText)];
    public static string CommitNewFile => Configuration[nameof(CommitNewFile)];
    public static string ConfirmToDelete => Configuration[nameof(ConfirmToDelete)];
    public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");
        var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }
}