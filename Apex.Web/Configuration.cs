using MudBlazor;

namespace Apex.Web;

public static class Configuration
{
    public const string HttpClientName = "apex";

    public static string BackendUrl { get; set; } = "http://localhost:5222";
    
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Raleway", "sans-serif"]
            }
        },
        PaletteLight = new PaletteLight
        {
            Primary = "#40e5f5",
            Secondary = "#374151",
            Background = "#F3E8E8",
            AppbarBackground = "#40e5f5",
            AppbarText = Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            PrimaryContrastText = Colors.Shades.Black,
            DrawerText = Colors.Shades.White,
            DrawerBackground = "#3498db"
        },
        PaletteDark = new PaletteDark
        {
            Primary = "#40e5f5",
            Secondary = "#1F2937",
            AppbarBackground = "#40e5f5",
            AppbarText = Colors.Shades.Black,
        }
    };
}