/* ==================================================
Custom Easy Pie Chart
================================================== */

(function(){
	var pieChart = {
		init: function() {
			jQuery('.easy-pie-chart').each(function(){
				jQuery(this).easyPieChart({
					animate: 1000,
					lineCap: 'square',
					lineWidth:7,
					size: jQuery(this).attr('data-size'),
					barColor: jQuery(this).attr('data-barcolor'),
					trackColor: "#f1f1f1",
					scaleColor: 'transparent'
				});
			});
		},
		charts: function() {
			pieChart.animateCharts();
			jQuery(window).scroll(function() { 
				pieChart.animateCharts();
			});	
			jQuery(".home4_top h2").click(function() { 
				pieChart.animateCharts();
			});	
		},
		animateCharts: function() {
			jQuery('.easy-pie-chart:in-viewport').each(function(){
				if (!jQuery(this).hasClass('animated')) {
					jQuery(this).addClass('animated');
					var animatePercentage = parseInt(jQuery(this).attr('data-animatepercent'), 10);
					jQuery(this).data('easyPieChart').update(animatePercentage);
				}
			});
		}
	};
	var onReady = {
		init: function(){
			pieChart.init();
		}
	};
	var onLoad = {
		init: function(){
			pieChart.charts();
		}
	};
	jQuery(document).ready(onReady.init);
	jQuery(window).load(onLoad.init);
})(jQuery);

/**!
 * easyPieChart
 * Lightweight plugin to render simple, animated and retina optimized pie charts
 *
 * @license Dual licensed under the MIT (http://www.opensource.org/licenses/mit-license.php) and GPL (http://www.opensource.org/licenses/gpl-license.php) licenses.
 * @author Robert Fleischmann <rendro87@gmail.com> (http://robert-fleischmann.de)
 * @version 2.1.1
 **/
!function(a,b){"object"==typeof exports?module.exports=b(require("jquery")):"function"==typeof define&&define.amd?define("EasyPieChart",["jquery"],b):b(a.jQuery)}(this,function(a){var b=function(a,b){var c,d=document.createElement("canvas");"undefined"!=typeof G_vmlCanvasManager&&G_vmlCanvasManager.initElement(d);var e=d.getContext("2d");d.width=d.height=b.size,a.appendChild(d);var f=1;window.devicePixelRatio>1&&(f=window.devicePixelRatio,d.style.width=d.style.height=[b.size,"px"].join(""),d.width=d.height=b.size*f,e.scale(f,f)),e.translate(b.size/2,b.size/2),e.rotate((-0.5+b.rotate/180)*Math.PI);var g=(b.size-b.lineWidth)/2;b.scaleColor&&b.scaleLength&&(g-=b.scaleLength+2),Date.now=Date.now||function(){return+new Date};var h=function(a,b,c){c=Math.min(Math.max(0,c||1),1),e.beginPath(),e.arc(0,0,g,0,2*Math.PI*c,!1),e.strokeStyle=a,e.lineWidth=b,e.stroke()},i=function(){var a,c,d=24;e.lineWidth=1,e.fillStyle=b.scaleColor,e.save();for(var d=24;d>0;--d)0===d%6?(c=b.scaleLength,a=0):(c=.6*b.scaleLength,a=b.scaleLength-c),e.fillRect(-b.size/2+a,0,c,1),e.rotate(Math.PI/12);e.restore()},j=function(){return window.requestAnimationFrame||window.webkitRequestAnimationFrame||window.mozRequestAnimationFrame||function(a){window.setTimeout(a,1e3/60)}}(),k=function(){b.scaleColor&&i(),b.trackColor&&h(b.trackColor,b.lineWidth)};this.clear=function(){e.clearRect(b.size/-2,b.size/-2,b.size,b.size)},this.draw=function(a){b.scaleColor||b.trackColor?e.getImageData&&e.putImageData?c?e.putImageData(c,0,0):(k(),c=e.getImageData(0,0,b.size*f,b.size*f)):(this.clear(),k()):this.clear(),e.lineCap=b.lineCap;var d;d="function"==typeof b.barColor?b.barColor(a):b.barColor,a>0&&h(d,b.lineWidth,a/100)}.bind(this),this.animate=function(a,c){var d=Date.now();b.onStart(a,c);var e=function(){var f=Math.min(Date.now()-d,b.animate),g=b.easing(this,f,a,c-a,b.animate);this.draw(g),b.onStep(a,c,g),f>=b.animate?b.onStop(a,c):j(e)}.bind(this);j(e)}.bind(this)},c=function(a,c){var d={barColor:"#ef1e25",trackColor:"#f9f9f9",scaleColor:"#dfe0e0",scaleLength:5,lineCap:"round",lineWidth:3,size:110,rotate:0,animate:1e3,easing:function(a,b,c,d,e){return b/=e/2,1>b?d/2*b*b+c:-d/2*(--b*(b-2)-1)+c},onStart:function(){},onStep:function(){},onStop:function(){}};if("undefined"!=typeof b)d.renderer=b;else{if("undefined"==typeof SVGRenderer)throw new Error("Please load either the SVG- or the CanvasRenderer");d.renderer=SVGRenderer}var e={},f=0,g=function(){this.el=a,this.options=e;for(var b in d)d.hasOwnProperty(b)&&(e[b]=c&&"undefined"!=typeof c[b]?c[b]:d[b],"function"==typeof e[b]&&(e[b]=e[b].bind(this)));e.easing="string"==typeof e.easing&&"undefined"!=typeof jQuery&&jQuery.isFunction(jQuery.easing[e.easing])?jQuery.easing[e.easing]:d.easing,this.renderer=new e.renderer(a,e),this.renderer.draw(f),a.dataset&&a.dataset.percent?this.update(parseFloat(a.dataset.percent)):a.getAttribute&&a.getAttribute("data-percent")&&this.update(parseFloat(a.getAttribute("data-percent")))}.bind(this);this.update=function(a){return a=parseFloat(a),e.animate?this.renderer.animate(f,a):this.renderer.draw(a),f=a,this}.bind(this),g()};a.fn.easyPieChart=function(b){return this.each(function(){a.data(this,"easyPieChart")||a.data(this,"easyPieChart",new c(this,b))})}});

/*
 * Viewport - jQuery selectors for finding elements in viewport
 * Copyright (c) 2008-2009 Mika Tuupola
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 * Project home:
 *  http://www.appelsiini.net/projects/viewport
 *
 */
(function(e){"use strict";e.belowthefold=function(t,n){var r=e(window).height()+e(window).scrollTop();return r<=e(t).offset().top-n.threshold},e.abovethetop=function(t,n){var r=e(window).scrollTop();return r>=e(t).offset().top+e(t).height()-n.threshold},e.rightofscreen=function(t,n){var r=e(window).width()+e(window).scrollLeft();return r<=e(t).offset().left-n.threshold},e.leftofscreen=function(t,n){var r=e(window).scrollLeft();return r>=e(t).offset().left+e(t).width()-n.threshold},e.inviewport=function(t,n){return!e.rightofscreen(t,n)&&!e.leftofscreen(t,n)&&!e.belowthefold(t,n)&&!e.abovethetop(t,n)},e.extend(e.expr[":"],{"below-the-fold":function(t){return e.belowthefold(t,{threshold:0})},"above-the-top":function(t){return e.abovethetop(t,{threshold:0})},"left-of-screen":function(t){return e.leftofscreen(t,{threshold:0})},"right-of-screen":function(t){return e.rightofscreen(t,{threshold:0})},"in-viewport":function(t){return e.inviewport(t,{threshold:0})}})})(jQuery)