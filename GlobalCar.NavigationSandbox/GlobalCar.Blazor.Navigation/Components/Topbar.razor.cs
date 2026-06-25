using Microsoft.AspNetCore.Components;

namespace GlobalCar.Blazor.Navigation.Components;

public partial class Topbar
{
    [Parameter] public string ModuleTitle { get; set; } = string.Empty;
    [Parameter] public string ModuleDescription { get; set; } = string.Empty;
    [Parameter] public string BranchName { get; set; } = string.Empty;
    [Parameter] public string EnvironmentName { get; set; } = string.Empty;
    [Parameter] public string UserName { get; set; } = string.Empty;
    [Parameter] public string UserRole { get; set; } = string.Empty;

    protected string EnvironmentBadgeClass => EnvironmentName.ToLowerInvariant() switch
    {
        "producción" or "produccion" or "production" => "badge bg-danger",
        "desarrollo" or "development" or "dev"       => "badge bg-success",
        "pruebas" or "qa" or "testing"               => "badge bg-warning text-dark",
        _                                            => "badge bg-secondary"
    };
}
