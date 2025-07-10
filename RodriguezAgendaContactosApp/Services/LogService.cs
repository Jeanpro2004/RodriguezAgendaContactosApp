using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodriguezAgendaContactosApp.Services
{
    public static class LogService
    {
        private static string FilePath => Path.Combine(FileSystem.AppDataDirectory, "Logs_Rodriguez.txt");

        public static async Task AppendLogAsync(string nombre)

        {
            string log = $"Se incluyo el registro {nombre} el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            await File.AppendAllTextAsync(FilePath, log);
        }

        public static async Task<string> ReadLogsAsync()
        {
            if (!File.Exists(FilePath))
            return await File.ReadAllTextAsync(FilePath);
            return "No existen aun logs";
        }
    }
}
