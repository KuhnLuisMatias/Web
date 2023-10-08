$(document).ready(function () {
    $('#servicios').dataTable({

        ajax: {
            url: "https://localhost:7078/api/Servicios/BuscarServicios",
            dataSrc: ""
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            { data: 'activo', title: 'Activo' },
            {
                data: function (data) {
                    var botones =
                        `<td><a href='javascript:EditarServicio(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarServicio"></i></td>` +
                        `<td><a href='javascript:EliminarServicio(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarServicio"></i></td>`
                    return botones;
                }
            }
        ]
    });
});

function GuardarServicio() {
    $("#serviciosAddPartial").html("");
    $.ajax({
        type: "GET",
        url: "/Servicios/ServiciosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#serviciosAddPartial").html(resultado);
            $("#servicioModal").modal("show");
        }
    });
}

function EditarServicio(data) {
    $("#serviciosAddPartial").html("");
    $.ajax({
        type: "POST",
        url: "/Servicios/ServiciosAddPartial",
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#serviciosAddPartial").html(resultado);
            $("#servicioModal").modal("show");
        }
    });
}

function EliminarServicio(data) {
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
                url: "/Servicios/EliminarServicio",
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
