# Code First con Entity Framework y SQLite en C# .Net

`SQLite` es un sistema de gestión de bases de datos relacional, diseñado para ser ligero y eficiente. Es una biblioteca de código abierto que proporciona un motor de base de datos SQL completo y autónomo, que no requiere un servidor de base de datos separado para funcionar.

`SQLite` es ampliamente utilizado en aplicaciones de software embebido, aplicaciones móviles, navegadores web y diversas aplicaciones de escritorio donde se requiere un sistema de gestión de bases de datos ligero y fácil de usar.

Ejemplificaremos cómo conectar un proyecto `.NET` a una Base de datos `SQLite`, utilizando un simple proyecto de consola.

## Instalar librerías

1. Instalar Entity Framework:
    * Microsoft.EntityFrameworkCore
    * Microsoft.EntityFrameworkCore.Sqlite

Para instalar una librería debemos seguir el siguiente proceso:

1. Ubicados en el proyecto donde haremos la conexión con la base de datos, es decir, donde irá nuestro contexto, daremos clic derecho y seleccionamos la opción: **Administrar Paquetes Nuget**
2. En la opción Examinar, Buscar la opción o librería deseada,
3. En la ventana auxiliar, seleccionamos la versión a utilizar e instalamos

> Es importante tener en cuenta que se utilicen las mismas versiones de la librerías, para evitar confilictos adelante

## Creación de nuestras clases

En nuestra capa de datos, comenzaremos a agregar clases por cada tabla que vaya a tener nuestra base de datos, que representarán las entidades de nuestro modelo.

```cs
public class Estado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set;}
}
```

## Creación de nuestro contexto

En una carpeta aparte, la cual nombraremos context, crearemos nuestro contexto.

El **contexto** representa una sesión de trabajo con la base de datos, donde se llevan a cabo operaciones como recuperar, insertar, actualizar o eliminar objetos de la base de datos. Además, el contexto puede proporcionar funcionalidades adicionales, como la administración de transacciones, el seguimiento de cambios, el control de concurrencia y la gestión de la caché.

**NOTA:** Los valores deberán ser ajustados de acuerdo a las entidades o tablas mencionadas, además, considere que cuando va a crear entidades que tienen llaves foráneas, la entidad a la que hace relación debe estar creada o por lo menos, por encima de la declaración en la estructura de sentencias.