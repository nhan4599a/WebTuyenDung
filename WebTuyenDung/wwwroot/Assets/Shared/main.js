// Show login form
__('#btn-login, .login--close, .main__login').forEach((item) => {
    item.addEventListener('click', () => {
        _('.main__login').classList.toggle('show');
    })
})

__('.register--close, .main__register').forEach((item) => {
    item.addEventListener('click', () => {
        _('.main__register').classList.toggle('show');
    })
})

__('.main__login--wrapper, .main__register--wrapper').forEach((item) => {
    item.addEventListener('click', (e) => {
        e.stopPropagation();
    });
});

_('#link-register').addEventListener('click', (e) => {
    _('.main__register').classList.add('show');
    _('.main__login').classList.remove('show');
});

_('#link-login').addEventListener('click', (e) => {
    _('.main__register').classList.remove('show');
    _('.main__login').classList.add('show');
});

$('#form_btn-login').off('click').on('click', (e) => {
    e.preventDefault();

    let email = $('#login_email').val();
    let password = $('#login_password').val();

    let data = {
        "username": email,
        "password": password
    };

    if (email.length > 0 && password.length > 0) {

        $.ajax({
            url: "/authentication/sign-in",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            complete: function (response) {
                if (response.status !== 200) {
                    $('#login_message').text(response.responseText);
                } else {
                    window.location.reload()
                }
            }
        });
    }
})

$('#form_btn-register').off('click').on('click', (e) => {
    e.preventDefault();

    let register_name = $('#register_name').val();
    let register_email = $('#register_email').val();
    let register_password = $('#register_password').val();
    let password_confirm = $('#password_confirm').val();

    console.log(register_name.length, register_email.length, register_password.length, password_confirm.length)

    if (register_password !== password_confirm) {
        $('#register_message').text('Mật khẩu không khớp');
        return;
    }

    var data = {
        "name": register_name,
        "username": register_email,
        "password": register_password,
        "isEmployerSignUp": false
    };

    if (register_name.length > 0 && register_email.length > 0 && register_password.length > 0) {
        $.ajax({
            url: "/authentication/sign-up",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            complete: function (response) {
                if (response.status !== 200) {
                    $('#register_message').text(response.responseText);
                } else {

                }
            }
        });
    }
})