window._elems = {
	errorContainer: '#errors'
};

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
    }
})(window._helpers = window._helpers || {})