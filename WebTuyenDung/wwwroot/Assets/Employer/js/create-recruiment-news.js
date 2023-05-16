$('#create-recruiment-news-form').submit(() => {

    const salary = $('input[name=salary]').val()
    const minSalary = $('#salary-from').val()
    const maxSalary = $('#salary-to').val()

    if (salary == 'Khác' && (minSalary == '' && maxSalary == '')) {
        $('#salary-error').css({ display: 'block' })
        return false
    }

    let workingAddress = $('#workingAddress').val();
    const city = $('#input-city option:selected').text();
    const district = $('#input-district option:selected').text();
    const ward = $('#input-ward option:selected').text();

    workingAddress += `, ${ward}, ${district}, ${city}`;

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

const onSalaryChange = function (e) {
    console.log(e)

    const value = e.target.value

    console.log(value, e.data, e.inputType)

    if (e.inputType != 'deleteContentBackward' && !/\.|\d/.test(e.data)) {
        e.preventDefault()
        return
    }

    if (value == '' && !/\.|\d/.test(e.data)) {
        e.preventDefault()
    } else if (value.indexOf('.') != -1 && e.data == '.') {
        e.preventDefault()
    }
}

document.getElementById('salary-from').onbeforeinput = onSalaryChange

document.getElementById('salary-to').onbeforeinput = onSalaryChange