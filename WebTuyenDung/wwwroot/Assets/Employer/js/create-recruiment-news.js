$('#create-recruiment-news-form').submit((e) => {

    let workingAddress = $('#workingAddress').val();
    const city = $('#input-city option:selected').text();
    const district = $('#input-district option:selected').text();
    const ward = $('#input-ward option:selected').text();

    workingAddress += ` ,${ward}, ${district}, ${city}`;

    $('#workingAddress').val(workingAddress)

    return true;
});

$('input[name=salary]').change(function () {
    $('#salary-from, #salary-to').val('')
    if ($(this).val() !== 'Khác') {
        $('#salary-from, #salary-to').prop('disabled', true)
    } else {
        $('#salary-from, #salary-to').prop('disabled', false)
    }
})