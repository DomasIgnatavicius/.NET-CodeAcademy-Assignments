using Music_Shop_DB.Database.Services;

namespace Music_Shop_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var programManager = new ProgramManager();
            programManager.initialWindow();
        }
    }
}
// Scaffold-DbContext „DataSource=C:\Users\ignat\Documents\.NET CodeAcademy\Assignments\NET CodeAcademy Assignments\Music Shop DB\Database\chinook.db“ Microsoft.EntityFrameworkCore.Sqlite
