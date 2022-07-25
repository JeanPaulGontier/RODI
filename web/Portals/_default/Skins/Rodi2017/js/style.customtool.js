/*
Name: 			Style Custom Tool Initializer
Written by: 	Bestdnnskins.com - (http://www.bestdnnskins.com)
Version: 		1.0
*/
jQuery(document).ready(function($){
	customTool.initialize(myDNNSkinPath); 
});


var customTool = {
    options: {
        color: "#24A1AF",
		header: "1",
		layout: "wide",
		menu: "1",
		bgImage: "",
		bgPattern: "bg_grid_01",
		megaColumn:"two",
		searchOption:"true",
		registerOption:"true",
		loginOption:"true",
    },
    initialize: function(SkinPath) {
        var $this = this;
        $this.SkinPath = SkinPath;
        $("body").append($('<link rel="stylesheet">').attr("href", $this.SkinPath + "css/style-customtool.css"));
        $("body").append($('<link rel="stylesheet/less">').attr("href", $this.SkinPath + "css/skin.less.txt"));
        $("body").append($('<link rel="stylesheet">').attr("href", $this.SkinPath + "js/colorpicker/css/colorpicker.css"));
        less = {
            env: "development"
        };
        $.getScript($this.SkinPath + "js/less.js",
        function(data, textStatus, jqxhr) {
            $this.build();
            if ($.cookie("SkinOptions") != null) {
                $this.options = JSON.parse($.cookie("SkinOptions"));
                oCustom.find("a").removeClass();
                $this.setColor($this.options.color);
                if (oCustom.find(".options-list a[data-color-hex='" + $this.options.color + "']").length) 
				{
					oCustom.find(".options-list a[data-color-hex='" + $this.options.color + "']").addClass("active"); 
				}else {
                    oCustom.find("#colorSelector").attr("data-color-hex", $this.options.color).css("background-color", $this.options.color).addClass("active");
                    oCustom.find("#colorSelector").ColorPickerSetColor($this.options.color);
                }
				oCustom.find(".options-btn a[data-layout-type='" + $this.options.layout + "']").addClass("active");
				$this.setLayoutStyle($this.options.layout);
                oCustom.find(".options-btn a[data-header-value='" + $this.options.header + "']").addClass("active");
				$this.setHeader($this.options.header);
				oCustom.find(".options-btn a[data-menu-type='" + $this.options.menu + "']").addClass("active");
				$this.setMenu($this.options.menu);
				if ($this.options.bgImage != "") {
                    oCustom.find(".bg_images a[data-image='" + $this.options.bgImage + "']").addClass("active");
                    if ($this.options.layout == "boxed")
					{
						$this.setBgImage($this.options.bgImage)
					}
                } else if ($this.options.bgPattern != "") {
                    oCustom.find(".bg_patterns a[data-pattern='" + $this.options.bgPattern + "']").addClass("active");
                    if ($this.options.layout == "boxed") 
					{
						$this.setBgPattern($this.options.bgPattern) 
					}
                }
				var megaWidth = "";
				$this.setMegaColumn($this.options.megaColumn);
				if ($this.options.searchOption == "true") {
                    oCustom.find("input.search-option").attr("checked", 'true');
                    $(".icon_search").show();
                } else {
                    oCustom.find("input.search-option").removeAttr('checked');
                    $(".icon_search").hide();
                }
				if ($this.options.registerOption == "true") {
                    oCustom.find("input.register-option").attr("checked", 'true');
                    $("a.User, .icon_user").show();
                } else {
                    oCustom.find("input.register-option").removeAttr('checked');
                    $("a.User, .icon_user").hide();
                }
				if ($this.options.loginOption == "true") {
                    oCustom.find("input.login-option").attr("checked", 'true');
                    $("a.Login, .icon_login").show();
                } else {
                    oCustom.find("input.login-option").removeAttr('checked');
                    $("a.Login, .icon_login").hide();
                }
            } 
        })
    },
    build: function() {
        var $this = this;
        var toolTemplate = $("<div />").attr("id", "customTool").append($("<a />").attr("href", "javascript:void(0)").attr("id", "custom-button").append($("<i />").addClass("fa fa-cog")), $("<div />").addClass("custom-tool-wrap").append($("<div />").css("clear", "both"), $("<h5 />").html("Color Scheme"), $("<ul />").addClass("colors").addClass("options-list").attr("data-type", "colors"), $("<div />").addClass("options-btn header").append($("<h5 />").html("Headers")).append($("<a />").attr("href", "#").attr("data-header-value", "1").addClass("active").html("1"), $("<a />").attr("href", "#").attr("data-header-value", "2").html("2"), $("<a />").attr("href", "#").attr("data-header-value", "3").html("3"), $("<a />").attr("href", "#").attr("data-header-value", "4").html("4")), $("<div />").addClass("options-btn layout").append($("<h5 />").html("Layout Style"), $("<a />").attr("href", "#").attr("data-layout-type", "wide").addClass("active").html("Wide"), $("<a />").attr("href", "#").attr("data-layout-type", "boxed").html("Boxed")), $("<div />").addClass("options-btn skinmenu").append($("<h5 />").html("Menu Style"), $("<a />").attr("href", "#").attr("data-menu-type", "1").addClass("active").html("Standard"), $("<a />").attr("href", "#").attr("data-menu-type", "2").html("Mega")), $("<div />").addClass("options-btn mega").hide().append($("<h5 />").html("Megamenu Columns"), $("<a />").attr("href", "#").attr("data-mega-column", "one").html("One"), $("<a />").attr("href", "#").attr("data-mega-column", "two").addClass("active").html("Two"), $("<a />").attr("href", "#").attr("data-mega-column", "three").html("Three")), $("<div />").addClass("bg_images").hide().append($("<h5 />").html("Background Images"), $("<ul />").addClass("options-list").attr("data-type", "images")), $("<div />").addClass("bg_patterns").hide().append($("<h5 />").html("Background Patterns"), $("<ul />").addClass("options-list").attr("data-type", "patterns")), $("<div />").addClass("dnn-token").append($("<h5 />").html("Search"), $("<input />").addClass("search-option").attr("checked", "true").attr("type", "checkbox"), $("<h5 />").html("Register"), $("<input />").addClass("register-option").attr("checked", "true").attr("type", "checkbox"), $("<h5 />").html("Login"), $("<input />").addClass("login-option").attr("checked", "true").attr("type", "checkbox")), $("<hr />"), $("<div />").addClass("options-btn").append($("<a />").attr("id", "reset").attr("href", "#").html("Reset"), $("<a />").attr("href", "#").attr("id", "get-css").attr("onclick", "customTool.getCSS(); return false;").html("Save"))));
        $("body").append(toolTemplate);
		
		$('#custom-button').click(
			function () {
				if ($('#customTool').css('right') != '0px') {
					$('#customTool').animate({ "right": "0px" }, { duration: 300 });
				}
				else {
					$('#customTool').animate({ "right": "-220px" }, { duration: 300 });
				}
			}
		);
		
        oCustom = $("#customTool");
		
        var modalHTML = '<div id="getCSSModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"><div class="modal-dialog"><div class="modal-content"><div class="modal-body"><textarea id="getCSSTextarea" class="get-css" style="display:none;" readonly></textarea></div></div></div></div>';
        var modalConfrmed = '<div id="getConfirmedModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button><h4 class="modal-title" id="cssModalLabel">Confirmation Message</h4></div><div class="modal-body"><strong>Would you like to overwrite your existing skin?</strong></div><div class="modal-footer"><button class="btn btn-primary save" aria-hidden="true" onclick="customTool.save(); return false;">Yes</button><button class="btn" data-dismiss="modal" aria-hidden="true">No</button></div></div></div></div>';
        $("body").append(modalHTML + modalConfrmed);
        var colors = [{
            "Hex": "#24A1AF",
        },
        {
            "Hex": "#c12026",
        },
        {
            "Hex": "#586c96",
        },
        {
            "Hex": "#8bad3a",
        },
        {
            "Hex": "#07b873",
        },
        {
            "Hex": "#f17931",
        },
        {
            "Hex": "#860c86",
        },
        {
            "Hex": "#37389a",
        },
        {
            "Hex": "#068584",
        },
        {
            "Hex": "#68429c",
        },
        {
            "Hex": "#397da7",
        },
        {
            "Hex": "#803258",
        },
        {
            "Hex": "#e15850",
        },
        {
            "Hex": "#b79c69",
        },
        {
            "Hex": "#c01570",
        }];
        var colorList = oCustom.find("ul[data-type=colors]");
        $.each(colors,
        function(i, value) {
            var color = $("<li />").append($("<a />").css("background-color", colors[i].Hex).attr({
                "data-color-hex": colors[i].Hex,
                "href": "#",
                "title":""
            }));
            if (i == 0) color.find("a").addClass("active");
            colorList.append(color)
        });
        var currentSkinColor = colors[0].Hex;
        var colorPicker = $("<li />").append($("<a />").attr({
            "id": "colorSelector",
            "style": "background-color: " + currentSkinColor,
            "data-color-hex": currentSkinColor,
            "href": "#"
        }).append($("<span />").addClass("color-picker-icon")));
        colorList.append(colorPicker);
        colorList.find("a").click(function(e) {
            e.preventDefault();
            colorList.find("a").removeClass("active");
            $(this).addClass("active");
            $this.createCookie();
            $this.setColor($(this).attr("data-color-hex"))
        });
        oCustom.find($("#colorSelector")).ColorPicker({
            color: currentSkinColor,
            onShow: function(colpkr) {
                $(colpkr).fadeIn(500);
                return false
            },
            onHide: function(colpkr) {
                $(colpkr).fadeOut(500);
                return false
            },
            onChange: function(hsb, hex, rgb) {
                $this.setColor("#" + hex);
                $("#colorSelector").css("background-color", "#" + hex);
                $("#colorSelector").attr("data-color-hex", "#" + hex);
                $this.createCookie()
            }
        });
		
		oCustom.find(".layout").find("a:first").click(function(e) {
            e.preventDefault();
            $(this).parent().find("a").removeClass("active");
            $(this).addClass("active");
			$this.createCookie();
            window.location.reload();
			var wideWidth = "100%";
			$.removeCookie("boxed");
			$.cookie("wide", wideWidth);
        });
		
		oCustom.find(".layout").find("a:last").click(function(e) {
            e.preventDefault();
            $(this).parent().find("a").removeClass("active");
            $(this).addClass("active");
            window.location.reload();
			$this.createCookie();
			var boxedWidth = "1140";
		  	$.removeCookie("wide");
			$.cookie("boxed", boxedWidth);
        });	
		
		oCustom.find(".mega").find("a").click(function(e) {
            e.preventDefault();
            $(this).parent().find("a").removeClass("active");
            $(this).addClass("active");
            $this.createCookie();
			$this.setMegaColumn($(this).attr("data-mega-column"))
        });
		
		oCustom.find(".header").find("a").click(function(e) {
            e.preventDefault();
            $(this).parent().find("a").removeClass("active");
            $(this).addClass("active");
            $this.createCookie();
			window.location.reload();
        });
		
		oCustom.find(".skinmenu").find("a").click(function(e) {
            e.preventDefault();
            $(this).parent().find("a").removeClass("active");
            $(this).addClass("active");
            $this.createCookie();
			window.location.reload();
        });
        
		var patterns = ["bg_grid_01", "bg_grid_02", "bg_grid_03", "bg_grid_04", "bg_grid_05", "bg_grid_06", "bg_grid_07", "bg_grid_08", "bg_grid_09", "bg_grid_10", "bg_grid_11", "bg_grid_12", "bg_grid_13", "bg_grid_14", "bg_grid_15", "bg_grid_16"];
        var patternsList = oCustom.find("ul[data-type=patterns]");
        $.each(patterns,
        function(key, value) {
            var pattern = $("<li />").append($("<a />").addClass("pattern").css("background-image", "url(" + $this.SkinPath + "images/bg_pattern/" + value + ".png)").attr({
                "data-pattern": value,
                "href": "#",
                "title": ""
            }));
            patternsList.append(pattern);
			patternsList.find("li:first a").addClass("active");
        });
		
		var images = ["bg_img1", "bg_img2", "bg_img3", "bg_img4", "bg_img5", "bg_img6"];
        var imagesList = oCustom.find("ul[data-type=images]");
        $.each(images,
        function(key, value) {
            var image = $("<li />").append($("<a />").css("background-image", "url(" + $this.SkinPath + "images/bg_pattern/" + value + ".jpg)").attr({
                "data-image": value,
                "href": "#",
                "title": ""
            }));
            imagesList.append(image)
        });
        patternsList.find("a").click(function(e) {
            e.preventDefault();
            patternsList.find("a").removeClass();
            imagesList.find("a").removeClass();
            $(this).addClass("active");
            $this.setBgPattern($(this).attr("data-pattern"));
            $this.createCookie()
        });
        imagesList.find("a").click(function(e) {
            e.preventDefault();
            patternsList.find("a").removeClass();
            imagesList.find("a").removeClass();
            $(this).addClass("active");
            $this.setBgImage($(this).attr("data-image"));
            $this.createCookie()
        });
		
		oCustom.find('input.search-option').click(function() {
            if ($(this).is(':checked')) 
			{
				$(".icon_search").show();
			} else {
				$(".icon_search").hide();
			}
			$this.createCookie()
        });
		
		oCustom.find('input.register-option').click(function() {
            if ($(this).is(':checked')) 
			{
				$("a.User, .icon_user").show();
			} else {
				$("a.User, .icon_user").hide();
			}
			$this.createCookie()
        });
		
		oCustom.find('input.login-option').click(function() {
            if ($(this).is(':checked')) 
			{
				$("a.Login, .icon_login").show();
			} else {
				$("a.Login, .icon_login").hide();
			}
			$this.createCookie()
        });
		
        oCustom.find("a#reset").click(function(e) {
            e.preventDefault();
			$.removeCookie("boxed");
			$.removeCookie("wide");
            $this.reset()
        })
    },
    createCookie: function() {
        var $this = this;
        $this.options.color = oCustom.find(".options-list .active").attr("data-color-hex");
		$this.options.layout = oCustom.find(".layout .active").attr("data-layout-type");
		$this.options.header = oCustom.find(".header .active").attr("data-header-value");
		$this.options.menu = oCustom.find(".skinmenu .active").attr("data-menu-type");
		$this.options.megaColumn = oCustom.find(".mega .active").attr("data-mega-column");
		var bgI = oCustom.find(".bg_images .active").attr("data-image");
        var bgP = oCustom.find(".bg_patterns .active").attr("data-pattern");
        if (bgI != null) {
            $this.options.bgImage = bgI;
            $this.options.bgPattern = ""
        } else if (bgP != null) {
            $this.options.bgPattern = bgP;
            $this.options.bgImage = ""
        }
		if (oCustom.find("input.search-option").is(':checked')) $this.options.searchOption = "true";
        else $this.options.searchOption = "false";
		if (oCustom.find("input.register-option").is(':checked')) $this.options.registerOption = "true";
        else $this.options.registerOption = "false";
		if (oCustom.find("input.login-option").is(':checked')) $this.options.loginOption = "true";
        else $this.options.loginOption = "false";
        $.cookie("SkinOptions", JSON.stringify($this.options));
		$.cookie("Layout", $this.options.layout);
		$.cookie("Header", $this.options.header);
		$.cookie("Menu", $this.options.menu);
		$.cookie("BGImage", $this.options.bgImage);
		$.cookie("BGPattern", $this.options.bgPattern);
		$.cookie("MegaColumn", $this.options.megaColumn);
		$.cookie("SearchOption", $this.options.searchOption);
		$.cookie("RegisterOption", $this.options.registerOption);
		$.cookie("LoginOption", $this.options.loginOption);
    },
    setColor: function(color) {
        var $this = this;
        if (this.isChanging) {
            return false
        }
        $this.options.color = color;
        less.modifyVars({
            skinColor: color
        })
    },
	setLayoutStyle: function(style) {
        var $this = this;
        var layoutStyles = oCustom.find("div.options-btn.layout");
        layoutStyles.find("a.active").removeClass("active");
        layoutStyles.find("a[data-layout-type=" + style + "]").addClass("active");
        if (style == "wide") {
			oCustom.find(".bg_images").hide();
			oCustom.find(".bg_patterns").hide();
        } else if (style == "boxed"){
			oCustom.find(".bg_images").show();
			oCustom.find(".bg_patterns").show();
        }
    },
	setHeader: function(header) {
        var $this = this;
        var headerSelected = oCustom.find("div.options-btn.header");
        headerSelected.find("a.active").removeClass("active");
        headerSelected.find("a[data-header-value=" + header + "]").addClass("active");
        if (header == "1") {
			$("#headerCSS").attr("href",$this.SkinPath +"commonparts/Header1.css");
        }else if (header == "2"){
			$("#headerCSS").attr("href",$this.SkinPath +"commonparts/Header2.css");
        }else if (header == "3"){
			$("#headerCSS").attr("href",$this.SkinPath +"commonparts/Header3.css");
        }else if (header == "4"){
			$("#headerCSS").attr("href",$this.SkinPath +"commonparts/Header4.css");
		}
    },
	setMenu: function(menu) {
        var $this = this;
        var menuSelected = oCustom.find("div.options-btn.skinmenu");
        menuSelected.find("a.active").removeClass("active");
        menuSelected.find("a[data-menu-type=" + menu + "]").addClass("active");
		if (menu == "1") {
            oCustom.find(".mega").hide();
        } else if (menu == "2"){
			oCustom.find(".mega").show();
        }
    },
	setBgPattern: function(pattern) {
        var $this = this;
        $("#Body").css("background-image", "url( " + $this.SkinPath + "images/bg_pattern/" + pattern + ".png)")
    },
	setBgImage: function(image) {
        var $this = this;
        $("#Body").css("background-image", "url( " + $this.SkinPath + "images/bg_pattern/" + image + ".jpg)")
    },
	setMegaColumn: function(column) {
        var $this = this;
        var megaColumns = oCustom.find("div.options-btn.mega");
        megaColumns.find("a.active").removeClass("active");
        megaColumns.find("a[data-mega-column=" + column + "]").addClass("active");
        if (column == "one") {
            megaWidth = "200px";
        } else if (column == "two"){
			megaWidth = "380px";
        }else if (column == "three"){
			megaWidth = "560px";
        }
		$("#megaMenu .category").css("width",megaWidth);
    },
    reset: function() {
        $.removeCookie("SkinOptions");
		$.removeCookie("Layout");
		$.removeCookie("Header");
		$.removeCookie("Menu");
		$.removeCookie("BGImage");
		$.removeCookie("BGPattern");
		$.removeCookie("MegaColumn");
		$.removeCookie("SearchOption");
		$.removeCookie("RegisterOption");
		$.removeCookie("LoginOption");
        window.location.reload();
    },
    getCSS: function() {
        var $this = this;
		var customBg ="";
		var megaColumn = "";
		var searchOption = "";
		var registerOption = "";
		var loginOption = "";
		if ($this.options.layout == "boxed"){
			if ($this.options.bgImage != "") {
				customBg = "#Body {\n background-image: url(images/bg_pattern/" + $this.options.bgImage + ".jpg); \n}\n\n";
			} else if ($this.options.bgPattern != "") {
				customBg = "#Body {\n background-image: url(images/bg_pattern/" + $this.options.bgPattern + ".png); \n}\n\n";
			} 
		}else if ($this.options.layout == "wide") {
			customBg = "#Body {\n background-image: none; \n}\n\n";
		}
		if ($this.options.menu == "2"){
			megaColumn = "#megaMenu .category {\n width: " + megaWidth + "; \n}\n\n";
		}else if ($this.options.menu == "1") {
			megaColumn = "";
		}
		
		if ($this.options.searchOption == "false") {
			searchOption = ".icon_search {\n display: none; \n}\n\n"
		} 
		if ($this.options.registerOption == "false") {
			registerOption = "a.User, .icon_user {\n display: none; \n}\n\n"
		} 
		if ($this.options.loginOption == "false") {
			loginOption = "a.Login, .icon_login {\n display: none; \n}\n\n"
		} 
        $("#getCSSTextarea").text(customBg + megaColumn + searchOption + registerOption + loginOption + $('style[id^="less:"]').text());
		$("#getConfirmedModal").modal("show");
    },
    save: function() {
        var $this = this;
		$this.options.layout = oCustom.find(".layout .active").attr("data-layout-type");
		$this.options.header = oCustom.find(".header .active").attr("data-header-value");
		$this.options.menu = oCustom.find(".skinmenu .active").attr("data-menu-type");
		$this.options.bgPattern = oCustom.find("ul[data-type=patterns]").find("a.active").attr("data-pattern");
        $this.options.bgImage = oCustom.find("ul[data-type=images]").find("a.active").attr("data-image");
        var CSS = $("#getCSSTextarea").val();
        $.post($this.SkinPath + "handlers/ajax.ashx", {
            CSS: CSS,
            Settings: JSON.stringify($this.options),
            Action: 'Save'
        },
        function(data) {
            if (data == "Success") {
                $("#getConfirmedModal").modal("hide");
            }
        })
    },
};

var boxed = $.cookie("boxed");
if (boxed) {
	$("#skin_wrapper").addClass("boxed");
}

var wide = $.cookie("wide");
if (wide) {
	$("#skin_wrapper").removeClass("boxed");
}