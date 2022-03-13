using Microsoft.AspNetCore.Components;

namespace Sirb.Template.WebApp.Shared;

public class NavMenuBase : ComponentBase
{
    private bool collapseNavMenu = true;

    protected string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    protected void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    protected string GetVersion() => typeof(NavMenuBase).Assembly.GetName().Version.ToString();

}
