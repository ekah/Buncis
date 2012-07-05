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
        $(row)
            .animate({ backgroundColor: '#acfa58' }, 1500)
            .animate({ backgroundColor: 'transparent' }, 1500); 
    };
})(window._helpers = window._helpers || {})