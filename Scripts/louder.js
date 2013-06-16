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
        else
            $('div.chant-detail').html("");
    });
    /*
    $("#btn-history").click(function () {
        context["current-chant-detail"] = "history";

        if (context["current-chant"].HISTORY != null)
            $('div.chant-detail').html(context["current-chant"].HISTORY);
        else
            $('div.chant-detail').html("");
    });
    */
    $("#btn-errata").click(function () {
        context["current-chant-detail"] = "errata";

        if (context["current-chant"].ERRATA != null)
            $('div.chant-detail').html(context["current-chant"].ERRATA);
        else
            $('div.chant-detail').html("");
    });
});

function LoadLatestChant() {
    $.get('/api/latestchant', function (data) {
        console.log("loading latest chant: " + data.CHANT_NAME);
        context["current-chant"] = data;
        $('div.latest-chant').html("<h3>Singing: " + data.CHANT_NAME + "</h3>");
        //SetAlbumImage();
        SetChantDetail();
    });
}

function Vote(chantId) {
    console.log("voting for " + chantId);
    $.ajax({
        type: "POST",
        data: {'chantId': chantId },
        url: "/vote/addVote",
        dataType: "json"
    });

    apprise("Thanks for voting!");
}


function SetChantDetail() {
    if (context["current-chant-detail"] == "lyrics")
        if (context["current-chant"].LYRICS != null)
            $('div.chant-detail').html(context["current-chant"].LYRICS.replace(/(\r\n|\n|\r)/gm, "<br>"));
        else
            $('div.chant-detail').html("");
    /*
    if (context["current-chant-detail"] == "history")
        if (context["current-chant"].HISTORY != null)
            $('div.chant-detail').html(context["current-chant"].HISTORY);
        else
            $('div.chant-detail').html("");
    */
    if (context["current-chant-detail"] == "errata")
        if (context["current-chant"].ERRATA != null)
            $('div.chant-detail').html(context["current-chant"].ERRATA);
        else
            $('div.chant-detail').html("");
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

function SetAlbumImage() {
    console.log("setting background." + "'/content/images/" + context["current-chant"].ALBUM_ART);
    $('div.latest-chant-container').css("background-image", "url('/content/images/" + context["current-chant"].ALBUM_ART + "')");
    $('div.latest-chant-container').css("background-repeat", "no-repeat");
}

function ClearVotes() {
    $.ajax({
        type: "POST",
        url: "/vote/clearvotes",
        success: function () { window.location.href = '/vote/topvotes'; },
    });
}