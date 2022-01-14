using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Data
{
    public class LocalDataAccess 
    {
        public void LoadData()
        {
            try { 
                using (IDbConnection cnn = new SQLiteConnection(GetConnectionString()))
                {
                    List<Package> output = cnn.Query<Package>("SELECT * FROM Packages", new DynamicParameters()).ToList();
                    foreach(Package package in output)
                    {
                        Console.WriteLine(package.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveData()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GetConnectionString()))
                {
                    using (var command = cnn.CreateCommand())
                    {
                        Package package = new Package();
                        package.Name = "Test";
                        package.Version = "0.1";
                        package.Path = "local";

                        command.CommandText = "INSERT INTO Packages (Name, Version, Path) VALUES (@Name, @Version, @Path)";
                        command.Parameters.Add(new SQLiteParameter("@Name", package.Name));
                        command.Parameters.Add(new SQLiteParameter("@Version", package.Version));
                        command.Parameters.Add(new SQLiteParameter("@Path", package.Path));
                        command.Connection.Open();
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string GetConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private class Package
        {
            public int Id;
            public string Name;
            public string Version;
            public string Path;

            public override string ToString()
            {
                return Id + ": " + Name + " Version " + Version + "\nPath: " + Path;
            }
        }
    }
}
