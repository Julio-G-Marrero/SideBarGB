using GlobalCar.Blazor.Navigation.Models;
using Microsoft.AspNetCore.Components;

namespace GlobalCar.Blazor.Navigation.Components;

public partial class SidebarItem
{
    [Parameter, EditorRequired] public SidebarMenuItem Item { get; set; } = default!;
    [Parameter] public bool IsCollapsed { get; set; }
    [Parameter] public string CurrentUrl { get; set; } = string.Empty;

    private bool isExpanded;

    protected bool HasChildren => Item.Children.Count > 0;
    protected IEnumerable<SidebarMenuItem> SortedChildren => Item.Children.OrderBy(x => x.Order);

    protected string TextClass => IsCollapsed ? "d-none" : "ms-2 small";

    protected string ChevronClass => IsCollapsed
        ? "d-none"
        : isExpanded
            ? "bi bi-chevron-up ms-auto small"
            : "bi bi-chevron-down ms-auto small";

    protected string GroupButtonClass =>
        "btn btn-dark nav-link text-white w-100 text-start d-flex align-items-center py-2 px-2 rounded border-0";

    protected string LinkClass
    {
        get
        {
            var isActive = IsActiveUrl(Item.Href);
            return isActive
                ? "nav-link text-white d-flex align-items-center py-2 px-2 rounded bg-primary"
                : "nav-link text-white-50 d-flex align-items-center py-2 px-2 rounded";
        }
    }

    protected string GetChildLinkClass(string? href)
    {
        var isActive = IsActiveUrl(href);
        return isActive
            ? "nav-link text-white d-flex align-items-center py-1 px-2 rounded bg-primary"
            : "nav-link text-white-50 d-flex align-items-center py-1 px-2 rounded";
    }

    private bool IsActiveUrl(string? href) =>
        !string.IsNullOrEmpty(href)
        && CurrentUrl.Contains(href, StringComparison.OrdinalIgnoreCase);

    protected void ToggleChildren() => isExpanded = !isExpanded;
}
