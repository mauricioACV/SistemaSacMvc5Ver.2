//Funciones Request EndPoints

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

async function obtenerResidentePorPalabraClave() {

    const cadenaBusqueda = document.querySelector('#txtPalabraClaveResidente').value;
    const data = { pPalabraClave: cadenaBusqueda };
    try {
        const resultado = await fetch('/GestionContrato/ObtenerResidentesPorPalabraClave', {
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

    if (txtCodigoSafi.value !== "") {

        const data = { codigoSafi: txtCodigoSafi.value };

        $('#modalSpinner').modal('show');

        try {
            const resultado = await fetch('/GestionContrato/ObtenerInfoContratoPorCodigoSafi', {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            const itemsSafi = await resultado.json();
            $('#modalSpinner').modal('hide');
            llenarDatosSafi(itemsSafi.data);
            txtNumProceso.focus();
        } catch (error) {
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

function fijarValorResidente(Rut, Nombres, Apellidos) {
    txtResidente.value = `${Rut} ${Nombres}${Apellidos}`;
}