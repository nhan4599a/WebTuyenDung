var load = function (keyWord, pageIndex, pageSize) {

    const isApproved = getQueryParams().isApproved ?? 0;

    $.ajax({
        url: "/employer/posts/search",
        data: {
            keyWord: keyWord,
            pageIndex: pageIndex,
            pageSize: pageSize
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
                str += "<td>" + value.author + "</td>";
                str += "<td>" + value.createdAt + "</td>";
                str += "<td>" + value.view + "</td>";
                str += "<td><span class='badge badge-success'>" + value.status + "</span></td>";
                if (isApproved == 0) {
                    str += `<td class="d-flex">
                                <a class="btn btn-warning" href="/employer/posts/edit/${value.id}">Sửa</a>
                            </td>`;
                    str += `<a class="btn btn-danger ml-1" href="#" data-user="${value.id}">Xóa</a>`;
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
    if (confirm("Bạn có muốn xóa bài viết có Mã = " + member_delete + " này không?")) {
        $.ajax({
            url: `/posts/delete/${member_delete}`,
            type: "DELETE",
            success: () => {
                location.reload();
            }
        });
    }
});