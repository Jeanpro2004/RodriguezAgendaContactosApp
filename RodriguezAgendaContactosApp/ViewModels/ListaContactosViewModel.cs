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
    public partial class ListaContactosViewModel: ObservableObject
    {
        private readonly ContactoDatabase _database;

        public ObservableCollection<Contacto> Contactos { get; } = new();
        public ListaContactosViewModel(ContactoDatabase database)
        {
            _database = database;
            CargarContactos();
        }

        private async void CargarContactos()
        {
            var lista = await _database.GetContactosAsync();
            Contactos.Clear();
            foreach (var c in lista)
            {
                Contactos.Add(c);
            }
        }
    }
}
