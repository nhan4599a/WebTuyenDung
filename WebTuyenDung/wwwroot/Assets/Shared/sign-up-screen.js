$(document).ready(() => {

    $('.input-group.date').datepicker({
        format: 'dd/mm/yyyy',
        startDate: moment().subtract(60, 'years').format('dd/MM/yyyy'),
        endDate: moment().subtract(18, 'years').format('dd/MM/yyyy')
    })
})

$('#sign-in__form').submit(e => {
    if ($('.btn-submit').hasClass('d-none')) {
        $('.btn-next').click()
        e.preventDefault()
    }
})

$('.btn-next').click(e => {
    e.preventDefault()
    $('#sign-in-error').html('')

    const username = $('input#username').val()
    const password = $('input#password').val()
    const rePassword = $('input#re-password').val()

    let validationError = ''

    if (!username || !password || !rePassword) {
        validationError += '<li>All fields are required</li>'
    }
    if (password !== rePassword) {
        validationError += `<li>Password does not match</li>`
    }

    const validatePasswordResult = validatePassword(password)
    if (validatePasswordResult) {
        validationError += `<li>${validatePasswordResult}</li>`
    }
    $('#sign-in-error').html(validationError)

    if (!validationError) {
        $.ajax({
            url: `/authentication/validate?username=${username}`,
            success: (data) => {

                if (!data) {
                    $('.sign-up-first-batch').css({
                        display: 'none'
                    })

                    $('.form-floating:not(.sign-up-first-batch), .form-group:not(.sign-up-first-batch)').removeClass('d-none')

                    $('.btn-next').addClass('d-none')
                    $('.btn-submit').removeClass('d-none')
                } else {
                    $('#sign-in-error').html('Username is already existed')
                }
            }
        })
    }
})

function validatePassword(password) {
    if (password.length < 6 && password > 63) {
        return 'Password phải từ 6 đến 63 ký tự'
    }

    const INVALID_PASSWORD_CHARS = ['$', '&', '<', '>', '(', ')', '/', '\\', '\'', '"', '`', '{', '}', ',', '~']

    let categoryCount = {};

    for (let i = 0; i < password.length; i++) {
        const char = password.charAt(i)

        if (INVALID_PASSWORD_CHARS.includes(char)) {
            return "Password must include lower, upper, digit and at least one of following characters ['.', '!', '@', '#', ' % ', ' ^']"
        }

        if (char.match(/[a-z]/)) {
            categoryCount.lower ??= 1;
        } else if (char.match(/[A-Z]/)) {
            categoryCount.upper ??= 1;
        } else if (char.match(/[0-9]/)) {
            categoryCount.number ??= 1;
        } else {
            categoryCount.other ??= 1;
        }
    }

    if (Object.keys(categoryCount).length !== 4) {
        return "Password must include lower, upper, digit and at least one of following characters ['.', '!', '@', '#', ' % ', ' ^']"
    }

    return ''
}   