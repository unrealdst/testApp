function sendRequest() {
    $.ajax({
        url: 'http://localhost:58617/Home/Calculate',
        type: 'GET',
        data: {
            depth: $("#depth").val(),
            width: $("#width").val(),
            height: $("#height").val(),
            weight: $("#weight").val()
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