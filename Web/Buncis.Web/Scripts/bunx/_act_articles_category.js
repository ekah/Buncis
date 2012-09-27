(function (oModule) {
	oModule.router = {};
	oModule.collection = {};
	oModule.ArticleCategoryCollectionModel = Backbone.Collection.extend({
		model: oModule.ArticleCategoryModel,
		comparator: function (model) {
			var id = model.get('articleId');
			return -id;
		}
	});
	oModule.ArticleCategoryModel = Backbone.Model.extend({
		idAttribute: 'articleCategoryId',
		articleCategoryId: -1,
		articleCategoryName: '',
		articleCategoryDescription: ''
	});
	oModule.ArticleCategoryView = Backbone.View.extend({
		initialize: function () {
			_.bindAll(this, "render");
			this.model.on('change', this.renderUpdate, this);
		},
		renderUpdate: function () {
			var template = _.template($('#category-management-template').html(), this.model, _helpers.underscoreTemplateSettings);
			var $item = $('li[rel="' + this.model.id + '"]');
			$item.replaceWith(template);
			return this;
		},
		render: function () {
			var template = _.template($('#category-management-template').html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		editItem: function (event) {
			event.preventDefault();
			trace("edit category");
			var editView = new oModule.EditCategoryView({
				el: $('#article-category-edit-popup'),
				model: this.model
			});
			editView.render();

			globalShowPopup(200, 400, '#article-category-edit-popup', 'Edit Article Category',
				function () {
				},
				function () {
					editView.close();
				}
			);
		},
		deleteItem: function (event) {
			event.preventDefault();
			trace("delete category");
		}
	});
	oModule.EditCategoryView = Backbone.View.extend({
		events: {
			"click #editcategory-save": "save"
		},
		validators: {},
		reset: function () {
			this.validators = {};
		},
		render: function (event) {
			var self = this;
			var template = _.template($('#edit-category-template').html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		save: function (event) {
			event.preventDefault();
			trace('save category');

			var eModel = this.model;
			var articleCategoryName = this.$el.find('#txtCategoryName').val();
			var articleCategoryDescription = this.$el.find('#txtCategoryDescription').val();
			_helpers.blockPopupDefault();

			var sData = {
				clientId: _elems.clientId,
				articleCategory: {
					ArticleCategoryId: eModel.get('articleCategoryId'),
					ArticleCategoryName: articleCategoryName,
					ArticleCategoryDescription: articleCategoryDescription
				}
			};

			$.ajax({
				type: "POST",
				url: '/webservices/articles.svc/BPUpdateArticleCategory',
				data: JSON.stringify(sData),
				dataType: 'json',
				contentType: 'text/json',
				success: function (result) {
					trace(result);
					var data = result.d;
					_helpers.unblockPopupDefault();
					if (data.IsSuccess) {
						eModel.set('articleCategoryName', articleCategoryName);
						eModel.set('articleCategoryDescription', articleCategoryDescription);
					}
				},
				error: function () {
					_helpers.unblockPopupDefault();
				}
			});
		},
		close: function (event) {
			this.undelegateEvents();
			$(this.el).empty();
		}
	});
	function loadData() {
		_articles._categories.collection = new _articles._categories.ArticleCategoryCollectionModel();
		_articles.fn.getArticleCategories(function (articleCategories) {
			for (var ac = 0; ac < articleCategories.length; ac++) {
				var acItem = articleCategories[ac];
				var articleCategoryModel = new _articles._categories.ArticleCategoryModel({
					articleCategoryId: acItem.ArticleCategoryId,
					articleCategoryName: acItem.ArticleCategoryName,
					articleCategoryDescription: acItem.ArticleCategoryDescription
				});
				_articles._categories.collection.add(articleCategoryModel);
				renderCategoryItemView(articleCategoryModel);
			}
		});
	}

	function renderCategoryItemView(itemModel) {
		var itemView = new oModule.ArticleCategoryView({
			el: $('#category-management-container'),
			model: itemModel,
			id: 'category-' + itemModel.id
		});
		itemView.events = {};
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.edit-category'] = 'editItem';
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.delete-category'] = 'deleteItem';
		itemView.delegateEvents();
		itemView.render();
	}

	function setupEvents() {
		$('#aManageCategories').click(function (evt) {
			evt.preventDefault();
			oModule.router.navigate("categories", { trigger: true });
			loadData();
		});
	}

	oModule.init = function () {
		oModule.router = _articles.router;
		trace(oModule.router);
		setupEvents();
	};
} (window._articles._categories = window._articles._categories || {}));


$(document).ready(function () {
	_articles._categories.init();
});