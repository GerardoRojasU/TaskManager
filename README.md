#Administrador de Tareas**

Esta aplicación de escritorio es una pequeña solución desarrollada para cumplir con un reto técnico para aplicar por el puesto de Senior Software Developer enfocado en tecnologías .Net y el lenguaje de programación C#.

##Configuración del entorno de Desarrollo
* El entorno de desarrollo se configuró creando una aplicación para escritorio, utilizando el framework de UI Windows Presentation Fundation(WPF).
* Se diseño siguiendo el patrón de arquitectura Modelo Vista Modelo (MVVM)
* Para la persistencia de datos se utilizó la librería SQLite que funciona como manejador de base de datos liviano, rápido, auto contenida y muy versátil
* El código fuente ha sido manejado y compartido en la plataforma de GitHub.

##Ejecución de la solución
Para la ejecución de la solución es necesario seguir los siguientes pasos:
* Descargar el código fuente desde mi repositorio en [GitHub](https://github.com/GerardoRojasU/TaskManager.git)
* Abrir la solución TaskManager.sln desde un entorno de desarrollo como Visual Studio .NET 2022 y previamente configurado para trabajar con el framework net8.0
* Compilar la solución
* Ejecutar la solución

##Decisiones técnicas
Además de seguir las instrucciones del documento de requerimientos se tomaron las siguientes decisiones
* Base de datos: al iniciar la ejecución de la aplicación se hace la validación de la existencia del archivo de la base de datos.
	* Si el archivo existe, se continua con la inicialización de los componentes de la solución.
	* Si el archivo no existe, se crea el archivo AdministradorTareas.db e inmediatamente después se crea la tabla Tarea con su respectiva estructura y se ingresan 3 tareas de prueba.
* Entidades: para un mejor manejo de los datos, se creó una clase objeto para representar los datos de la tabla Tarea.
* Framework: A diferencia del documento de requerimientos, donde especifica el uso del framework de UI WinForms, yo preferí utilizar el framework de WPF, ya esta facilita la implementación de patrón MVVM.
* Para el manejo de los eventos de los componentes del UI se implementó usando vinculaciones a comandos en la capa de ViewModel

##Estilo de código
* Se implemento el principio de la separación de responsabilidades para reducir la complejidad y la interdependencia del sistema, así como para mejorar la modularidad, mantenibilidad y reutilización.
* Se implemento el manejo de eventos delegados para:
	* Cargar los datos de la tabla con la lista de las tareas
	* Las acciones de los botones del detalle de las tareas: Nuevo, Insertar, Actualizar, Eliminar, Cancelar.
	* El botón para filtrar los datos
* Se escribió el código utilizando la tabulación para estructurar los bloques de código y mejorar la legibilidad.

##Convenciones
* Para la definición de nombres de variables se utilizó camelCase
* Para la definición de nombres de propiedades, métodos y funciones se utilizó PascalCase
