//Hard Code
const objUsuario = {
    Usuario_Ingreso: 'CENTRAL',
    Clase: '*',
};

const setupItemDropDownList = [
    {
        endPoint: 'ObtenerItemsIndiceBase',
        pDominio: '',
        pGrupoUsuario: '',
        funcion: llenarModalInfoIndiceBase
    },
    {
       endPoint: 'ObtenerItemsPorDominioUsuario',
       pDominio: 'CTO_TIPO_CONTRATO',
       pGrupoUsuario: objUsuario.Usuario_Ingreso,
       funcion: llenarSelectTipoContrato
    },
    {
       endPoint: 'ObtenerItemsPorDominioUsuario',
       pDominio: 'CTO_CONTRATO_PROGRAMA',
       pGrupoUsuario: objUsuario.Usuario_Ingreso,
       funcion: llenarSelectProgramaPlan
    },
    {
       endPoint: 'ObtenerItemsPorDominio',
       pDominio: 'CTO_LICITACION',
       pGrupoUsuario: '',
       funcion: llenarSelectLicitacion
    },
    {
       endPoint: 'ObtenerItemsPorDominio',
       pDominio: 'CTO_FINANCIAMIENTO',
       pGrupoUsuario: '',
       funcion: llenarSelectFinanciamiento
    },
    {
       endPoint: 'ObtenerItemsPorDominio',
       pDominio: 'CTO_MODALIDAD',
       pGrupoUsuario: '',
       funcion: llenarSelectModalidad
    },
    {
       endPoint: 'ObtenerItemsPorDominio',
       pDominio: 'CTO_REAJUSTE',
       pGrupoUsuario: '',
       funcion: llenarSelectReajuste
    },
    {
        endPoint: 'ObtenerItemsAdministracionPorClaseUsuario',
        pDominio: '',
        pGrupoUsuario: objUsuario.Usuario_Ingreso,
        funcion: llenarSelectAdministracion
    },
    {
        endPoint: 'ObtenerItemsPorDominioUsuario',
        pDominio: 'CTO_ORIGEN_RESOLUCION',
        pGrupoUsuario: objUsuario.Usuario_Ingreso,
        funcion: llenarSelectOrigenRes
    },
    {
        endPoint: 'ObtenerItemsPorDominio',
        pDominio: 'CTO_CONTRATO_TIPORESOLUCION',
        pGrupoUsuario: '',
        funcion: llenarSelectTipoRes
    },
];

//Selectores
const selectTipoContrato = document.querySelector('#ddlTipoContrato');
const selectProgramaPlan = document.querySelector('#programaPlan');
const selectLicitacion = document.querySelector('#ddlLicitacion');
const selectFinanciamiento = document.querySelector('#ddlFinanciamiento');
const selectModalidad = document.querySelector('#ddlModalidad');
const selectReajuste = document.querySelector('#ddlReajuste');
const selectAdministracion = document.querySelector('#ddlAdministracion');
const selectOrigenRes = document.querySelector('#ddlOrigenRes');
const selectTipoRes = document.querySelector('#ddlTipoRes');
const listaModalIndiceBase = document.querySelector('#listaModalIndiceBase');
const modalIndiceBase = document.querySelector('#modalIndiceBase');
const tablaInspectorFiscal = document.querySelector('#tablaInspectorFiscal');

const txtVisitador = document.querySelector('#txtVisitador');
const txtCodigoSafi = document.querySelector('#txtCodigoSafi');
const txtCodigoCarpeta = document.querySelector('#txtCodigoCarpeta');
const txtAperturaTecnica = document.querySelector('#txtAperturaTecnica');
const txtAperturaEconomica = document.querySelector('#txtAperturaEconomica');
const txtPresupuestoInicial = document.querySelector('#txtPresupuestoInicial');
const txtNombreContrato = document.querySelector('#txtNombreContrato');
const txtPresupuestoOficial = document.querySelector('#txtPresupuestoOficial');
const txtIndiceBase = document.querySelector('#txtIndiceBase');
const txtInspectorFiscal = document.querySelector('#txtInspectorFiscal');
const txtAsesoria = document.querySelector('#txtAsesoria');
const txtContratista = document.querySelector('#txtContratista');
const txtResidente = document.querySelector('#txtResidente');

