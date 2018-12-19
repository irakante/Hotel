using App1.SqlLite;
using System; 
using System.IO;
using Xamarin.Forms;
 
[assembly: Dependency(typeof(SQLite_Android))]
 
namespace App1.SqlLite
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public string GetDatabasePath(string filename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);
            return path;
        }
    }
}
