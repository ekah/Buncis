/* File Created: June 9, 2012 */

(function (pages) {

	var listWebServiceUrl = '/webservices/pages.svc/getpages?clientid=' + pages._elems.clientId;
    var singleWebServiceUrl = '/webservices/pages.svc/getpage?clientid=' + pages._elems.clientId;
    var pTemplate = {
        DateCreated: "/Date(958775525000+0800)/",
        DateLastUpdated: "/Date(958775525000+0800)/",
        DisplayDateCreated: "",
        DisplayDateLastUpdated: "",
        FriendlyUrl: "",
        IsHomePage: false,
        MetaDescription: "",
        MetaTitle: "",
        PageContent: "",
        PageDescription: "",
        PageId: 0,
        PageName: "",
        PageTeaser: ""
    };

	function getPages(callback) {
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

    function getPage(pageId, callback) {
		$.ajax({
			type: "GET",
			url: singleWebServiceUrl + '&pageid=' + pageId,
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

    function bind(data) {
        $(pages._elems.txtPageName).val(data.PageName);
        $(pages._elems.txtPageUrl).val(data.FriendlyUrl);
        $(pages._elems.txtPageMenuName).val(data.PageMenuName);
        $(pages._elems.txtPageMetaTitle).val(data.MetaTitle);
        $(pages._elems.txtPageMetaDescription).val(data.MetaDescription);
        $(pages._elems.txtPageContent).val(data.PageContent);
        if(data.IsHomePage) {
            $(pages._elems.chkIsHomePage).attr('checked','checked');
        }
        else {
            $(pages._elems.chkIsHomePage).removeAttr('checked');
        }
    }

    function resetForm() {
        $(pages._elems.txtPageName).val('');
        $(pages._elems.txtPageUrl).val('');
        $(pages._elems.txtPageMenuName).val('');
        $(pages._elems.txtPageMetaTitle).val('');
        $(pages._elems.txtPageMetaDescription).val('');
        $(pages._elems.txtPageContent).val('');
        $(pages._elems.chkIsHomePage).removeAttr('checked');
    }
	
	function showPopup(mode, pageId) {
		$.colorbox({
			height: 662,
			width: 900,
			title: "Add/Edit Page",
			href: $(pages._elems.pageFormPopup),
			inline: true,
			overlayClose: false,
			scrolling: false,
			onLoad: function() {
				
			},
			onComplete: function() {
                if(mode === 'edit') {
                    $(pages._elems.colorboxArea).block(); // block colorbox
                    getPage(pageId, function(data) {
                        bind(data);                            
                        $(pages._elems.colorboxArea).unblock(); // unblock colorbox
				        $(pages._elems.txtPageContent).htmlarea(); 
                        $(pages._elems.tabsMenu).tabs(pages._elems.tabs);				                
                        pages.validators = $(pages._elems.pageForm).validator();  
                    });
                }
                else {
                    resetForm();                    
                    $(pages._elems.txtPageContent).htmlarea(); 
				    $(pages._elems.tabsMenu).tabs(pages._elems.tabs);
				    pages.validators = $(pages._elems.pageForm).validator();      
                }
			}
		});
	}

    function setupEvents() {
    	$(pages._elems.btnAddPage).click(function () {
		    showPopup('add');
	    });
	    $(pages._elems.chkIsHomePage).iButton({
    	    change: function ($input){
    		    if($input.is(":checked")) {
				    $(pages._elems.txtPageUrl).val('/');
    			    $(pages._elems.txtPageUrl).attr('disabled', 'disabled');
    		    }
    		    else {
    			    $(pages._elems.txtPageUrl).val('');
    			    $(pages._elems.txtPageUrl).removeAttr('disabled');
    		    }
	        }
  	    });
        $(pages._elems.tablePages).delegate(pages._elems.btnEditPage, 'click', function() {
            var $self = $(this);
            var pageId = $self.attr('rel');
            showPopup('edit', pageId);
        });
    }

	pages.init = function () {
		getPages(render);
        setupEvents();
	};

} (window._pages = window._pages || {}));

// debugging
//var pages = window._pages;

$(document).ready(function () {
    _pages.init();	
});