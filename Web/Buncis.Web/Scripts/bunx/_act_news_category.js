(function (oModule) {
	oModule.router = {};
	oModule.categoryManagementView = [];
	oModule.editCategoryView = {};
	oModule.collection = {};
	oModule.CategoryCollectionModel = Backbone.Collection.extend({
		model: oModule.NewsCategoryModel,
		comparator: function (model) {
			var id = model.get('newsCategoryId');
			return -id;
		}
	});
	oModule.NewsCategoryModel = Backbone.Model.extend({
		idAttribute: 'newsCategoryId',
		newsCategoryId: -1,
		newsCategoryName: '',
		newsCategoryDescription: ''
	});
	oModule.NewsCategoryView = Backbone.View.extend({
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
				el: $('#news-category-edit-popup'),
				model: this.model
			});
			editView.render();
			oModule.editCategoryView = editView;
			globalShowPopup(200, 400, '#news-category-edit-popup', 'Edit News Category',
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
			var deletePopupView = new oModule.DeleteCategoryView({
				el: $('#news-category-delete-popup'),
				model: this.model
			});
			deletePopupView.render();

			globalShowPopup(200, 400, '#news-category-delete-popup', 'Delete News Category',
				function () {
				},
				function () {
					deletePopupView.close();
				}
			);
		},
		close: function () {
			this.undelegateEvents();
			$(this.el).empty();
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

			var self = this;
			var eModel = this.model;
			var fMode = parseInt(eModel.get('newsCategoryId'), 10) > 0 ? "edit" : "add";
			var newsCategoryName = this.$el.find('#txtCategoryName').val();
			var newsCategoryDescription = this.$el.find('#txtCategoryDescription').val();
			_helpers.blockPopupDefault();

			var sData = {
				clientId: _elems.clientId,
				newsCategory: {
					NewsCategoryId: eModel.get('newsCategoryId'),
					NewsCategoryName: newsCategoryName,
					NewsCategoryDescription: newsCategoryDescription
				}
			};

			$.ajax({
				type: "POST",
				url: '/webservices/news.svc/BPUpdateNewsCategory',
				data: JSON.stringify(sData),
				dataType: 'json',
				contentType: 'text/json',
				success: function (result) {
					trace(result);
					var data = result.d;
					_helpers.unblockPopupDefault();
					if (data.IsSuccess) {
						eModel.set('newsCategoryId', data.ResponseObject.NewsCategoryId);
						eModel.set('newsCategoryName', newsCategoryName);
						eModel.set('newsCategoryDescription', newsCategoryDescription);
						if (fMode === 'edit') {
							msg = 'Successfully edited news category';
							self.close();
						}
						else {
							oModule.collection.add(eModel);
							renderCategoryItemView(eModel);
							msg = 'Successfully added new news category';
							self.close();
						}
						globalShowMessages([msg]);
					}
					else {
						_helpers.unblockPopupDefault();
						globalShowError([data.Message]);
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
	oModule.DeleteCategoryView = Backbone.View.extend({
		events: {
			'click #deleteCategory-confirm': 'confirmDelete'
		},
		render: function (event) {
			var template = _.template($('#category-delete-template').html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		confirmDelete: function (event) {
			event.preventDefault();
			var self = this;
			var id = parseInt(this.model.get('newsCategoryId'), 10);
			var name = this.model.get('newsCategoryName');
			var sdata = {
				clientId: -1,
				newsCategoryId: id
			};
			var jData = JSON.stringify(sdata);
			$.ajax({
				type: "POST",
				url: '/webservices/news.svc/BPDeleteNewsCategory',
				data: jData,
				dataType: 'json',
				contentType: 'text/json',
				success: function (result) {
					var data = result.d;
					if (data.IsSuccess) {
						oModule.collection.remove(self.model);
						$('#category-management-container').find('li[rel="' + id + '"]').remove();
						globalClosePopup();
						globalShowMessages(["System has successfully deleted news category " + name]);
					}
					else {
						globalShowError([data.Message]);
					}
				},
				error: function () {
					_helpers.unblockPopupDefault();
				}
			});
		},
		close: function () {
			this.undelegateEvents();
			$(this.el).empty();
		}
	});

	oModule.loadData = function () {
		oModule.reset();
		_news._categories.collection = new _news._categories.CategoryCollectionModel();
		_news.fn.getNewsCategories(function (newsCategories) {
			for (var ac = 0; ac < newsCategories.length; ac++) {
				var acItem = newsCategories[ac];
				var categoryModel = new _news._categories.NewsCategoryModel({
					newsCategoryId: acItem.NewsCategoryId,
					newsCategoryName: acItem.NewsCategoryName,
					newsCategoryDescription: acItem.NewsCategoryDescription
				});
				_news._categories.collection.add(categoryModel);
				renderCategoryItemView(categoryModel);
			}
		});
	};

	function renderCategoryItemView(itemModel) {
		var itemView = new oModule.NewsCategoryView({
			el: $('#category-management-container'),
			model: itemModel,
			id: 'category-' + itemModel.id
		});
		itemView.events = {};
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.edit-category'] = 'editItem';
		itemView.events['click li[rel="' + itemModel.id + '"] a.action.delete-category'] = 'deleteItem';
		itemView.delegateEvents();
		itemView.render();
		oModule.categoryManagementView.push(itemView);
	}

	function setupEvents() {
		$('#aManageCategories').click(function (evt) {
			evt.preventDefault();
			trace('manage news categories');
			oModule.router.navigate("categories", { trigger: true });
			//loadData();
		});
		$(document).delegate('.btnBack', 'click', function (evt) {
			evt.preventDefault();
			oModule.reset();
			oModule.router.navigate("home", { trigger: true });
		});
		$(document).delegate('#editcategory-cancel', 'click', function (evt) {
			evt.preventDefault();
			oModule.editCategoryView.close();
		});
		$(document).delegate('#mAddNewsCategory', 'click', function (evt) {
			evt.preventDefault();

			var defaultItem = new oModule.NewsCategoryModel({
				newsCategoryId: -1,
				newsCategoryName: '',
				newsCategoryDescription: ''
			});

			var addView = new oModule.EditCategoryView({
				el: $('#news-category-edit-popup'),
				model: defaultItem
			});
			addView.render();

			oModule.editCategoryView = addView;

			globalShowPopup(200, 400, '#news-category-edit-popup', 'Add News Category',
				function () {
				},
				function () {
					editView.close();
				}
			);
		});
	}
	oModule.reset = function () {
		for (var i = 0; i < oModule.categoryManagementView.length; i++) {
			oModule.categoryManagementView[i].close();
		}
		oModule.categoryManagementView = [];
	};
	oModule.init = function () {
		oModule.router = _news.newsRouter;
		trace(oModule.router);
		setupEvents();
	};
} (window._news._categories = window._news._categories || {}));


$(document).ready(function () {
	_news._categories.init();
});