//Eventos Carga completa del HTML
$(document).ready(function () {

    //Carga datos drop down list globales
    setupItemDropDownList.forEach(async item => {
        const items = await obtenerItemsGlobalesDDL(item);
        item.funcion(items);
    });

    //Llenado Ventanas Modal
    llenarModalInspectorFiscal();
    llenarModalVisitadores();
    llenarModalAsesoria();
    llenarModalContratista();
    llenarModalResidentes();

    //Listeners
    txtCodigoSafi.addEventListener('blur', obtieneItemsSafi);
});

//Funciones Request

async function obtenerItemsGlobalesDDL(objSetupItemDropDownList) {

    const { endPoint, pDominio, pGrupoUsuario } = objSetupItemDropDownList;

    const data = {
        pDominio: `${pDominio}`,
        pGrupoUsuario: `${pGrupoUsuario}`,
    };
    try {
        const resultado = await fetch(`/GestionContrato/${endPoint}`, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const itemsDropDownList = await resultado.json();
        return itemsDropDownList.data;
    } catch (error) {
        console.log(error)
    }
};

function obtieneItemsSafi() {

    if (txtCodigoSafi.value !== "") {
        $.ajax({
            type: "POST",
            url: "/GestionContrato/ObtenerInfoContratoPorCodigoSafi",
            data: {
                codigoSafi: txtCodigoSafi.value,
            },
            dataType: "json",
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (itemsSafi) {
                llenarDatosSafi(itemsSafi.data);
            }
        });
    };

};

//Funciones Interaccion HTML
function llenarModalInfoIndiceBase(items) {

    while (listaModalIndiceBase.firstChild) {
        listaModalIndiceBase.removeChild(listaModalIndiceBase.firstChild);
    };

    items.forEach(item => {
        const { Agno, IdIndiceBase, Valor } = item;

        const trIndiceBase = document.createElement('tr');
        const tdAgno = document.createElement('td');
        tdAgno.innerHTML = `<p class=""> ${Agno} </p>`;
        const tdIdIndiceBase = document.createElement('td');
        tdIdIndiceBase.innerHTML = `<p class="">${IdIndiceBase}</p>`;
        const tdValor = document.createElement('td');
        tdValor.innerHTML = `<p class="">${Valor}</p>`;
        const tdButton = document.createElement('td');
        const btnSeleccionar = document.createElement('button');
        btnSeleccionar.classList.add("btn", "btn-success", "btn-sm");
        btnSeleccionar.setAttribute("data-toggle", "modal");
        btnSeleccionar.setAttribute("data-target", "#modalIndiceBase");
        btnSeleccionar.onclick = () => fijarValorInputIndice(IdIndiceBase);
        btnSeleccionar.innerHTML = 'Seleccionar';

        tdButton.appendChild(btnSeleccionar);

        trIndiceBase.appendChild(tdAgno);
        trIndiceBase.appendChild(tdIdIndiceBase);
        trIndiceBase.appendChild(tdValor);
        trIndiceBase.appendChild(tdButton);

        listaModalIndiceBase.appendChild(trIndiceBase);
    });
};

function llenarSelectTipoContrato(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Id_Item, Descripcion } = item;
            const optionSelectTipoContrato = document.createElement('option');
            optionSelectTipoContrato.value = Id_Item;
            optionSelectTipoContrato.textContent = Descripcion;
            selectTipoContrato.appendChild(optionSelectTipoContrato);
        }
    });
};

function llenarSelectProgramaPlan(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Id_Item, Descripcion } = item;
            const optionSelectProgramaPlan = document.createElement('option');
            optionSelectProgramaPlan.value = Id_Item;
            optionSelectProgramaPlan.textContent = Descripcion;
            selectProgramaPlan.appendChild(optionSelectProgramaPlan);
        }
    });

    selectProgramaPlan.size = items.length + 1;
};

