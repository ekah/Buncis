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
	oModule.articleCategoryList = {};
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
			this.$el.append($(template));
			return this;
		},
		editItem: function(event) {
			_articles.router.navigate("edit/" +  this.model.id, {trigger: true});
			var editView = new _articles.FormView({
				el: $(oModule._elems.formContainer), 
				model: this.model
			});			
			editView.events = {};
			editView.formMode = 'edit';
			editView.events['click ' + _articles._elems.formContainer + ' a.close-view-area'] = 'close';
			editView.events['click ' + _articles._elems.formContainer + ' a.btnSave'] = 'save';
			editView.delegateEvents();
			editView.render();
			$(editView.el).find('h3').text('Edit Article');
			oModule.fn.prepareForm(editView);
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
		articleCategoryView: {},
		events: {
			//EXAMPLE 'click #btnSave': 'save'
			// PUT EVENTS HERE
		},
		render: function(event) {
			var template = _.template($(_articles._elems.editTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			$.scrollTo(0, 0);
			
			var articleCategoryView = new _articles.ArticleCategoryView({
				el: this.$('#article-category-container'),
				model: _articles.articleCategoryList
			});
			this.articleCategoryView = articleCategoryView;
			articleCategoryView.render();

			return this;
		},
		save: function(event) {         
			var self = this;
			var api = this.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			var fMode = this.formMode;
			var eModel = this.model;            
			eModel.set('articleTitle', this.$el.find('[id*="txtArticleTitle"]').val());
			eModel.set('articleTeaser', this.$el.find('[id*="txtArticleTeaser"]').val());
			eModel.set('articleUrl', this.$el.find('[id*="txtArticleUrl"]').val());
			eModel.set('articleContent', this.$el.find('[id*="txtArticleContent"]').val());
			
			_articles.fn.saveItem(eModel, function(result) {
				// code below: Show message
				var msg = '';
				eModel.set('articleId', result.ArticleId);
				if(fMode === 'edit') {
					msg = 'Successfully edited article data';
					self.close();
				}
				else {
					_articles.collection.add(eModel);
					_articles.fn.renderListItemView(eModel);
					msg = 'Successfully added new article';
					self.close();            
				}
				globalShowMessages([msg]);
			});
		},
		close: function(event) {
			this.undelegateEvents();
			$(this.el).empty();
			this.articleCategoryView.close();
			_articles.router.navigate("home", {trigger: true});
			oModule.fn.animateItem(this.model);
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
				globalClosePopup();
				globalShowMessages(["System has successfully deleted article " + articleTitle]);                
			});
		}
	});
	oModule.ArticleCategoryListModel = Backbone.Model.extend({
		articleCategories: null
	});
	oModule.ArticleCategoryModel = Backbone.Model.extend({
		idAttribute: 'articleCategoryId',
		articleCategoryId: 0,
		articleCategoryName: ''
	});
	oModule.ArticleCategoryView = Backbone.View.extend({
		initialize: function(){
			_.bindAll(this, "render");
			this.model.on('change', this.renderUpdate, this);
		},
		events: {
			'click a#aAddArticleCategory': 'addCategory',
			'click a#aSaveArticleCategory': 'saveCategory'
		},
		render: function(){
			var template = _.template($('#category-template').html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		addCategory: function (event) {
			event.preventDefault();
			if($('.add-category-section').is(':visible')) {
				$('.add-category-section').hide();
			}
			else {
				$('.add-category-section').show();
			}
		},
		close: function (event) {
			this.undelegateEvents();
			$(this.el).empty();
		},
		saveCategory: function(event) {
			event.preventDefault();
			var categoryName = $('#txtArticleCategoryName').val();
			if(categoryName && categoryName.length > 0) {
				$('.add-category-section').hide();
				_articles.fn.insertArticleCategory(categoryName, function(result) {
					trace(result);
				});
			}
		}
	});
}(window._articles = window._articles || {}));


