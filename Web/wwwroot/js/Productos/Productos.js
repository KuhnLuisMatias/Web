$(document).ready(function () {
    $('#productos').dataTable({

        ajax: {
            url: "https://localhost:7078/api/Productos/BuscarProductos",
            dataSrc: ""
        },
        columns: [
            { data: 'id', title: 'Id' },
            {
                data: 'imagen', render: function (data) {
                    if (data != null) {
                        return '<img src="data:image/jpeg;base64,' + data + '"width="100px" height="100px">'
                    }
                    else {
                        return '<img src="/images/noexiste.jpg" width="100px" height="100px">'
                    }
                }, title: 'Imagen'
            },
            { data: 'descripcion', title: 'Descripcion' },
            { data: 'precio', title: 'Precio' },
            { data: 'stock', title: 'Stock' },
            { data: 'activo', title: 'Activo' },
            {
                data: function (data) {
                    var botones =
                        `<td><a href='javascript:EditarProducto(${JSON.stringify(data)})'><i class="fa-solid fa-pen-to-square editarProducto"></i></td>` +
                        `<td><a href='javascript:EliminarProducto(${JSON.stringify(data)})'><i class="fa-solid fa-trash eliminarProducto"></i></td>`
                    return botones;
                }
            }
        ]
    });
});

function GuardarProducto() {
    $("#productosAddPartial").html("");
    $.ajax({
        type: "GET",
        url: "/Productos/ProductosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#productosAddPartial").html(resultado);
            $("#productoModal").modal("show");
        }
    });
}

function EditarProducto(data) {
    $("#productosAddPartial").html("");
    $.ajax({
        type: "POST",
        url: "/Productos/ProductosAddPartial",
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $("#productosAddPartial").html(resultado);
            $("#productoModal").modal("show");
        }
    });
}

function EliminarProducto(data) {
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
                url: "/Productos/EliminarProducto",
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
