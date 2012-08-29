(function (oModule) {
	oModule._elems = {			
		editSection: '#',
		editContainer: '',
		editSectionTemplate: '#',
		deletePopup: '#',
		confirmDeletePopupTemplate: '#',		
		tabs: '#',
		formElements: '.form-item :input',		
		btnSave: '#',
		btnAdd: '#',		
		itemTemplate: '#',
		itemContainer: ''
	};
	oModule.form = {
		validators: {},
		reset: function() {
			this.validators = {};
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
		// PUT MODEL PROPERTY HERE
	});
	oModule.ItemView = Backbone.View.extend({
		initialize: function(){
			_.bindAll(this, "render");
			this.model.on('change', this.renderUpdate, this);
		},
		renderUpdate: function() {
			var template = _.template($(_articles._elems.itemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			// EXAMPLE: $('li[rel="' + this.model.get('Id') + '"]').replaceWith(template);
			// PUT THE ID ON THE ELEMENT LIST HERE
			return this;
		},
		render: function(){
			var template = _.template($(_articles._elems.itemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.prepend($(template));
			return this;
		},
		editItem: function(event) {
			var editView = new _articles.FormView({
				el: $(_articles._elems.editSection),
				model: this.model
			});			
			editView.render();

			
		}, 
		/*
		deleteItem: function(event) {
			var deletePopupView = new _articles.DeleteView({
				el: $(_articles._elems.deletePopup),
				model: this.model
			});
			deletePopupView.render();
			globalShowPopup(200, 400, _articles._elems.deletePopup, 'Delete ', 
				function() {
					$.colorbox.resize();					
				}, 
				function() {
					deletePopupView.undelegateEvents();
					$(deletePopupView.el).empty();
				}
			);
		}*/
	});
	oModule.FormView = Backbone.View.extend({
		events: {
			//EXAMPLE 'click #btnSave': 'save'
			// PUT EVENTS HERE
		},
		render: function(event) {
			var template = _.template($(_articles._elems.editSectionTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		/*
		save: function(event) {
			var api = _articles.form.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			// GET THE DATA FROM UI
			var fMode = $(_articles._elems.btnSave).attr('rel');
			// SET THE MODEL DATA HERE		
			var eModel = this.model;			
			// EXAMPLE model.set('Title', nTitle);
			
			_articles.fn.saveItem(eModel, function(result) {

				$.colorbox.close();

				var msg = '';
				if(fMode === 'edit') {
					msg = 'Successfully edited  data';
				}
				else {
					_articles.collection.add(eModel);
					_articles.fn.renderListItemView(eModel);
					msg = 'Successfully added new ';
				}
				globalShowMessages([msg]);
			});
		}
		*/
	});
	/*
	oModule.DeleteView = Backbone.View.extend({
		events: {
			// EXAMPLE: 'click #delete-confirm': 'cDelete'
			// PUT EVENTS HERE
		},
		render: function(event) {
			var template = _.template($(_articles._elems.confirmDeletePopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		confirmDelete: function(event) {
			var id = parseInt(this.model.get('ID PROPERTY HERE'), 10);
			
			_articles.fn.deleteItem(id, function() {
				_articles.collection.remove(this.model);
				//EXAMPLE: $(_articles._elems.itemContainer).find('li[rel="' + Id + '"]').remove();
				// REMOVE VIEW FROM COLLECTION
				$.colorbox.close();				
				globalShowMessages(["System has successfully deleted XXX"]);
			});
		}
	});
	*/
}(window._articles = window._articles || {}));


(function(oFn) {
	var listWebServiceUrl = '' + _elems.clientId;	
	var editWebServiceUrl = '';	
	var addWebServiceUrl = '';	
	var deleteWebServiceUrl = '';	

	oFn.setupEvents = function() {
		$(_articles._elems.btnAdd).click(function(event) {
			event.preventDefault();
			/*
			var defaultItem = new _articles.ItemModel({
				
			});
			var popupView = new _articles.FormView({
				el: $(_articles._elems.editPopup),
				model: defaultItem
			});
			popupView.render();

			_articles.fn.showFormPopup(_articles._elems.editPopup, 'Add ', 
				function() {
					_articles.fn.prepareEditForm();
				}, 
				function() {
					popupView.undelegateEvents();
					$(popupView.el).empty();
				}
			);
			*/
		});	
	};
	oFn.prepareEditForm = function() {
		_articles.form.reset();
		/*
		if(!_articles.form.wizardHasBeenInitialized) {
			_articles.form.wizard = $(_articles._elems.wizards).smartWizard({
				keyNavigation: false,
				enableAllSteps: true,
				enableFinishButton: false, 
				labelNext: '',
				labelPrevious: '',
				labelFinish: '',
				transitionEffect: 'slideleft',
				onShowStep: function (step) {
					// !!! CHANGE THIS !!!
					if($(_articles._elems."TEXTAREAHERE").is(':visible')) {
						$(_articles._elems."TEXTAREAHERE").htmlarea('dispose'); 
						$(_articles._elems."TEXTAREAHERE").htmlarea();
					}
				}
			});
			_articles.form.wizardHasBeenInitialized = true;
		}
		else {
			$(_articles._elems.tabs).find('a.tabStart').click();
		}
		_articles.form.validators = $(_articles._elems.formElements).validator({
			effect: 'floatingWall',
			container: _elems.errorContainer,
			errorInputEvent: null,
		});  
		*/
	};
	/*
	oFn.showFormPopup = function(selector, title, _completeCallback, _closedCallback) {
		globalShowPopup(662, 960, selector, title, _completeCallback, _closedCallback)
	};
	*/
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
	/*
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
	*/
	oFn.loadData = function() {
		_articles.collection = new _articles.CollectionModel();
		oFn.getCollection(function(result) {
			for(var i = 0; i < result.length; i++) {				
				var item = result[i];
				// create new model instance
				var itemModel = new _articles.ItemModel({
					// fill out model properties here
				});

				// put model instance to collections
				_articles.collection.add(itemModel);
				_articles.fn.renderListItemView(itemModel);
			}
		});
	};
	oFn.renderListItemView = function(itemModel) {
		// set the view and render it
		var itemView = new _articles.ItemView({ 
			el: $(_articles._elems.itemContainer),
			model: itemModel,
			id: 'put id here'
		});
		itemView.events = {};
		// put events here
		// EXAMPLE: ItemView.events['click li[rel="' + Item.id + '"] a.action-edit'] = 'editItem';
		itemView.delegateEvents();
		itemView.render();
	};
}(window._articles.fn = window._articles.fn || {}));


$(document).ready(function() {	
	_articles.fn.loadData();
	_articles.fn.setupEvents();
});