(function(oFn) {
	var listWebServiceUrl = '/webservices/articles.svc/BPGetArticles?clientId=' + _elems.clientId;	
	var editWebServiceUrl = '/webservices/articles.svc/BPUpdateArticle';	
	var addWebServiceUrl = '/webservices/articles.svc/BPInsertArticle';	
	var deleteWebServiceUrl = '/webservices/articles.svc/BPDeleteArticle';	
	var listArticleCategoryUrl = '/webservices/articles.svc/BPGetArticleCategories?clientId=' + _elems.clientId;	
	var addArticleCategoryUrl = '/webservices/articles.svc/BPInsertArticleCategory';

	function loadData() {
		_articles.collection = new _articles.CollectionModel();
		getCollection(function(result) {
			//trace(result);
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
			getArticleCategories(function (articleCategories) {
				//trace(articleCategories);
				var articleCategoryListModel = new _articles.ArticleCategoryListModel({
					articleCategories: []
				});
				for(var ac = 0; ac < articleCategories.length; ac++) {
					var acItem = articleCategories[ac];
					var articleCategoryModel = new _articles.ArticleCategoryModel({
						articleCategoryId: acItem.ArticleCategoryId,
						articleCategoryName: acItem.ArticleCategoryName
					});
					articleCategoryListModel.attributes.articleCategories.push(articleCategoryModel);
				}
				//trace(articleCategoryListModel);
				_articles.articleCategoryList = articleCategoryListModel;
			});
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

			$(addView.el).find('h3').text('Add Article');			
			oFn.prepareForm(addView);
		});		
	}
	
	function getArticleCategories(_callback) {
		$.ajax({
			type: "GET",
			url: listArticleCategoryUrl,
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

	oFn.prepareForm = function($view) {
		var $model = $view.model;
		var $target = $view.$el;
		$view.reset();
		$view.validators = $target.find(_articles._elems.formElements).validator({
			effect: 'floatingWall',
			container: window._elems.errorContainer,
			errorInputEvent: null,
		});
		$target.find('textarea[id*="txtArticleContent"]').wysihtml5({
			"font-styles": true, //Font styling, e.g. h1, h2, etc. Default true
			"emphasis": true, //Italics, bold, etc. Default true
			"lists": true, //(Un)ordered lists, e.g. Bullets, Numbers. Default true
			"html": true, //Button which allows you to edit the generated HTML. Default false
			"link": true, //Button to insert a link. Default true
			"image": true, //Button to insert an image. Default true
			"color": true //Button to change color of font  
		});	
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
				//DateCreated: '/Date(1341158400000)/',
				DisplayDateCreated: '',
				//DateLastUpdated: '/Date(1341158400000)/',
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

		_helpers.blockBuncisContentBodyDefault();
		$.ajax({
			type: "POST",
			url: wsUrl,
			data: jData,
			dataType: 'json',
			contentType: 'text/json',
			success: function (result) {
				var data = result.d;
				_helpers.unblockBuncisContentBodyDefault();
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
		if($target.length) {
			$.scrollTo($target);
		}
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
	oFn.insertArticleCategory = function(cateogryName, _callback) {
		var sData = {
			clientId: _elems.clientId,
			articleCategory: {
				ArticleCategoryId: 0,
				ArticleCategoryName: cateogryName,
				ArticleCategoryDescription: cateogryName
			}
		};
		var jData = JSON.stringify(sData);
		var wsUrl = addArticleCategoryUrl;		

		_helpers.blockBuncisContentBodyDefault();
		$.ajax({
			type: "POST",
			url: wsUrl,
			data: jData,
			dataType: 'json',
			contentType: 'text/json',
			success: function (result) {
				var data = result.d;
				_helpers.unblockBuncisContentBodyDefault();
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
}(window._articles.fn = window._articles.fn || {}));


$(document).ready(function() {	
	_articles.fn.init();	
});

