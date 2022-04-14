function GetFromWired(_url) {
    $.ajax({
        url: "/quiz/getpost?url=" + _url,
        type: 'GET',
    })
        .done(function (data) {
            $("#floatingTextarea").html(data);
        })
        .fail(function () {
            alert("hata oluştu...");
        });

}

var ShowDiv = $("#showDiv");
var QTitle = $("#QTitle");

$.ajax({
    url: 'https://www.wired.com/feed/rss',
    type: 'GET',
    dataType: 'xml',
})
    .done(function (e) {
        var SelectList = `<select id="Posts" class="form-control mb-2"><option value="None" selected>Yazı Seçin</option>`;
        var link = "";
        var title = "";

        $("item", e).each(function (i, v) {
            if (i <= 4) {
                link = $("link", v).text();
                title = $("title", v).text();

                SelectList += `<option value="${link}" class="clickable">${title}</option>`;
            }

        });
        SelectList += `</select>`;
        ShowDiv.html(SelectList);
        $("#Posts").on('change', function (event) {
            QTitle.val($(this).children("option:selected").text());
            GetFromWired($("#Posts").val());
        });

    })
    .fail(function () {
        alert("hata veriler çekilemedi");
    });