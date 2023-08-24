using MudBlazor;
using NPOI.HPSF;

namespace B_B_App.Core.Managers
{
    public class ErrorManager
    {
        private readonly ISnackbar _snackbar;

        public ErrorManager(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public void InfoBar(string message, MudBlazor.Variant variant = MudBlazor.Variant.Text, Severity severity = Severity.Warning) 
        {
            _snackbar.Configuration.SnackbarVariant = variant;
            _snackbar.Configuration.MaxDisplayedSnackbars = 10;
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            _snackbar.Add(message, severity);
        }
    }
}
