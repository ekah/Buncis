﻿window._elems = window._elems || {};
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
	var concatenated = '';
	$.each(errors, function (index, error) {
		concatenated += "<p>" + error.messages[0] + "</p>";
	});
	//toastr.options.positionClass = 'toast-top-left';
	toastr.error(concatenated, 'Oops! Please fix this first.')
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
	helpers.dateFn = {
		cleanDotNetDateJson: function(dateJson) {
			var frt = parseInt(dateJson.substr(6));
			return frt;    	
		},
		convertEpochToDate: function(epochDate) {
			var d = new Date(epochDate);    	
			return d;
		},
		convertEpochToDefaultFormattedString: function(epochDate) {
			// DEAFULT FORMATTED STRING IS d-m-yy
			var d = new Date(epochDate); 					
			var s = '';
			var dd = d.getDate();
			if(dd < 10) {
				s += '' + dd + '-';
			} 
			else {
				s += dd + '-';
			}
			var m = (d.getMonth() + 1);
			if(m < 10) {
				s += '' + m + '-';	
			}
			else {
				s += m + '-';		
			}		
			s += d.getFullYear();
			return s;
		},		
		convertDateToDefaultFormattedString: function(date) {
			// DEAFULT FORMATTED STRING IS d-m-yy
			return date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear();
		}
	};	
	helpers.underscoreTemplateSettings = {
		interpolate : /\{\{(.+?)\}\}/g,     // print value: {{ value_name }}
		evaluate    : /\{%([\s\S]+?)%\}/g,  // excute code: {% code_to_execute %}
		escape      : /\{%-([\s\S]+?)%\}/g  // excape HTML: {%- <script> %} prints &lt;script&gt;
	};
})(window._helpers = window._helpers || {})

function globalShowMessages(msg) {
	var messages = '';
	if(Object.prototype.toString.call(msg) === '[object Array]') {
		for (var i = 0; i < msg.length; i++) {
			messages += '<p>' + msg[i] + '</p>';
		}
	}
	//toastr.options.positionClass = 'toast-top-left';
	toastr.success(messages, 'It\' a Success!');
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