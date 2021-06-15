//Datos que obtendre del login (variables session)
const objUsuario = {
    Usuario_Ingreso: 'D.I.V.URBANA',
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
const chkAdminCentral = document.querySelector('#chkAdminCentral');
const chkRangoFechas = document.querySelector('#chkRangoFechas');

document.addEventListener('DOMContentLoaded', async () => {
    await obtenerGrupo();
    await obtenerRegiones();
    await obtenerClases();
    btnGeneraReporte.addEventListener('click', generarReporte);
    ddlGrupo.addEventListener('change', verificaOpcionesFiltros);
    ddlEstadoContrato.addEventListener('change', verificaOpcionesFiltros);
    chkRangoFechas.addEventListener('change', verificaOpcionesFiltros);
});

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
        if (Grupo === 'CENTRAL') { optionSelectGrupo.selected = true }
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

async function obtenerClases() {
    const EndPoint = '/DominioItemsFormulario/ObtenerItemsAdministracionPorClaseUsuario';
    const data = {
        pGrupoUsuario: ddlGrupo.value
        //pGrupoUsuario: objUsuario.Usuario_Ingreso
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
    while (ddlClase.firstChild) {
        ddlClase.removeChild(ddlClase.firstChild);
    };
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

function generarReporte() {

    if (ddlGrupo.value == "" || ddlEstadoContrato.value == "") {
        console.log('Debe Escoger opciones de Grupo y Estado')
    } else {
        if (chkRangoFechas.checked && (dateInicio.value === "" || dateFin.value === "")) {
            console.log('Debe ingresar rango de fechas');
        } else {
            const fechaInicio = convierteFechaDiaMesAgno(dateInicio.value);
            const fechaFin = convierteFechaDiaMesAgno(dateFin.value);

            const filtroReportes = {
                grupo: ddlGrupo.value,
                rangoFecha: chkRangoFechas.checked,
                fechaDesde: fechaInicio,
                fechaHasta: fechaFin,
                estadoContrato: ddlEstadoContrato.value,
                region: ddlRegion.value,
                tipoContrato: ddlTipoContrato.value,
                clase: ddlClase.value,
                IncluirCentral: chkAdminCentral.checked,
            }
            //Enviar datos a pagina que hara solitud al servidor y renderiza resultados
            localStorage.setItem('filtroReporteObras', JSON.stringify(filtroReportes));
            window.open('/ReportesSac/ReporteBasicoDeObras')
        }

    }
    
}

function verificaOpcionesFiltros(e) {

    console.log(e.target.id);
    if (e.target.id === 'ddlGrupo') {
        obtenerClases();
        const grupo = ddlGrupo.value;
        const divChkAdminCentral = document.querySelector('#divChkAdminCentral');
        const divRegion = document.querySelector('#divRegion');

        if (grupo !== 'CENTRAL' && grupo !== 'DOP' && grupo !== 'D.I.V.URBANA' && grupo !== 'D.INGENIERIA' && grupo !== 'D.REDES') {
            divRegion.style.display = 'none';
            divChkAdminCentral.style.display = 'block';
        } else {
            divRegion.style.display = 'block';
            divChkAdminCentral.style.display = 'none';
            chkAdminCentral.checked = false;
        }
    }

    if (e.target.id === 'ddlEstadoContrato') {
        const divRangoFechas = document.querySelector('#divRangoFechas');
        const divChkRangoFechas = document.querySelector('#divChkRangoFechas');

        if (ddlEstadoContrato.value === 'EN EJECUCION') {
            chkRangoFechas.checked = false;
            divRangoFechas.style.display = 'none';
            divChkRangoFechas.style.display = 'none';
        } else {
            divChkRangoFechas.style.display = 'block';
        }
    }

    if (chkRangoFechas.checked) {
        divRangoFechas.style.display = 'block';
    } else {
        dateInicio.value = '';
        dateFin.value = '';
        divRangoFechas.style.display = 'none';
    }
}

function convierteFechaDiaMesAgno(fecha) {
    const agno = fecha.split("-")[0];
    const mes = fecha.split("-")[1];
    const dia = fecha.split("-")[2];
    const fechaDiaMesAgno = `${dia}-${mes}-${agno}`;
    return fechaDiaMesAgno;
}