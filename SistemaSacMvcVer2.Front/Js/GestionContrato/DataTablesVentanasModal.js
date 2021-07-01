//DATATABLE **Modal Inspector Fiscal**
function llenarModalInspectorFiscal() {
    console.log('se lleno modal de IF');

    Tabla = $("#tablaInspectorFiscal").DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],

        "ajax": {
            "url": "/DominioItemsFormulario/ObtenerListadoInspectorFiscalActivos",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "Rut", "name": "Rut", "autoWidth": true },
            { "data": "Nombres", "name": "Nombres", "autoWidth": true },
            { "data": "Apellidos", "name": "Apellidos", "autoWidth": true },
            {
                "defaultContent": '<i class="fa fa-check-square-o fa-2x seleccionaIf" style="cursor:pointer; color:darkcyan" aria-hidden="true" data-toggle="modal" data-target="#modalInspectorFiscal"></i>'
            }
        ]
    });
};
//Evento Boton Seleccionar **Modal Inspector Fiscal**
$(document).on('click', '.seleccionaIf', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtInspectorFiscal.value = `${valores[1]} ${valores[2]}`

});

//DATATABLE **Modal Visitador**
function llenarModalVisitadores() {
    console.log('se lleno modal de Visitador');

    Tabla = $("#tablaVisitadores").DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],

        "ajax": {
            "url": "/DominioItemsFormulario/ObtenerListadoVisitadoresActivos",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "Rut", "name": "Rut", "autoWidth": true },
            { "data": "Nombres", "name": "Nombres", "autoWidth": true },
            { "data": "Apellidos", "name": "Apellidos", "autoWidth": true },
            {
                "defaultContent": '<i class="fa fa-check-square-o fa-2x seleccionaVisitador" style="cursor:pointer; color:darkcyan" aria-hidden="true" data-toggle="modal" data-target="#modalVisitadores"></i>'
            }
        ]
    });
};
//Evento Boton Seleccionar **Modal Visitador**
$(document).on('click', '.seleccionaVisitador', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtVisitador.value = `${valores[1]} ${valores[2]}`

});

//DATATABLE **Modal Asesoria**
function llenarModalAsesoria() {
    console.log('se lleno modal de Asesoria');

    Tabla = $("#tablaAsesoria").DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],

        "ajax": {
            "url": "/DominioItemsFormulario/ObtenerAsesoriaContratosEnEjecucionOrGarantia",
            "data": { pGrupoUsuario: GrupoUser },
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "CodigoCarpeta", "name": "CodigoCarpeta", "autoWidth": true },
            { "data": "NombreContrato", "name": "NombreContrato", "autoWidth": true },
            {
                "defaultContent": '<i class="fa fa-check-square-o fa-2x seleccionaAsesoria" style="cursor:pointer; color:darkcyan" aria-hidden="true" data-toggle="modal" data-target="#modalAsesoria"></i>'
            }
        ]
    });
};
//Evento Boton Seleccionar **Modal Asesoria**
$(document).on('click', '.seleccionaAsesoria', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtAsesoria.value = `${valores[0]} ${valores[1]}`

});

//DATATABLE **Modal Constratistas**
function llenarModalContratista() {
    console.log('se lleno modal de Contratista');

    Tabla = $("#tablaContratistas").DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },

        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],

        "ajax": {
            "url": "/DominioItemsFormulario/ObtenerContratistas",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "Rut", "name": "Rut", "autoWidth": true },
            { "data": "RazonSocial", "name": "RazonSocial", "autoWidth": true },
            {
                "defaultContent": '<i class="fa fa-check-square-o fa-2x seleccionaContratista" style="cursor:pointer; color:darkcyan" aria-hidden="true" data-toggle="modal" data-target="#modalContratista"></i>'
            }
        ]
    });
};
//Evento Boton Seleccionar **Modal Constratistas**
$(document).on('click', '.seleccionaContratista', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtContratista.value = `${valores[0]} ${valores[1]}`

});