$(document).ready(() => {
    getLocales(null, (cityData) => {

        const selectedCity = $('#input-city').data('selected')
        $('#input-city').html(buildLocaleSelectOptions(cityData, 'Thành phố', selectedCity))

        if ($('#input-district')) {

            $('#input-city').change(function () {
                const cityId = this.value;

                getLocales(cityId, (districtData) => {

                    const selectedDistrict = $('#input-district').data('selected')

                    $('#input-district')
                        .html(buildLocaleSelectOptions(districtData, 'Quận', selectedDistrict))
                        .prop('disabled', false)
                        .selectpicker('refresh', {
                            noneSelectedText: '-- Quận --'
                        })

                    if ($('#input-ward')) {
                        $('#input-district').change(function () {
                            const districtId = this.value;

                            getLocales(districtId, (wardData) => {

                                const selectedWard = $('#input-ward').data('selected')

                                $('#input-ward')
                                    .prop('disabled', false)
                                    .html(buildLocaleSelectOptions(wardData, 'Phường', selectedWard))
                                    .selectpicker('refresh', {
                                        noneSelectedText: '-- Phường --'
                                    })
                            })
                        })
                    }
                })
            })
        }
    })
})

function getLocales(localeParent, complete) {
    $.ajax({
        url: localeParent ? `/api/locales/${localeParent}` : '/api/locales',
        success: complete
    })
}

function buildLocaleSelectOptions(data, top, selectedItem) {
    let options = `'<option value="">-- ${top} --</option>`
    for (let item of data) {
        if (item.id == selectedItem) {
            options += `<option value="${item.id}" selected>${item.name}</option>`
        } else {
            options += `<option value="${item.id}">${item.name}</option>`
        }
    }
    return options;
}