//Funciones Request EndPoints

async function obtenerItemsGlobalesDDL(objSetupItemDropDownList) {

    const { endPoint, pDominio, pGrupoUsuario } = objSetupItemDropDownList;

    const data = {
        pDominio: `${pDominio}`,
        pGrupoUsuario: `${pGrupoUsuario}`,
    };
    try {
        const resultado = await fetch(`/DominioItemsFormulario/${endPoint}`, {
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

async function obtenerResidentePorPalabraClave() {

    const cadenaBusqueda = document.querySelector('#txtPalabraClaveResidente').value;
    const data = { pPalabraClave: cadenaBusqueda };
    try {
        const resultado = await fetch('/DominioItemsFormulario/ObtenerResidentesPorPalabraClave', {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const listadoResidente = await resultado.json();
        llenarModalResidente(listadoResidente.data);
    } catch (error) {
        console.log(error)
    }
};

async function obtieneItemsSafi() {

    const url = '/GestionContrato/ObtenerInfoContratoPorCodigoSafi';

    if (txtCodigoSafi.value !== "") {

        $("#modalSpinner").modal("show")

        const data = { codigoSafi: txtCodigoSafi.value };
        try {
            const request = await fetch(url, {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            const itemsSafi = await request.json();
            if (itemsSafi.data.length) {
                await llenarDatosSafi(itemsSafi.data);
            }
            setTimeout(() => {
                $('#modalSpinner').modal('hide')
                if (txtCodigoCarpeta.value) {
                    txtNumProceso.focus();
                } else {
                    txtCodigoCarpeta.focus();
                }
            }, 500)


        } catch (error) {
            setTimeout(() => { $('#modalSpinner').modal('hide') }, 500)
            console.log('Ocurrio un error WS');
            console.log(error)
        }
    }

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
        const btnSeleccionar = document.createElement('i');
        btnSeleccionar.classList.add("fa", "fa-check-square-o", "fa-2x");
        btnSeleccionar.setAttribute("aria-hidden", "true");
        btnSeleccionar.setAttribute("data-toggle", "modal");
        btnSeleccionar.setAttribute("data-target", "#modalIndiceBase");
        btnSeleccionar.style.color = "darkcyan";
        btnSeleccionar.style.cursor = ("pointer");
        btnSeleccionar.onclick = () => fijarValorInputIndice(IdIndiceBase);

        tdButton.appendChild(btnSeleccionar);

        trIndiceBase.appendChild(tdAgno);
        trIndiceBase.appendChild(tdIdIndiceBase);
        trIndiceBase.appendChild(tdValor);
        trIndiceBase.appendChild(tdButton);

        listaModalIndiceBase.appendChild(trIndiceBase);
    });
};

function llenarModalResidente(itemsResidentes) {
    while (listaModalResidentes.firstChild) {
        listaModalResidentes.removeChild(listaModalResidentes.firstChild);
    };

    itemsResidentes.forEach(item => {
        const { Rut, Nombres, Apellidos, TotalObrasEnEjecucion } = item;

        const trResidentes = document.createElement('tr');
        const tdRut = document.createElement('td');
        tdRut.innerHTML = `<p class=""> ${Rut} </p>`;
        const tdNombres = document.createElement('td');
        tdNombres.innerHTML = `<p class="">${Nombres}</p>`;
        const tdApellidos = document.createElement('td');
        tdApellidos.innerHTML = `<p class="">${Apellidos}</p>`;
        const tdObrasEjecucion = document.createElement('td');
        tdObrasEjecucion.innerHTML = `<p class="">${TotalObrasEnEjecucion}</p>`;
        const tdButton = document.createElement('td');
        const btnSeleccionar = document.createElement('i');
        btnSeleccionar.classList.add("fa", "fa-check-square-o", "fa-2x");
        btnSeleccionar.setAttribute("aria-hidden", "true");
        btnSeleccionar.setAttribute("data-toggle", "modal");
        btnSeleccionar.setAttribute("data-target", "#modalResidentes");
        btnSeleccionar.style.color = "darkcyan";
        btnSeleccionar.style.cursor = ("pointer");
        btnSeleccionar.onclick = () => fijarValorResidente(Rut, Nombres, Apellidos);

        tdButton.appendChild(btnSeleccionar);

        trResidentes.appendChild(tdRut);
        trResidentes.appendChild(tdNombres);
        trResidentes.appendChild(tdApellidos);
        trResidentes.appendChild(tdObrasEjecucion);
        trResidentes.appendChild(tdButton);

        listaModalResidentes.appendChild(trResidentes);
    });
};

function llenarDatosSafi(items) {

    const { CodigoCarpeta,
        AperturaTecnica,
        AperturaEconomica,
        PresupuestoInicial,
        NombreContrato,
        PresupuestoOficial } = items[0];

    const fechaAperturaTenica = convierteFechaFormatoIso(AperturaTecnica);
    const fechaAperturaEconomica = convierteFechaFormatoIso(AperturaEconomica);


    txtCodigoCarpeta.value = CodigoCarpeta;
    txtAperturaTecnica.value = fechaAperturaTenica
    txtAperturaEconomica.value = fechaAperturaEconomica
    txtPresupuestoInicial.value = PresupuestoInicial;
    txtNombreContrato.value = NombreContrato;
    txtPresupuestoOficial.value = PresupuestoOficial;
};

function fijarValorInputIndice(IdIndiceBase) {
    txtIndiceBase.value = IdIndiceBase;
};

function fijarValorResidente(Rut, Nombres, Apellidos) {
    txtResidente.value = `${Rut} ${Nombres}${Apellidos}`;
}

function convierteFechaFormatoIso(fecha) {
    const dia = fecha.split("-")[0];
    const mes = fecha.split("-")[1];
    const agno = fecha.split("-")[2];
    const fechaISo = `${agno}-${mes}-${dia}`;
    return fechaISo;
}