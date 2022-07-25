jQuery(document).ready(function ($) {

    function HoverOver() {
        $(this).addClass('rmhover') .find(".subMenu").stop().fadeIn(200);
			// submenu right align
			var position	= $(this).offset();
			var x	= position.left;
			var width	= $(this).find(".subMenu").width();
			// position
			if( x + width > $(window).width() )
			{
				$(this).find(".subMenu").css({"right": 0, "left": "auto"});
			}
	}

    function HoverOut() {
         $(this).removeClass('rmhover').find(".subMenu").fadeOut(200, function() {
		  $(this).hide(); 
	  });
    }
	
	function HoverOversub() {
        $(this).find(".level1").stop().fadeIn(200);
     	// SubMenu right align
			var sublevel = $(".level1", $(this));
			if(sublevel.length > 0){
				var offset = sublevel.offset();
				var rightEage = offset.left + sublevel.outerWidth();
				if(rightEage > $(window).width()){
					sublevel.css("left", -200 + "px");
					sublevel.find(".level2").css("left", -200 + "px");
					sublevel.find(".level3").css("left", -200 + "px");
					sublevel.find(".subarrow").css("background", "none");
				}
			}
	}

    function HoverOutsub() {
         $(this).find(".level1").stop().fadeOut(200, function() {
		  $(this).hide(); 
	  });
    }

	function HoverOversubsub() {
        $(this).find(".level2").stop().fadeIn(200);
    }

    function HoverOutsubsub() {
         $(this).find(".level2").stop().fadeOut(200, function() {
		  $(this).hide(); 
	  });
    }
	
    var config = {
        sensitivity: 2,
        interval:110,
        over: HoverOver,
        timeout:110,
        out: HoverOut
    };
    var configsub = {
        sensitivity: 2,
        interval:110,
        over: HoverOversub,
        timeout:110,
        out: HoverOutsub
    };
    var configsubsub = {
        sensitivity: 2,
        interval:110,
        over: HoverOversubsub,
        timeout:110,
        out: HoverOutsubsub
    };
	
    if ($(window).width() >= 992){
        $("#standardMenu .rootMenu > li.haschild").hoverIntent(config);
		$("#standardMenu .subMenu li.haschild").hoverIntent(configsub);
		$("#standardMenu .subMenu li li.haschild").hoverIntent(configsubsub);		
    }else if ($(window).width() < 992){
		$("#standardMenu .rootMenu > li").each(function(i){
			var i = i + 1;
			$("#standardMenu li.child-"+i+" .navarrow").click(function(event) {
			  event.preventDefault();
			  $("#standardMenu li.child-"+i+" .subMenu").slideToggle(100);
			  $(this).toggleClass("navarrow2"); return false;
			});	
		});
	}
	
   // For Win8 Tablet
   $('#standardMenu .haschild li').attr("aria-haspopup","false");
   $('#standardMenu .haschild li').attr("role","menu");
   $('#standardMenu .haschild').attr("aria-haspopup","true");
   $('#standardMenu .haschild').attr("role","menuitem");
   
   //From Mobile Menu to Tablet/Computer
	$(window).resize(function() {
		if( $(window).width() >= 992 ) {
			$("#standardMenu .rootMenu > li.haschild").hoverIntent(config);
			$("#standardMenu .subMenu li.haschild").hoverIntent(configsub);
			$("#standardMenu .subMenu li li.haschild").hoverIntent(configsubsub);	
		}
	});
});