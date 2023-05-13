var load = function (keyWord, pageIndex, pageSize) {
    $.ajax({
        url: "/admin/users/search",
        data: {
            keyWord: keyWord,
            pageIndex: pageIndex,
            pageSize: pageSize
        },
        type: "GET",
        success: function (response) {
            var pageCurrent = pageIndex;
            var totalPage = response.totalPages;

            var str = "";
            var info = `Trang ${pageCurrent} / ${totalPage}`;
            var startSTT = ((pageCurrent - 1) * pageSize) + 1;
            $("#selection-datatable_info").text(info);
            $.each(response.data, function (index, value) {
                str += "<tr>";
                str += "<td>" + (startSTT + index) + "</td>";
                str += "<td>" + value.username + "</td>";
                str += "<td>" + parseUserRole(value.role) + "</td>";
                str += "<td>" + value.createdAt + "</td>";
                str += "<td>Hoạt động</td>";
                str += '<td class="d-flex justify-content-around"><a class="btn btn-warning" href="/admin/users/edit/' + value.id + '">Cập nhật</a>';
                str += '<a class="btn btn-danger" href="#" data-user=' + value.id + '>Xóa</a>';
                str += '<a class="btn btn-success" href="/Admin/User/RoleAssign/' + value.id + '">Phân quyền</a></td>'
                str += "</tr>";

                //create pagination
                var pagination_string = "";

                if (pageCurrent > 1) {
                    var pagePrevious = pageCurrent - 1;
                    pagination_string += '<li class="paginate_button page-item previous"><a href="#" class="page-link" data-page="' + pagePrevious + '">‹</a></li>';
                }
                for (var i = 1; i <= totalPage; i++) {
                    if (i == pageCurrent) {
                        pagination_string += '<li class="paginate_button page-item active"><a class="page-link" href="#" data-page=' + i + '>' + i + '</a></li>';
                    } else {
                        pagination_string += '<li class="paginate_button page-item"><a href="#" class="page-link" data-page=' + i + '>' + i + '</a></li>';
                    }
                }
                //create button next
                if (pageCurrent > 0 && pageCurrent < totalPage) {
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
    var user_delete = $(this).attr('data-user');
    if (confirm("Bạn có muốn xóa tài khoản có id = " + user_delete + " này không?")) {
        $.ajax({
            url: "/api/admin/users/" + user_delete,
            type: "DELETE",
            success: () => {
                location.reload();
            }
        });
    }
});