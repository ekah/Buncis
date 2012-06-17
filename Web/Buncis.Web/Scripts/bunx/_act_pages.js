/* File Created: June 9, 2012 */

(function (pages) {
	pages.init = function () {
		
	};
} (window._pages = window._pages || {}));

var pages = window._pages;

$(document).ready(function () {
    $(pages._elems.txtPageContent).htmlarea();
});