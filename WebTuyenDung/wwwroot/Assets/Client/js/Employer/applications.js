var load = function (status, month, keyWord, pageIndex, pageSize) {

    const userId = $('#user-id').val();

    $.ajax({
        url: `/api/applications/${userId}`,
        data: {
            //status: status,
            //month: month,
            //keyWord: keyWord,
            pageIndex: pageIndex,
            pageSize: pageSize
        },
        type: "GET",
        success: function (response) {
            var pageCurrent = pageIndex;
            var totalPages = response.totalPages;

            var str = "";
            var info = `Trang ${pageCurrent} / ${totalPages}`;
            $("#selection-datatable_info").text(info);

            var startSTT = ((pageCurrent - 1) * pageSize) + 1;

            $.each(response.data, function (index, value) {
                str += "<tr>";
                str += "<td>" + (startSTT + index) + "</td>";
                str += `<td><a target="_blank" href="/recruiment-news/${value.recruimentNewsId}">${value.jobName}</td>`;
                str += "<td>" + value.candidateName + "</td>";
                str += "<td>" + value.createdAt + "</td>";
                str += "<td><span class='badge badge-warning'>" + parseApplicationsStatus(value.status) + "</span></td>";
                str += `<td><a href='/employer/applications/view/${value.id}' target='_blank' class='btn btn-success'>Xem hồ sơ</a>`;
                str += `<br /><a href='/employer/applications/edit/${value.id}' class='btn btn-warning mt-1'>Cập nhật trạng thái</a></td>`;
                str += "</tr>";

                //create pagination
                var pagination_string = "";

                if (pageCurrent > 1) {
                    var pagePrevious = pageCurrent - 1;
                    pagination_string += '<li class="paginate_button page-item previous"><a href="#" class="page-link" data-page="' + pagePrevious + '">‹</a></li>';
                }
                for (var i = 1; i <= totalPages; i++) {
                    if (i == pageCurrent) {
                        pagination_string += '<li class="paginate_button page-item active"><a class="page-link" href="#" data-page=' + i + '>' + i + '</a></li>';
                    } else {
                        pagination_string += '<li class="paginate_button page-item"><a href="#" class="page-link" data-page=' + i + '>' + i + '</a></li>';
                    }
                }
                //create button next
                if (pageCurrent > 0 && pageCurrent < totalPages) {
                    var pageNext = pageCurrent + 1;
                    pagination_string += '<li class="paginate_button page-item next"><a href="#" class="page-link" data-page=' + pageNext + '>›</a></li>';
                }
                $("#load-pagination").html(pagination_string);
            });
            //load str to class="load-list"
            $("#datatablesSimple > tbody").html(str);
        }
    });
}