const JOB_TYPE = ['Bán thời gian', 'Toàn thời gian', 'Làm việc remote từ xa']

function parseJobType(numberValue) {
    return JOB_TYPE[numberValue]
}