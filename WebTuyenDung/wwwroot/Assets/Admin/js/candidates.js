var load = function (keyWord, pageIndex, pageSize) {
    $.ajax({
        url: "/admin/candidates/search",
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
                str += "<td>" + (index + startSTT) + "</td>";
                str += "<td>" + value.name + "</td>";
                str += "<td>" + value.phoneNumber + "</td>";
                str += "<td>" + parseGender(value.gender) + "</td>";
                str += "<td>" + value.birthDay + "</td>";
                str += "<td>" + value.address + "</td>";
                str += '<td><a style="min-width: 90px" class="btn btn-success" href="/admin/candidates/' + value.id + '">Xem thông tin</a>';
                str += '<a class="btn btn-danger" href="#" data-user=' + value.id + ' style="margin-left: 15px">Xóa</a>';
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
$("body").on("click", "#datatablesSimple a.btn.btn-danger", function (event) {
    event.preventDefault();
    var userId = $(this).attr('data-user');
    if (confirm("Bạn có muốn xóa ứng viên này không?")) {
        $.ajax({
            url: "/api/users/" + userId,
            type: "DELETE",
            success: () => {
                location.reload();
            },
            error: () => {
                alert('Ứng viên này đã có thông tin, không thể xóa')
            }
        });
    }
});