

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