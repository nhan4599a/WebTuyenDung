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
            const pageCurrent = pageIndex;
            const totalPage = response.totalPages;

            let str = "";
            const info = `Trang ${pageCurrent} / ${totalPage}`;
            const startSTT = ((pageCurrent - 1) * pageSize) + 1;
            const userId = $('#user-id').val()
            $("#selection-datatable_info").text(info);
            $.each(response.data, function (index, value) {
                str += "<tr>";
                str += "<td>" + (startSTT + index) + "</td>";
                str += "<td>" + value.username + "</td>";
                str += "<td>" + parseUserRole(value.role) + "</td>";
                str += "<td>" + value.createdAt + "</td>";
                str += "<td>Hoạt động</td>";
                str += '<td class="d-flex justify-content-around">';
                if (value.role != 2) {
                    str += '<a class="btn btn-danger" href="#" data-user=' + value.id + ' data-action="remove">Xóa</a>';
                }
                if (value.role == 0 || (value.role == 2 && value.id != userId)) {
                    str += `<a class="btn btn-success" href="#" data-user='${value.id}' data-target='${value.role == 0 ? 2 : 0}' data-action="role-assign">Gán làm ${value.role == 0 ? 'Admin' : 'Ứng viên'}</a></td>`
                }
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
$("body").on("click", "#datatablesSimple a.btn.btn-danger[data-action]", function (event) {
    event.preventDefault();

    const action = $(this).data('action')
    const user_delete = $(this).attr('data-user');

    if (action === 'remove') {
        if (confirm(`Bạn có muốn xóa tài khoản có id = "${user_delete}" này không?`)) {
            $.ajax({
                url: "/api/users/" + user_delete,
                type: "DELETE",
                success: () => {
                    location.reload();
                },
                error: () => {
                    alert('User này đã có thông tin, không thể xóa')
                }
            });
        }
    } else {
        const targetRole = $(this).data('target')

        if (confirm(`Bạn có muốn gán tài khoản có id = "${user_delete}" này thành ${parseUserRole(targetRole)} không?`)) {
            $.ajax({
                url: "/api/users/" + user_delete,
                type: "patch",
                data: {
                    role: targetRole
                },
                success: () => {
                    location.reload();
                }
            });
        }
    }
});