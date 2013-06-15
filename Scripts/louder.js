$(document).ready(function () {
    LoadLatestChant();
    
    window.setInterval(LoadLatestChant,5000);
});

function LoadLatestChant() {
    $.get('/api/latestchant', function (data) {
        console.log("loading latest chant: " + data.CHANT_NAME)
        $('div.latest-chant').html("<b>Latest:  </b>" + data.CHANT_NAME);
    });
}