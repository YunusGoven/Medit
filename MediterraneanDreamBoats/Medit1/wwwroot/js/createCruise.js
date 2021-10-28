function addTransits() {
    var select = document.getElementById('transitsPortsSelect');
    var depart = (document.getElementById('DeparturePortId')).value;
    var arrival = (document.getElementById('ArrivalPortId')).value;
    var port = select.value;
    var contains = false;
    for (let i = 0; i < transit.length && !contains; i++) {
        if (transit[i] === port) {
            contains = true;
        }
    }
    if (!contains && depart !==port && arrival !==port) {
        var div = $("<div />").attr("class", "row");
        var portName = select.options[select.selectedIndex].text;
        var box = $("<div />").attr("name", "TransitPortId[" + i + "]").attr("class", "col-md-8");
        var hidden = $("<input />").attr("type", "textbox").attr("name", "TransitPortId[" + i + "]").attr("hidden", "hidden").attr("value", port);
        box.append(hidden);
        box.append(portName);
        var button = $("<input />").attr("type", "button").attr("value", "Remove").attr("name",i).attr("id", port).attr("class", "btn btn-secondary col-md-4");
        button.attr("onclick", "RemoveTextBox(this)");
        div.append(box).append(button);
        i++;
        transit.push(port);
        $('#transitsPorts').append(div);
        askDistance();
    }
};

function RemoveTextBox(remove) {
    var name = remove.name;
    var hidden = $("<input />").attr("type", "textbox").attr("name", "TransitPortId[" + name + "]").attr("hidden", "hidden").attr("value", "-1");
    $('#transitsPorts').append(hidden);
    var pos = transit.indexOf(remove.id);
    transit.splice(pos, 1);
    $(remove).parent().remove();
    askDistance();
}

function askDistance() {
    var dep = document.getElementById("DeparturePortId").value;
    var arr = document.getElementById("ArrivalPortId").value;

    $(document).ready(function() {
        $.ajax({
            headers: { RequestVerificationToken: $("#GetToken").val() },
                dataType: 'json',
                traditional: true,
                url: "AskDistance",
                data: {
                    portDepartId: dep,
                    portArrivalId: arr,
                    portsTransitId: transit
            },
            success: function(data) {
                $('#Cruise_DistanceTotal').val(data);
            }
        });
    });
}