//Datos que obtendre del login (variables session)
const objUsuario = {
    Usuario_Ingreso: 'CENTRAL',
    pDominio: 'CTO_CONTRATO_PROGRAMA',
    Clase: '*'
};

//Selectores
const ddlClase = document.querySelector('#ddlClase');
const ddlProgramaPlan = document.querySelector('#ddlProgramaPlan');
const ddlGrupo = document.querySelector('#ddlGrupo');
const ddlRegion = document.querySelector('#ddlRegion');
const btnGeneraReporte = document.querySelector('#btnGeneraReporte');
const dateInicio = document.querySelector('#dateInicio');
const dateFin = document.querySelector('#dateFin');
const ddlEstadoContrato = document.querySelector('#ddlEstadoContrato');
const ddlTipoContrato = document.querySelector('#ddlTipoContrato');

document.addEventListener('DOMContentLoaded', async () => {
    await obtenerClases();
    await obtenerGrupo();
    await obtenerRegiones();
    btnGeneraReporte.addEventListener('click', generarReporte);
    ddlEstadoContrato.addEventListener('change', verificaOpcionesFiltros);
});

async function obtenerClases() {
    const EndPoint = '/DominioItemsFormulario/ObtenerItemsAdministracionPorClaseUsuario';
    const data = {
        pGrupoUsuario: objUsuario.Usuario_Ingreso
    };

    try {
        const request = await fetch(EndPoint, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const itemsClase = await request.json();
        llenarSelectClase(itemsClase.data);

    } catch (error) {
        console.log(error)
    }
};

function llenarSelectClase(items) {
    items.forEach(item => {
        if (item.Clase !== " ") {
            const { Clase } = item;
            const optionSelectClase = document.createElement('option');
            optionSelectClase.value = Clase;
            optionSelectClase.textContent = Clase;
            ddlClase.appendChild(optionSelectClase);
        }

        ddlClase.size = items.length + 1;
    });
};

async function obtenerGrupo() {
    const EndPoint = '/DominioItemsFormulario/ObtenerListadoGrupos';

    try {
        const request = await fetch(EndPoint, {
            method: 'POST'
        });

        const itemsGrupo = await request.json();
        llenarSelectGrupo(itemsGrupo.data);

    } catch (error) {
        console.log(error)
    }
};

function llenarSelectGrupo(items) {
    items.forEach(item => {
        const { Grupo, Linea2 } = item;
        const optionSelectGrupo = document.createElement('option');
        optionSelectGrupo.value = Grupo;
        optionSelectGrupo.textContent = Linea2;
        ddlGrupo.appendChild(optionSelectGrupo);
    });
}

async function obtenerRegiones() {
    const EndPoint = '/DominioItemsFormulario/ObtenerRegiones';

    try {
        const request = await fetch(EndPoint, {
            method: 'POST'
        });

        const itemsRegiones = await request.json();
        llenarSelectRegiones(itemsRegiones.data);

    } catch (error) {
        console.log(error)
    }
};

function llenarSelectRegiones(items) {
    items.forEach(item => {
        const { Region } = item;
        const optionSelectRegion = document.createElement('option');
        optionSelectRegion.value = Region;
        optionSelectRegion.textContent = Region;
        ddlRegion.appendChild(optionSelectRegion);
    });
}

function generarReporte() {
    const paramReportes = {
        grupo: ddlGrupo.value,
        fechaDesde: dateInicio.value,
        fechaHasta: dateFin.value,
        estadoContrato: ddlEstadoContrato.value,
        region: ddlRegion.value,
        tipoContrato: ddlTipoContrato,
        clase: ddlClase.value
    }

    //Enviar datos al servidor y realizar la consulta
    obtenerListadoObras();
}

async function obtenerListadoObras() {
    const EndPoint = '/ReportesSac/ObtenerListadoBasicoObras';

    try {
        const request = await fetch(EndPoint, {
            method: 'POST'
        });

        const listadoBasicoObras = await request.json();
        console.log(listadoBasicoObras);

    } catch (error) {
        console.log(error)
    }
};

function verificaOpcionesFiltros() {
    console.log(ddlEstadoContrato.value);
    if (ddlEstadoContrato.value === 'EN EJECUCION') {
        const divRangoFechas = document.querySelector('#divRangoFechas');
        divRangoFechas.style.display = 'none';
    } else {
        divRangoFechas.style.display = 'block';
    }
}