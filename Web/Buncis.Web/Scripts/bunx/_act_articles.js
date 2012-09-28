(function (oModule) {
	//	oModule.ModuleRouter = Backbone.Router.extend({
	//		routes: {
	//			"home": "home",
	//			"edit/:query": "edit", 
	//			"add": "add", 
	//			"categories": "managecategories"
	//		},
	//		home: function() {
	//			$('#homeSection').show();
	//			$('#article-edit-section').hide();
	//			$('#article-list-container').show();
	//			$('.article-category-section').hide();
	//		},
	//		edit: function(query) {
	//			var articleId = query;
	//			$('#homeSection').hide();
	//			$('#article-edit-section').show();
	//		},
	//		add: function() {
	//			$('#homeSection').hide();
	//			$('#article-edit-section').show();
	//		},
	//		managecategories: function () {
	//			$('#article-list-container').hide();
	//			$('.article-category-section').show();
	//		}
	//	});
	//oModule.router = {};
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
	oModule.itemViewCollection = [];
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
		ordinal: -1,
		articleCategoryId: -1,
		articleCategoryName: ''
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
			event.preventDefault();
			trace('edit article');
			
			//_articles.router.navigate("edit/" +  this.model.get('articleId'), {trigger: true});
			$('#homeSection').hide();
			$('#article-edit-section').show();
			
			var editView = new _articles.FormView({
				el: $(oModule._elems.formContainer), 
				model: this.model
			});			
			editView.events = {};
			editView.formMode = 'edit';
			editView.events['click ' + _articles._elems.formContainer + ' a.close-view-area'] = 'close';
			editView.events['click ' + _articles._elems.formContainer + ' a.btnSave'] = 'save';
			editView.events['blur ' + _articles._elems.formContainer + ' [id*="txtArticleTitle"]'] = 'updateUrl';
			editView.delegateEvents();
			editView.render();

			$(editView.el).find('h3').text('Edit Article');
			oModule.fn.prepareForm(editView);
		}, 
		deleteItem: function(event) {
			event.preventDefault();
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
		},
		close: function () {
			this.undelegateEvents();
			$(this.el).empty();
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
			var self = this;
			var template = _.template($(_articles._elems.editTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			$.scrollTo(0, 0);
			
			var articleCategoryView = new _articles.ArticleCategoryView({
				el: this.$('#article-category-container'),
				model: _articles.articleCategoryList
			});
			this.articleCategoryView = articleCategoryView;
			articleCategoryView.render();

			// populate with additional data
			//trace(this.model);
			if(parseInt(this.model.get('articleCategoryId'), 10) > 0) {
				$('#radioArticleCategory button[data-categoryid=' + this.model.get("articleCategoryId") + ']').addClass('active');
			}
			
			return this;
		},
		save: function(event) {
			event.preventDefault();
			var editWebServiceUrl = '/webservices/articles.svc/BPUpdateArticle';	
			var addWebServiceUrl = '/webservices/articles.svc/BPInsertArticle';	
			var self = this;
			var api = this.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			var fMode = this.formMode;
			var eModel = this.model;
			var wsUrl = '';
			
			var selectedCategoryId = 0;
			var selectedCategoryName = '';
			var selectedCategory = $('#radioArticleCategory button.active');
			if(selectedCategory.length > 0) {
				selectedCategoryId = parseInt(selectedCategory.attr('data-categoryid'), 10);
				selectedCategoryName = selectedCategory.val();
			}
			var articleTitle = this.$el.find('[id*="txtArticleTitle"]').val();
			var articleTeaser = this.$el.find('[id*="txtArticleTeaser"]').val();
			var articleUrl = this.$el.find('[id*="txtArticleUrl"]').text();
			trace(articleUrl);
			var articleContent = this.$el.find('[id*="txtArticleContent"]').val();
			var articleCategoryId = selectedCategoryId;
			var articleCategoryName = selectedCategoryName;
			
			var sData = {
				clientId: _elems.clientId,
				article: {
					ArticleId: eModel.get('articleId'),
					ArticleTitle: articleTitle,
					ArticleTeaser: articleTeaser,
					ArticleUrl: articleUrl,
					ArticleContent: articleContent,
					DisplayDateCreated: '',
					DisplayDateLastUpdated: '',
					ArticleCategory: {
						ArticleCategoryId: articleCategoryId,
						ArticleCategoryName: articleCategoryName,
						ArticleCategoryDescription: articleCategoryName
					} 
				}
			};
			var jData = JSON.stringify(sData);
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
						// code below: Show message
						var msg = '';
						eModel.set('articleTitle', articleTitle);
						eModel.set('articleTeaser', articleTeaser);
						eModel.set('articleContent', articleContent);
						eModel.set('articleCategoryId', selectedCategoryId);
						eModel.set('articleCategoryName', selectedCategoryName);
						eModel.set('articleId', data.ResponseObject.ArticleId);
						eModel.set('articleUrl', data.ResponseObject.ArticleUrl);
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
					}
				},
				error: function () {
					_helpers.unblockBuncisContentBodyDefault();
				}
			});
		},
		close: function(event) {
			this.undelegateEvents();
			$(this.el).empty();
			this.articleCategoryView.close();
			
			//_articles.router.navigate("home", {trigger: true});
			$('#homeSection').show();
			$('#article-edit-section').hide();
			$('#article-list-container').show();
			$('.article-category-section').hide();
			
			oModule.fn.animateItem(this.model);
		},
		updateUrl: function (event) {
			trace('updateurl called');
			var self = this;
			var oData = {
				articleId: self.model.get("articleId"),
				articleTitle: self.$el.find('[id*="txtArticleTitle"]').val()
			};
			$.ajax({
				type: "POST",
				url: '/webservices/articles.svc/GetArticleUrl',
				data: JSON.stringify(oData),
				dataType: 'json',
				contentType: 'text/json',
				success: function (result) {
					var data = result.d;
					self.$el.find('[id*="txtArticleUrl"]').text(data);
				},
				error: function () {
				}
			});
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
			event.preventDefault();
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
		articleCategories: null,
		token: ''
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
		renderUpdate: function() {
			//trace('render update called');
			var template = _.template($('#category-template').html(), this.model, _helpers.underscoreTemplateSettings);
			var $item = $('#category-innerWrapper');
			$item.replaceWith(template);
			return this;
		},
		addCategory: function (event) {
			//trace('add category');
			event.preventDefault();
			if($('.add-category-section').is(':visible')) {
				$('.add-category-section').hide();
			}
			else {
				$('.add-category-section').show();
				$('#txtArticleCategoryName').val('');
				$('#txtArticleCategoryName').focus();
			}
		},
		close: function (event) {
			this.undelegateEvents();
			$(this.el).empty();
		},
		saveCategory: function(event) {
			//trace('save category via ajax');
			event.preventDefault();
			var $self = this;
			var categoryName = $('#txtArticleCategoryName').val();
			if(categoryName && categoryName.length > 0) {
				$('.add-category-section').hide();
				_articles.fn.insertArticleCategory(categoryName, function(result) {
					//trace(result);
					var articleCategoryModel = new _articles.ArticleCategoryModel({
						articleCategoryId: result.ArticleCategoryId,
						articleCategoryName: result.ArticleCategoryName
					});
					$self.model.attributes.articleCategories.push(articleCategoryModel);
					$self.model.set('token', (new Date()).toString());
				});
			}
		}
	});
}(window._articles = window._articles || {}));