function llenarSelectLicitacion(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Id_Item, Descripcion } = item;
            const optionSelectLicitacion = document.createElement('option');
            optionSelectLicitacion.value = Id_Item;
            optionSelectLicitacion.textContent = Descripcion;
            selectLicitacion.appendChild(optionSelectLicitacion);
        }
    });
};

function llenarSelectFinanciamiento(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Id_Item, Descripcion } = item;
            const optionSelectFinanciamiento = document.createElement('option');
            optionSelectFinanciamiento.value = Id_Item;
            optionSelectFinanciamiento.textContent = Descripcion;
            selectFinanciamiento.appendChild(optionSelectFinanciamiento);
        };

    });
};

function llenarSelectModalidad(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Id_Item, Descripcion } = item;
            const optionSelectModalidad = document.createElement('option');
            optionSelectModalidad.value = Id_Item;
            optionSelectModalidad.textContent = Descripcion;
            selectModalidad.appendChild(optionSelectModalidad);
        }
    });
};

function llenarSelectReajuste(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Id_Item, Descripcion } = item;
            const optionSelectReajuste = document.createElement('option');
            optionSelectReajuste.value = Id_Item;
            optionSelectReajuste.textContent = Descripcion;
            selectReajuste.appendChild(optionSelectReajuste);
        }
    });
};

function llenarSelectAdministracion(items) {
    items.forEach(item => {
        if (item.Clase !== " ") {
            const { Clase } = item;
            const optionSelectAdministracion = document.createElement('option');
            optionSelectAdministracion.value = Clase;
            optionSelectAdministracion.textContent = Clase;
            selectAdministracion.appendChild(optionSelectAdministracion);
        }
    });
};

function llenarSelectOrigenRes(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Id_Item, Descripcion } = item;
            const optionSelectOrigenRes = document.createElement('option');
            optionSelectOrigenRes.value = Id_Item;
            optionSelectOrigenRes.textContent = Descripcion;
            selectOrigenRes.appendChild(optionSelectOrigenRes);
        }
    });
};

function llenarSelectTipoRes(items) {
    items.forEach(item => {
        if (item.Descripcion !== " ") {
            const { Descripcion } = item;
            const optionSelectTipoRes = document.createElement('option');
            optionSelectTipoRes.value = Descripcion;
            optionSelectTipoRes.textContent = Descripcion;
            selectTipoRes.appendChild(optionSelectTipoRes);
        }
    });
};

function llenarDatosSafi(items) {

    const { CodigoCarpeta, AperturaTecnica, AperturaEconomica, PresupuestoInicial, NombreContrato, PresupuestoOficial } = items[0];

    const dia = AperturaTecnica.split("-")[0];
    const mes = AperturaTecnica.split("-")[1];
    const ano = AperturaTecnica.split("-")[2];
    const fechaISo = `${ano}-${mes}-${dia}`;

    const dia2 = AperturaEconomica.split("-")[0];
    const mes2 = AperturaEconomica.split("-")[1];
    const ano2 = AperturaEconomica.split("-")[2];
    const fechaISo2 = `${ano2}-${mes2}-${dia2}`;

      
    txtCodigoCarpeta.value = CodigoCarpeta;
    txtAperturaTecnica.value = fechaISo
    txtAperturaEconomica.value = fechaISo2
    txtPresupuestoInicial.value = PresupuestoInicial;
    txtNombreContrato.value = NombreContrato;
    txtPresupuestoOficial.value = PresupuestoOficial;

};

function fijarValorInputIndice(IdIndiceBase) {
    txtIndiceBase.value = IdIndiceBase;
};

