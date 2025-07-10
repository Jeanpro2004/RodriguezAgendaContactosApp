using __XamlGeneratedCode__;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RodriguezAgendaContactosApp.Models;
using RodriguezAgendaContactosApp.Services;
using GalaSoft.MvvmLight;

namespace RodriguezAgendaContactosApp.ViewModels
{
    public partial class NuevoContactoViewModel : ObservableObject

        [ObservableObject] private string nombre;
        [ObservableObject] private string correo;
        [ObservableObject] private string telefono;
        [ObservableObject] private bool favorito;

        private ContactoDatabase _database;

        public NuevoContactoViewModel(ContactoDatabase database)
    {
        _database = database;
    }

    [RelayComand]

    public async Task GuardarAsync()
    {
        if (!Telefono .StartsWith("+593"))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "El número de teléfono debe comenzar con +593", "OK");
            return;
        }

        var contacto = new Contacto
        {
            Nombre = Nombre,
            Correo = Correo,
            Telefono = Telefono,
            Favorito = Favorito
        };

        await _database.SaveContactoAsync(contacto);
        await Application.Current.MainPage.DisplayAlert("Éxito", "Contacto guardado correctamente", "OK");

        Nombre = Correo = Telefono = string.Empty;
        Favorito = false;
    }
    
    }
}
