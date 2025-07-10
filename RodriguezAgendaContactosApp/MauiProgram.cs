using Microsoft.Extensions.Logging;
using RodriguezAgendaContactosApp.Services;
using RodriguezAgendaContactosApp.Models;
using RodriguezAgendaContactosApp.ViewModels;
using RodriguezAgendaContactosApp.Views;


namespace RodriguezAgendaContactosApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contactos.db3");

        builder.Services.AddSingleton<ContactoDatabase>(s => new ContactoDatabase(dbPath));
        builder.Services.AddSingleton<NuevoContactoViewModel>();
		builder.Services.AddSingleton<ListaContactosViewModel>();
        builder.Services.AddSingleton<LogsViewModel>();

		builder.Services.AddSingleton<NuevoContactoPage>();
        builder.Services.AddSingleton<ListaContactosPage>();
        builder.Services.AddSingleton<LogsPage>();
        builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
