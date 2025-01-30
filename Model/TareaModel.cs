using Database;
using Entity;

namespace Model
{
    public class TareaModel
    {
        public EventHandler TareaCambio;

        List<Tarea> Tareas { get; set; }

        public TareaModel()
        {
            Tareas = CRUD.Obtene();
        }

        public List<Tarea> ObtenerTareas()
        {
            return Tareas = CRUD.Obtene();
        }

        public List<Tarea> FiltrarTareas(string filtro, string valor)
        {
            var lista = new List<Tarea>();
            switch (filtro)
            {
                case "Usuario":
                    lista = Tareas.Where(t => t.Usuario.Contains(valor)).ToList();
                    break;
                case "Estado":
                    lista = Tareas.Where(t => t.Estado.Contains(valor)).ToList();
                    break;
                case "Prioridad":
                    lista = Tareas.Where(t => t.Prioridad == int.Parse(valor)).ToList();
                    break;
                case "FechaDesde":
                    lista = Tareas.Where(t => t.FechaFin.Contains(valor)).ToList();
                    break;
                case "FechaHasta":
                    lista = Tareas.Where(t => t.FechaFin.Contains(valor)).ToList();
                    break;
                default:
                    break;
            }

            //Tareas = lista;
            //OnTareaCambio();
            return lista;
        }

        public void Insertar(Tarea tarea)
        {
            CRUD.Insertar(tarea);
            OnTareaCambio();
        }

        public void Actualizar(Tarea tarea)
        {
            CRUD.Actualizar(tarea);
            OnTareaCambio();
        }

        public void Eliminar(Tarea tarea)
        {
            CRUD.Eliminar(tarea);
            OnTareaCambio();
        }

        void OnTareaCambio()
        {
            TareaCambio?.Invoke(this, null);
        }
    }
}
