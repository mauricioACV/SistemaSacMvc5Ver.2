var txtUser = document.getElementById('txtUser');
var txtPass = document.getElementById('txtPass');
var loginForm = document.getElementById('loginForm');
var txtError = document.getElementById('txtError');
var alertIcon = document.getElementById('alertIcon');

window.onload = function () {
    if (browserVersion() <= 11) {
        var mainPanel = document.getElementById('mainPanel');

        while (mainPanel.firstChild) {
            mainPanel.removeChild(mainPanel.firstChild);
        }
        mainPanel.className = 'red-text bold';
        mainPanel.innerText = 'ESTIMADO USUARIO, ESTE SITIO ESTA OPTIMIZADO PARA TODOS LOS NAVEGADORES EXCEPTO INTERNET EXPLORER, POR FAVOR CAMBIE DE NAVEGADOR (GOOGLE CHROME, FIREFOX, ETC). ADMINISTRACIÓN SAC.';
    } else {
        console.log(loginForm);
        loginForm.addEventListener('submit', validaFormulario);
    }
};

function browserVersion() {
    var rv = -1; // Return value assumes failure.

    if (navigator.appName == 'Microsoft Internet Explorer') {

        var ua = navigator.userAgent,
            re = new RegExp("MSIE ([0-9]{1,}[\\.0-9]{0,})");

        if (re.exec(ua) !== null) {
            rv = parseFloat(RegExp.$1);
        }
    }
    else if (navigator.appName == "Netscape") {
        if (navigator.appVersion.indexOf('Trident') === -1) rv = 12;
        else rv = 11;
    }

    return rv;
};

function validaFormulario(e) {
    e.preventDefault();
    if (txtUser.value === '' && txtPass.value === '') {
        alertIcon.className = 'fas fa-exclamation-triangle red-text alert-icon-show'
        txtError.innerText = 'Ingrese credenciales';
    } else if (txtUser.value === '') {
        alertIcon.className = 'fas fa-exclamation-triangle red-text alert-icon-show'
        txtError.innerText = 'Ingrese usuario';
    } else if (txtPass.value === '') {
        alertIcon.className = 'fas fa-exclamation-triangle red-text alert-icon-show'
        txtError.innerText = 'Ingrese contraseña';
    }
    else {
        loginForm.submit();
    }
};