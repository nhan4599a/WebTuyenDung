$('#create-recruiment-news-form').submit((e) => {

    if ($('input[name=salary]:checked').val() === 'Khác') {
        const from = $('#salary-from').val();
        const to = $('#salary-to').val();

        if (from !== '' && to !== '') {
            $('input[name=salary]').val(`${from} - ${to} triệu`);
        } else if (from !== '' && to === '') {
            $('input[name=salary]').val(`Trên ${from}`);
        } else if (from === '' && to !== '') {
            $('input[name=salary]').val(`Dưới ${to}`);
        }
    }

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