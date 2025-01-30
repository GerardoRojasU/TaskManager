#Administrador de Tareas**

Esta aplicaci�n de escritorio es una peque�a soluci�n desarrollada para cumplir con un reto t�cnico para aplicar por el puesto de Senior Software Developer enfocado en tecnolog�as .Net y el lenguaje de programaci�n C#.

##Configuraci�n del entorno de Desarrollo
* El entorno de desarrollo se configur� creando una aplicaci�n para escritorio, utilizando el framework de UI Windows Presentation Fundation(WPF).
* Se dise�o siguiendo el patr�n de arquitectura Modelo Vista Modelo (MVVM)
* Para la persistencia de datos se utiliz� la librer�a SQLite que funciona como manejador de base de datos liviano, r�pido, auto contenida y muy vers�til
* El c�digo fuente ha sido manejado y compartido en la plataforma de GitHub.

##Ejecuci�n de la soluci�n
Para la ejecuci�n de la soluci�n es necesario seguir los siguientes pasos:
* Descargar el c�digo fuente desde mi repositorio en [GitHub](https://github.com/GerardoRojasU/TaskManager.git)
* Abrir la soluci�n TaskManager.sln desde un entorno de desarrollo como Visual Studio .NET 2022 y previamente configurado para trabajar con el framework net8.0
* Compilar la soluci�n
* Ejecutar la soluci�n

##Decisiones t�cnicas
Adem�s de seguir las instrucciones del documento de requerimientos se tomaron las siguientes decisiones
* Base de datos: al iniciar la ejecuci�n de la aplicaci�n se hace la validaci�n de la existencia del archivo de la base de datos.
	* Si el archivo existe, se continua con la inicializaci�n de los componentes de la soluci�n.
	* Si el archivo no existe, se crea el archivo AdministradorTareas.db e inmediatamente despu�s se crea la tabla Tarea con su respectiva estructura y se ingresan 3 tareas de prueba.
* Entidades: para un mejor manejo de los datos, se cre� una clase objeto para representar los datos de la tabla Tarea.
* Framework: A diferencia del documento de requerimientos, donde especifica el uso del framework de UI WinForms, yo prefer� utilizar el framework de WPF, ya esta facilita la implementaci�n de patr�n MVVM.
* Para el manejo de los eventos de los componentes del UI se implement� usando vinculaciones a comandos en la capa de ViewModel

##Estilo de c�digo
* Se implemento el principio de la separaci�n de responsabilidades para reducir la complejidad y la interdependencia del sistema, as� como para mejorar la modularidad, mantenibilidad y reutilizaci�n.
* Se implemento el manejo de eventos delegados para:
	* Cargar los datos de la tabla con la lista de las tareas
	* Las acciones de los botones del detalle de las tareas: Nuevo, Insertar, Actualizar, Eliminar, Cancelar.
	* El bot�n para filtrar los datos
* Se escribi� el c�digo utilizando la tabulaci�n para estructurar los bloques de c�digo y mejorar la legibilidad.

##Convenciones
* Para la definici�n de nombres de variables se utiliz� camelCase
* Para la definici�n de nombres de propiedades, m�todos y funciones se utiliz� PascalCase
