
// Show apply form
__('.apply__cv--button, .apply__button--cancel, .apply--close, .main__apply').forEach((item) => {
    item.addEventListener('click', () => {
        _('.main__apply').classList.toggle('show');
    })
})

_('.main__apply--post').addEventListener('click', (e) => {
    e.stopPropagation();
})

// Show name file upload
//_('#cv_upload').addEventListener('change', (e) => {
//    var file = _('#cv_upload').files[0];
//    var message = _('.apply__content--uploadcv > span');

//    if (!file) {
//        message.innerText = null;
//        return;
//    }

//    if(file.size / (1024 * 1024) >= 5) {
//        message.style.color = 'red';
//        message.innerText = "Chỉ chấp nhận file dưới 5Mb";
//        return;
//    }

//    if(file.name.endsWith('.docx') || file.name.endsWith('.pdf') || file.name.endsWith('.doc')) {
//        message.style.color = 'black';
//        message.innerHTML = `${file.name} (${(file.size/1024).toFixed(3)}Kb)`;
//    }else {
//        message.style.color = 'red';
//        message.innerText = "Chỉ chấp nhận file định dạng .docx, .doc, .pdf";
//    }
//});

$('input[name=cv-type]').change(function () {
    const selectedValue = $(this).val();

    if (selectedValue === 'online') {
        $('#cv-type-radio-online-content').css({
            display: 'block'
        });

        $('#cv-type-radio-upload-content').css({
            display: 'none'
        });

        fetchCVs();
    } else {
        $('#cv-type-radio-online-content').css({
            display: 'none'
        });

        $('#cv-type-radio-upload-content').css({
            display: 'block'
        });
    }
})

function fetchCVs() {
    const listCVsContainer = $('#cv-type-radio-online-content');

    if (listCVsContainer.html() === '') {
        $.ajax({
            url: '/api/cv',
            success: data => {
                if (data.length === 0) {
                    listCVsContainer.html('<p class="text-danger">Hiện tại bạn chưa có CV nào, vui lòng sử dụng lựa chọn tải lên CV bên dưới</p>');
                } else {
                    let cvsHtml = ''

                    for (let cvItem of data) {
                        const url = cvItem.url ?? `/cv/${cvItem.id}`
                        cvsHtml += `<input type="radio" name="CVId" value="${cvItem.id}" />
                                        <a href="${url}" target="_blank">${cvItem.name}</a><br>`;
                    }

                    listCVsContainer.html(cvsHtml)
                }
            }
        })
    }
}

$('#cv_type-upload').change(() => {
    if ($('#cv_type-upload').is(":checked")) {
        $("input:radio[name='HoSo']").prop("checked", false);
    }
})

$('.main__apply--post').off('submit').submit((e) => {
    const selectedOnlineCvInput = $('#cv-type-radio-online-content > input[name=CVId]:checked');
    const uploadedCvInput = $('#cv-type-radio-upload-content > input[type=file]');

    if (selectedOnlineCvInput.length === 0 && uploadedCvInput.val() === '') {
        alert('Bạn chưa chọn hồ sơ ứng tuyển')
        return false
    }
})