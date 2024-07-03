# Cordoba.Rodrigo.PrimerParcial 

# Titulo: CRUD - Indumentaria

## Sobre mi
Soy Rodrigo Cordoba, tengo 21 años, estudio Tecnicatura Universitaria en Programacion en UTN.

## Resumen
La aplicacion Crud - Indumentaria es una herramienta diseñada para realizar la carga de productos de indumentaria los cuales seran agregados a una lista y podran ser tanto modificados como eliminados de la misma. A la aplicacion se ingresa utilizando un correo y contraseña cargados previamente en un archivo de tipo .JSON y luego son validados para ingresar a la aplicacion.

### Uso de la aplicacion:
1. Ingresa utilizando un correo y contraseña validos cargados en el archivo MOCK.JSON. Al validar tambien se extrae el perfil del usuario que ingresa, teniendo distintas funciones. Administrador tendra acceso a todas las funciones (Agregar, modificar, eliminar y leer), el supervisor podra agregar, modificar y leer, por ultimo el vendedor solo tendra acceso a la lectura del listado.
2. Una vez dentro de la aplicacion, puedes presionar el boton "Salir" donde estaran las opciones cerrar sesion para cambiar de usuario o cerrar el programa.
3. Habra informacion en la barra superior sobre el perfil logueado mostrando su nombre, ademas de mostrar la fecha y la hora real en el momento que esta logueado.
4. Agrega un nuevo producto a la lista presionando el boton verde "Agregar". Se abrira una ventana para ingresar los detalles del producto. Ademas se almacenara en la base de datos del programa para que los demas perfiles puedan ver si hubo cambios en la lista de productos.
5. Para modificar un producto, seleccionalo de la lista y presiona el boton amarillo "Modificar". Se abrira una ventana emergente para editar los atributos del producto, actualizando la lista con estos nuevos atributos.
6. Para eliminar un producto, seleccionalo de la lista y presiona el boton rojo "Eliminar", confirma la accion en la ventana emergente. El producto sera removido tanto de la lista como de la base de datos.
7. Ordena los productos por tipo ("Pantalon", "Campera", "Remera") al presionar el boton ordenar prenda, y por cantidad ascendente presionando el boton "ordenar por cantidad ascendente" y por cantidad descendente "ordenar por cantidad descendente.
8. Serializacion en la barra superior desplegara 4 opciones, "guardar xml", la cual guardara la lista de elementos en un archivo xml; "guardar json" hara lo mismo peor en archivo tipo json; "cargar xml" cargara la lista guardada previamente con sus respectivos valores; "cargar json" realizara lo mismo pero del archivo json guardado.


## Diagrama de clases
![alt text](image-2.png)

## Usuario y contraseña sql
usuario: sa
contraseña: rodri

## Script sql
Puedes encontrar el script SQL en la carpeta `sql_scripts` dentro de este repositorio: `sql_scripts/script.sql`.
