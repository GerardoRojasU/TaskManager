using Entity;
using System.Data.SQLite;

namespace Database
{
    public class CRUD
    {
        private static string connectionString = "Data Source=AdministradorTareas.db;Version=3;";

        public static Tarea? Obtener(int Id)
        {
            Tarea? tarea = null;

            using (SQLiteConnection connection = new(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = $"SELECT * FROM Tarea WHERE Id = {Id}";
                    using SQLiteCommand selectCmd = new(selectQuery, connection);
                    using SQLiteDataReader reader = selectCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string descripcion = reader.GetString(1);
                        string usuario = reader.GetString(2);
                        string estado = reader.GetString(3);
                        int prioridad = reader.GetInt32(4);
                        string fechaFin = reader.GetString(5);
                        string notas = reader.GetString(6);

                        var nuevaTarea = new Tarea
                        {
                            Id = id,
                            Descripcion = descripcion,
                            Usuario = usuario,
                            Estado = estado,
                            Prioridad = prioridad,
                            FechaFin = fechaFin,
                            Notas = notas
                        };

                        tarea = nuevaTarea;
                    }
                }
                catch (SQLiteException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"SQLite Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"General Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }

            return tarea;
        }
        
        public static List<Tarea> Obtene()
        {
            var tareas = new List<Tarea>();
            using (SQLiteConnection connection = new(connectionString))
            {
                try
                { 
                    connection.Open();

                    string selectQuery = "SELECT * FROM Tarea ORDER BY FechaFin ASC";
                    using SQLiteCommand selectCmd = new(selectQuery, connection);
                    using SQLiteDataReader reader = selectCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string descripcion = reader.GetString(1);
                        string usuario = reader.GetString(2);
                        string estado = reader.GetString(3);
                        int prioridad = reader.GetInt32(4);
                        string fechaFin = reader.GetString(5);
                        string notas = reader.GetString(6);

                        var nuevaTarea = new Tarea
                        {
                            Id = id,
                            Descripcion = descripcion,
                            Usuario = usuario,
                            Estado = estado,
                            Prioridad = prioridad,
                            FechaFin = fechaFin,
                            Notas = notas
                        };

                        tareas.Add(nuevaTarea);
                    }
                }
                catch (SQLiteException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"SQLite Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"General Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return tareas;
        }

        public static void Insertar(Tarea tarea)
        {
            string insertQuery = "INSERT INTO Tarea (Descripcion, Usuario, Estado, Prioridad, FechaFin, Notas) "+
                                 "VALUES (@Descripcion, @Usuario, @Estado, @Prioridad, @FechaFin, @Notas)";

            using SQLiteConnection connection = new(connectionString);
            try
            {
                connection.Open();

                using SQLiteCommand insertCmd = new(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                insertCmd.Parameters.AddWithValue("@Usuario", tarea.Usuario);
                insertCmd.Parameters.AddWithValue("@Estado", tarea.Estado);
                insertCmd.Parameters.AddWithValue("@Prioridad", tarea.Prioridad);
                insertCmd.Parameters.AddWithValue("@FechaFin", tarea.FechaFin);
                insertCmd.Parameters.AddWithValue("@Notas", tarea.Notas);
                insertCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQLite Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public static void Actualizar(Tarea tarea)
        {
            string actualizarQuery = "UPDATE Tarea " +
                                     "SET Descripcion = @Descripcion, " +
                                         "Usuario = @Usuario, " +
                                         "Estado = @Estado, " +
                                         "Prioridad = @Prioridad, " +
                                         "FechaFin = @FechaFin, " +
                                         "Notas = @Notas " +
                                     "WHERE Id = @Id";

            using SQLiteConnection connection = new(connectionString);
            try
            {
                connection.Open();

                using SQLiteCommand actualizarCmd = new(actualizarQuery, connection);
                actualizarCmd.Parameters.AddWithValue("@Id", tarea.Id);
                actualizarCmd.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
                actualizarCmd.Parameters.AddWithValue("@Usuario", tarea.Usuario);
                actualizarCmd.Parameters.AddWithValue("@Estado", tarea.Estado);
                actualizarCmd.Parameters.AddWithValue("@Prioridad", tarea.Prioridad);
                actualizarCmd.Parameters.AddWithValue("@FechaFin", tarea.FechaFin);
                actualizarCmd.Parameters.AddWithValue("@Notas", tarea.Notas);
                actualizarCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQLite Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public static void Eliminar(Tarea tarea)
        {
            string eliminarQuery = "DELETE FROM Tarea WHERE Id = @Id";

            using SQLiteConnection connection = new(connectionString);

            try
            {
                connection.Open();

                using SQLiteCommand eliminarCmd = new(eliminarQuery, connection);
                eliminarCmd.Parameters.AddWithValue("@Id", tarea.Id);
                eliminarCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQLite Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