(function(oFn) {
	var listWebServiceUrl = '/webservices/articles.svc/BPGetArticles?clientId=' + _elems.clientId;	
	var deleteWebServiceUrl = '/webservices/articles.svc/BPDeleteArticle';	
	var listArticleCategoryUrl = '/webservices/articles.svc/BPGetArticleCategories?clientId=' + _elems.clientId;	
	var addArticleCategoryUrl = '/webservices/articles.svc/BPInsertArticleCategory';
	
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

			//_articles.router.navigate("add", {trigger: true});
			$('#homeSection').hide();
			$('#article-edit-section').show();
			
			var addView = new _articles.FormView({
				el: $(_articles._elems.formContainer),
				model: defaultItem,
			});
			addView.events = {};
			addView.formMode = 'add';
			addView.events['click ' + _articles._elems.formContainer + ' a.close-view-area'] = 'close';
			addView.events['click ' + _articles._elems.formContainer + ' a.btnSave'] = 'save';
			addView.events['blur ' + _articles._elems.formContainer + ' [id*="txtArticleTitle"]'] = 'updateUrl';
			addView.delegateEvents();
			addView.render();

			$(addView.el).find('h3').text('Add Article');			
			oFn.prepareForm(addView);
		});
	}
	
	oFn.loadData = function(callback) {
		oFn.reset();
		_articles.collection = new _articles.CollectionModel();
		getCollection(function(result) {
			//trace(result);
			for(var i = 0; i < result.length; i++) {
				var item = result[i];
				//trace(item);
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
				if(item.ArticleCategory) {
					itemModel.set("articleCategoryId", item.ArticleCategory.ArticleCategoryId);
					itemModel.set("articleCategoryName", item.ArticleCategory.ArticleCategoryName);
				}

				// put model instance to collections
				_articles.collection.add(itemModel);
				_articles.fn.renderListItemView(itemModel);
			}
			_articles.fn.getArticleCategories(function (articleCategories) {
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
				
				if(typeof callback === 'function') {
					callback();
				}
			});
		});
	};
	oFn.getArticleCategories = function(_callback) {
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
	};
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
		_articles.itemViewCollection.push(itemView);
	};
	oFn.init = function() {
		//_articles.router = new _articles.ModuleRouter();
		oFn.loadData(function() {
			setupEvents();	
			$('#homeSection').show();
			$('#article-edit-section').hide();
			$('#article-list-container').show();
			$('.article-category-section').hide();
		});
		//Backbone.history.start();
		//_articles.router.navigate("home", {trigger: true});
	};
	oFn.insertArticleCategory = function(categoryName, _callback) {
		var sData = {
			clientId: _elems.clientId,
			articleCategory: {
				ArticleCategoryId: 0,
				ArticleCategoryName: categoryName,
				ArticleCategoryDescription: categoryName
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
	oFn.reset = function() {
		for (var i = 0; i < _articles.itemViewCollection.length; i++) {
			_articles.itemViewCollection[i].close();
		}
	};
}(window._articles.fn = window._articles.fn || {}));


$(document).ready(function() {	
	_articles.fn.init();	
});

