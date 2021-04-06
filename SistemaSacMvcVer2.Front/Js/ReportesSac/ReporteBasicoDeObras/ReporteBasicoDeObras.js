const mensaje = document.querySelector('#mensaje');
const filtrosReporte = JSON.parse(localStorage.getItem('filtroReporteObras')) || [];

document.addEventListener('DOMContentLoaded', () => {
    generarReporteHtml();
});

function generarReporteHtml() {
    spinner();
    obtenerListadoObras(filtrosReporte);
}

function obtenerListadoObras(filtroReporte) {
    console.log(filtroReporte);
    let endPoint;

    if (filtroReporte.estadoContrato !== "EJECUCION+TERMINADOS" && (filtroReporte.tipoContrato == "00" || filtroReporte.tipoContrato == "01")) {

        endPoint = "/ReportesSac/ObtenerListadoBasicoObrasPorEstadoGrupoTipoContrato";

    } else if (filtroReporte.estadoContrato !== "EJECUCION+TERMINADOS" && filtroReporte.tipoContrato == "OBRAS") {

        endPoint = "/ReportesSac/ObtenerListadoBasicoObrasPorEstadoGrupoSoloObras";

    } else if (filtroReporte.estadoContrato == "EJECUCION+TERMINADOS" && (filtroReporte.tipoContrato == "00" || filtroReporte.tipoContrato == "01" || filtroReporte.tipoContrato == "OBRAS")) {

        endPoint = "/ReportesSac/ObtenerListadoBasicoObrasEnEjecucionTerminados";

    } else if (filtroReporte.estadoContrato == "EJECUCION+TERMINADOS" && filtroReporte.tipoContrato == "TODOS") {

        endPoint = "/ReportesSac/ObtenerListadoBasicoObrasEnEjecucionTerminados";

    } else {

        endPoint = "/ReportesSac/ObtenerListadoBasicoObras";

    }

    Tabla = $("#tablaReporteBasicoObras").DataTable({
        "language": {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "sLoadingRecords": "Cargando...",
            "sProcessing": "Procesando...",
            "sSearch": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Ultimo",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
        },
        "fnInitComplete": removeSpinner,
        "dom":"Blfrtip",
        "reponsive": "true",
        "buttons": [
            {
                "extend": "excelHtml5",
                "text": "<i class='fas fa-file-excel'></i>",
                "titleAttr": "Exportar a Excel",
                "className": "btm btn-success"
            },
            //{
            //    "extend": "pdfHtml5",
            //    "text": "<i class='fas fa-file-pdf'></i>",
            //    "titleAttr": "Exportar a PDF",
            //    "className": "btm btn-danger"
            //},
            //{
            //    "extend": "print",
            //    "text": "<i class='fas fa-print'></i>",
            //    "titleAttr": "Imprinir",
            //    "className": "btm btn-info"
            //}
        ],

        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
        "processing": true,

        "ajax": {
            "url": `${endPoint}`,
            "data": { filtroReporteBasico: filtroReporte },
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "EstadoContrato", "name": "EstadoContrato"},
            { "data": "Grupo", "name": "Grupo"},
            { "data": "CodigoCarpeta", "name": "CodigoCarpeta"},
            { "data": "CodigoSafi", "name": "CodigoSafi", "autoWidth": true },
            { "data": "Clase", "name": "Clase", "autoWidth": true },
            { "data": "NombreContrato", "name": "NombreContrato"},
            { "data": "Resolucion", "name": "Resolucion", "autoWidth": true },
            { "data": "FechaResolucion", "name": "FechaResolucion", "autoWidth": true },
            { "data": "FechaTramite", "name": "FechaTramite", "autoWidth": true },
            { "data": "FechaAperturaEconomica", "name": "FechaAperturaEconomica", "autoWidth": true },
            { "data": "FechaAperturaTecnica", "name": "FechaAperturaTecnica", "autoWidth": true },
            { "data": "Contratista", "name": "Contratista", "autoWidth": true },
            { "data": "Residente", "name": "Residente", "autoWidth": true },
            { "data": "InspectorFiscal", "name": "InspectorFiscal", "autoWidth": true },
            { "data": "Visitador", "name": "Visitador", "autoWidth": true },
            { "data": "CodigoAsesoria", "name": "CodigoAsesoria", "autoWidth": true },
            { "data": "Financiamiento", "name": "Financiamiento", "autoWidth": true },
            { "data": "Licitacion", "name": "Licitacion", "autoWidth": true },
            { "data": "TipoReajuste", "name": "TipoReajuste", "autoWidth": true },
            { "data": "IndiceBase", "name": "IndiceBase", "autoWidth": true },
            { "data": "PresupuestoOficial", "name": "PresupuestoOficial", "autoWidth": true },
            { "data": "PresupuestoInicial", "name": "PresupuestoInicial", "autoWidth": true },
            { "data": "MontoModificatoriasTramitadas", "name": "MontoModificatoriasTramitadas", "autoWidth": true },
            { "data": "MontoActual", "name": "MontoActual", "autoWidth": true },
            { "data": "Pagado", "name": "Pagado", "autoWidth": true },
            { "data": "MontoReajustes", "name": "MontoReajustes", "autoWidth": true },
            { "data": "FechaInicio", "name": "FechaInicio", "autoWidth": true },
            { "data": "PlazoOriginal", "name": "PlazoOriginal", "autoWidth": true },
            { "data": "FechaTerminoOriginal", "name": "FechaTerminoOriginal", "autoWidth": true },
            { "data": "ModificaDiasTramitados", "name": "ModificaDiasTramitados", "autoWidth": true },
            { "data": "FechaTerminoLegal", "name": "FechaTerminoLegal", "autoWidth": true },
            { "data": "FechaRealTermino", "name": "FechaRealTermino", "autoWidth": true },
            { "data": "ModificaDiasPreAprobado", "name": "ModificaDiasPreAprobado", "autoWidth": true },
            { "data": "ModificaMontoPreAprobado", "name": "ModificaMontoPreAprobado", "autoWidth": true },
            { "data": "ModificaDiasNoAprobado", "name": "ModificaDiasNoAprobado", "autoWidth": true },
            { "data": "ModificaMontoNoAprobado", "name": "ModificaMontoNoAprobado", "autoWidth": true },
            { "data": "AmbitoContrato", "name": "AmbitoContrato", "autoWidth": true },
            { "data": "TipoCarpeta", "name": "TipoCarpeta", "autoWidth": true },
            { "data": "TipoContrato", "name": "TipoContrato", "autoWidth": true },
            { "data": "CodigoChileCompra", "name": "CodigoChileCompra", "autoWidth": true },
        ]
    });

};

function spinner() {
    const divSpinner = document.createElement("div");

    divSpinner.classList.add("text-center", "sk-fading-circle");

    divSpinner.innerHTML = `
          <div class="sk-circle1 sk-circle"></div>
          <div class="sk-circle2 sk-circle"></div>
          <div class="sk-circle3 sk-circle"></div>
          <div class="sk-circle4 sk-circle"></div>
          <div class="sk-circle5 sk-circle"></div>
          <div class="sk-circle6 sk-circle"></div>
          <div class="sk-circle7 sk-circle"></div>
          <div class="sk-circle8 sk-circle"></div>
          <div class="sk-circle9 sk-circle"></div>
          <div class="sk-circle10 sk-circle"></div>
          <div class="sk-circle11 sk-circle"></div>
          <div class="sk-circle12 sk-circle"></div>
      `;

    mensaje.appendChild(divSpinner);
};

const removeSpinner = () => {
   mensaje.removeChild(mensaje.firstChild);
}