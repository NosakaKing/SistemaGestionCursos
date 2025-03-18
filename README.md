<h1 align="center">Semana 5 Tarea 1 1👋</h1>
<h2>Sistema de gestión de Cursos Basico</h2></h2>
<h2>Entidad Estudiante</h2>
<p>Empezamos registrando los estudiantes pero esta vez usamos javascript para mostrar los datos en una tabla.</p>
<p align="center">
  <img src="https://i.imgur.com/KpcnrYz.png">
</p>
- Archivo Js para la carga de datos en  `Estudiante`

``` javascript
   listaEstudiantes() {
       var html = "";
       $.get("/Estudiante/GetEstudiantes", (listaEstudiantes) => {
           $.each(listaEstudiantes, (index, valor) => {
               html += `<tr>
                           <td>${valor.cedula}</td>
                           <td>${valor.nombre}</td>
                           <td>${valor.primerApellido}</td>
                           <td>${valor.segundoApellido}</td>
                           <td>${valor.fechaNacimiento}</td>
                           <td>${valor.telefono}</td>
                           <td>${valor.email}</td>
                           <td>
                               <a href="/Estudiante/Edit/${valor.id}" class="btn btn-secondary">Editar</a> |
                               <a href="/Estudiante/Details/${valor.id}" class="btn btn-info">Detalles</a> |
                               <button class="btn btn-danger" onclick="confirmarEliminar(${valor.id})">Eliminar</button>
                           </td>
                       </tr>`;
           });
           $("#tablaEstudiante").html(html);
       });
   }
```

<p>Usamos javascript para eliminar los datos</p>
<p align="center">
  <img src="https://i.imgur.com/Wo4vebh.png">
</p>
- Archivo Js para eliminar  `Estudiante`

``` javascript
      eliminarEstudiante(id) {
        var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            url: "/Estudiante/DeleteEstudianteConfirmed",
            type: "POST",
            data: {
                __RequestVerificationToken: token,
                id: id
            },
            success: (data) => {
                if (data) {
                    this.listaEstudiantes();
                }
            },
            error: (xhr, status, error) => {
                console.error("Error al eliminar el estudiante:", error);
            }
        });
    }
}
```

## Acerca del proyecto

- 👌 Semana 5 Tarea 1
- 👨‍💻 C# .NET Framework, Boostrap
