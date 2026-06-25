using GlobalCar.Blazor.Navigation.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace NavigationSandbox.Web.Layout;

public partial class MainLayout : LayoutComponentBase, IDisposable
{
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    protected bool IsSidebarCollapsed { get; private set; }
    protected string CurrentUrl { get; private set; } = string.Empty;

    protected string ModuleTitle { get; } = "Dashboard";
    protected string ModuleDescription { get; } = "Bienvenido al sandbox de navegación de Global Car — Niux 2.0";
    protected string BranchName { get; } = "Almacén FSP";
    protected string EnvironmentName { get; } = "Producción";
    protected string UserName { get; } = "Julio García";
    protected string UserRole { get; } = "Administrador";
    protected string AppVersion { get; } = "v1.0.0";

    protected List<SidebarMenuItem> MenuItems { get; } =
    [
        new()
        {
            Text = "Operación", Icon = "bi bi-truck", Order = 1,
            Children =
            [
                new() { Text = "Órdenes",  Href = "/ordenes",  Icon = "bi bi-file-earmark-text", Order = 1 },
                new() { Text = "Facturas", Href = "/facturas", Icon = "bi bi-receipt",            Order = 2 },
                new() { Text = "Clientes", Href = "/clientes", Icon = "bi bi-people",             Order = 3 },
            ]
        },
        new()
        {
            Text = "Compras", Icon = "bi bi-cart3", Order = 2,
            Children =
            [
                new() { Text = "Módulo de Compras", Href = "/purchase-report-demo", Icon = "bi bi-bag-check",  Order = 1 },
                new() { Text = "Proveedores",        Href = "/proveedores",          Icon = "bi bi-building",   Order = 2 },
                new() { Text = "Lista de empaques",  Href = "/empaques",             Icon = "bi bi-box-seam",   Order = 3 },
            ]
        },
        new()
        {
            Text = "Almacén", Icon = "bi bi-archive", Order = 3,
            Children =
            [
                new() { Text = "Inventario",        Href = "/inventory-demo", Icon = "bi bi-clipboard-data",    Order = 1 },
                new() { Text = "Consumos almacén",  Href = "/consumos",       Icon = "bi bi-arrow-down-circle", Order = 2 },
            ]
        },
        new()
        {
            Text = "Reportes", Icon = "bi bi-bar-chart-line", Order = 4,
            Children =
            [
                new() { Text = "Reportes estratégicos", Href = "/reportes",  Icon = "bi bi-graph-up",      Order = 1 },
                new() { Text = "Métricas inventario",   Href = "/metricas",  Icon = "bi bi-speedometer2",  Order = 2 },
            ]
        },
        new()
        {
            Text = "Configuración", Icon = "bi bi-gear", Order = 5,
            Children =
            [
                new() { Text = "Parámetros", Href = "/settings-demo", Icon = "bi bi-sliders",     Order = 1 },
                new() { Text = "Usuarios",   Href = "/usuarios",      Icon = "bi bi-person-gear", Order = 2 },
            ]
        },
        new() { Text = "Salida", Href = "/", Icon = "bi bi-box-arrow-right", Order = 99 },
    ];

    protected override void OnInitialized()
    {
        CurrentUrl = Navigation.Uri;
        Navigation.LocationChanged += OnLocationChanged;
    }

    private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        CurrentUrl = e.Location;
        StateHasChanged();
    }

    protected void ToggleSidebar() => IsSidebarCollapsed = !IsSidebarCollapsed;

    public void Dispose() => Navigation.LocationChanged -= OnLocationChanged;
}
