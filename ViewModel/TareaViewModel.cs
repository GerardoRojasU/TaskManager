using Entity;
using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace ViewModel
{
    public class TareaViewModel : ViewModelBase
    {
        public TareaViewModel()
        {
            //Inicio
            tareaModel = new TareaModel();
            tareaModel.TareaCambio += new EventHandler(Tarea_CambiO);
            ActualizarBindingGroup = new BindingGroup { Name = "Grupo1" };

            //Botones
            NewCommand = new PasarComando(Nuevo);
            CancelCommand = new PasarComando(Cancelar);
            AddCommand = new PasarComando(Insertar);
            SaveCommand = new PasarComando(Actualizar);
            DeleteCommand = new PasarComando(Eliminar);

            //Filtros
            FilterCommand = new PasarComando(Filtrar);
        }

        #region Inicio

        TareaModel tareaModel;

        void Tarea_CambiO(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                OnPropertyChanged("Tareas");
            }));
        }

        private BindingGroup _ActualizarBindingGroup;
        public BindingGroup ActualizarBindingGroup
        {
            get
            {
                return _ActualizarBindingGroup;
            }
            set
            {
                if (_ActualizarBindingGroup != value)
                {
                    _ActualizarBindingGroup = value;
                    OnPropertyChanged("ActualizarBindingGroup");
                }
            }
        }

        private ObservableCollection<Tarea> _Tareas;
        public ObservableCollection<Tarea> Tareas
        {
            get
            {
                _Tareas = new ObservableCollection<Tarea>(tareaModel.ObtenerTareas());
                return _Tareas;
            }
            set
            {
                _Tareas = value;
                OnPropertyChanged("Tareas");
            }
        }

        #endregion

        #region Botones

        public PasarComando NewCommand { get; set; }
        public PasarComando CancelCommand { get; set; }
        public PasarComando AddCommand { get; set; }
        public PasarComando SaveCommand { get; set; }
        public PasarComando DeleteCommand { get; set; }
        public PasarComando FilterCommand { get; set; }

        void Nuevo(object param)
        {
            SelectedIndex = -1;
            TareaSeleccionada = null;
            TareaSeleccionada =
            new Tarea
            {
                Descripcion = String.Empty,
                Usuario = String.Empty,
                Estado = String.Empty,
                Prioridad = 0,
                FechaFin = String.Empty,
                Notas = String.Empty
            };
        }

        void Cancelar(object param)
        {
            ActualizarBindingGroup.CancelEdit();
            SelectedIndex = -1;
            TareaSeleccionada = null;
        }

        void Insertar(object param)
        {
            ActualizarBindingGroup.CommitEdit();
            var tarea = TareaSeleccionada as Tarea;
            tareaModel.Insertar(tarea);
            OnPropertyChanged("Tareas");
            TareaSeleccionada = null;
        }

        void Actualizar(object param)
        {
            ActualizarBindingGroup.CommitEdit();
            var tarea = TareaSeleccionada as Tarea;
            tareaModel.Actualizar(tarea);
            TareaSeleccionada = null;
        }

        void Eliminar(object param)
        {
            var tarea = TareaSeleccionada as Tarea;
            if (SelectedIndex != -1)
            {
                tareaModel.Eliminar(tarea);
                OnPropertyChanged("Tareas");
            }
            else
                TareaSeleccionada = null;
        }

        public int SelectedIndex { get; set; }

        object _TareaSeleccionada;
        public object TareaSeleccionada
        {
            get
            {
                return _TareaSeleccionada;
            }
            set
            {
                if (_TareaSeleccionada != value)
                {
                    _TareaSeleccionada = value;
                    OnPropertyChanged("TareaSeleccionada");
                }
            }
        }

        #endregion

        #region Filtros

        void Filtrar(object sender)
        {
            var filtroValor = (string)sender;
            if (!string.IsNullOrEmpty(filtroValor))
            {
                _Tareas = new ObservableCollection<Tarea>(tareaModel.FiltrarTareas("Usuario", filtroValor));
                //OnPropertyChanged("Tareas");
                TareaSeleccionada = null;
            }
        }

        #endregion
    }
}

