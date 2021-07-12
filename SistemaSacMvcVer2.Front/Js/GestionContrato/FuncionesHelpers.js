//***********************************Funciones Pestaña GENERAL************************************************
//Funciones fill option select
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



//***********************************Funciones Pestaña COMUNAS************************************************
async function mostrarComunas(e) {
    console.log(e.target);

    url = '/DominioItemsFormulario/ObtenerComunas';
    bodyData = { pGrupoUsuario: GrupoUser };
    const data = await fetchRequestPost(url, bodyData);
    console.log(data);
};

function agregarInputComuna() {
    console.log('agregando comuna')

    contInputsComuna++;

    const divContainerInputs = document.createElement('div');
    divContainerInputs.classList.add('col-md-12');

    const divColComuna = document.createElement('div');
    divColComuna.classList.add('col-md-6');

    const divColInversion = document.createElement('div');
    divColInversion.classList.add('col-md-1');


    const divFormGroupComuna = document.createElement('div');
    divFormGroupComuna.classList.add('form-group');

    const divFormGroupInversion = document.createElement('div');
    divFormGroupInversion.classList.add('form-group');


    const labelComuna = document.createElement('label');
    labelComuna.textContent = 'Comuna';

    const labelInversion = document.createElement('label');
    labelInversion.textContent = 'Inversión %';

    const inputComuna = document.createElement('input');
    inputComuna.type = 'text';
    inputComuna.id = `txtComuna${contInputsComuna}`;
    inputComuna.setAttribute('data-toggle','modal');
    inputComuna.setAttribute('data-target', '#modalComunas');
    inputComuna.classList.add('form-control');
    inputComuna.placeholder = 'Click aquí para buscar comuna'
    inputComuna.addEventListener('click', (e) => mostrarComunas(e));


    const inputInversion = document.createElement('input');
    inputInversion.type = 'number';
    inputInversion.id = `txtInversion${contInputsComuna}`;
    inputInversion.classList.add('form-control');


    divFormGroupComuna.appendChild(labelComuna);
    divFormGroupComuna.appendChild(inputComuna);

    divFormGroupInversion.appendChild(labelInversion);
    divFormGroupInversion.appendChild(inputInversion);

    divColComuna.appendChild(divFormGroupComuna);
    divColInversion.appendChild(divFormGroupInversion);

    divContainerInputs.appendChild(divColComuna);
    divContainerInputs.appendChild(divColInversion);

    containerInputsComuna.appendChild(divContainerInputs);
};

function quitarInputComuna() {
    if (containerInputsComuna.firstChild) {
        contInputsComuna--;
        containerInputsComuna.removeChild(containerInputsComuna.lastChild);
    }
};