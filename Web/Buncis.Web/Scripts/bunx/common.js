window._elems = window._elems || {};
window._elems.errorContainer = '#errors';
window._elems.colorboxArea = '.modal-body';
window.activeModals = '';

/**********************/
/*** window.log **/
(function () {
	// Tell IE9 to use its built-in console
	if (Function.prototype.bind && (typeof console === 'object' || typeof console === 'function') && typeof console.log == "object") {
	  ["log","info","warn","error","assert","dir","clear","profile","profileEnd"]
		.forEach(function (method) {
		  console[method] = this.call(console[method], console);
		}, Function.prototype.bind);
	}

	// log() -- The complete, cross-browser (we don't judge!) console.log wrapper for his or her logging pleasure
	if (!window.log) {
	  window.log = function () {
		log.history = log.history || [];  // store logs to an array for reference
		log.history.push(arguments);
		// Modern browsers
		if (typeof console != 'undefined' && typeof console.log == 'function') {

		  // Opera 11
		  if (window.opera) {
			var i = 0;
			while (i < arguments.length) {
			  console.log("Item " + (i+1) + ": " + arguments[i]);
			  i++;
			}
		  }

		  // All other modern browsers
		  else if ((Array.prototype.slice.call(arguments)).length == 1 && typeof Array.prototype.slice.call(arguments)[0] == 'string') {
			console.log( (Array.prototype.slice.call(arguments)).toString() );
		  }
		  else {
			console.log( Array.prototype.slice.call(arguments) );
		  }

		}

		// IE8
		else if (!Function.prototype.bind && typeof console != 'undefined' && typeof console.log == 'object') {
		  Function.prototype.call.call(console.log, console, Array.prototype.slice.call(arguments));
		}

		// IE7 and lower, and other old browsers
		else {
		  // Inject Firebug lite
		  if (!document.getElementById('firebug-lite')) {
			// Include the script
			var script = document.createElement('script');
			script.type = "text/javascript";
			script.id = 'firebug-lite';
			// If you run the script locally, point to /path/to/firebug-lite/build/firebug-lite.js
			script.src = 'https://getfirebug.com/firebug-lite.js';
			// If you want to expand the console window by default, uncomment this line
			//document.getElementsByTagName('HTML')[0].setAttribute('debug','true');
			document.getElementsByTagName('HEAD')[0].appendChild(script);
			setTimeout(function () { log( Array.prototype.slice.call(arguments) ); }, 2000);
		  }
		  else {
			// FBL was included but it hasn't finished loading yet, so try again momentarily
			setTimeout(function () { log( Array.prototype.slice.call(arguments) ); }, 500);
		  }
		}
	  };
	  window.trace = window.log;
	}
} ());
/*** end window.log  **/
/**********************/


$(document).ready(function () {
	$('table.data-table tbody tr:nth-child(odd)').addClass('odd');

	$('body').delegate('.popup-button-close', 'click', function (evt) {
		evt.preventDefault();
		globalClosePopup();
	});
	$('.wall-close a').click(function (evt) {
		evt.preventDefault();
		$('#errors').hide();
	})

	$('#openMenu').click(function (evt) {
		evt.preventDefault();
		if ($('.buncis-menu-container').is(':visible')) {
			$('.buncis-menu-container').slideUp(400, function () {
				$('#openMenu').find('i').addClass('icon-arrow-down');
				$('#openMenu').find('i').removeClass('icon-arrow-up');
				$('#openMenu').find('strong').text('Open Menu');
			});
		}
		else {
			$('.buncis-menu-container').slideDown(400, function () {
				$('#openMenu').find('i').removeClass('icon-arrow-down');
				$('#openMenu').find('i').addClass('icon-arrow-up');
				$('#openMenu').find('strong').text('Close Menu');
			});
		}
	});

	$('#closeMenu').click(function (evt) {
		evt.preventDefault();
		$('.buncis-menu-container').slideUp(400, function () {
			$('#openMenu').find('i').addClass('icon-arrow-down');
			$('#openMenu').find('i').removeClass('icon-arrow-up');
			$('#openMenu').find('strong').text('Open Menu');
		});
	});

	(function () {
		var currentUrl = window.location.pathname;
		trace(currentUrl);
		if (currentUrl === '/bPanel/dashboard.aspx' || currentUrl === '/bPanel/') {
			$('.buncis-menu-container').show();
		}
		else {
			$('.buncis-menu-container').hide();
		}
	} ());
});

$.tools.validator.addEffect("floatingWall", function (errors, event) {
	var concatenated = '';
	$.each(errors, function (index, error) {
		concatenated += "<div>" + error.messages[0] + "</div>";
	});
	toastr.options.timeOut = 8000;
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
	helpers.blockBuncisContentBodyDefault = function() {
		$('.buncisContentBody').block();
	};
	helpers.unblockBuncisContentBodyDefault = function() {
		$('.buncisContentBody').unblock();
	};	 
	helpers.animateRow = function(row) {
		$(row)
			.animate({ backgroundColor: '#acfa58' }, 1000)
			.animate({ backgroundColor: '#fff' }, 1000, function () {
				$(this).css('background-color', '');
			});
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
		},
		convertDateStringToEpochString: function(fDate) {
			var oDate = new Date(fDate);
			var tzo = parseInt((oDate.getTimezoneOffset() / (-60)), 10);
			var itzo = tzo < 10 ? ('0' + tzo) : ('' + tzo);
			var stzo = tzo < 0 ? '-' : '+';
			return '/Date(' + oDate.getTime() + stzo + itzo + '00)/'
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
			messages += '<div>' + msg[i] + '</div>';
		}
	}
	toastr.options.timeOut = 8000;
	toastr.success(messages, 'It\' a Success!');
}

function globalClosePopup() {    
	$(window.activeModals).modal('hide');    
	window.activeModals = '';
}

function globalShowPopup(width, height, selector, title, _completeCallback, _closedCallback) {
	$(selector).modal({
		keyboard: false,
		backdrop: false,
		show: false
	}).css({
		width: 'auto',
		'margin-left': function () {
			return -($(this).width() / 2);
		},
		'top': function () {
			return (($(window).height() - $(this).height()) / 2);
		}
	});

	$(selector).on('shown', function() {
		$(selector).find('.modal-header h3').html(title);
		if(_completeCallback) {
			_completeCallback();
		}
	});

	$(selector).on('hidden', function() {
		if(_closedCallback) {
			_closedCallback();
		}
		$(selector).unbind('shown');
		$(selector).unbind('hidden');
	});

	$(selector).modal('show');
	window.activeModals = selector;
}

function globalTruncate(elementSelectorToTruncate) {
	$(elementSelectorToTruncate).trunk8({
		fill: '&hellip; <a class="global-read-more" href="#">more</a>'
	});

	$('.global-read-more').live('click', function (event) {
		event.preventDefault();
		$(this).parent().trunk8('revert').append(' <a class="global-read-less" href="#">less</a>');
		return false;
	});

	$('.global-read-less').live('click', function (event) {
		event.preventDefault();
		$(this).parent().trunk8();
		return false;
	});
}