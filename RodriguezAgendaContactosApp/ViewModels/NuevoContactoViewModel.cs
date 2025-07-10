using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RodriguezAgendaContactosApp.Models;
using RodriguezAgendaContactosApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RodriguezAgendaContactosApp.ViewModels
{
    public partial class NuevoContactoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string nombre;
        [ObservableProperty]
        private string correo;
        [ObservableProperty]
        private string telefono;
        [ObservableProperty]
        private bool favorito;

        private readonly ContactoDatabase _database;

        public NuevoContactoViewModel(ContactoDatabase database)
        {
            _database = database;
        }

        [RelayCommand]
        public async Task GuardarAsync()
        {
            
            if (string.IsNullOrWhiteSpace(Telefono) || !Telefono.StartsWith("+593"))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El número de teléfono debe comenzar con +593", "OK");
                return;
            }

            
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Correo))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor complete todos los campos", "OK");
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
            // Agregar al log
            await LogService.AppendLogAsync(Nombre);
            await Application.Current.MainPage.DisplayAlert("Éxito", "Contacto guardado correctamente", "OK");

            // Limpiar campos
            Nombre = Correo = Telefono = string.Empty;
            Favorito = false;
        }
    }
}