/*
(function (oArticle) {

	var oCollection = {};

	oArticle._elems = {
		clonedClass: 'cloned-view-template',
		clonnedSelector: '.cloned-view-template',
		templateClass: '.article-view-template',
		templateSelector: '.article-view-template',
		viewAreaContainerSelector: '.view-container',
		viewAreaCloseButtonSelector: '.close-view-area',
		articleItemSelector: '.article-item'
	};
	
	function setupEvents() {
		$(_article._elems.viewAreaCloseButtonSelector).click(function (evt) {
			evt.preventDefault();
			$(_article._elems.clonnedSelector).remove();
		});
		$(_article._elems.articleItemSelector).click(function (evt) {
			var $self = $(this);
			
			var container = $self.parent().find(_article._elems.viewAreaContainerSelector);
			var existing = $self.parent().find(_article._elems.clonnedSelector);
			if (existing.length) {
				return false;
			}

			cloned.removeClass(templateClass);
			cloned.addClass(clonedClass);
			cloned.appendTo(container).slideDown('slow');

		});
	}


} (window._article = window._article || {}));

$(document).ready(function () {
	_article.init();
});

*/

(function (oModule) {
	oModule._elems = {
		tabs: '#',
		formElements: '.form-item :input',		
		btnSave: '#',
		btnAdd: '#',
		addContainer: '#',
		itemTemplate: '#article-item-template',
		itemContainer: '#article-list-container',
		editContainer: '#',
		editTemplate: '#article-edit-template',
		deletePopup: '#',
		confirmDeletePopupTemplate: '#'
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
		articleId: 0,
		articleTitle: '',
		articleTeaser: '',
		articleContent: '',
		displayDateCreated: '',
		displayDateLastUpdated: ''
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
				el: $(_articles._elems.editContainer),
				model: this.model
			});			
			editView.render();

			// DO POST PROCESSING OF THE FORM VIEW HERE
		}, 
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
		}
	});
	oModule.FormView = Backbone.View.extend({
		events: {
			//EXAMPLE 'click #btnSave': 'save'
			// PUT EVENTS HERE
		},
		render: function(event) {
			var template = _.template($(_articles._elems.editTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
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

				// POST PROCESSING AFTER SAVE

				// code below: Show message
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
	});
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
				
				// POST PROCESSING AFTER SUCCSES DELETE
						
				globalShowMessages(["System has successfully deleted XXX"]);
			});
		}
	});
}(window._articles = window._articles || {}));


(function(oFn) {
	var listWebServiceUrl = '/webservices/articles.svc/BPGetArticles?clientId=' + _elems.clientId;	
	var editWebServiceUrl = '';	
	var addWebServiceUrl = '';	
	var deleteWebServiceUrl = '';	

	oFn.setupEvents = function() {
		$(_articles._elems.btnAdd).click(function(event) {
			event.preventDefault();			
			var defaultItem = new _articles.ItemModel({});
			var addView = new _articles.FormView({
				el: $(_articles._elems.addContainer),
				model: defaultItem
			});
			addView.render();

			// DO POST PROCESS AFTER ADD VIEW IS ADDED TO STAGE
		});	
	};
	oFn.prepareForm = function() {
		_articles.form.reset();
		_articles.form.validators = $(_articles._elems.formElements).validator({
			effect: 'floatingWall',
			container: _elems.errorContainer,
			errorInputEvent: null,
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
		var sData = {
			clientId: _elems.clientId,
			// PUT DATE OBJECT HERE
		};
		var jData = JSON.stringify(sData);
		var wsUrl = '';
		
		// determine if edit/add
		// !!! CHANGE THIS !!!
		
        //        if(sData."ITEMNAMEHERE.IDHERE" > 0) { 
        //			wsUrl = editWebServiceUrl;			
        //		}
        //		else {
        //			wsUrl = addWebServiceUrl;
        //		}

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
			// PUT DELETED ID HERE
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
		_articles.collection = new _articles.CollectionModel();
		oFn.getCollection(function(result) {
			for(var i = 0; i < result.length; i++) {				
				var item = result[i];
				
				// create new model instance
				var itemModel = new _articles.ItemModel({
					articleId: item.ArticleId,
					articleTitle: item.ArticleTitle,
					articleTeaser: item.ArticleTeaser,
					articleContent: item.ArticleContent,
					displayDateCreated: item.DisplayDateCreated,
					displayDateLastUpdated: item.DisplayDateLastUpdated
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

