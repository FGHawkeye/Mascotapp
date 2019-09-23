using Domain.DB;
using Mascotapp.Droid;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace Mascotapp.Droid
{
    public class DatabaseService : IDBInterface
    {

        public DatabaseService()
        {
        }

        void VerificarPathDB(string dbName, string dbPath)
        {
            // Check if your DB has already been extracted.
            if (!File.Exists(dbPath))
            {
                using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            }
        }
        public SQLiteConnection CreateConnection()
        {
            string dbName = "db.db";
            string directoryPath = Android.OS.Environment.ExternalStorageDirectory.ToString() + "/Mascotapp";
            Directory.CreateDirectory(directoryPath);
            string dbPath = Path.Combine(directoryPath, dbName);
            VerificarPathDB(dbName, dbPath);

            var conn = new SQLiteConnection(dbPath);

            return conn;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}