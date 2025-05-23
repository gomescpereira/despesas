namespace Fina.Core;

public static class Configuration
{
    public const int DefaultStatusCode = 200;
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    
    public static string BackendUrl { get; set; } = "http://localhost:5250";
    public static string FrontendUrl { get; set; } = "http://localhost:5200";
    public static string FrontendReact { get; set; } = "http://localhost:5173";
    public static string FrontendLocal { get; set; } = "http://192.168.0.191:5173";
}
