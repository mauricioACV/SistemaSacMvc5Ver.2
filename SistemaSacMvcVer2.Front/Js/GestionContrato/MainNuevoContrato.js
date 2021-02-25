//Hard Code
const objUsuario = {
    Usuario_Ingreso: 'CENTRAL',
    Clase: '*',
};

//Arreglo Configuracion Enpoints y callback de DropDownList
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

//Eventos carga completa del HTML
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

    //Listeners
    txtCodigoSafi.addEventListener('blur', obtieneItemsSafi);
    btnBuscarResidente.addEventListener('click', obtenerResidentePorPalabraClave);
});