﻿const JOB_TYPE = ['Bán thời gian', 'Toàn thời gian', 'Làm việc remote từ xa']
const APPLICATIONS_STATUS = ['Đã nhận hồ sơ', 'Đã xem', 'Ứng viên tiềm năng', 'Đã hẹn phỏng vấn', 'Đã vượt qua phỏng vấn', 'Đã trượt ứng tuyển']
const USER_ROLES = ['Ứng viên', 'Nhà tuyển dụng', 'Admin']
const GENDERS = ['Nam', 'Nữ']

function parseJobType(numberValue) {
    return JOB_TYPE[numberValue]
}

function parseApplicationsStatus(numberValue) {
    return APPLICATIONS_STATUS[numberValue]
}

function parseUserRole(numberValue) {
    return USER_ROLES[numberValue]
}

function parseGender(numberValue) {
    return GENDERS[numberValue]
}