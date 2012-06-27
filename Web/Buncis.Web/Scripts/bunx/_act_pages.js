﻿/* File Created: June 9, 2012 */

(function (pages) {

	var listWebServiceUrl = '/webservices/pages.svc/getpages?clientid=' + pages._elems.clientId;
    var singleWebServiceUrl = '/webservices/pages.svc/getpage?clientid=' + pages._elems.clientId;
    var deleteWebServiceUrl = '/webservices/pages.svc/deletepage';
    
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

    function deletePage(pageId) {
        var oData = ({
            clientId: _pages._elems.clientId,
            pageId: pageId,                        
        });
        $(pages._elems.colorboxArea).block();
		$.ajax({
			type: "POST",
			url: deleteWebServiceUrl,
            data: JSON.stringify(oData),
            dataType: 'json',
            contentType: 'text/json',
			success: function (result) {                
                if(result.d.IsSuccess) {                    
                    var deleted = $(pages._elems.tablePages).find('a.delete[rel="' + pageId + '"]').parent();
                    var aPos = pages.pageTable.fnGetPosition(deleted.get(0));
                    var idx = aPos[0];
                    pages.pageTable.fnDeleteRow(idx);
                    setTimeout(function() { 
                        $(_pages._elems.colorboxArea).unblock(); 
                        $.colorbox.close();
                    }, 1000);                    
                }
				else {
                    // show error message here
                }
			},
			error: function () {
                $(pages._elems.colorboxArea).unblock();
			}
		});
    }

    function savePage(pageId) {
        pages.form.validators.data("validator").checkValidity();
    }

	function render(data) {
		pages.pageTable = $(pages._elems.tablePages).dataTable({
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
        $(pages._elems.btnSavePage).attr('rel', '0');
    }
	
	function showPopup(mode, pageId) {
        if(mode === 'delete') {
            $.colorbox({
                width: 450,
                height: 200,
			    title: "Delete Page",
			    href: $(pages._elems.deletePagePopup),
			    inline: true,
			    overlayClose: false,
			    scrolling: false,
                onClosed: function() {
                    $(pages._elems.confirmDeletePage).removeAttr('rel');
                },
			    onLoad: function() {
                    var td = $(pages._elems.tablePages).find('a.delete[rel="' + pageId + '"]').parent();
                    var tr = $(td).parent();
                    var oTd = $(tr).find('td:nth-child(2)');
                    var el = $(oTd).find('strong');
                    var pageName = $(el).text();
                    $(pages._elems.deletedPageName).text(pageName);
                },
			    onComplete: function() {
                    $(pages._elems.confirmDeletePage).attr('rel', pageId);
                }
		    });
        }
        else {
		    $.colorbox({
			    height: 662,
			    width: 960,
			    title: "Add/Edit Page",
			    href: $(pages._elems.pageFormPopup),
			    inline: true,
			    overlayClose: false,
			    scrolling: false,
                onClosed: function() {
                    destroyForm();
                },
			    onLoad: function() { },
			    onComplete: function() {
                    preparePopupForm();
                    if(mode === 'edit') {
                        $(pages._elems.colorboxArea).block(); // block colorbox
                        getPage(pageId, function(data) {
                            bind(data);
                            $(pages._elems.btnSavePage).attr('rel', pageId);
                            setTimeout(function() { $(_pages._elems.colorboxArea).unblock(); }, 1000);
                        });
                    }
                    else {
                        resetForm();
                    }
			    }
		    });
        }
	}

    function preparePopupForm() {
    	/*
		$(pages._elems.tabsMenu).tabs(pages._elems.tabs, {
			onClick: function (event, tabIndex) {
				if($(pages._elems.txtPageContent).is(':visible')) {
					$(pages._elems.txtPageContent).htmlarea('dispose'); // redispose
					$(pages._elems.txtPageContent).htmlarea();
				}
			}
		});*/
    	if(!pages.form.wizardHasBeenInitialized) {
    		pages.form.wizard = $(pages._elems.pageWizards).smartWizard({
    			enableAllSteps: true,
    			enableFinishButton: false, // makes finish button enabled always
    			labelNext:'', // label for Next button
    			labelPrevious:'', // label for Previous button
    			labelFinish:'',  // label for Finish button
    			onShowStep: function (step) {
    				if($(pages._elems.txtPageContent).is(':visible')) {
						$(pages._elems.txtPageContent).htmlarea('dispose'); // redispose
						$(pages._elems.txtPageContent).htmlarea();
					}
    			}
    		});
    		pages.form.wizardHasBeenInitialized = true;
    	}
		pages.form.validators = $(pages._elems.pageFormElements).validator({
			effect: 'floatingWall',
			container: window._elems.errorContainer,
		});  
    }
	
	function destroyForm() {
		$(pages._elems.txtPageContent).htmlarea('dispose'); 
        var api = _pages.form.validators.data("validator");
		api.destroy();
		pages.form.validators = {};
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
        $(pages._elems.tablePages).delegate(pages._elems.btnDeletePage, 'click', function() {
            var $self = $(this);
            var pageId = $self.attr('rel');
            showPopup('delete', pageId);
        });
        $(pages._elems.confirmDeletePage).click(function() {
            var $self = $(this);
            var pageId = $self.attr('rel');
            deletePage(pageId);
        });
        $(pages._elems.btnSavePage).click(function() {
            var $self = $(this);
            var pageId = parseInt($self.attr('rel'), 10);
            savePage(pageId);
        });
    }

	pages.init = function () {
		getPages(render);
        setupEvents();
	};
	pages.form = {
		wizard: {},
		wizardHasBeenInitialized: false,
		validators: {},
	};
    pages.pageTable = {};

} (window._pages = window._pages || {}));

// debugging
//var pages = window._pages;

$(document).ready(function () {
    _pages.init();	
});