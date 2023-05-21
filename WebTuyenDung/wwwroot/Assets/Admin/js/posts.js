var load = function (keyWord, pageIndex, pageSize) {

    let isApprovedRawString = getQueryParams().isApproved;
    if (!isApprovedRawString) {
        isApprovedRawString = '1';
    }
    const isApproved = isApprovedRawString.toLowerCase() === '1';

    $.ajax({
        url: "/api/posts/management",
        data: {
            keyWord: keyWord,
            pageIndex: pageIndex,
            pageSize: pageSize,
            isApproved
        },
        type: "GET",
        success: function (response) {
            var pageCurrent = response.totalPages === 0 ? 0 : pageIndex;
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
                if (isApproved) {
                    str += "<td>" + value.view + "</td>";
                }
                str += "<td><span class='badge badge-success'>" + (isApproved ? 'Đã duyệt' : 'Chưa được duyệt') + "</span></td>";
                str += '<td><a class="btn btn-warning" href="/admin/posts/edit/' + value.id + '">Cập nhật</a>';
                if (isApproved) {
                    str += `<a class="btn btn-danger ml-1" href="#" data-user="${value.id}" data-action="delete">Xóa</a>`;
                } else {
                    str += `<a style="min-width: 95px; margin-left: 15px" class="btn btn-success" href="#" data-user="${value.id}" data-action="approve">Duyệt bài</a>`;
                }
                str += "</td></tr>";

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
$("body").on("click", "#datatablesSimple a.btn[data-action]", function (event) {
    event.preventDefault();
    let postId = $(this).attr('data-user');
    let action = $(this).data('action');
    let question = 'Bạn có muốn ' + (action === 'approve' ? 'duyệt ' : 'xóa ') + `bài viết có Mã = ${postId} này không?`;

    if (confirm(question)) {
        $.ajax({
            url: "/api/posts/" + (action === 'approve' ? 'approve/' : '') + `${postId}`,
            type: action === 'approve' ? "PUT" : 'DELETE',
            success: () => {
                location.reload();
            }
        });
    }
});