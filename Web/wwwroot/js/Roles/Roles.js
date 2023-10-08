$(document).ready(function () {
    $('#roles').dataTable({

        ajax: {
            url: "https://localhost:7078/api/Roles/BuscarRoles",
            dataSrc: ""
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            { data: 'activo', title: 'Activo' },
            {
                data: function (data) {
                    var botones =
                        `<td><a href='javascript:EditarRol(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarRol"></i></td>` +
                        `<td><a href='javascript:EliminarRol(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarRol"></i></td>`
                    return botones;
                }
            }
        ]
    });
});

function GuardarRol() {
    $("#rolesAddPartial").html("");
    $.ajax({
        type: "GET",
        url: "/Roles/RolesAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#rolesAddPartial").html(resultado);
            $("#rolModal").modal("show");
        }
    });
}

function EditarRol(data) {
    $("#rolesAddPartial").html("");
    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#rolesAddPartial").html(resultado);
            $("#rolModal").modal("show");
        }
    });
}

function EliminarRol(data) {
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
                url: "/Roles/EliminarRol",
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
