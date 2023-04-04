$(document).ready(() => {
    getLocales(null, (cityData) => {

        $('#input-city').html(buildLocaleSelectOptions(cityData, 'Thành phố'))

        if ($('#input-district')) {

            $('#input-city').change(function () {
                const cityId = this.value;

                getLocales(cityId, (districtData) => {
                    $('#input-district')
                        .html(buildLocaleSelectOptions(districtData, 'Quận'))
                        .prop('disabled', false)
                        .selectpicker('refresh', {
                            noneSelectedText: '-- Quận --'
                        })

                    if ($('#input-ward')) {
                        $('#input-district').change(function () {
                            const districtId = this.value;

                            getLocales(districtId, (wardData) => {
                                $('#input-ward')
                                    .prop('disabled', false)
                                    .html(buildLocaleSelectOptions(wardData, 'Phường'))
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
        url: localeParent ? `/locales/${localeParent}` : '/locales',
        success: complete
    })
}

function buildLocaleSelectOptions(data, top) {
    let options = `'<option value="">-- ${top} --</option>`
    for (let item of data) {
        options += `<option value="${item.id}">${item.name}</option>`
    }
    return options;
}