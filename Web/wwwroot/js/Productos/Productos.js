$(document).ready(function () {
    $('#productos').dataTable({
            
        ajax: {
            url: "https://localhost:7078/api/Productos/BuscarProductos",
            dataSrc: ""
        },
        columns: [
            { data: 'id', title: 'Id' },
            {
                data: 'imagen', render: function (data)
                {
                    if (data != null ) {
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
    debugger
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