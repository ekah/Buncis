$(document).ready(function () {
	$('table.data-table tbody tr:nth-child(odd)').addClass('odd');

	$('body').delegate('.popup-button-close', 'click', function () {
		$.colorbox.close();
	});
});


$.tools.validator.addEffect("floatingWall", function(errors, event) {
 
	// get the message wall
	var floatingWall = $(this.getConf().container).fadeIn();
 
	// remove all existing messages
	floatingWall.find("p").remove();
 
	// add new ones
	$.each(errors, function(index, error) {
		floatingWall.append("<p>" + error.messages[0] + "</p>");
	});
 
// the effect does nothing when all inputs are valid
});