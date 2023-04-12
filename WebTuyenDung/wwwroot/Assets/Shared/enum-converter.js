const JOB_TYPE = ['Bán thời gian', 'Toàn thời gian', 'Làm việc remote từ xa']
const APPLICATIONS_STATUS = ['Đã nhận hồ sơ', 'Đã xem', 'Ứng viên tiềm năng', 'Đã hẹn phỏng vấn', 'Đã vượt qua phỏng vấn', 'Đã trượt ứng tuyển']

function parseJobType(numberValue) {
    return JOB_TYPE[numberValue]
}

function parseApplicationsStatus(numberValue) {
    return APPLICATIONS_STATUS[numberValue]
}