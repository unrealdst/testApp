function sendRequest() {
    $.ajax({
        url: 'http://localhost:58617/Home/Calculate',
        type: 'GET',
        data: {
            depth: $("#user-input .depth").val(),
            width: $("#user-input .width").val(),
            height: $("#user-input .height").val(),
            weight: $("#user-input .weight").val()
        },
        success: function (data) {
            if (data.Success) {
                $("#calculation-result").html(data.Data);
                $("#errors-section").html("");
            }
            else {
                $("#errors-section").html(data.Data);
            }
        }
    });
}