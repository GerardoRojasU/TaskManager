using Entity;

namespace ViewModel
{
    public class TareaObjectoNegocio
    {
        internal EventHandler TareaCambio;

        List<Tarea> Tareas { get; set; }
        
        public TareaObjectoNegocio()
        {
            Tareas = Database.CRUD.Obtene();
        }

        public List<Tarea> ObtenerTareas()
        {
            return Tareas = Database.CRUD.Obtene();
        }

        public void Insertar(Tarea tarea)
        {
            Database.CRUD.Insertar(tarea);
            OnTareaCambio();
        }

        public void Actualizar(Tarea tarea)
        {
            Database.CRUD.Actualizar(tarea);
            OnTareaCambio();
        }

        public void Eliminar(Tarea tarea)
        {
            Database.CRUD.Eliminar(tarea);
            OnTareaCambio();
        }

        void OnTareaCambio()
        {
            if (TareaCambio != null)
                TareaCambio(this, null);
        }
    }
}
