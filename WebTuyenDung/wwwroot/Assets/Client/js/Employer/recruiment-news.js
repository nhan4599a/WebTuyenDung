var load = function (keyWord, pageIndex, pageSize) {

    const mode = getQueryParams().mode ?? 0;

    $.ajax({
        url: "/employer/recruiment-news/search",
        data: {
            keyWord: keyWord,
            pageIndex: pageIndex,
            pageSize: pageSize,
            mode: mode
        },
        type: "GET",
        success: function (response) {
            var pageCurrent = parseInt(pageIndex);
            var totalPages = response.totalPages;

            var str = "";
            var info = `Trang ${pageCurrent} / ${totalPages}`;
            var startSTT = ((pageCurrent - 1) * pageSize) + 1;

            $("#selection-datatable_info").text(info);
            $.each(response.data, function (index, value) {
                str += "<tr>";
                str += "<td>" + (startSTT + index) + "</td>";
                str += `<td><a target="_blank" href="/recruiment-news/${value.id}">${value.title}</td>`;
                str += "<td>" + value.numberOfCandidates + "</td>";
                str += "<td>" + value.createdAt + "</td>";
                str += "<td>" + value.deadline + "</td>";
                str += "<td>" + value.view + "</td>";
                str += "<td><span class='badge badge-success'>" + value.status + "</span></td>";
                if (mode == 0 || mode == 1) {
                    str += `<td class="d-flex"><a class="btn btn-warning" href="/employer/recruiment-news/edit/${value.id}">Sửa</a>`;
                    str += `<a class="btn btn-danger ml-1" href="#" data-user="${value.id}">Xóa</a>`;
                } else if (mode == 2) {
                    str += `<td class="d-flex"><a class="btn btn-danger ml-1" href="/employer/recrument-news/edit/${value.id}">Gia hạn thêm</a></td>`
                }

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

//click delete button
$("body").on("click", "#datatablesSimple a.btn.btn-danger", function (event) {
    event.preventDefault();
    var member_delete = $(this).attr('data-user');
    if (confirm("Bạn có muốn xóa tin tuyển dụng có Mã = " + member_delete + " này không?")) {
        $.ajax({
            url: `/employer/recruiment-news/delete/${member_delete}`,
            type: "DELETE",
            success: () => {
                location.reload();
            }
        });
    }
});