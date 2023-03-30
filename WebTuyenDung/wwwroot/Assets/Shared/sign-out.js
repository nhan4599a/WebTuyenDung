$('#sign-out').click((e) => {
    console.log('ok')
    e.preventDefault();
    $('#sign-out-form').submit();
})