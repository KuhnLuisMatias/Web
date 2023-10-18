$(document).ready(function () {

    var token = getCookie("Token");
    $('#usuarios').dataTable({
        ajax: {
            url: "https://localhost:7078/api/Usuarios/BuscarUsuarios",
            dataSrc: "",
            headers: { "Authorization": "Bearer " + token }
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            { data: 'apellido', title: 'Apellido' },
            { data: 'mail', title: 'Mail' },
            { data: 'activo', title: 'Activo' },
            {
                data: function (data) {
                    return moment(data.fecha_Nacimiento).format("DD/MM/YYYY")
                }
                , title: 'Fecha Nacimiento'
            },
            { data: 'roles.nombre', title: 'Rol' },
            {
                data: function (data) {
                    return data.activo == true ? "Si" : "No";
                }, title: 'Activo'
            },
            {
                data: function (data) {
                    var botones =
                        `<td><a href='javascript:EditarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarUsuario"></i></td>` +
                        `<td><a href='javascript:EliminarUsuario(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarUsuario"></i></td>`
                    return botones;
                }
            }
        ]
    });
});

function GuardarUsuario() {
    $("#usuariosAddPartial").html("");
    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#usuariosAddPartial").html(resultado);
            $("#usuarioModal").modal("show");
        }
    });
}

function EditarUsuario(data) {
    $("#usuariosAddPartial").html("");
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#usuariosAddPartial").html(resultado);
            $("#usuarioModal").modal("show");
        }
    });
}

function EliminarUsuario(data) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: "/Usuarios/EliminarUsuario",
                data: JSON.stringify(data),
                contentType: "application/json",
                dataType: "html",
                success: function (resultado) {

                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                }
            });
        }
    })
}
