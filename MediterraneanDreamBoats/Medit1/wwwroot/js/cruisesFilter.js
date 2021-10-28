$(document).ready(function () {
    $('#portname').autocomplete({
        source: function (request, response) {
            $.ajax({
                headers: { RequestVerificationToken: $("#GetToken").val() },
                datatype: 'json',
                url: 'Cruises/SearchPort',
                data: { portname: request.term },
                success: function (data) { response(data) }
            });
        }
    });
});