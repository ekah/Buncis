(function (oModule) {
	oModule.ModuleRouter = Backbone.Router.extend({
		routes: {
			"home": "home",
			"edit/:query": "edit", 
			"add": "add", 
		},
		home: function() {
			$('#homeSection').show();
			$('#article-edit-section').hide();
		},
		edit: function(query) {
			var articleId = query;
			$('#homeSection').hide();
			$('#article-edit-section').show();
		},
		add: function() {
			$('#homeSection').hide();
			$('#article-edit-section').show();
		}
	});
	oModule.router = {};
	oModule.activeView = {};
	oModule._elems = {
		formElements: '.form-item :input',		
		btnAdd: '#aAddArticle',
		formContainer: '#article-edit-section',
		itemTemplate: '#article-item-template',
		itemContainer: '#article-list-container',
		editTemplate: '#article-edit-template',
		deletePopup: '#article-delete-popup',
		confirmDeletePopupTemplate: '#article-confirmDelete-popup-template'
	};	
	oModule.collection = {};
	oModule.CollectionModel = Backbone.Collection.extend({
		model: oModule.ItemModel,
		comparator: function(itemModel){
			var id = itemModel.get('articleId');
			return -id;
		}
	});
	oModule.ItemModel = Backbone.Model.extend({
		idAttribute: 'articleId',
		articleId: 0,
		articleTitle: '',
		articleTeaser: '',
		articleUrl: '',
		articleContent: '',
		displayDateCreated: '',
		displayDateLastUpdated: '',
		ordinal: -1
	});
	oModule.ItemView = Backbone.View.extend({
		initialize: function(){
			_.bindAll(this, "render");
			this.model.on('change', this.renderUpdate, this);
		},
		renderUpdate: function() {
			var template = _.template($(_articles._elems.itemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			var $item = $('li[rel="' + this.model.id + '"]');
			$item.replaceWith(template);
			oModule.fn.animateItem(this.model);
			return this;
		},
		render: function(){
			var template = _.template($(_articles._elems.itemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.prepend($(template));
			return this;
		},
		editItem: function(event) {
			var $model = this.model;
			var $parent = $('li[rel="' + $model.id + '"]');

			_articles.router.navigate("edit/" +  $model.id, {trigger: true});

			var editView = new _articles.FormView({
				el: $(oModule._elems.formContainer), 
				model: $model
			});			
			editView.events = {};
			editView.formMode = 'edit';
			editView.events['click ' + _articles._elems.formContainer + ' a.close-view-area'] = 'close';
			editView.events['click ' + _articles._elems.formContainer + ' a.btnSave'] = 'save';
			editView.delegateEvents();
			editView.render();

			oModule.activeView = editView;
			$(editView.el).find('h3').text('Edit Article');			
			oModule.fn.prepareForm(editView);
			$.scrollTo($parent);
		}, 
		deleteItem: function(event) {
			var deletePopupView = new _articles.DeleteView({
				el: $(_articles._elems.deletePopup),
				model: this.model
			});
			deletePopupView.render();

			globalShowPopup(200, 400, _articles._elems.deletePopup, 'Delete Article', 
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
			//EXAMPLE 'click #btnSave': 'save'
			// PUT EVENTS HERE
		},
		render: function(event) {
			var template = _.template($(_articles._elems.editTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		save: function(event) {         
			var self = this;
			var api = this.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			// GET THE DATA FROM UI
			var fMode = this.formMode;
			// SET THE MODEL DATA HERE	            	
			var eModel = this.model;            
			eModel.set('articleTitle', this.$el.find('[id*="txtArticleTitle"]').val());
			eModel.set('articleTeaser', this.$el.find('[id*="txtArticleTeaser"]').val());
			eModel.set('articleUrl', this.$el.find('[id*="txtArticleUrl"]').val());
			eModel.set('articleContent', this.$el.find('[id*="txtArticleContent"]').val());
			
			_articles.fn.saveItem(eModel, function(result) {
				// code below: Show message
				var msg = '';

				eModel.set('articleId', result.ArticleId);

				$('#btnClose').trigger('click');

				if(fMode === 'edit') {
					msg = 'Successfully edited  data';
					self.closeView();
				}
				else {
					_articles.collection.add(eModel);
					_articles.fn.renderListItemView(eModel);
					msg = 'Successfully added new ';
					self.closeView();            
					oModule.fn.animateItem(eModel);
				}

				var affected = $(_articles._elems.itemContainer).find('li[rel="' + result.ArticleId + '"]');
				$.scrollTo(affected);

				globalShowMessages([msg]);
			});
		},
		close: function(event) {
			this.closeView();
			_articles.router.navigate("home", {trigger: true});
			oModule.fn.animateItem($model);
		},
		closeView: function() {
			this.undelegateEvents();
			$(this.el).empty();
		}
	});
	oModule.DeleteView = Backbone.View.extend({
		events: {
			'click #deleteArticle-confirm': 'confirmDelete'
		},
		render: function(event) {
			var template = _.template($(_articles._elems.confirmDeletePopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		confirmDelete: function(event) {
			var id = parseInt(this.model.get('articleId'), 10);	
			var articleTitle = this.model.get('articleTitle');
			_articles.fn.deleteItem(id, function() {                
				_articles.collection.remove(this.model);
				$(_articles._elems.itemContainer).find('li[rel="' + id + '"]').remove();
				globalShowMessages(["System has successfully deleted article " + articleTitle]);                
			});
		}
	});
}(window._articles = window._articles || {}));


(function(oFn) {
	var listWebServiceUrl = '/webservices/articles.svc/BPGetArticles?clientId=' + _elems.clientId;	
	var editWebServiceUrl = '/webservices/articles.svc/BPUpdateArticle';	
	var addWebServiceUrl = '/webservices/articles.svc/BPInsertArticle';	
	var deleteWebServiceUrl = '/webservices/articles.svc/BPDeleteArticle';	

	function loadData() {
		_articles.collection = new _articles.CollectionModel();
		getCollection(function(result) {
			for(var i = 0; i < result.length; i++) {				
				var item = result[i];
				
				// create new model instance
				var itemModel = new _articles.ItemModel({
					articleId: item.ArticleId,
					articleTitle: item.ArticleTitle,
					articleTeaser: item.ArticleTeaser,
					articleUrl: item.ArticleUrl,
					articleContent: item.ArticleContent,
					displayDateCreated: item.DisplayDateCreated,
					displayDateLastUpdated: item.DisplayDateLastUpdated
				});

				// put model instance to collections
				_articles.collection.add(itemModel);
				_articles.fn.renderListItemView(itemModel);
			}
		});
	}

	function getCollection(_callback) {
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
	}

	function setupEvents() {
		$(_articles._elems.btnAdd).click(function(event) {
			event.preventDefault();			
			var defaultItem = new _articles.ItemModel({
				articleId: -1,
				articleTitle: '',
				articleTeaser: '',
				articleUrl: '',
				articleContent: '',
				displayDateCreated: '',
				displayDateLastUpdated: ''
			});

			_articles.router.navigate("add", {trigger: true});

			var addView = new _articles.FormView({
				el: $(_articles._elems.formContainer),
				model: defaultItem,
			});
			addView.events = {};
			addView.formMode = 'add';
			addView.events['click ' + _articles._elems.formContainer + ' a.close-view-area'] = 'close';
			addView.events['click ' + _articles._elems.formContainer + ' a.btnSave'] = 'save';
			addView.delegateEvents();            
			addView.render();

			_articles.activeView = addView;
			$(addView.el).find('h3').text('Add Article');			
			oFn.prepareForm(addView);
		});		
	}

	oFn.prepareForm = function($view) {
		var $model = $view.model;
		var $target = $view.$el;
		$view.reset();
		$view.validators = $target.find(_articles._elems.formElements).validator({
			effect: 'floatingWall',
			container: _elems.errorContainer,
			errorInputEvent: null,
		});        
		var $tContent = $target.find('#txtArticleContent-' + $model.id);
		if($tContent.is(':visible')) {
			$tContent.htmlarea('dispose'); 
			$tContent.htmlarea();
		}
	};		
	oFn.saveItem = function(oData, _callback) {
		var sData = {
			clientId: _elems.clientId,
			article: {
				ArticleId: oData.get('articleId'),
				ArticleTitle: oData.get('articleTitle'),
				ArticleTeaser: oData.get('articleTeaser'),
				ArticleUrl: oData.get('articleUrl'),
				ArticleContent: oData.get('articleContent'),
				DateCreated: '/Date(1341158400000)/',
				DisplayDateCreated: '',
				DateLastUpdated: '/Date(1341158400000)/',
				DisplayDateLastUpdated: ''
			}
		};
		var jData = JSON.stringify(sData);
		var wsUrl = '';
		
		// determine if edit/add				
		if(sData.article.ArticleId > 0) { 
			wsUrl = editWebServiceUrl;			
		}
		else {
			wsUrl = addWebServiceUrl;
		}

		
		$.ajax({
			type: "POST",
			url: wsUrl,
			data: jData,
			dataType: 'json',
			contentType: 'text/json',
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
	oFn.deleteItem = function(deletedId, _callback) {
		var data = {
			clientId: -1,			
			articleId: deletedId
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
	oFn.animateItem = function($model) {
		var $target = $('li[rel="' + $model.id + '"]');
		$.scrollTo($target);
		window._helpers.animateRow($target);
	};	
	oFn.renderListItemView = function(itemModel) {
		// set the view and render it
		var itemView = new _articles.ItemView({ 
			el: $(_articles._elems.itemContainer),
			model: itemModel,
			id: 'articleItem-' + itemModel.id
		});
		itemView.events = {};	
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.edit'] = 'editItem';
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.delete'] = 'deleteItem';
		itemView.delegateEvents();
		itemView.render();
	};
	oFn.init = function() {
		_articles.router = new _articles.ModuleRouter();
		loadData();
		setupEvents();
		Backbone.history.start();
		_articles.router.navigate("home", {trigger: true});
	};
}(window._articles.fn = window._articles.fn || {}));


$(document).ready(function() {	
	_articles.fn.init();	
});

