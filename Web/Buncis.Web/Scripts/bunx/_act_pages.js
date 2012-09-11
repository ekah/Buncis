/* File Created: June 9, 2012 */

(function (pages) {
	pages._elems = {
		tablePages: '#table-pages',
		btnAddPage: '#aAddPage',
		pageFormPopup: '#form-page-popup',
		pageFormElements: '.form-page .form-item :input',
		pageTabs: '#page-tabs',
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
		btnEditPage: '#table-pages td a.action.edit',
		btnDeletePage: '#table-pages td a.action.delete'
	};

	var listWebServiceUrl = '/webservices/pages.svc/bpgetpages?clientid=' + _elems.clientId;
	var singleWebServiceUrl = '/webservices/pages.svc/bpgetpage?clientid=' + _elems.clientId;
	var deleteWebServiceUrl = '/webservices/pages.svc/bpdeletepage';
	var updateWebServiceUrl = '/webservices/pages.svc/bpupdatepage';
	var insertWebServiceUrl = '/webservices/pages.svc/bpinsertpage';
	
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
		PageUrl: "",
		IsHomePage: false,
	};
	
	var pageRouter = {};
	var PagesRouter = Backbone.Router.extend({
		routes: {
			"home": "home",
			"edit/:query": "edit", 
			"add": "add", 
		},
		home: function() {
			$('#homeSection').show();
			$('#form-page-popup').hide();
		},
		edit: function(query) {
			var pageId = query;
			$('#homeSection').hide();
			$('#form-page-popup').show();
			initAddOrEditSection('edit', pageId);
		},
		add: function() {
			$('#homeSection').hide();
			$('#form-page-popup').show();
			initAddOrEditSection('add');
		}
	});

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
						globalClosePopup();
						$(_pages._elems.confirmDeletePage).removeAttr('rel');
						globalShowMessages(["System has successfully deleted page " + _pages.form.deletedPageName]);
					}, 0);               
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
			template.PageUrl = $(pages._elems.txtPageUrl).val();
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
						globalShowMessages([msg]);
						
						pageRouter.navigate("home", {trigger: true});
						
						if(mode === 'add') {
							var added = pages.pageTable.fnAddDataAndDisplay(result.d.ResponseObject);
							$.scrollTo(added.nTr);
						}
						else {
							pages.pageTable.fnUpdate(result.d.ResponseObject, pages.form.editedRowPos);
							$.scrollTo(pages.form.editedRow);
							window._helpers.animateRow(pages.form.editedRow);
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
				var col0class = aData.IsHomePage ? 'icon-home' : 'icon-file';
				var col0 = '<a href="javascript:void(0);" class="pages view" rel="' + aData.PageId + '">';
				col0 += '<i class="' + col0class + '">&nbsp;</i>';
				col0 += '</a>';
				$('td:eq(0)', nRow).html(col0);

				var col1 = '<span><strong>' + aData.PageName + '</strong></span><br/>';
				col1 += '<span class="info" rel="tooltip" title="' + aData.PageDescription + '">' + aData.PageTeaser + '</span>';
				$('td:eq(1)', nRow).html(col1);

				var col2 = '<span>' + aData.DisplayDateLastUpdated + '</span>';
				$('td:eq(2)', nRow).html(col2);

				var col3 = '<span>' + aData.DisplayDateCreated + '</span>';
				$('td:eq(3)', nRow).html(col3);

				var col4 = '';
				col4 += '<a href="javascript:void(0);" rel="' + aData.PageId + '" class="action edit btn btn-info"><span>Edit</span></a>';
				col4 += '<a href="javascript:void(0);" rel="' + aData.PageId + '" class="action delete btn btn-danger"><span>Delete</span></a>';
				$('td:eq(4)', nRow).html(col4);
			},
			"aoColumnDefs": [
				{ "sClass": "", "aTargets": [0] }, 
				{ "sClass": "action-col", "aTargets": [4]}
			],
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
		$(pages._elems.txtPageUrl).val(data.PageUrl);
		$(pages._elems.txtPageMenuName).val(data.PageMenuName);
		$(pages._elems.txtPageMetaTitle).val(data.MetaTitle);
		$(pages._elems.txtPageMetaDescription).val(data.MetaDescription);
		$(pages._elems.txtPageContent).data("wysihtml5").editor.setValue(data.PageContent);
		if(data.IsHomePage) {
			$(pages._elems.chkIsHomePage).attr('checked','checked');
		}
		else {
			$(pages._elems.chkIsHomePage).removeAttr('checked');
		}
		$(pages._elems.chkIsHomePage).trigger('change');
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
		$(pages._elems.txtPageUrl).removeAttr('disabled');
		$(pages._elems.btnSavePage).attr('rel', '0');
	}
	
	function showDeletePopup(pageId) {
		globalShowPopup(420, 100, pages._elems.deletePagePopup, "Delete Page",
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
	
	function initAddOrEditSection(mode, pageId) {
		var title = '';
		if(mode === 'edit') { 
			title = 'Edit Page';
		}
		else {
			title = 'Add Page';
		}
		
		$('#form-page-popup h3').text(title);
		
		resetForm();
		preparePopupForm();
		
		if(mode === 'edit') {
			getPage(pageId, function(data) {
				var td = $(pages._elems.tablePages).find('a.edit[rel="' + pageId + '"]').parent();
				var tr = $(td).parent();
				var aPos, 
					collection, 
					dData;

				// bind data to form
				bind(data);

				// set edited pageId
				$(pages._elems.btnSavePage).attr('rel', pageId);

				pages.form.editedRow = tr;
				aPos = pages.pageTable.fnGetPosition(tr.get(0));
				pages.form.editedRowPos = aPos;
				collection = pages.pageTable.fnGetData();
				dData = collection[aPos];
				pages.form.editedData = dData;
			});
		}
		else {
			$(pages._elems.txtPageContent).data("wysihtml5").editor.setValue('');
		}

		$.scrollTo(0, 0);
	}

	function preparePopupForm() {	
		$(pages._elems.pageTabs + ' a').on('click', function (evt) {
			evt.preventDefault();
			
			$(".tab-pane").removeClass("active");
			$(".tab-btn").removeClass("active");
			
			$(this).parent().addClass("active in");
			$($(this).attr('href')).addClass("active");
			
			if($(this).hasClass('hasEditor')) {
				if(!pages.form.isEditorReady) {
					$(pages._elems.txtPageContent).wysihtml5({
						"font-styles": true, //Font styling, e.g. h1, h2, etc. Default true
						"emphasis": true, //Italics, bold, etc. Default true
						"lists": true, //(Un)ordered lists, e.g. Bullets, Numbers. Default true
						"html": true, //Button which allows you to edit the generated HTML. Default false
						"link": true, //Button to insert a link. Default true
						"image": true, //Button to insert an image. Default true
						"color": true //Button to change color of font  
					});	
					pages.form.isEditorReady = true;
				}
			}
		});
		
		$(pages._elems.pageTabs + ' a:first').trigger('click');
		
		pages.form.validators = $(pages._elems.pageFormElements).validator({
			effect: 'floatingWall',
			container: window._elems.errorContainer,
			errorInputEvent: null,
		});  
		
		$(pages._elems.chkIsHomePage).button();
	}
	
	function destroyForm() {
		$(pages._elems.chkIsHomePage).button('destroy');
		var api = _pages.form.validators.data("validator");
		api.destroy();
		pages.form.validators = {};
	}

	function setupEvents() {
		$(pages._elems.btnAddPage).click(function () {
			pageRouter.navigate("add", {trigger: true});
		});
		
		$(document).delegate(pages._elems.chkIsHomePage, 'change', function() {
			var $self = $(this);
			if($self.is(":checked")) {
				$(pages._elems.txtPageUrl).val('/');
				$(pages._elems.txtPageUrl).attr('disabled', 'disabled');
			}
			else {
				$(pages._elems.txtPageUrl).removeAttr('disabled');
			}
		});

		$(pages._elems.tablePages).delegate(pages._elems.btnEditPage, 'click', function() {
			var $self = $(this);
			var pageId = $self.attr('rel');
			pageRouter.navigate("edit/" + pageId, {trigger: true});
		});

		$(pages._elems.tablePages).delegate(pages._elems.btnDeletePage, 'click', function() {
			var $self = $(this);
			var pageId = $self.attr('rel');
			showDeletePopup(pageId);
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
		
		$('#btnClose').click(function (evt) {
			evt.preventDefault();
			destroyForm();
			pageRouter.navigate("home", {trigger: true});
		});
	}

	pages.init = function () {
		getPages(render);
		setupEvents();
		pageRouter = new PagesRouter();
		Backbone.history.start();
		pageRouter.navigate("home", {trigger: true});
	};

	pages.form = {
		isEditorReady: false,
		validators: {},
		deletedPageName: '',   
		editedRow: {},
		editedRowPos: -1,  
		editedData: {}   
	};

	pages.pageTable = {};
} (window._pages = window._pages || {}));

$(document).ready(function () {
	_pages.init();	
});