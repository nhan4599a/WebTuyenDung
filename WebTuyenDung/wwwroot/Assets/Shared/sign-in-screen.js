$('#sign-in__form').submit(e => {
    e.preventDefault();

    const username = $('#username').val();
    const password = $('#password').val();

    let data = {
        "username": username,
        "password": password
    };

    if (username.length > 0 && password.length > 0) {

        $.ajax({
            url: "/authentication/sign-in",
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            complete: function (response) {
                $('#sign-in-error').text('');
                $('#username').parent().children('ul').remove();
                $('#password').parent().children('ul').remove();
                if (response.status === 403) {
                    $('#sign-in-error').text('You do not have permission to visit this page')
                }
                else if (response.status !== 200) {
                    if (response.responseText.startsWith('{')) {
                        const errorMessagesObj = JSON.parse(response.responseText);
                        const usernameErrorMessage = parseErrorMessagesToDOMElement(errorMessagesObj, 'Username');
                        const passwordErrorMessage = parseErrorMessagesToDOMElement(errorMessagesObj, 'Password');
                        if (usernameErrorMessage !== '') {
                            $('#username').parent().append(usernameErrorMessage);
                        }
                        if (passwordErrorMessage !== '') {
                            $('#password').parent().append(passwordErrorMessage);
                        }
                    } else {
                        $('#sign-in-error').text(response.responseText)
                    }
                } else {
                    window.location.href = getQueryParams().ReturnUrl ?? '/';
                }
            }
        });
    }
})

function parseErrorMessagesToDOMElement(errorMessagesObj, key) {
    if (errorMessagesObj[key]) {
        let innerHtml = '';
        for (let errorMessageItem of errorMessagesObj[key]) {
            innerHtml += `<li>${errorMessageItem}</li>`;
        }
        if (innerHtml !== '') {
            return `<ul class="error text-danger">${innerHtml}</ul>`;
        }
    }
    return '';
}