//DATATABLE **Modal Inspector Fiscal**
function llenarModalInspectorFiscal() {
    
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
            "url": "/GestionContrato/ObtenerListadoInspectorFiscalActivos",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "Rut", "name": "Rut", "autoWidth": true },
            { "data": "Nombres", "name": "Nombres", "autoWidth": true },
            { "data": "Apellidos", "name": "Apellidos", "autoWidth": true },
            {
                "defaultContent": '<Button type="button" value="Seleccionar" title="Seleccionar" class="btn btn-success btn-sm seleccionaIf" data-target="#modalInspectorFiscal" data-toggle="modal">Seleccionar</button>'
            }
        ]
    });
};
//Evento Boton Seleccionar
$(document).on('click', '.seleccionaIf', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtInspectorFiscal.value = `${valores[1]} ${valores[2]}`

});
//FIN DATATABLE Inspector Fiscal**

//DATATABLE **Modal Visitador**
function llenarModalVisitadores() {

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
            "url": "/GestionContrato/ObtenerListadoVisitadoresActivos",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "Rut", "name": "Rut", "autoWidth": true },
            { "data": "Nombres", "name": "Nombres", "autoWidth": true },
            { "data": "Apellidos", "name": "Apellidos", "autoWidth": true },
            {
                "defaultContent": '<Button type="button" value="Seleccionar" title="Seleccionar" class="btn btn-success btn-sm seleccionaVisitador" data-target="#modalVisitadores" data-toggle="modal">Seleccionar</button>'
            }
        ]
    });
};
//Evento Boton Seleccionar
$(document).on('click', '.seleccionaVisitador', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtVisitador.value = `${valores[1]} ${valores[2]}`

});
//FIN DATATABLE Visitador

//DATATABLE **Modal Asesoria**
function llenarModalAsesoria() {

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
            "url": "/GestionContrato/ObtenerAsesoriaContratosEnEjecucionOrGarantia",
            "data": { pGrupoUsuario: objUsuario.Usuario_Ingreso },
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "CodigoCarpeta", "name": "CodigoCarpeta", "autoWidth": true },
            { "data": "NombreContrato", "name": "NombreContrato", "autoWidth": true },
            {
                "defaultContent": '<Button type="button" value="Seleccionar" title="Seleccionar" class="btn btn-success btn-sm seleccionaAsesoria" data-target="#modalAsesoria" data-toggle="modal">Seleccionar</button>'
            }
        ]
    });
};
//Evento Boton Seleccionar
$(document).on('click', '.seleccionaAsesoria', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtAsesoria.value = `${valores[0]} ${valores[1]}`

});
//DATATABLE Asesoria

//DATATABLE **Modal Constratistas**
function llenarModalContratista() {

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
            "url": "/GestionContrato/ObtenerContratistas",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "Rut", "name": "Rut", "autoWidth": true },
            { "data": "RazonSocial", "name": "RazonSocial", "autoWidth": true },
            {
                "defaultContent": '<Button type="button" value="Seleccionar" title="Seleccionar" class="btn btn-success btn-sm seleccionaContratista" data-target="#modalContratista" data-toggle="modal">Seleccionar</button>'
            }
        ]
    });
};
//Evento Boton Seleccionar
$(document).on('click', '.seleccionaContratista', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtContratista.value = `${valores[0]} ${valores[1]}`

});
//DATATABLE Constratistas

//DATATABLE **Modal Residente**
function llenarModalResidentes() {

    Tabla = $("#tablaResidentes").DataTable({
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
            "url": "/GestionContrato/ObtenerResidentes",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "Rut", "name": "Rut", "autoWidth": true },
            { "data": "Nombres", "name": "Nombres", "autoWidth": true },
            { "data": "Apellidos", "name": "Apellidos", "autoWidth": true },
            { "data": "TotalObrasEnEjecucion", "name": "TotalObrasEnEjecucion", "autoWidth": true },
            {
                "defaultContent": '<Button type="button" value="Seleccionar" title="Seleccionar" class="btn btn-success btn-sm seleccionaResidente" data-target="#modalResidentes" data-toggle="modal">Seleccionar</button>'
            }
        ]
    });
};
//Evento Boton Seleccionar
$(document).on('click', '.seleccionaResidente', function (e) {
    e.preventDefault();
    var valores = [];
    $(this).parents("tr").find("td").each(function () {
        valores.push($(this).html());
    });

    txtResidente.value = `${valores[1]} ${valores[2]}`

});
//DATATABLE Residente