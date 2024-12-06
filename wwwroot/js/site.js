function validateContent() {
    var textdata = document.getElementById('SentimentText').innerText;
    var status = "";
    var data = {
        text: textdata
    };

    $.ajax({
        url: "/api/SentimentEngine?text='"+textdata + "'",
        type: 'GET',
        //data: JSON.stringify(textdata),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert(data);
            status = data;
            console.log(data);
        },
        error: function (err) {
            console.log(err);
        }
    });

    return status;
}
