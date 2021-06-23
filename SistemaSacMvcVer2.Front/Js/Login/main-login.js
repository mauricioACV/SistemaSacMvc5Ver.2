const txtUser = document.querySelector('#txtUser');
const txtPass = document.querySelector('#txtPass');
const btnForm = document.querySelector('#loginForm');


document.addEventListener('DOMContentLoaded', () => {
    loginForm.addEventListener('submit', validaFormulario);
});

function validaFormulario(e) {
    e.preventDefault();
    if (txtUser.value === '' || txtPass.value === '') {
        console.log('Error')
    }
    else {
        loginForm.submit();
    }
}