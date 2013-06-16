var context = {
    'current-chant-detail': 'lyrics',
    'current-chant': undefined,
};

$(document).ready(function () {
    LoadLatestChant();
    
    window.setInterval(LoadLatestChant, 5000);

    $("#btn-lyrics").click(function () {
        context["current-chant-detail"] = "lyrics";

        if (context["current-chant"].LYRICS != null)
            $('div.chant-detail').html(context["current-chant"].LYRICS.replace(/(\r\n|\n|\r)/gm, "<br>"));
    });
    
    $("#btn-history").click(function () {
        context["current-chant-detail"] = "history";

        if (context["current-chant"].HISTORY != null)
            $('div.chant-detail').html(context["current-chant"].HISTORY);
    });
    
    $("#btn-errata").click(function () {
        context["current-chant-detail"] = "errata";

        if (context["current-chant"].ERRATA != null)
            $('div.chant-detail').html(context["current-chant"].ERRATA);
    });
});

function LoadLatestChant() {
    $.get('/api/latestchant', function (data) {
        console.log("loading latest chant: " + data.CHANT_NAME);
        context["current-chant"] = data;
        $('div.latest-chant').html("<b>Latest:  </b>" + data.CHANT_NAME);
        SetChantDetail();
    });
}

function AddUser() {
    console.log($('form').serialize());
    $.ajax({
        type: "POST",
        url: "/user/addUser",
        data: $('user').serialize(),
        dataType: "json"
    });
}

function SetChantDetail() {
    if (context["current-chant-detail"] == "lyrics")
        if (context["current-chant"].LYRICS != null)
            $('div.chant-detail').html(context["current-chant"].LYRICS.replace(/(\r\n|\n|\r)/gm, "<br>"));
    
    if (context["current-chant-detail"] == "history")
        if (context["current-chant"].HISTORY != null)
            $('div.chant-detail').html(context["current-chant"].HISTORY);
    
    if (context["current-chant-detail"] == "errata")
        if (context["current-chant"].ERRATA!= null)
            $('div.chant-detail').html(context["current-chant"].ERRATA);
}

function SetCurrentChant(chantId) {
    console.log("seting current chant to: " + chantId);
    $.ajax({
        type: "POST",
        url: "/capo/create",
        data: { 'chantId': chantId },
        dataType: "json"
    });
}