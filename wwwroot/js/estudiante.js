class Estudiante {
    constructor() { }

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

function confirmarEliminar(id) {
    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminarlo'
    }).then((result) => {
        if (result.isConfirmed) {
            var estudiante = new Estudiante();
            estudiante.eliminarEstudiante(id);
            Swal.fire(
                '¡Eliminado!',
                'El estudiante ha sido eliminado.',
                'success'
            )
        }
    })
}
