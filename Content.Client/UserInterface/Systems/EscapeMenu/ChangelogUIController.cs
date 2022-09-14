using Content.Client.Changelog;
using Content.Shared.Administration;
using JetBrains.Annotations;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controllers;
using Robust.Shared.Console;

namespace Content.Client.UserInterface.Systems.EscapeMenu;

[UsedImplicitly]
public sealed class ChangelogUIController : UIController
{
    private ChangelogWindow _changeLogWindow = default!;

    public void OpenWindow()
    {
        EnsureWindow();

        _changeLogWindow.OpenCentered();
        _changeLogWindow.MoveToFront();
    }

    private void EnsureWindow()
    {
        if (_changeLogWindow is { Disposed: false })
            return;

        _changeLogWindow = UIManager.CreateWindow<ChangelogWindow>();
    }

    public void ToggleWindow()
    {
        EnsureWindow();

        if (_changeLogWindow.IsOpen)
        {
            _changeLogWindow.Close();
        }
        else
        {
            OpenWindow();
        }
    }
}

[UsedImplicitly, AnyCommand]
public sealed class ChangelogCommand : IConsoleCommand
{
    public string Command => "changelog";
    public string Description => "Opens the changelog";
    public string Help => "Usage: changelog";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        IoCManager.Resolve<IUserInterfaceManager>().GetUIController<ChangelogUIController>().OpenWindow();
    }
}
