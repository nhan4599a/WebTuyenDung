var load = function (keyWord, pageIndex, pageSize) {

    let isApprovedRawString = getQueryParams().isApproved;
    if (!isApprovedRawString) {
        isApprovedRawString = '1';
    }

    const isApproved = isApprovedRawString === '1';

    console.log(isApproved)

    $.ajax({
        url: "/api/recruiment-news/management",
        data: {
            keyWord: keyWord,
            pageIndex: pageIndex,
            pageSize: pageSize,
            mode: isApproved ? 0 : 1
        },
        type: "GET",
        success: function (response) {
            var pageCurrent = pageIndex;
            var totalPages = response.totalPages;

            var str = "";
            var info = `Trang ${pageCurrent} / ${totalPages}`;
            var startSTT = ((pageCurrent - 1) * pageSize) + 1;
            $("#selection-datatable_info").text(info);
            $.each(response.data, function (index, value) {
                str += "<tr>";
                str += "<td>" + (startSTT + index) + "</td>";
                str += "<td>" + value.jobName + "</td>";
                str += "<td>" + value.employerName + "</td>";
                str += "<td>" + value.numberOfCandidates + "</td>";
                str += "<td>" + value.createdAt + "</td>";
                str += "<td>" + (value.deadline ?? 'Vô thời hạn') + "</td>";
                str += "<td>" + value.view + "</td>";
                if (isApproved) {
                    str += "<td><span class='badge badge-success'>Đã phê duyệt</span></td>";
                } else {
                    str += "<td><span class='badge badge-warning'>Chờ phê duyệt</span></td>";
                }
                if (!isApproved) {
                    str += `<td>
                                <a class="btn btn-success mt-1" href="#" data-id="${value.id}">Duyệt bài</a>
                            </td>`
                }
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

$('body').on('click', '#datatablesSimple a.btn.btn-success', function (e) {
    e.preventDefault();

    const recruimentNewsId = $(this).data('id');

    if (confirm(`Bạn có muốn duyệt tin tuyển dụng có Mã = ${recruimentNewsId} này không?`)) {
        $.ajax({
            url: `/api/recruiment-news/approve/${recruimentNewsId}`,
            type: 'PUT',
            success: () => {
                location.reload();
            }
        })
    }
})