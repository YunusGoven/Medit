function addChamp() {
    if (max > 1) {
        var name = $("<input />").attr("type", "textbox").attr("name", "Participants[" + i + "].Name").attr("required", "required").attr("placeholder", "Nom");
        var firstname = $("<input />").attr("type", "textbox").attr("name", "Participants[" + i + "].FirstName").attr("required", "required").attr("placeholder", "Prénom");
        var ddn = $("<input />").attr("type", "date").attr("name", "Participants[" + i + "].BirthDate").attr("required", "required").attr("placeholder", "Date de naissance");
        var namediv = $("<div />").attr("class", "col-md-4");
        namediv.append(name);
        var firstnamediv = $("<div />").attr("class", "col-md-4");
        firstnamediv.append(firstname);
        var ddndiv = $("<div />").attr("class", "col-md-4");
        ddndiv.append(ddn);
        var containerdiv = $("<div />").attr("class", "container row");
        containerdiv.append(namediv).append(firstnamediv).append(ddndiv);
        var btndiv = $("<div />").attr("class", "col-md-1");
        var button = $("<input />").attr("type", "button").attr("value", "Remove").attr("name", i).attr("class", "btn btn-danger");
        button.attr("onclick", "RemoveTextBox(this)");
        btndiv.append(button);
        containerdiv.append(btndiv);


        $('#participantContainer').append(containerdiv);
        i++;
        max--;
    }
}

function RemoveTextBox(button) {
    var name = button.name;
    var hidden = $("<input />").attr("type", "textbox").attr("name", "Participants[" + name + "].Name").attr("hidden", "hidden").attr("value", "-1");
    var hiddenprenom = $("<input />").attr("type", "textbox").attr("name", "Participants[" + name + "].FirstName").attr("hidden", "hidden").attr("value", "-1");
    var hiddenddn = $("<input />").attr("type", "textbox").attr("name", "Participants[" + name + "].BirthDate").attr("hidden", "hidden").attr("value", "03/11/1999");
    $('#participantContainer').append(hidden).append(hiddenprenom).append(hiddenddn);
    $(button).parent().parent().remove();
    max++;
}