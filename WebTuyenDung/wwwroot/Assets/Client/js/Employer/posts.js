﻿var load = function (keyWord, pageIndex, pageSize) {

    const isApproved = getQueryParams().isApproved ?? 1;
    
    const userId = $('#user-id').val()
    const username = $('#username').val()

    $.ajax({
        url: `/api/posts/management/${userId}`,
        data: {
            keyWord: keyWord,
            pageIndex: pageIndex,
            pageSize: pageSize,
            isApproved: isApproved >= 1
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
                str += "<td><img src='" + value.image + "' width='50' height='50' ></td>";
                str += "<td>" + value.title + "</td>";
                str += "<td>" + username + "</td>";
                str += "<td>" + value.createdAt + "</td>";
                str += "<td>" + value.view + "</td>";
                str += `<td><span class="bad bad-success">${isApproved == 0 ? 'Chưa được duyệt' : 'Đã duyệt'}</span></td>`
                if (isApproved == 0) {
                    str += `<td>
                                <a class="btn btn-warning" href="/employer/posts/edit/${value.id}">Sửa</a>`;
                    str += `<a style="margin-left: 15px" class="btn btn-danger" href="#" data-user="${value.id}">Xóa</a></td>`;
                } else {
                    str += `<td>
                                <a class="btn btn-danger ml-1" href="#" data-user="${value.id}">Xóa</a>
                            </td>`;
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

$("body").on("click", "#datatablesSimple a.btn.btn-danger", function (event) {
    event.preventDefault();
    var member_delete = $(this).attr('data-user');
    if (confirm("Bạn có muốn xóa bài viết có này không?")) {
        $.ajax({
            url: `/api/posts/${member_delete}`,
            type: "DELETE",
            success: () => {
                location.reload();
            }
        });
    }
});