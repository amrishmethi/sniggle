function socialWindow(posturl, medium) {
    debugger
    var url = window.location.href;
    var images = 'https://sniggle.in/' + $('#ContentPlaceHolder1_lblBigImg').text();
    var imgPintRest = $('#ContentPlaceHolder1_lblBigImg').text();
    var prodname = $('#ContentPlaceHolder1_lblCusrProdNameCustEnq').text();
    var img = $('#ContentPlaceHolder1_lblBigImg').text();
    var images1 = $('#lblBigImg').text();
    var prodname1 = $('#productName').text();
    if (img == '' || img == null) {
        images = 'https://sniggle.in/' + images1;
    }
    if (prodname == '' || prodname == null) {
        prodname = prodname1;
    }
    if (posturl == 'bolg') { 
        posturl = $('#ContentPlaceHolder1_lblBolgDtlUrl').text();
        prodname = $('#ContentPlaceHolder1_lblBolgName').text();
        imgPintRest = $('#ContentPlaceHolder1_lblBlogImg').text();
    }
    var sharer;
    switch (medium) {
        case 'fb':
            {
                sharer = 'https://www.facebook.com/sharer/sharer.php?u=' + posturl;
                break;
            }
        case 'twitter':
            {
                sharer = 'https://twitter.com/intent/tweet?text=' + prodname + ' ' + encodeURIComponent(posturl), 'sharertwt', 'toolbar=0,status=0,width=640,height=445';
                //sharer = 'https://twitter.com/intent/tweet?text=' + posturl + '&url=' + posturl;
                break;
            }
        case 'pinterest':
            {
                var sharing_url = posturl;
                //var img_url = images;
                var img_url = imgPintRest; 
                window.open('https://www.pinterest.com/pin/create/button/?media=' + img_url + '&url=' + sharing_url, 'sharerpinterest', 'toolbar=0,status=0,width=660,height=445');
                break;
            }
    }
    var w = 640;
    var h = 460;
    var sTop = window.screen.height / 2 - (h / 2);
    var sLeft = window.screen.width / 2 - (w / 2);
    var sharer = window.open(sharer, "sharer", "status=1,height=" + h + ",width=" + w + ",top=" + sTop + ",left=" + sLeft + ",resizable=0");
}