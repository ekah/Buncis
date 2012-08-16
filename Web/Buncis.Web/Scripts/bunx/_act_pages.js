/* File Created: June 9, 2012 */

(function (pages) {
	pages._elems = pages._elems || {
		pageWizards: '#page-wizard',
		tablePages: '#table-pages',
		btnAddPage: '#aAddPage',
		pageFormPopup: '#form-page-popup',
		pageFormElements: '.form-page .form-item :input',
		pageTabs: '.page-tabs',
		deletePagePopup: '#delete-page-popup',
		deletedPageName: '#d-pageName',
		confirmDeletePage: '#deletePage-confirm',
		cancelDeletePage: '#deletePage-cancel',
		validated: '.form-page :input, .form-page :textarea',
		txtPageName: '#txtPageName',
		txtPageDescription: '#txtPageDescription',
		txtPageUrl: '#txtPageUrl',
		txtPageMenuName: '#txtPageMenuName',
		txtPageMetaTitle: '#txtPageMetaTitle',
		txtPageMetaDescription: '#txtPageMetaDescription',
		txtPageContent: '#txtPageContent',
		chkIsHomePage: '#chkIsHomePage',
		btnSavePage: '#btnSavePage',
		btnEditPage: '#table-pages td a.edit',
		btnDeletePage: '#table-pages td a.delete'
	};

	var listWebServiceUrl = '/webservices/pages.svc/getpages?clientid=' + _elems.clientId;
	var singleWebServiceUrl = '/webservices/pages.svc/getpage?clientid=' + _elems.clientId;
	var deleteWebServiceUrl = '/webservices/pages.svc/deletepage';
	var updateWebServiceUrl = '/webservices/pages.svc/updatepage';
	var insertWebServiceUrl = '/webservices/pages.svc/insertpage';
	
	var pTemplate = {
		PageId: 0,
		PageName: "",
		PageMenuName: "",
		PageDescription: "",
		PageTeaser: "",
		PageContent: "",
		MetaTitle: "",
		MetaDescription: "",
		DisplayDateCreated: "",
		DisplayDateLastUpdated: "",
		FriendlyUrl: "",
		IsHomePage: false,
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
			clientId: _elems.clientId,
			pageId: pageId,                        
		});

		_helpers.blockPopupDefault();

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
					var tr = deleted.parent();
					var data = pages.pageTable.fnGetData(tr.get(0));
					var name = data.PageName;
					
					pages.form.deletedPageName = name;
					pages.pageTable.fnDeleteRow(idx);
					
					setTimeout(function() { 
						_helpers.unblockPopupDefault();
						$.colorbox.close();
						$(_pages._elems.confirmDeletePage).removeAttr('rel');
						globalShowMessages(["System has successfully deleted page " + _pages.form.deletedPageName]);
					}, 500);               
				}
				else {
					// show error message here
					_helpers.unblockPopupDefault();
				}
			},
			error: function () {
				_helpers.unblockPopupDefault();
			}
		});
	}

	function savePage(pageId) {
		var oPageId = parseInt(pageId, 10);
		var api = _pages.form.validators.data("validator");
		var isValid = api.checkValidity();
		var template = {};
		var oData = '';
		var wsUrl = '';
		var mode = '';

		if(isValid) {
			if(oPageId <= 0) {
				template = $.extend(true, {}, pTemplate);                
				wsUrl = insertWebServiceUrl;
				mode = 'add';
			}
			else {
				template = pages.form.editedData;
				wsUrl = updateWebServiceUrl;
				mode = 'edit';
			}
			
			template.PageId = oPageId;
			template.PageName = $(pages._elems.txtPageName).val();
			template.PageDescription = $(pages._elems.txtPageDescription).val();
			template.PageMenuName = $(pages._elems.txtPageMenuName).val();            
			template.PageContent = $(pages._elems.txtPageContent).val();
			template.MetaTitle = $(pages._elems.txtPageMetaTitle).val();
			template.MetaDescription = $(pages._elems.txtPageMetaDescription).val();
			template.FriendlyUrl = $(pages._elems.txtPageUrl).val();
			template.IsHomePage = $(pages._elems.chkIsHomePage).is(':checked');

			oData = {
				clientId: _elems.clientId,
				page: template
			};

			$.ajax({
				type: "POST",
				url: wsUrl,
				data: JSON.stringify(oData),
				dataType: 'json',
				contentType: 'text/json',
				success: function (result) {                                  
					if(result.d.IsSuccess) { 
						var msg = '';
						if(mode === 'add') {     
							msg = "System has successfully added new page.";
						}
						else {
							msg = "System has successfully edited page data.";
						}

						$.colorbox.close();
						globalShowMessages([msg]);

						if(mode === 'add') {
							var added = pages.pageTable.fnAddDataAndDisplay(result.d.ResponseObject);
							$.scrollTo(added.nTr);
						}                
						else {                            
							pages.pageTable.fnUpdate(result.d.ResponseObject, pages.form.editedRowPos);
							window._helpers.animateRow(pages.form.editedRow);
							$.scrollTo(pages.form.editedRow);
						}
					}
					else {
						// show error message here
					}
				},
				error: function () {
						
				}
			});
		}
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

				var col4 = '<a href="javascript:void(0);" rel="' + aData.PageId + '" class="delete">Delete</a>';
				col4 += '<a href="javascript:void(0);" rel="' + aData.PageId + '" class="edit">Edit</a>';
				$('td:eq(4)', nRow).html(col4);
			},
			"aoColumnDefs": [{ "sClass": "icon-col", "aTargets": [0] }, { "sClass": "action-col", "aTargets": [4]}],
			"bStateSave": false,
			"bFilter": true,
			"bSort": true,
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
			"sDom": 'lrt<"tableFoot"ip>'
		});
	}

	function bind(data) {
		$(pages._elems.txtPageName).val(data.PageName);
		$(pages._elems.txtPageDescription).val(data.PageDescription);
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
		$(pages._elems.txtPageDescription).val('');
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
			globalShowPopup(200, 450, pages._elems.deletePagePopup, "Delete Page",
				function() {
					var td = $(pages._elems.tablePages).find('a.delete[rel="' + pageId + '"]').parent();
					var tr = $(td).parent();
					var oTd = $(tr).find('td:nth-child(2)');
					var el = $(oTd).find('strong');
					var pageName = $(el).text();
					$(pages._elems.deletedPageName).text(pageName);
					$(pages._elems.confirmDeletePage).attr('rel', pageId);
				},
				function() {

				}
			);
		}
		else {
			var title = '';
			if(mode === 'edit') { 
				title = 'Edit Page';           
			}
			else {
				title = 'Add Page';
			}

			globalShowPopup(662, 960, pages._elems.pageFormPopup, title,
				function() {
					preparePopupForm();
					_helpers.blockPopupDefault();
					if(mode === 'edit') {
						getPage(pageId, function(data) {

							bind(data);
							
							$(pages._elems.btnSavePage).attr('rel', pageId);
							
							var td = $(pages._elems.tablePages).find('a.edit[rel="' + pageId + '"]').parent();
							var tr = $(td).parent();
							pages.form.editedRow = tr;
							
							var aPos = pages.pageTable.fnGetPosition(tr.get(0));
							pages.form.editedRowPos = aPos;
							
							var data = pages.pageTable.fnGetData();
							var dData = data[aPos];
							pages.form.editedData = dData;
							
							setTimeout(function() { _helpers.unblockPopupDefault(); }, 500);
						});
					}
					else {
						resetForm();
						setTimeout(function() { _helpers.unblockPopupDefault(); }, 500);
					}
				},
				function() {
					destroyForm();
				}
			);
		}
	}

	function preparePopupForm() {
		if(!pages.form.wizardHasBeenInitialized) {
			pages.form.wizard = $(pages._elems.pageWizards).smartWizard({
				keyNavigation: false,
				enableAllSteps: true,
				enableFinishButton: false,
				labelNext:'', 
				labelPrevious:'', 
				labelFinish:'',
				transitionEffect: 'slideleft',
				onShowStep: function (step) {
					if($(pages._elems.txtPageContent).is(':visible')) {
						$(pages._elems.txtPageContent).htmlarea('dispose'); 
						$(pages._elems.txtPageContent).htmlarea();
					}
				}
			});
			pages.form.wizardHasBeenInitialized = true;
		}
		else {
			$(pages._elems.pageTabs).find('a.tabStart').click();
		}
		pages.form.validators = $(pages._elems.pageFormElements).validator({
			effect: 'floatingWall',
			container: window._elems.errorContainer,
			errorInputEvent: null,
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
		deletedPageName: '',   
		editedRow: {},
		editedRowPos: -1,  
		editedData: {}   
	};

	pages.pageTable = {};
} (window._pages = window._pages || {}));

// debugging
//var pages = window._pages;

$(document).ready(function () {
	_pages.init();	
});