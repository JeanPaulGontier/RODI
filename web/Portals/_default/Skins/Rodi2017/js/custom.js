/*
 * JS Settings For DotNetNuke Skin by bestdnnskins.com
 * Copyright 2014 By BESTDNNSKINS.COM
 */

//Window Phone Compatible:
(function() {
if ("-ms-user-select" in document.documentElement.style &&
(navigator.userAgent.match(/IEMobile/) ||
navigator.userAgent.match(/ZuneWP7/) ||
navigator.userAgent.match(/WPDesktop/))) {
var msViewportStyle = document.createElement("style");
msViewportStyle.appendChild(
document.createTextNode("@-ms-viewport{width:auto!important}")
);
document.getElementsByTagName("head")[0].appendChild(msViewportStyle);
}
})();

//For Mobile Menu:
jQuery(document).ready(function(){
	  $(".menuclick").click(function(event) {
	    event.preventDefault();
	    $(".menu_box, .menuBox").slideToggle("fast");
			return false;
	  });
});

//For Fancy Lightbox Alternative:
jQuery(document).ready(function() {
	$(".fancybox").fancybox({
	    openEffect:'elastic',closeEffect:'fade',nextEffect:'fade', prevEffect:'fade'
	});
});


//For Page Name Display:
jQuery(document).ready(function() {
	if($("#standardMenu > .rootMenu > li").hasClass("selected"))
	{
		$(".breadcrumb_style").css({"display": "none"});
	}
	if($("#megaMenu > .root > li").hasClass("selected"))
	{
		$(".breadcrumb_style").css({"display": "none"});
	}
});

//For Top Icon Hover:
jQuery(document).ready(function($){
    function iconHoverOver() {
       $(this).find(".top_icon_hover").stop().fadeIn(100).show();
    }
    function iconHoverOut() {
       $(this).find(".top_icon_hover").stop().fadeOut(100, function() {
	     $(this).hide(); 
	     });
    }
	var config = {
        sensitivity: 5,
        interval:50,
        over: iconHoverOver,
        timeout:50,
        out: iconHoverOut
     };
   $(".icon_search, .icon_user, .icon_lang").hoverIntent(config);
}); 

//For Tipsy Style:
jQuery(document).ready(function(){
   if ($(window).width() >= 992){		
	   $('.user-tipsy').tipsy({ fade: true, gravity: 'n' });
	};
});

//For Login Style:
jQuery(document).ready(function() {
	$('.logout-button').click(function () {
        document.location.href = $('.user_login a').attr("href");
    });
});

//For User Back Link:
jQuery(document).ready(function() {
	$('.user-back').click(function () {
        document.location.href = $("[id*='dnnUSER3_registerLink']").attr("href");
    });
});

//For Language Icon Display:
jQuery(document).ready(function() {
    var lang_width = $("#Language").width();
	if ( lang_width >= 2){
	  $(".icon_lang").css('display', 'block');
	} else {
	  $(".icon_lang").css('display', 'none');
	}

});

//For User Icon Display:
jQuery(document).ready(function() {
    var lang_width = $("[id*='dnnUSER3_registerLink']").width();
	if ( lang_width <= 1){
	  $(".user-button").css('display', 'none');
	} else {
	  $(".user-button").css('display', 'block');
	}

});

//For Slideshow Banner:
jQuery(document).ready(function() {
	  $('.flexslider').flexslider({animation:"slide",slideshowSpeed: 6000, animationSpeed: 500, pauseOnHover: true, start: function(slider){} });
	  $('.flexslider2').flexslider({animation:"fade",slideshowSpeed: 6000, animationSpeed: 500, pauseOnHover: true, start: function(slider){} });
	  $('.flexslider3').flexslider({animation:"fade",slideshowSpeed: 6000, animationSpeed: 800, pauseOnHover: true, start: function(slider){} });
	  $('.flexslider4').flexslider({animation:"fade",slideshowSpeed: 6000, animationSpeed: 500, pauseOnHover: true, start: function(slider){} });
});


//For TB Slider:
jQuery(document).ready(function($) {
	$('.TB_Wrapper').TransBanner({
		slide_delaytime: 6,
		slide_transition: 2,
		navigation_type: 3,
		button_size: 26,
		caption_bg_color: '#000',
		caption_bg_opacity: .2,
		caption_bg_blur: 10,
		responsive: true,
		responsive_limit_autoplay: '',
		responsive_limit_caption: 480,
		responsive_limit_navigation: 480,
		responsive_limit_navigation_type: 2,
		responsive_screen_based_limits: true
	});
});

