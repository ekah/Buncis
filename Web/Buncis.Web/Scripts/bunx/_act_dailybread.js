(function (oModule) {
	oModule._elems = {
		detailPopup: '#',
		editPopup: '#',
		deletePopup: '#',
		wizards: '#',		
		tabs: '#',
		formElements: '.form-item :input',		
		btnSave: '#',
		btnAdd: '#',		
		editPopupTemplate: '#',
		confirmDeletePopupTemplate: '#',
		itemTemplate: '#',
		itemContainer: ''
	};
	oModule.form = {
		wizardHasBeenInitialized: false,
		validators: {},
		wizard: {},
		reset: function() {
			this.wizardHasBeenInitialized = false;
			this.validators = {};
			this.wizard = {};
		}
	};
	oModule.collection = {};
	oModule.CollectionModel = Backbone.Collection.extend({
		model: oModule.ItemModel,
		comparator: function(itemModel){
			//	!! update !!
			var id = itemModel.get('ID PROPERTY HERE');
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
			// EXAMPLE: $('li[rel="' + this.model.get('Id') + '"]').replaceWith(template);
			// PUT THE ID ON THE ELEMENT LIST HERE
			return this;
		},
		render: function(){
			var template = _.template($(_dailyBread._elems.itemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.prepend($(template));
			return this;
		},
		editItem: function(event) {
			var popupView = new _dailyBread.FormView({
				el: $(_dailyBread._elems.editPopup),
				model: this.model
			});			
			popupView.render();

			_dailyBread.fn.showFormPopup(_dailyBread._elems.editPopup, 'Edit ', 
				function() {
					_dailyBread.fn.prepareEditForm();
					$(_dailyBread._elems.btnSave).attr('rel', 'edit');
				}, 
				function() {
					popupView.undelegateEvents();
					$(popupView.el).empty();
				}
			);
		}, 
		deleteItem: function(event) {
			var deletePopupView = new _dailyBread.DeleteView({
				el: $(_dailyBread._elems.deletePopup),
				model: this.model
			});
			deletePopupView.render();
			globalShowPopup(200, 400, _dailyBread._elems.deletePopup, 'Delete ', 
				function() {
					$.colorbox.resize();					
				}, 
				function() {
					deletePopupView.undelegateEvents();
					$(deletePopupView.el).empty();
				}
			);
		}
	});
	oModule.FormView = Backbone.View.extend({
		events: {
			//EXAMPLE 'click #btnSave': 'save'
			// PUT EVENTS HERE
		},
		render: function(event) {
			var template = _.template($(_dailyBread._elems.editPopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		save: function(event) {
			var api = _dailyBread.form.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			// GET THE DATA FROM UI
			var fMode = $(_dailyBread._elems.btnSave).attr('rel');
			// SET THE MODEL DATA HERE		
			var eModel = this.model;			
			// EXAMPLE model.set('Title', nTitle);
			
			_dailyBread.fn.saveItem(eModel, function(result) {

				$.colorbox.close();

				var msg = '';
				if(fMode === 'edit') {
					msg = 'Succesfully edited  data';
				}
				else {
					_dailyBread.collection.add(eModel);
					_dailyBread.fn.renderListItemView(eModel);
					msg = 'Succesfully added new ';
				}
				globalShowMessages([msg]);
			});
		}
	});
	oModule.DeleteView = Backbone.View.extend({
		events: {
			// EXAMPLE: 'click #delete-confirm': 'cDelete'
			// PUT EVENTS HERE
		},
		render: function(event) {
			var template = _.template($(_dailyBread._elems.confirmDeletePopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		confirmDelete: function(event) {
			var id = parseInt(this.model.get('ID PROPERTY HERE'), 10);
			
			_dailyBread.fn.deleteItem(id, function() {
				_dailyBread.collection.remove(this.model);
				//EXAMPLE: $(_dailyBread._elems.itemContainer).find('li[rel="' + Id + '"]').remove();
				// REMOVE VIEW FROM COLLECTION
				$.colorbox.close();				
				globalShowMessages(["System has succesfully deleted XXX"]);
			});
		}
	});
}(window._dailyBread = window._dailyBread || {}));


(function(oFn) {
	var listWebServiceUrl = '' + _elems.clientId;	
	var editWebServiceUrl = '';	
	var addWebServiceUrl = '';	
	var deleteWebServiceUrl = '';	

	oFn.setupEvents = function() {
		$(_dailyBread._elems.btnAdd).click(function(event) {
			event.preventDefault();
			
			var defaultItem = new _dailyBread.ItemModel({
				
			});
			var popupView = new _dailyBread.FormView({
				el: $(_dailyBread._elems.editPopup),
				model: defaultItem
			});
			popupView.render();

			_dailyBread.fn.showFormPopup(_dailyBread._elems.editPopup, 'Add ', 
				function() {
					_dailyBread.fn.prepareEditForm();
				}, 
				function() {
					popupView.undelegateEvents();
					$(popupView.el).empty();
				}
			);
		});	
	};
	oFn.prepareEditForm = function() {
		_dailyBread.form.reset();
		if(!_dailyBread.form.wizardHasBeenInitialized) {
			_dailyBread.form.wizard = $(_dailyBread._elems.wizards).smartWizard({
				keyNavigation: false,
				enableAllSteps: true,
				enableFinishButton: false, 
				labelNext: '',
				labelPrevious: '',
				labelFinish: '',
				transitionEffect: 'slideleft',
				onShowStep: function (step) {
					// !!! CHANGE THIS !!!
					if($(_dailyBread._elems."TEXTAREAHERE").is(':visible')) {
						$(_dailyBread._elems."TEXTAREAHERE").htmlarea('dispose'); 
						$(_dailyBread._elems."TEXTAREAHERE").htmlarea();
					}
				}
			});
			_dailyBread.form.wizardHasBeenInitialized = true;
		}
		else {
			$(_dailyBread._elems.tabs).find('a.tabStart').click();
		}
		_dailyBread.form.validators = $(_dailyBread._elems.formElements).validator({
			effect: 'floatingWall',
			container: _elems.errorContainer,
			errorInputEvent: null,
		});  
	};
	oFn.showFormPopup = function(selector, title, _completeCallback, _closedCallback) {
		globalShowPopup(662, 960, selector, title, _completeCallback, _closedCallback)
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
		var sData = {
			clientId: _elems.clientId,
			
		};
		var jData = JSON.stringify(sData);
		var wsUrl = '';
		
		// determine if edit/add
		// !!! CHANGE THIS !!!
		if(sData."ITEMNAMEHERE.IDHERE" > 0) { 
			wsUrl = editWebServiceUrl;			
		}
		else {
			wsUrl = addWebServiceUrl;
		}

		_helpers.blockPopupDefault();
		$.ajax({
			type: "POST",
			url: wsUrl,
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
	oFn.deleteItem = function(deletedId, _callback) {
		var data = {
			clientId: -1,			
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
			for(var i = 0; i < result.length; i++) {				
				var item = result[i];
				// create new model instance
				var itemModel = new _dailyBread.ItemModel({
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
			id: 'put id here'
		});
		itemView.events = {};
		// put events here
		// EXAMPLE: ItemView.events['click li[rel="' + Item.id + '"] a.action-edit'] = 'editItem';
		itemView.delegateEvents();
		itemView.render();
	};
}(window._dailyBread.fn = window._dailyBread.fn || {}));


$(document).ready(function() {	
	_dailyBread.fn.loadData();
	_dailyBread.fn.setupEvents();
});

