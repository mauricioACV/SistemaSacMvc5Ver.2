//objUserSession esta seteado en un script dentro de la vista _Layout.cshtml (carpeta Views/Shared)
const { GrupoUser } = objUserSession;

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
       pGrupoUsuario: GrupoUser,
       funcion: llenarSelectTipoContrato
    },
    {
       endPoint: 'ObtenerItemsPorDominioUsuario',
       pDominio: 'CTO_CONTRATO_PROGRAMA',
       pGrupoUsuario: GrupoUser,
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
        pGrupoUsuario: GrupoUser,
        funcion: llenarSelectAdministracion
    },
    {
        endPoint: 'ObtenerItemsPorDominioUsuario',
        pDominio: 'CTO_ORIGEN_RESOLUCION',
        pGrupoUsuario: GrupoUser,
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
document.addEventListener('DOMContentLoaded', () => {
    console.log(GrupoUser);

    //Carga datos drop down list globales pertaña GENERAL
    setupItemDropDownList.forEach(async item => {
        const items = await obtenerItemsGlobalesDDL(item);
        item.funcion(items);
    });

    //Listeners pestaña GENERAL
    txtCodigoSafi.addEventListener('blur', obtieneItemsSafi);
    btnBuscarResidente.addEventListener('click', obtenerResidentePorPalabraClave);
    txtInspectorFiscal.addEventListener('click', llenarModalInspectorFiscal);
    txtVisitador.addEventListener('click', llenarModalVisitadores);
    txtAsesoria.addEventListener('click', llenarModalAsesoria);
    txtContratista.addEventListener('click', llenarModalContratista);

    //Listeners pestaña COMUNAS
    //txtComuna.addEventListener('click', mostrarComunas);
    btnAgregarComuna.addEventListener('click', agregarInputComuna);
    btnQuitarComuna.addEventListener('click', quitarInputComuna);

});