//For CarouFredSel Style:
jQuery(document).ready(function() {
	$("#carouFredSel").carouFredSel({
		responsive: true,
		width: "100%",
		height: 'auto',
		prev: "#caroul_prev",
		next: "#caroul_next",
		swipe: {
			onMouse: true,
			onTouch: true
		},
		scroll: {
			'items': 1,
			'duration': 1500
		},
		items: {
			width:360,
			//	height: '30%',	//	optionally resize item-height
			visible: {
				min: 1,
				max: 3
			}
		}
	});
});

//For CarouFredSel2 Style:
jQuery(document).ready(function() {
	$("#carouFredSel2").carouFredSel({
		responsive: true,
		width: "100%",
		height: 'auto',
		prev: "#caroul2_prev",
		next: "#caroul2_next",
		swipe: {
			onMouse: true,
			onTouch: true
		},
		scroll: {
			'items': 1,
			'duration': 1500
		},
		items: {
			width:270,
			//	height: '30%',	//	optionally resize item-height
			visible: {
				min: 1,
				max: 4
			}
		}
	});
});

//For CarouFredSel3 Style:
jQuery(document).ready(function() {
	$("#carouFredSel3").carouFredSel({
		responsive: true,
		width: "100%",
		height: 'auto',
		prev: "#caroul3_prev",
		next: "#caroul3_next",
		swipe: {
			onMouse: true,
			onTouch: true
		},
		scroll: {
			'items': 1,
			'duration': 1500
		},
		items: {
			width:200,
			//	height: '30%',	//	optionally resize item-height
			visible: {
				min: 1,
				max: 5
			}
		}
	});
});

//For CarouFredSel4 Style:
jQuery(document).ready(function() {
	$("#carouFredSel4").carouFredSel({
		responsive: true,
		width: "100%",
		height: 'auto',
		prev: "#caroul4_prev",
		next: "#caroul4_next",
		swipe: {
			onMouse: true,
			onTouch: true
		},
		scroll: {
			'items': 1,
			'duration': 1500
		},
		items: {
			width:360,
			//	height: '30%',	//	optionally resize item-height
			visible: {
				min: 1,
				max: 4
			}
		}
	});
});

//For CarouFredSel2 Style:
jQuery(document).ready(function() {
		$("#carousel_up").carouFredSel({
		items : 3,
		direction : "up",
		scroll: {
		'items': 1,
		'duration': 1000
		},
	});
}); 

	
//For Accordion Style:
jQuery(document).ready(function() { 
    $( ".accordion2" ).accordion({  
            collapsible: true,
			heightStyle: "content"
    });  
}); 


//For Unoslider Banner:
jQuery(window).load(function(){
	//For Unoslider Banner1:
	$('#slider').unoslider({
		width:1600,
		height: 560,
        tooltip: true,
        indicator: { autohide: false },
        navigation: { autohide: true },
        slideshow: { hoverPause: true, continuous: true, timer: true, speed: 9, infinite: true, autostart: true },
        responsive: true,
        responsiveLayers: false,
        preset: ['sq_flyoff', 'sq_drop', 'sq_squeeze', 'sq_random', 'sq_diagonal_rev', 'sq_diagonal', 'sq_fade_random', 'sq_fade_diagonal_rev', 'sq_fade_diagonal', 'explode', 'implode', 'fountain', 'shot_right', 'shot_left', 'zipper_right', 'zipper_left', 'bar_slide_random', 'bar_slide_bottomright', 'bar_slide_bottomright', 'bar_slide_topright', 'bar_slide_topleft'],
        order: 'random',
        block: {
            vertical: 10,
            horizontal: 4
        },
        animation: {
            speed: 500,
            delay: 50,
            transition: 'grow',
            variation: 'topleft',
            pattern: 'diagonal',
            direction: 'topleft'
        }
	});
	
	//For Unoslider Banner2:
	$('#slider2').unoslider({
		width: 1140,
		height: 350,
        tooltip: true,
        indicator: { autohide: false },
        navigation: { autohide: true },
        slideshow: { hoverPause: true, continuous: true, timer: true, speed: 9, infinite: true, autostart: true },
        responsive: true,
        responsiveLayers: false,
        preset: ['sq_flyoff', 'sq_drop', 'sq_squeeze', 'sq_random', 'sq_diagonal_rev', 'sq_diagonal', 'sq_fade_random', 'sq_fade_diagonal_rev', 'sq_fade_diagonal', 'explode', 'implode', 'fountain', 'shot_right', 'shot_left', 'zipper_right', 'zipper_left', 'bar_slide_random', 'bar_slide_bottomright', 'bar_slide_bottomright', 'bar_slide_topright', 'bar_slide_topleft'],
        order: 'random',
        block: {
            vertical: 10,
            horizontal: 4
        },
        animation: {
            speed: 500,
            delay: 50,
            transition: 'grow',
            variation: 'topleft',
            pattern: 'diagonal',
            direction: 'topleft'
        }
	});
	
	//For Unoslider Banner3:
	$('#slider3').unoslider({
		width: 850,
		height: 350,
        tooltip: true,
        indicator: { autohide: false },
        navigation: { autohide: true },
        slideshow: { hoverPause: true, continuous: true, timer: true, speed: 9, infinite: true, autostart: true },
        responsive: true,
        responsiveLayers: false,
        preset: ['sq_flyoff', 'sq_drop', 'sq_squeeze', 'sq_random', 'sq_diagonal_rev', 'sq_diagonal', 'sq_fade_random', 'sq_fade_diagonal_rev', 'sq_fade_diagonal', 'explode', 'implode', 'fountain', 'shot_right', 'shot_left', 'zipper_right', 'zipper_left', 'bar_slide_random', 'bar_slide_bottomright', 'bar_slide_bottomright', 'bar_slide_topright', 'bar_slide_topleft'],
        order: 'random',
        block: {
            vertical: 10,
            horizontal: 4
        },
        animation: {
            speed: 500,
            delay: 50,
            transition: 'grow',
            variation: 'topleft',
            pattern: 'diagonal',
            direction: 'topleft'
        }
	});
	
	//For Unoslider Banner4:
	$('#slider4').unoslider({
		width: 570,
		height: 220,
        tooltip: true,
        indicator: { autohide: false },
        navigation: { autohide: true },
        slideshow: { hoverPause: true, continuous: true, timer: true, speed: 9, infinite: true, autostart: true },
        responsive: true,
        responsiveLayers: false,
        preset: ['sq_flyoff', 'sq_drop', 'sq_squeeze', 'sq_random', 'sq_diagonal_rev', 'sq_diagonal', 'sq_fade_random', 'sq_fade_diagonal_rev', 'sq_fade_diagonal', 'explode', 'implode', 'fountain', 'shot_right', 'shot_left', 'zipper_right', 'zipper_left', 'bar_slide_random', 'bar_slide_bottomright', 'bar_slide_bottomright', 'bar_slide_topright', 'bar_slide_topleft'],
        order: 'random',
        block: {
            vertical: 10,
            horizontal: 4
        },
        animation: {
            speed: 500,
            delay: 50,
            transition: 'grow',
            variation: 'topleft',
            pattern: 'diagonal',
            direction: 'topleft'
        }
	});
}); 


