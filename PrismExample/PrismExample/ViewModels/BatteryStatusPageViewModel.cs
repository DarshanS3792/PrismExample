using Prism.Commands;
using Prism.Services;
using PrismExample.DependencyServices;
using System.Windows.Input;

namespace PrismExample.ViewModels
{
    public class BatteryStatusPageViewModel
    {
        IPageDialogService _pageDialogService;
        IBatteryService _batteryService;

        public ICommand GetBatteryStatusCommand { get; set; }

        public BatteryStatusPageViewModel(IPageDialogService pageDialogService, IBatteryService batteryService)
        {
            _pageDialogService = pageDialogService;
            _batteryService = batteryService;

            GetBatteryStatusCommand = new DelegateCommand(GetBatteryStatus);
        }

        async void GetBatteryStatus()
        {
            var batteryStatus = _batteryService.GetBatteryStatus();
            await _pageDialogService.DisplayAlertAsync("Battery Status", batteryStatus, "Ok");
        }
    }
}
