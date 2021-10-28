function RemoveTextBox(button) {
    var text = button.id;
    var id = parseInt(text, 10);
    removed.push(id);

    $(button).parent().parent().remove();
}
function valider() {
    var idres = parseInt(document.getElementById("reservationId").value, 10);
    $.ajax({
        headers: { RequestVerificationToken: $("#GetToken").val() },
        dataType: "json",
        url: "../Editer",
        traditional: true,
        data: {
            reservationId: idres,
            removed: removed
        },
        success: function (data) {
            window.location.href = data.redirectToUrl;
        }
    });
}