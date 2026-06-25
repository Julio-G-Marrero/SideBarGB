namespace GlobalCar.Blazor.Navigation.Models;

public class SidebarMenuItem
{
    public string Text { get; set; } = string.Empty;
    public string? Href { get; set; }
    public string Icon { get; set; } = string.Empty;
    public int Order { get; set; }
    public List<SidebarMenuItem> Children { get; set; } = [];
}
