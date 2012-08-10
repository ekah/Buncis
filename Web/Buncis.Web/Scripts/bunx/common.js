window._elems = window._elems || {};
window._elems.errorContainer = '#errors';
window._elems.colorboxArea = '#cboxLoadedContent';

$(document).ready(function () {
	$('table.data-table tbody tr:nth-child(odd)').addClass('odd');

	$('body').delegate('.popup-button-close', 'click', function () {
		$.colorbox.close();
	});
	$('.wall-close a').click(function () {
		$('#errors').hide();
	})
});


$.tools.validator.addEffect("floatingWall", function (errors, event) {

	// get the message wall
	var floatingWall = $(this.getConf().container).fadeIn();

	var innerWall = floatingWall.find('.innerWall');

	// remove all existing messages
	innerWall.find("p").remove();

	// add new ones
	$.each(errors, function (index, error) {
		innerWall.append("<p>" + error.messages[0] + "</p>");
	});

	// the effect does nothing when all inputs are valid
}, function (inputs) {

});


(function(helpers) {
	helpers.blockPopupDefault = function() {
		$(_elems.colorboxArea).block();
	};
	helpers.unblockPopupDefault = function() {
		$(_elems.colorboxArea).unblock(); 
	};
	helpers.animateRow = function(row) {
		$(row).animate({ backgroundColor: '#acfa58' }, 1500)
			.animate({ backgroundColor: 'transparent' }, 1500); 
	};
	helpers.cleanDotNetDateJson = function(dateJson) {
		var frt = parseInt(dateJson.substr(6));
		return frt;    	
	};
	helpers.convertEpochToDate = function(epochDate) {
		var d = new Date(epochDate);    	
		return d;
	};
	helpers.convertEpochToString = function(epochDate) {
		var d = new Date(epochDate); 
					
		var s = '';

		var dd = d.getDate();
		if(dd < 10) {
			s += '0' + dd + '-';
		} 
		else {
			s += dd + '-';
		}

		var m = (d.getMonth() + 1);
		if(m < 10) {
			s += '0' + m + '-';	
		}
		else {
			s += m + '-';		
		}
		
		s += d.getFullYear();
		return s;
	};
	helpers.convertDateToString = function(date) {
		return date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear();
	};
	helpers.underscoreTemplateSettings = {
		interpolate : /\{\{(.+?)\}\}/g,     // print value: {{ value_name }}
		evaluate    : /\{%([\s\S]+?)%\}/g,  // excute code: {% code_to_execute %}
		escape      : /\{%-([\s\S]+?)%\}/g  // excape HTML: {%- <script> %} prints &lt;script&gt;
	};
})(window._helpers = window._helpers || {})


function globalShowMessages(msg) {
	$('.buncisContent').showMessage({
		thisMessage: msg,
		position: 'fixed',
		opacity: 100,
		className: 'success'
	});
}


function globalShowPopup(height, width, selector, title, _completeCallback, _closedCallback) {
	$.colorbox({
		height: height,
		width: width,
		title: title,
		href: selector,
		inline: true,
		overlayClose: false,
		scrolling: false,
		onComplete: function() {
			if(_completeCallback) {
				_completeCallback();
			}
		},
		onClosed: function() {
			if(_closedCallback) {
				_closedCallback();
			}
		}
	});
}