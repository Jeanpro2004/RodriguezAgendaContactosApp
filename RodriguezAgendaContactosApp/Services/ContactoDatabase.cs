using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using RodriguezAgendaContactosApp.Models;


namespace RodriguezAgendaContactosApp.Services
{
    public class ContactoDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        public ContactoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contacto>().Wait();
        }
      
        public Task<int> SaveContactoAsync(Contacto contacto)
        {
            return _database.InsertAsync(contacto);
        }
        public Task<List<Contacto>> GetContactosAsync()
        {
            return _database.Table<Contacto>().ToListAsync();
        } 
       
    }
}
