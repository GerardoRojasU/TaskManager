using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class Create
    {
        public static void CreateDatabase()
        {
            string dbFile = "AdministradorTareas.db";

            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                CreateTable();
            }
        }

        public static void CreateTable()
        {
            string connectionString = "Data Source=AdministradorTareas.db;Version=3;";

            using SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Tarea (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    Descripcion TEXT, 
                    Usuario TEXT, 
                    Estado TEXT, 
                    Prioridad INTEGER, 
                    FechaFin TEXT, 
                    Notas TEXT)";

            SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();

            string sql = "INSERT INTO Tarea(Descripcion,Usuario, Estado,Prioridad,FechaFin,Notas) VALUES('Primera Tarea','Gerardo Rojas','COMPLETADA',1,'2024-12-19','Prueba1')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Tarea(Descripcion,Usuario, Estado,Prioridad,FechaFin,Notas) VALUES('Segunda Tarea','Luis Rojas','PENDIENTE',2,'2025-02-07','Prueba2')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO Tarea(Descripcion,Usuario, Estado,Prioridad,FechaFin,Notas) VALUES('Tercera Tarea','Juan Rojas','EN PROCESO',3,'2025-01-31','Prueba3')";
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
