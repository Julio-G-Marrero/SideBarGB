using GlobalCar.Blazor.Navigation.Models;
using Microsoft.AspNetCore.Components;

namespace GlobalCar.Blazor.Navigation.Components;

public partial class Sidebar
{
    [Parameter] public List<SidebarMenuItem> MenuItems { get; set; } = [];
    [Parameter] public bool IsCollapsed { get; set; }
    [Parameter] public EventCallback OnToggle { get; set; }
    [Parameter] public string CurrentUrl { get; set; } = string.Empty;
    [Parameter] public string AppVersion { get; set; } = "v1.0.0";

    protected string HeaderClass => IsCollapsed ? "d-none" : "";
    protected string ToggleIcon => IsCollapsed ? "bi bi-layout-sidebar-reverse" : "bi bi-layout-sidebar";
    protected string HeaderContainerClass => IsCollapsed
        ? "d-flex align-items-center justify-content-center p-3 border-bottom border-primary"
        : "d-flex align-items-center gap-2 p-3 border-bottom border-primary";
    protected string FooterTextClass => IsCollapsed ? "d-none" : "d-flex flex-column";
    protected string FooterIconClass => IsCollapsed ? "d-flex justify-content-center" : "d-none";
    protected IEnumerable<SidebarMenuItem> SortedItems => MenuItems.OrderBy(x => x.Order);
}
