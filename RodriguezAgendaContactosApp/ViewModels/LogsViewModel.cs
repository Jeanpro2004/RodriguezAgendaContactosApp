using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RodriguezAgendaContactosApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RodriguezAgendaContactosApp.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string contenidoLogs;

        public LogsViewModel()
        {
            CargarLogs();
        }

        private async void CargarLogs()
        {
            contenidoLogs = await LogService.ReadLogsAsync();
        }

    }
}
