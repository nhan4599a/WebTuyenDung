var isAdvancedUpload = function () {
    var div = document.createElement('div');
    return (('draggable' in div) || ('ondragstart' in div && 'ondrop' in div)) && 'FormData' in window && 'FileReader' in window;
}();

let draggableFileArea = document.querySelector(".drag-file-area");
let browseFileText = document.querySelector(".browse-files");
let uploadIcon = document.querySelector(".upload-icon");
let dragDropText = document.querySelector(".dynamic-message");
let fileInput = document.querySelector(".default-file-input");
let cannotUploadMessage = document.querySelector(".cannot-upload-message");
let cancelAlertButton = document.querySelector(".cancel-alert-button");
let uploadedFile = document.querySelector(".file-block");
let fileName = document.querySelector(".file-name");
let fileSize = document.querySelector(".file-size");
let progressBar = document.querySelector(".progress-bar");
let removeFileButton = document.querySelector(".remove-file-icon");
let uploadButton = document.querySelector(".upload-button");
let fileFlag = 0;
let uploadForm = document.querySelector('#upload-cv-form');
const ALLOWED_FILE_EXTENSIONS = ['doc', 'docx', 'pdf', 'png', 'jpg', 'jpeg']
const ERROR_MESSAGE_TEMPLATE = `<span class="material-icons-outlined">error</span> {0}
                                        <span class="material-icons-outlined cancel-alert-button">cancel</span>`;

fileInput.addEventListener("click", onClick);

fileInput.addEventListener("change", onFileChange);

uploadButton.addEventListener("click", () => {
    let isFileUploaded = fileInput.value;
    if (isFileUploaded != '') {
        if (fileFlag == 0) {
            fileFlag = 1;
        }
    } else {
        $(cannotUploadMessage).html(ERROR_MESSAGE_TEMPLATE.replace('{0}', 'Please select a file first'))
        cannotUploadMessage.style.cssText = "display: flex; animation: fadeIn linear 1.5s;";
    }
});

cancelAlertButton.addEventListener("click", () => {
    cannotUploadMessage.style.cssText = "display: none;";
});

if (isAdvancedUpload) {
    ["drag", "dragstart", "dragend", "dragover", "dragenter", "dragleave", "drop"].forEach(evt =>
        draggableFileArea.addEventListener(evt, e => {
            e.preventDefault();
            e.stopPropagation();
        })
    );

    ["dragover", "dragenter"].forEach(evt => {
        draggableFileArea.addEventListener(evt, e => {
            e.preventDefault();
            e.stopPropagation();
            uploadIcon.innerHTML = 'file_download';
            dragDropText.innerHTML = 'Drop your file here!';
        });
    });

    draggableFileArea.addEventListener("drop", e => {
        uploadIcon.innerHTML = 'check_circle';
        dragDropText.innerHTML = 'File Dropped Successfully!';
        document.querySelector(".label").innerHTML = `drag & drop or <span class="browse-files"> <input type="file" class="default-file-input" /> <span class="browse-files-text" style="top: -23px; left: -20px;"> browse file</span> </span>`;
        uploadButton.innerHTML = `Upload`;

        let files = e.dataTransfer.files;

        fileInput.files = files;
        fileName.innerHTML = files[0].name;
        fileSize.innerHTML = (files[0].size / 1024).toFixed(1) + " KB";
        uploadedFile.style.cssText = "display: flex;";
        progressBar.style.width = 0;
        fileFlag = 0;

        document.querySelector(".default-file-input").addEventListener('change', onFileChange)
    });
}

removeFileButton.addEventListener("click", () => {
    uploadedFile.style.cssText = "display: none;";
    fileInput.value = '';
    uploadIcon.innerHTML = 'file_upload';
    dragDropText.innerHTML = 'Drag & drop any file here';
    document.querySelector(".label").innerHTML = `or <span class="browse-files"> <input type="file" class="default-file-input" name="CV" /> <span class="browse-files-text">browse file</span> <span>from device</span> </span>`;
    document.querySelector(".default-file-input").addEventListener('change', onFileChange)
    uploadButton.innerHTML = `Upload`;
});

uploadForm.addEventListener('submit', e => {
    e.preventDefault();

    let tempData = $(uploadForm).serializeArray();

    if (!tempData[1].value) {
        $('#upload-form-error').text('You must input name for cv')
        return
    }
    if (fileInput.files.length === 0) {
        $(cannotUploadMessage).html(ERROR_MESSAGE_TEMPLATE.replace('{0}', 'Please select a file first'))
        return
    }

    let formData = new FormData();
    formData.append('__RequestVerificationToken', tempData[0].value)
    formData.append('name', tempData[1].value);
    formData.append('cv', fileInput.files[0]);

    $.ajax({
        url: '/cv/upload',
        method: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: () => {
            _('.main__upload').classList.toggle('show');
            alert('Upload cv thành công')
        },
        error: (response) => {
            $('#upload-form-error').text(JSON.parse(response.responseText)['Name'][0])
        }
    })
})

function getFileExtension(fileName) {
    const lastIndexOfDotCharacter = fileName.lastIndexOf('.')
    if (lastIndexOfDotCharacter === -1) {
        return ''
    }
    return fileName.substring(lastIndexOfDotCharacter + 1)
}

function onFileChange() {
    const fileExtension = getFileExtension(this.files[0].name)
    cannotUploadMessage.style.cssText = "display: none";
    if (!ALLOWED_FILE_EXTENSIONS.includes(fileExtension)) {
        this.files.length = 0
        this.value = ''
        $(cannotUploadMessage).html(ERROR_MESSAGE_TEMPLATE.replace('{0}', `.${fileExtension} file is not allowed`))
        cannotUploadMessage.style.cssText = "display: flex; animation: fadeIn linear 1.5s;";
        return
    }
    uploadIcon.innerHTML = 'check_circle';
    dragDropText.innerHTML = 'File Dropped Successfully!';
    document.querySelector(".label").innerHTML = `drag & drop or <span class="browse-files"> <input type="file" name="CV" class="default-file-input" /> <span class="browse-files-text" style="top: 0; left: 10px"> browse file</span></span>`;
    document.querySelector(".default-file-input").addEventListener('change', onFileChange)
    uploadButton.innerHTML = `Upload`;
    fileName.innerHTML = this.files[0].name;
    fileSize.innerHTML = (this.files[0].size / 1024).toFixed(1) + " KB";
    uploadedFile.style.cssText = "display: flex;";
    progressBar.style.width = 0;
    fileFlag = 0;
    fileInput = this;
}

function onClick() {
    this.value = '';
    this.files.length = 0
}