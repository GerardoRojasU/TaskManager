namespace Entity
{
    public class Tarea : ViewModelBase
    {
        private int id;
        private string descripcion;
        private string usuario;
        private string estado;
        private int prioridad;
        private string fechaFin;
        private string notas;

        public Tarea()
        {
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public required string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }
        public required string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                OnPropertyChanged("Usuario");
            }
        }
        public required string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged("Estado");
            }
        }
        public int Prioridad
        {
            get { return prioridad; }
            set
            {
                prioridad = value;
                OnPropertyChanged("Prioridad");
            }
        }
        public required string FechaFin
        {
            get { return fechaFin; }
            set
            {
                fechaFin = value;
                OnPropertyChanged("FechaFin");
            }
        }
        public required string Notas
        {
            get { return notas; }
            set
            {
                notas = value;
                OnPropertyChanged("Notas");
            }
        }
    }
}
