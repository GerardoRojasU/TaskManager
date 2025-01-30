
using Database;

namespace Repository
{
    public class Tarea
    {
        public void Insertar(string descripcion, string usuario, string estado, int prioridad, string fechaFin, string notas)
        {
            if (string.IsNullOrEmpty(descripcion) ||
                string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(estado) ||
                string.IsNullOrEmpty(fechaFin) ||
                string.IsNullOrEmpty(notas))
            {
                Console.WriteLine("Data Incomplete on Insert");
            }
            else
            {
                var fecha = new DateTime();
                if (DateTime.TryParse(fechaFin, out fecha))
                {
                    CRUD.Insertar(descripcion, usuario, estado, prioridad, fechaFin, notas);
                }                
            }
        }
    }

}
