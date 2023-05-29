var load = function (keyWord, pageIndex, pageSize) {
    $.ajax({
        url: "/api/employers",
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
                str += "<td>" + value.name + "</td>";
                str += "<td>" + value.phoneNumber + "</td>";
                str += "<td>" + value.size + "</td>";
                str += "<td>" + value.address + "</td>";
                str += "<td>" + value.website + "</td>";
                if (value.isApproved) {
                    str += `<td>
                                <a style="min-width: 90px" class="btn btn-success" href="/admin/employers/${value.id}">Xem thông tin</a>
                                <a class="btn btn-success" style="margin-left: 15px" href="#" data-user="${value.id}" data-action="make-as-paid">Đánh dấu đã thanh toán</a>
                                <a class="btn btn-danger" style="margin-left: 15px" href="#" data-user="${value.id}" data-action="delete">Xóa</a>
                            </td>`
                } else {
                    str += `<td>
                                <a style="min-width: 90px" class="btn btn-success" href="/admin/employers/${value.id}">Xem thông tin</a>
                                <a style="min-width: 90px" class="btn btn-success" href="#" data-user="${value.id}" data-action="approve">Duyệt</a>
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

//click delete button
$("body").on("click", "#datatablesSimple a.btn[data-action]", function (event) {
    event.preventDefault();
    const userId = $(this).data('user');
    const action = $(this).data('action');

    if (action === 'approve') {
        if (confirm('Bạn có muốn duyệt nhà tuyển dụng này không?')) {
            $.ajax({
                url: "/api/users/approve/" + userId,
                type: "PATCH",
                success: () => {
                    location.reload();
                }
            });
        }
    } else if (action === 'make-as-paid') {
        if (confirm('Bạn có muốn xác nhận đánh dấu nhà tuyển dụng này đã thanh toán tiền nợ không?')) {
            $.ajax({
                url: "/api/employers/make-as-paid/" + userId,
                type: "PATCH",
                success: () => {
                    location.reload();
                }
            });
        }
    } else {
        if (confirm('Bạn có muốn xóa nhà tuyển dụng này không?')) {
            $.ajax({
                url: "/api/users/" + userId,
                type: "DELETE",
                success: () => {
                    location.reload();
                }
            });
        }
    }
});