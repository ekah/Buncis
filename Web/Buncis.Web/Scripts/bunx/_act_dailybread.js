(function (oModule) {
	var router = {};
	oModule._elems = {
		formContainer: '#edit-section',
		deletePopup: '#delete-popup',
		formElements: '.form-item :input',
		btnAdd: '#aAddDailyBread',
		editTemplate: '#edit-template',
		confirmDeletePopupTemplate: '#confirm-delete-popup-template',
		itemTemplate: '#item-template',
		itemContainer: '#dailyBread-list-container'
	};
	oModule.Router = Backbone.Router.extend({
		routes: {
			"home": "home",
			"edit/:query": "edit", 
			"add": "add", 
		},
		home: function() {
			$('#homeSection').show();
			$('#edit-section').hide();
		},
		edit: function(query) {
			$('#homeSection').hide();
			$('#edit-section').show();
		},
		add: function() {
			$('#homeSection').hide();
			$('#edit-section').show();
		}
	});
	oModule.collection = {};
	oModule.CollectionModel = Backbone.Collection.extend({
		model: oModule.ItemModel,
		comparator: function(itemModel){
			var id = itemModel.get('dailyBreadId');
			return -id;
		}
	});
	oModule.ItemModel = Backbone.Model.extend({
		idAttribute: 'dailyBreadId',
		dailyBreadId: 0,
		dailyBreadTitle: '',
		dailyBreadSummary: '',
		dailyBreadContent: '',
		dailyBreadUrl: '',
		displayDateCreated: '',
		displayDateLastUpdated: '',
		displayDatePublished: '',
		epochDatePublished: '',
		formattedDatePublished: '',
		actualDatePublished: null,
		dailyBreadBook: '',
		dailyBreadBookChapter: 0,
		dailyBreadBookVerse1: 0,
		dailyBreadBookVerse2: 0,
		dailyBreadBookContent: ''
	});
	oModule.ItemView = Backbone.View.extend({
		initialize: function(){
			_.bindAll(this, "render");
			this.model.on('change', this.renderUpdate, this);
		},
		renderUpdate: function() {
			var template = _.template($(_dailyBread._elems.itemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			var $item = $(_dailyBread._elems.itemContainer).find('li[rel="' + this.model.id + '"]');
			$item.replaceWith(template);
			oModule.fn.animateItem(this.model);
			return this;
		},
		render: function(){
			var template = _.template($(_dailyBread._elems.itemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.prepend($(template));
			return this;
		},
		editItem: function(event) {			
			_dailyBread.router.navigate("edit/" + this.model.id, {trigger: true});

			var editView = new _dailyBread.FormView({
				el: $(_dailyBread._elems.formContainer),
				model: this.model
			});
			editView.formMode = 'edit';
			editView.render();
			_dailyBread.fn.prepareForm(editView);
			$(editView.el).find('#selDailyBreadBook').val(this.model.get('dailyBreadBook'));
			$(editView.el).find('h3').text('Edit Daily Bread');
			trace(this.model);
		}, 
		deleteItem: function(event) {
			var deletePopupView = new _dailyBread.DeleteView({
				el: $(_dailyBread._elems.deletePopup),
				model: this.model
			});
			deletePopupView.render();
			globalShowPopup(200, 400, _dailyBread._elems.deletePopup, 'Delete Daily Bread', 
				function() {
				}, 
				function() {
					deletePopupView.undelegateEvents();
					$(deletePopupView.el).empty();
				}
			);
		}
	});
	oModule.FormView = Backbone.View.extend({
		formMode: '',
		validators: {},
		reset: function() {
			this.validators = {};
		},
		events: {
			'click a.close-view-area': 'close',
			'click a#btnSaveDailyBread': 'save'
		},
		render: function(event) {
			var template = _.template($(_dailyBread._elems.editTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			$.scrollTo(0, 0);
			return this;
		},
		save: function(event) {
			trace('save called');
			var self = this;
			var api = this.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			var fMode = this.formMode;
			var eModel = this.model;	
			var textPublished = $('#txtDailyBreadPublishedDate').attr('rel');
			var epochDate = _helpers.dateFn.convertDateStringToEpochString(textPublished);
			eModel.set('dailyBreadTitle', this.$el.find('#txtDailyBreadTitle').val());
			eModel.set('dailyBreadSummary', this.$el.find('#txtDailyBreadSummary').val());
			eModel.set('dailyBreadContent', this.$el.find('#txtDailyBreadContent').val());
			eModel.set('dailyBreadUrl', this.$el.find('#txtDailyBreadUrl').val());
			eModel.set('epochDatePublished', epochDate);
			eModel.set('dailyBreadBook', this.$el.find('#selDailyBreadBook').val());
			eModel.set('dailyBreadBookChapter', this.$el.find('#txtDailyBreadBookChapter').val());
			eModel.set('dailyBreadBookVerse1', this.$el.find('#txtDailyBreadBookVerse1').val());
			eModel.set('dailyBreadBookVerse2', this.$el.find('#txtDailyBreadBookVerse2').val());
			eModel.set('dailyBreadBookContent', this.$el.find('#txtDailyBreadBookContent').val());
			
			_dailyBread.fn.saveItem(eModel, function(result) {
				var msg = '';
				eModel.set('dailyBreadId', result.DailyBreadId);
				eModel.set('displayDateCreated', result.DisplayDateCreated);
				eModel.set('displayDatePublished', result.DisplayDatePublished);
				eModel.set('formattedDatePublished', _helpers.dateFn.convertEpochToDefaultFormattedString(_helpers.dateFn.cleanDotNetDateJson(result.DatePublished)));
				eModel.set('actualDatePublished', _helpers.dateFn.convertEpochToDate(_helpers.dateFn.cleanDotNetDateJson(result.DatePublished)).toString());
					
				if(fMode === 'edit') {
					msg = 'Succesfully edited daily bread data';
					self.close();
				}
				else {
					_dailyBread.collection.add(eModel);
					_dailyBread.fn.renderListItemView(eModel);
					msg = 'Succesfully added new daily bread';
					self.close();
				}
				globalShowMessages([msg]);
			});
		},
		close: function(event) {
			this.undelegateEvents();
			$(this.el).empty();
			_dailyBread.router.navigate("home", {trigger: true});
			oModule.fn.animateItem(this.model);
		}
	});
	oModule.DeleteView = Backbone.View.extend({
		events: {
			'click #delete-confirm': 'confirmDelete'
		},
		render: function(event) {
			var template = _.template($(_dailyBread._elems.confirmDeletePopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		confirmDelete: function(event) {
			var id = parseInt(this.model.id, 10);	
			var title = this.model.get('dailyBreadTitle');
			_dailyBread.fn.deleteItem(id, function() {
				_dailyBread.collection.remove(this.model);
				$(_dailyBread._elems.itemContainer).find('li[rel="' + id + '"]').remove();
				globalClosePopup();
				globalShowMessages(["System has successfully deleted daily bread " + title]);
			});
		}
	});
}(window._dailyBread = window._dailyBread || {}));


(function(oFn) {
	var listWebServiceUrl = '/webservices/dailybread.svc/BPGetDailyBreadList?clientId=' + _elems.clientId;
	var editWebServiceUrl = '/webservices/dailybread.svc/BPUpdateDailyBread';	
	var addWebServiceUrl = '/webservices/dailybread.svc/BPInsertDailyBread';	
	var deleteWebServiceUrl = '/webservices/dailybread.svc/BPDeleteDailyBread';	

	oFn.setupEvents = function() {
		log('setupEvents called');
		$(_dailyBread._elems.btnAdd).click(function(event) {
			log('add daily bread');
			event.preventDefault();				
			var defaultItem = new _dailyBread.ItemModel({
				dailyBreadId: 0,
				dailyBreadTitle: '',
				dailyBreadSummary: '',
				dailyBreadContent: '',
				dailyBreadUrl: '',
				displayDateCreated: '',
				displayDateLastUpdated: '',
				displayDatePublished: '',
				epochDatePublished: '',
				formattedDatePublished: '',
				dailyBreadBook: '',
				dailyBreadBookChapter: 0,
				dailyBreadBookVerse1: 0,
				dailyBreadBookVerse2: 0,
				dailyBreadBookContent: ''
			});
			_dailyBread.router.navigate("add", {trigger: true});
			var addView = new _dailyBread.FormView({
				el: $(_dailyBread._elems.formContainer),
				model: defaultItem
			});
			addView.formMode = 'add';
			addView.render();
			$(addView.el).find('h3').text('Add Daily Bread');
			oFn.prepareForm(addView);
		});	
		$(document).delegate('#txtDailyBreadPublishedDate', 'change', function() {
			var $elem = $(this);
			var selectedDate = $elem.val();
			var actualDate = $.datepicker.parseDate('d-m-yy', selectedDate);
			var displayDate = $.datepicker.formatDate('D, d M yy', actualDate);
			$elem.siblings('span').text(displayDate);
		});
	};
	oFn.prepareForm = function($view) {
		var $model = $view.model;
		var $target = $view.$el;
		$view.reset();
		$view.validators = $target.find(_dailyBread._elems.formElements).validator({
			effect: 'floatingWall',
			container: window._elems.errorContainer,
			errorInputEvent: null,
		});
		$target.find('textarea[id*="txtDailyBreadContent"]').wysihtml5({
			"font-styles": true, //Font styling, e.g. h1, h2, etc. Default true
			"emphasis": true, //Italics, bold, etc. Default true
			"lists": true, //(Un)ordered lists, e.g. Bullets, Numbers. Default true
			"html": true, //Button which allows you to edit the generated HTML. Default false
			"link": true, //Button to insert a link. Default true
			"image": true, //Button to insert an image. Default true
			"color": true //Button to change color of font  
		});
		$('#txtDailyBreadPublishedDate').datepicker({
			changeMonth: true,
			numberOfMonths: 1,
			dateFormat: 'd-m-yy',
			onSelect: function(selectedDate) {
				var actualDate = $.datepicker.parseDate('d-m-yy', selectedDate);
				$(this).attr('rel', actualDate);
				$(this).trigger('change');
			}
		});
	};
	oFn.getCollection = function(_callback) {
		$.ajax({
			type: "GET",
			url: listWebServiceUrl,
			success: function (result) {
				var data = result.d;
				if (data.IsSuccess) {
					if(_callback) {
						_callback(data.ResponseObject);
					}
				}
			},
			error: function () {
			}
		});
	};
	oFn.saveItem = function(oData, _callback) {
		trace('save item');
		trace(oData);
		var sData = {
			clientId: _elems.clientId,
			dailyBread: {
				DailyBreadId: oData.get('dailyBreadId'),
				DailyBreadTitle: oData.get('dailyBreadTitle'),
				DailyBreadSummary: oData.get('dailyBreadSummary'),
				DailyBreadContent: oData.get('dailyBreadContent'),
				DailyBreadUrl: oData.get('dailyBreadUrl'),
				DisplayDateCreated: '',
				DisplayDateLastUpdated: '',
				DatePublished: oData.get('epochDatePublished'),
				DisplayDatePublished: '',
				DailyBreadBook: oData.get('dailyBreadBook'),
				DailyBreadBookChapter: oData.get('dailyBreadBookChapter'),
				DailyBreadBookVerse1: oData.get('dailyBreadBookVerse1'),
				DailyBreadBookVerse2: oData.get('dailyBreadBookVerse2'),
				DailyBreadBookContent: oData.get('dailyBreadBookContent')
			}
		};
		var jData = JSON.stringify(sData);
		var wsUrl = '';
		if(sData.dailyBread.DailyBreadId > 0) { 
			wsUrl = editWebServiceUrl;			
		}
		else {
			wsUrl = addWebServiceUrl;
		}
		_helpers.blockBuncisContentBodyDefault();
		$.ajax({
			type: "POST",
			url: wsUrl,
			data: jData,
			dataType: 'json',
			contentType: 'text/json',
			success: function (result) {
				_helpers.unblockBuncisContentBodyDefault();
				var data = result.d;
				if (data.IsSuccess) {
					if(_callback) {
						_callback(data.ResponseObject);
					}
				}
			},
			error: function () {
				_helpers.unblockBuncisContentBodyDefault();
			}
		});
	};
	oFn.deleteItem = function(deletedId, _callback) {
		var data = {
			clientId: -1,
			dailyBreadId: deletedId
		};
		
		var jData = JSON.stringify(data);
		
		_helpers.blockPopupDefault();

		$.ajax({
			type: "POST",
			url: deleteWebServiceUrl,
			data: jData,
			dataType: 'json',
			contentType: 'text/json',
			success: function (result) {
				_helpers.unblockPopupDefault();
				var data = result.d;
				if (data.IsSuccess) {
					if(_callback) {
						_callback(data.ResponseObject);
					}
				}
			},
			error: function () {
				_helpers.blockPopupDefault();
			}
		});
	};
	oFn.loadData = function() {
		_dailyBread.collection = new _dailyBread.CollectionModel();
		oFn.getCollection(function(result) {
			log(result);
			for(var i = 0; i < result.length; i++) {				
				var item = result[i];
				// create new model instance
				var itemModel = new _dailyBread.ItemModel({
					dailyBreadId: item.DailyBreadId,
					dailyBreadTitle: item.DailyBreadTitle,
					dailyBreadSummary: item.DailyBreadSummary,
					dailyBreadContent: item.DailyBreadContent,
					dailyBreadUrl: item.DailyBreadUrl,
					displayDateCreated: item.DisplayDateCreated,
					displayDateLastUpdated: item.DisplayDateLastUpdated,
					displayDatePublished: item.DisplayDatePublished,
					epochDatePublished: item.DatePublished,
					formattedDatePublished: _helpers.dateFn.convertEpochToDefaultFormattedString(_helpers.dateFn.cleanDotNetDateJson(item.DatePublished)),
					actualDatePublished: _helpers.dateFn.convertEpochToDate(_helpers.dateFn.cleanDotNetDateJson(item.DatePublished)).toString(),
					dailyBreadBook: item.DailyBreadBook,
					dailyBreadBookChapter: item.DailyBreadBookChapter,
					dailyBreadBookVerse1: item.DailyBreadBookVerse1,
					dailyBreadBookVerse2: item.DailyBreadBookVerse2,
					dailyBreadBookContent: item.DailyBreadBookContent
				});

				// put model instance to collections
				_dailyBread.collection.add(itemModel);
				_dailyBread.fn.renderListItemView(itemModel);
			}
		});
	};
	oFn.renderListItemView = function(itemModel) {
		// set the view and render it
		var itemView = new _dailyBread.ItemView({ 
			el: $(_dailyBread._elems.itemContainer),
			model: itemModel,
			id: 'dailyBreadItem-' + itemModel.id
		});
		itemView.events = {};
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.edit'] = 'editItem';
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.delete'] = 'deleteItem';
		itemView.delegateEvents();
		itemView.render();
	};
	oFn.animateItem = function($model) {
		var $target = $('li[rel="' + $model.id + '"]');
		if($target.length) {
			$.scrollTo($target);
		}
		window._helpers.animateRow($target);
	};	
	oFn.init = function () {
		_dailyBread.router = new _dailyBread.Router();
		_dailyBread.fn.loadData();
		_dailyBread.fn.setupEvents();	
		Backbone.history.start();
		_dailyBread.router.navigate("home", {trigger: true});
	};
}(window._dailyBread.fn = window._dailyBread.fn || {}));


$(document).ready(function() {	
	_dailyBread.fn.init();
});

