if (!resize) {
    var resize = [];
}
resize['@block.Guid'] = function () {
    var gallery = document.getElementById('@("gallery"+block.Guid)');
    var rect = gallery.getBoundingClientRect();
    var width = rect.width;
    const padding = 8;
    const marginv = 8;

    var y = [];
    var col = 0;
    var maxcol = Math.round(width / 300, 0);
    var pct = Math.round(100 / maxcol, 0);
    var colWidth = Math.round(width / maxcol, 0);
    for (var i = 0; i < maxcol; i++) {
        y.push(0);
    }
    /* attention : une fois minifié il faut enlever les guillemets pour @Html.Raw(images) */
    var images = '@Html.Raw(images)';
    var maxheight = 0;
    for (var i = 0; i < images.length; i++) {
        var c = document.getElementById(images[i].GUID);
        var im = images[i];
        let ratio = im.Height / im.Width;
        let height = Math.round(colWidth * ratio, 0) + marginv;
        let max = Number.MAX_SAFE_INTEGER;
        col = 0;
        for (var j = 0; j < maxcol; j++) {
            if (y[j] < max) {
                col = j;
                max = y[j];
            }
        }

        c.style.top = y[col] + 'px';
        c.style.left = col * colWidth + 'px';
        c.style.width = colWidth + 'px';
        c.style.height = height + 'px';
        c.style.padding = marginv + 'px ' + (padding / 2) + 'px 0px ' + (padding / 2) + 'px';
        y[col] += height;
        if (y[col] > maxheight)
            maxheight = y[col];

    };
    gallery.style.height = maxheight + 'px';
};
$(window).resize(resize['@block.Guid']);
$(document).ready(function () {
    resize['@block.Guid']();
});