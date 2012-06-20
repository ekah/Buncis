﻿/* File Created: June 9, 2012 */

(function (pages) {
	var listWebServiceUrl = '/webservices/pages.svc/getpages?clientid=' + pages._elems.clientId;
	function getData(callback) {
		$.ajax({
			type: "GET",
			url: listWebServiceUrl,
			success: function (result) {
				var data = result.d;
				if (data.IsSuccess) {
					callback(data.ResponseObject);
				}
			},
			error: function () {
			}
		});
	}
	function render(data) {
		$(pages._elems.tablePages).dataTable({
			"bProcessing": true,
			"aaData": data,
			"aoColumns": [
                { "mDataProp": null },
                { "mDataProp": null },
                { "mDataProp": null },
            	{ "mDataProp": null },
                { "mDataProp": null }
            ],
			"fnRowCallback": function (nRow, aData, iDisplayIndex) {
				var col0class = aData.IsHomePage ? 'icon icon-home' : 'icon icon-pages';
				var col0 = '<a href="javascript:void(0);" class="pages view" rel="' + aData.PageId + '">';
				col0 += '<span runat="server" class="' + col0class + '">&nbsp;</span></a>';
				$('td:eq(0)', nRow).html(col0);

				var col1 = '<span><strong>' + aData.PageName + '</strong></span><br/>';
				col1 += '<span class="info">' + aData.PageTeaser + '</span>';
				$('td:eq(1)', nRow).html(col1);

				var col2 = '<span>' + aData.DisplayDateLastUpdated + '</span>';
				$('td:eq(2)', nRow).html(col2);

				var col3 = '<span>' + aData.DisplayDateCreated + '</span>';
				$('td:eq(3)', nRow).html(col3);

				var col4 = '<a href="javascript:void(0);" rel="' + aData.PageId + '" class="pages delete">Delete</a>';
				col4 += '<a href="javascript:void(0);" rel="' + aData.PageId + '" class="pages edit">Edit</a>';
				$('td:eq(4)', nRow).html(col4);
			},
			"aoColumnDefs": [{ "sClass": "icon-col", "aTargets": [0] },
                             { "sClass": "action-col", "aTargets": [4]}],
			"bStateSave": true,
			"bFilter": false,
			"bSort": false,
			"bPaginate": true,
			"sPaginationType": "full_numbers",
			"oLanguage": {
				"oPaginate": {
					"sFirst": "&laquo;First",
					"sPrevious": "&lsaquo;Prev",
					"sNext": "Next&rsaquo;",
					"sLast": "Last&raquo;"
				}
			},
			"sDom": 'lrt<"tableFoot"ip>',
		});
	}
	pages.init = function () {
		getData(render);
	};
} (window._pages = window._pages || {}));

var pages = window._pages;

$(document).ready(function () {
    $(pages._elems.txtPageContent).htmlarea();
    pages.init();
});