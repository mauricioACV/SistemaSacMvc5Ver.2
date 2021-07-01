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