using System.IO;
using Microsoft.Extensions.Configuration;

namespace HotelService.Test
{
    public class TestHelper
    {
           public static IConfigurationRoot GetIConfigurationRoot()
        {
            var outputPath = Path.GetDirectoryName(typeof(TestHelper).Assembly.Location);
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}