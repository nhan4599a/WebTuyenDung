var load = function (keyWord, pageIndex, pageSize) {

    let isApprovedRawString = getQueryParams().isApproved;
    if (!isApprovedRawString) {
        isApprovedRawString = '1';
    }
    const isApproved = isApprovedRawString.toLowerCase() === '1';

    $.ajax({
        url: "/admin/recruiment-news/search",
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
                str += "<td>" + value.deadline + "</td>";
                str += "<td>" + value.view + "</td>";
                str += "<td><span class='badge badge-success'>" + value.status + "</span></td>";
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