/* Inner Coming Soon Page JS */
/* Countdown */
jQuery(document).ready(function($) {
    launchTime = new Date();
    launchTime.setDate(launchTime.getDate() + 365);
    $("#countdown").countdown({
        until: launchTime,
        format: "dHMS"
    });
});


//For Isotope Style:
jQuery(document).ready(function() {
	var $container = $('#container');
	$container.isotope({
		itemSelector: '.element'
	});
	var $optionSets = $('#options .option-set'),
	$optionLinks = $optionSets.find('a');
	$optionLinks.click(function() {
		var $this = $(this);
		if ($this.hasClass('selected')) {
			return false;
		}
		var $optionSet = $this.parents('.option-set');
		$optionSet.find('.selected').removeClass('selected');
		$this.addClass('selected');
		var options = {},
		key = $optionSet.attr('data-option-key'),
		value = $this.attr('data-option-value');
		value = value === 'false' ? false: value;
		options[key] = value;
		if (key === 'layoutMode' && typeof changeLayoutMode === 'function') {
			changeLayoutMode($this, options)
		} else {
			$container.isotope(options);
		}
		return false;
	});
});


/*
	By Osvaldas Valutis, www.osvaldas.info
	Available for use under the MIT License
*/
;(function( $, window, document, undefined )
{
	$.fn.doubleTapToGo = function( params )
	{
		if( !( 'ontouchstart' in window ) &&
			!navigator.msMaxTouchPoints &&
			!navigator.userAgent.toLowerCase().match( /windows phone os 7/i ) ) return false;

		this.each( function()
		{
			var curItem = false;

			$( this ).on( 'click', function( e )
			{
				var item = $( this );
				if( item[ 0 ] != curItem[ 0 ] )
				{
					e.preventDefault();
					curItem = item;
				}
			});

			$( document ).on( 'click touchstart MSPointerDown', function( e )
			{
				var resetItem = true,
					parents	  = $( e.target ).parents();

				for( var i = 0; i < parents.length; i++ )
					if( parents[ i ] == curItem[ 0 ] )
						resetItem = false;

				if( resetItem )
					curItem = false;
			});
		});
		return this;
	};
})( jQuery, window, document );

/* For tablet double tap */	
jQuery(document).ready(function() {
	if ($(window).width() >= 992){
	   $( '#standardMenu .rootMenu li.haschild' ).doubleTapToGo();
	   $( '#megaMenu > .root > li.haschild' ).doubleTapToGo();
	 }
});

