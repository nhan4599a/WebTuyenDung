$(document).ready(() => {
    $('.input-group.date').datepicker({
        format: 'dd/mm/yyyy'
    })
})

$('sign-form__form').submit(e => {
    e.preventDefault()
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

                    $('.btn-next').removeClass('btn-next').text('Đăng ký')
                } else {
                    $('#sign-in-error').html('Username is already existed')
                }
            }
        })
    }
})