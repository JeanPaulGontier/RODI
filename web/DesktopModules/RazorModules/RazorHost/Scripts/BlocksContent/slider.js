if (typeof resizeslider == 'undefined')
    resizeslider = [];
var slfnname = '@Html.Raw(slider_name)';
resizeslider[slfnname] = function () {
    var container = document.getElementById('@slider_name');
    var width = container.getBoundingClientRect().width;
    /* attention : une fois minifié il faut enlever les guillemets pour @Html.Raw(Yemon.dnn.Functions.Serialize(ratios))' */
    var ratios = '@Html.Raw(Yemon.dnn.Functions.Serialize(ratios))';
    var height = Number.MAX_SAFE_INTEGER;
    ratios.forEach((d) => {
        var h = Math.round(width * d.r, 0);
        height = Math.min(height, h);
    });
    ratios.forEach((d) => {
        var el = document.getElementById(d.g);
        el.style.minHeight = height + 'px';
        //    el.style.height = height + 'px';

    });
    container.style.height = height + 'px';
    console.log('@slider_name', ratios);
}