(function (oNews) {
	oNews.activeFormView = null;
	oNews.newsRouter = {};
	oNews.newsCategoryList = {};
	oNews.itemViewCollection = [];
	oNews.NewsRouter = Backbone.Router.extend({
		routes: {
			"home": "home",
			"edit/:query": "edit", 
			"add": "add", 
			"categories": "managecategories"
		},
		home: function() {
			$('#homeSection').show();
			$('#news-edit-popup').hide();
			$('.news-list-wrapper').show();
			$('.news-category-management').hide();
			oNews.fn.renderData();
		},
		edit: function(query) {
			var newsId = parseInt(query, 10);
			$('#homeSection').hide();
			$('#news-edit-popup').show();
			
			if(oNews.activeFormView) {
				oNews.activeFormView.close();
				oNews.activeFormView.categoryView.close();
				oNews.activeFormView = null;
			}
			
			for (var i = 0; i < oNews.itemViewCollection.length; i++) {
				if(oNews.itemViewCollection[i].newsId === newsId) {
					oNews.itemViewCollection[i].editData();
				}
			}
		},
		add: function() {
			$('#homeSection').hide();
			$('#news-edit-popup').show();

			if(oNews.activeFormView) {
				oNews.activeFormView.close();
				oNews.activeFormView.categoryView.close();
				oNews.activeFormView = null;
			}

			oNews.fn.renderAddView();
		},
		managecategories: function () {
			trace('categories');
			$('#news-edit-popup').hide();
			$('#homeSection').show();
			$('.news-list-wrapper').hide();
			$('.news-category-management').show();
			
			if(oNews._categories) {
				oNews._categories.loadData();
			}
		}
	});
	oNews._elems = {
		detailPopup: '#news-detail-popup',
		editPopup: '#news-edit-popup',
		deletePopup: '#news-delete-popup',
		txtNewsTitle: '#txtNewsTitle',
		txtNewsContent: '#txtNewsContent',
		txtNewsTeaser: '#txtNewsTeaser',
		txtNewsUrl: '#txtNewsUrl',
		txtDateExpired: '#txtDateExpired',
		txtDatePublished: '#txtDatePublished',
		newsTabs: '#news-tabs',
		newsFormElements: '.form-item :input',
		btnSaveNews: '#btnSaveNews',
		btnAddNews: '#aAddNews',
		newsEditPopupTemplate: '#news-edit-popup-template',
		newsConfirmDeletePopupTemplate: '#news-confirmDelete-popup-template',
		newsItemTemplate: '#news-item-template',
		newsItemContainer: '.news-item-container'
	};
	oNews.form = {
		validators: {},
		reset: function() {
			this.validators = {};
		}
	};
	oNews.newsList = {};
	oNews.NewsCollection = Backbone.Collection.extend({
		model: oNews.NewsItem,
		comparator: function(newsItemModel){
			var newsId = newsItemModel.get('newsId');
			return -newsId;
		}
	});
	oNews.NewsItem = Backbone.Model.extend({
		idAttribute: 'newsId',
		newsId: 0,
		newsTitle: '',
		newsTeaser: '',
		newsContent: '',
		datePublished: '', // display date as in "Mon, 4 Aug 2012 00:00"
		dateExpired: '',
		//dateCreated: '',
		//dateLastUpdated: '',
		newsUrl: '',
		epochDatePublished: '', // epoch date from server
		epochDateExpired: '',
		formattedDatePublished: '', // display date as in 4-8-2012
		formattedDateExpired: '',
		actualDatePublished: '', // the actual date object 
		actualDateExpired: '',
		recentlyAdded: false,
		recentlyEdited: false,
		ordinal: -1,
		newsCategoryId: -1,
		newsCategoryName: ''
	});
	oNews.NewsCategoryListModel = Backbone.Model.extend({
		categories: null,
		token: ''
	});
	oNews.NewsCategoryModel = Backbone.Model.extend({
		idAttribute: 'newsCategoryId',
		newsCategoryId: 0,
		newsCategoryName: ''
	});
	oNews.NewsItemView = Backbone.View.extend({
		newsId: -1,
		initialize: function(){
			_.bindAll(this, "render");
			this.model.on('change', this.renderUpdate, this);
		},
		renderUpdate: function() {
			var template = _.template($(_news._elems.newsItemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			$('li[rel="' + this.model.get('newsId') + '"]').replaceWith(template);
			return this;
		},
		render: function(){
			var template = _.template($(_news._elems.newsItemTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		editItem: function(event) {
			event.preventDefault();
			// navigate
			_news.newsRouter.navigate("edit/" + this.model.id, {trigger: true});
		}, 
		editData: function () {
			var editView = new _news.NewsFormView({
				el: $(_news._elems.editPopup),
				model: this.model
			});			
			editView.render();
			oNews.activeFormView = editView;
			$(editView.el).find('h3').text('Edit News');
			_news.fn.prepareEditForm();
			$(_news._elems.btnSaveNews).attr('rel', 'edit');
		},
		deleteItem: function(event) {
			event.preventDefault();
			var deleteView = new _news.NewsDeleteView({
				el: $(_news._elems.deletePopup),
				model: this.model
			});
			deleteView.render();
			globalShowPopup(210, 400, _news._elems.deletePopup, 'Delete News', 
				function() {
				}, 
				function() {
					deleteView.undelegateEvents();
					$(deleteView.el).empty();
				}
			);
		},
		close: function () {
			this.undelegateEvents();
			$(this.el).empty();
		}
	});
	oNews.NewsFormView = Backbone.View.extend({
		categoryView: {},
		events: {
			'click #btnSaveNews': 'save'
		},
		render: function(event) {
			var template = _.template($(_news._elems.newsEditPopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			$.scrollTo(0, 0);
			//trace(_news.newsCategoryList);
			var categoryView = new _news.CategoryView({
				el: this.$('#news-category-container'),
				model: _news.newsCategoryList
			});
			this.categoryView = categoryView;
			categoryView.render();

			if(parseInt(this.model.get('newsCategoryId'), 10) > 0) {
				$('#radioNewsCategory button[data-categoryid=' + this.model.get("newsCategoryId") + ']').addClass('active');
			}

			return this;
		},
		save: function(event) {
			event.preventDefault();
			
			var editWebServiceUrl = '/webservices/news.svc/BPUpdateNews';	
			var addWebServiceUrl = '/webservices/news.svc/BPInsertNews';	
			var api = _news.form.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			var fMode = $(_news._elems.btnSaveNews).attr('rel');
			var title = $(_news._elems.txtNewsTitle).val();
			var teaser = $(_news._elems.txtNewsTeaser).val();
			var url = $(_news._elems.txtNewsUrl).text();
			var content = $(_news._elems.txtNewsContent).val();
			var formattedPublished = $(_news._elems.txtDatePublished).val();
			var formattedExpired = $(_news._elems.txtDateExpired).val();
			var textPublished = $(_news._elems.txtDatePublished).attr('rel');
			var epochPublished = _helpers.dateFn.convertDateStringToEpochString(textPublished);
			var textExpired = $(_news._elems.txtDateExpired).attr('rel');
			var epochExpired = _helpers.dateFn.convertDateStringToEpochString(textExpired);			
			var eNews = this.model;
			
			var selectedCategoryId = 0;
			var selectedCategoryName = '';
			var selectedCategory = $('#radioNewsCategory button.active');
			if(selectedCategory.length > 0) {
				selectedCategoryId = parseInt(selectedCategory.attr('data-categoryid'), 10);
				selectedCategoryName = selectedCategory.val();
			}
			
			var sData = {
				clientId: _elems.clientId,
				news: {
					NewsId: eNews.get('newsId'),
					NewsTitle: title,
					NewsTeaser: teaser,
					NewsContent: content,
					DisplayDateCreated: '',
					DisplayDatePublished: '',
					DisplayDateExpired: '',
					DisplayDateLastUpdated: '',
					NewsUrl: url,
					DatePublished: epochPublished,
					DateExpired: epochExpired,
					NewsCategory: {
						NewsCategoryId: selectedCategoryId,
						NewsCategoryName: selectedCategoryName,
						NewsCategoryDescription: selectedCategoryName
					} 
				}
			};
			var jData = JSON.stringify(sData);
			var wsUrl = '';
			if(sData.news.NewsId > 0) {
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
						var msg = '';
						
						eNews.set('newsTitle', title);
						eNews.set('newsTeaser', teaser);
						eNews.set('newsContent', content);
						eNews.set('formattedDatePublished', formattedPublished);
						eNews.set('formattedDateExpired', formattedExpired);
						eNews.set('epochDatePublished', epochPublished);
						eNews.set('epochDateExpired', epochExpired);
						eNews.set('newsCategoryId', selectedCategoryId);
						eNews.set('newsCategoryName', selectedCategoryName);
						
						eNews.set('newsId', data.ResponseObject.NewsId);
						eNews.set('datePublished', data.ResponseObject.DisplayDatePublished);
						eNews.set('dateExpired', data.ResponseObject.DisplayDateExpired);
						eNews.set('newsUrl', data.ResponseObject.NewsUrl);
				
						$('#btnClose').trigger('click');
				
						if(fMode === 'edit') {
							eNews.set('recentlyEdited', true);
							msg = 'Succesfully edited News data';
						}
						else {
							eNews.set('recentlyAdded', true);
							_news.newsList.add(eNews);
							
							eNews.set('ordinal', _news.newsList.length);
							_news.fn.renderListItemView(eNews);
							
							msg = 'Succesfully added new News';
						}
				
						oNews.fn.animateItem(eNews);
						globalShowMessages([msg]);
					}
				},
				error: function () {
					_helpers.unblockBuncisContentBodyDefault();
				}
			});
		},
		close: function () {
			this.undelegateEvents();
			$(this.el).empty();
		}
	});
	oNews.NewsDeleteView = Backbone.View.extend({
		events: {
			'click #deleteNews-confirm': 'confirmDelete'
		},
		render: function(event) {
			var template = _.template($(_news._elems.newsConfirmDeletePopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		confirmDelete: function(event) {
			event.preventDefault();
			var newsId = parseInt(this.model.get('newsId'), 10);
			var newsTitle = this.model.get('newsTitle'); 
			_news.fn.deleteNews(newsId, function() {
				_news.newsList.remove(this.model);
				$(_news._elems.newsItemContainer).find('li[rel="' + newsId + '"]').remove();
				globalClosePopup();
				globalShowMessages(["System has succesfully deleted News " + newsTitle]);
			});
		}
	});
	oNews.CategoryView = Backbone.View.extend({
		initialize: function(){
			_.bindAll(this, "render");
			this.model.on('change', this.renderUpdate, this);
		},
		events: {
			'click a#aAddNewsCategory': 'addCategory',
			'click a#aSaveNewsCategory': 'saveCategory'
		},
		render: function(){
			//trace(this.model);
			var template = _.template($('#category-template').html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		renderUpdate: function() {
			var template = _.template($('#category-template').html(), this.model, _helpers.underscoreTemplateSettings);
			var $item = $('#newsCategory-innerWrapper');
			$item.replaceWith(template);
			return this;
		},
		addCategory: function (event) {
			event.preventDefault();
			if($('.add-category-section').is(':visible')) {
				$('.add-category-section').hide();
			}
			else {
				$('.add-category-section').show();
				$('#txtNewsCategoryName').val('');
				$('#txtNewsCategoryName').focus();
			}
		},
		close: function (event) {
			this.undelegateEvents();
			$(this.el).empty();
		},
		saveCategory: function(event) {
			event.preventDefault();
			var $self = this;
			var categoryName = $('#txtNewsCategoryName').val();
			if(categoryName && categoryName.length > 0) {
				$('.add-category-section').hide();
				_news.fn.insertCategory(categoryName, function(result) {
					//trace(result);
					var categoryModel = new _news.NewsCategoryModel({
						newsCategoryId: result.NewsCategoryId,
						newsCategoryName: result.NewsCategoryName
					});
					$self.model.attributes.categories.push(categoryModel);
					$self.model.set('token', (new Date()).toString());
				});
			}
		}
	});
}(window._news = window._news || {}));


(function(oFn) {
	var listWebServiceUrl = '/webservices/news.svc/BPGetNewsList?clientid=' + _elems.clientId;	
	var deleteWebServiceUrl = '/webservices/news.svc/BPDeleteNews';	
	var listNewsCategoryUrl = '/webservices/news.svc/BPGetNewsCategories?clientId=' + _elems.clientId;	
	var addNewsCategoryUrl = '/webservices/news.svc/BPInsertNewsCategory';
	var generateUrlWsUrl = '/webservices/news.svc/GetNewsUrl';

	function processDataOnDatePickerSelect(selectedDate, elem) {
		var actualDate = $.datepicker.parseDate('d-m-yy', selectedDate);
		$(elem).attr('rel', actualDate);
		$(elem).trigger('change');
	}

	function dateInputChanged(elem) {
		var $elem = $(elem);
		var selectedDate = $elem.val();
		var actualDate = $.datepicker.parseDate('d-m-yy', selectedDate);
		var displayDate = $.datepicker.formatDate('D, d M yy', actualDate);
		$elem.siblings('span').text(displayDate);
	}

	function setupEvents() {
		$(_news._elems.btnAddNews).click(function(event) {
			event.preventDefault();
			_news.newsRouter.navigate("add", {trigger: true});
		});	
		$(document).delegate(_news._elems.txtDatePublished, 'change', function() {
			dateInputChanged(this);
		});
		$(document).delegate(_news._elems.txtDateExpired, 'change', function() {
			dateInputChanged(this);
		});
		$(document).delegate('#btnClose', 'click', function (evt) {
			evt.preventDefault();
			_news.activeFormView.close();
			_news.activeFormView.categoryView.close();
			_news.activeFormView = null;
			_news.newsRouter.navigate("home", {trigger: true});
		});
		$(document).delegate('#txtNewsTitle', 'blur', function (evt) {
			evt.preventDefault();
			//trace(_news.activeFormView);
			var oData = {
				newsId: _news.activeFormView.model.get("newsId"),
				newsTitle: $(this).val()
			};
			$.ajax({
				type: "POST",
				url: generateUrlWsUrl,
				data: JSON.stringify(oData),
				dataType: 'json',
				contentType: 'text/json',
				success: function (result) {
					var data = result.d;
					trace(data);
					$('#txtNewsUrl').text(data);
				},
				error: function () {
				}
			});
		});
	}
	
	function loadData(callback) {
		_news.newsList = new _news.NewsCollection();
		oFn.getNews(function(result) {
			trace(result);
			for(var i = 0; i < result.length; i++) {
				var iNewsItem = result[i];
				// create new model instance
				var cvtNewsItem = new _news.NewsItem({
					newsId: iNewsItem.NewsId,
					newsTitle: iNewsItem.NewsTitle,
					newsTeaser: iNewsItem.NewsTeaser,
					newsContent: iNewsItem.NewsContent,
					epochDatePublished: iNewsItem.DatePublished,
					epochDateExpired: iNewsItem.DateExpired,
					datePublished: iNewsItem.DisplayDatePublished,
					dateExpired: iNewsItem.DisplayDateExpired,		
					actualDatePublished: _helpers.dateFn.convertEpochToDate(_helpers.dateFn.cleanDotNetDateJson(iNewsItem.DatePublished)).toString(),
					actualDateExpired: _helpers.dateFn.convertEpochToDate(_helpers.dateFn.cleanDotNetDateJson(iNewsItem.DateExpired)).toString(),
					formattedDatePublished: _helpers.dateFn.convertEpochToDefaultFormattedString(_helpers.dateFn.cleanDotNetDateJson(iNewsItem.DatePublished)),
					formattedDateExpired: _helpers.dateFn.convertEpochToDefaultFormattedString(_helpers.dateFn.cleanDotNetDateJson(iNewsItem.DateExpired)),
					newsUrl: iNewsItem.NewsUrl,
					ordinal: i + 1
				});
				if(iNewsItem.NewsCategory) {
					cvtNewsItem.set("newsCategoryId", iNewsItem.NewsCategory.NewsCategoryId);
					cvtNewsItem.set("newsCategoryName", iNewsItem.NewsCategory.NewsCategoryName);
				}

				// put model instance to collections
				_news.newsList.add(cvtNewsItem);
			}

			// get news category
			oFn.getNewsCategories(function(newsCategories) {
				var listModel = new _news.NewsCategoryListModel({
					categories: []
				});
				for(var nc = 0; nc < newsCategories.length; nc++) {
					var ncItem = newsCategories[nc];
					var categoryModel = new _news.NewsCategoryModel({
						newsCategoryId: ncItem.NewsCategoryId,
						newsCategoryName: ncItem.NewsCategoryName
					});
					listModel.attributes.categories.push(categoryModel);
				}
				_news.newsCategoryList = listModel;
				
				if(typeof callback === "function") {
					callback();
				}
			});
		});
	}
	
	oFn.renderAddView = function () {
		var currentDate = new Date();
		var currentDatePlusOneMonth = _helpers.dateFn.convertEpochToDate((new Date()).setMonth(currentDate.getMonth() + 1));
		var defNewsItem = new _news.NewsItem({
			newsId: -1,
			newsTitle: '',
			newsTeaser: '',
			newsContent: '',
			epochDatePublished: '',
			epochDateExpired: '',
			datePublished: '',
			dateExpired: '',
			actualDatePublished: currentDate,
			actualDateExpired: currentDatePlusOneMonth,
			formattedDatePublished: _helpers.dateFn.convertDateToDefaultFormattedString(currentDate),
			formattedDateExpired: _helpers.dateFn.convertDateToDefaultFormattedString(currentDatePlusOneMonth),
			newsUrl: ''
		});
		
		var addView = new _news.NewsFormView({
			el: $(_news._elems.editPopup),
			model: defNewsItem
		});
		addView.render();
		_news.activeFormView = addView;
		$(addView.el).find('h3').text('Add News');
		_news.fn.prepareEditForm();
		$(_news._elems.txtDatePublished).trigger('change');
		$(_news._elems.txtDateExpired).trigger('change');
	};
	oFn.renderData = function() {
		//trace(_news.newsList);
		oFn.reset();
		_news.newsList.each(function (elem) {
			//trace(elem);
			_news.fn.renderListItemView(elem);	
		});
	};
	oFn.getNewsCategories = function(_callback) {
		$.ajax({
			type: "GET",
			url: listNewsCategoryUrl,
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
	oFn.animateItem = function($model) {
		var $target = $('li[rel="' + $model.id + '"]');
		if($target.length) {
			$.scrollTo($target);
		}
		window._helpers.animateRow($target);
	};	
	oFn.prepareEditForm = function() {
		_news.form.reset();       

		$(_news._elems.newsTabs + ' a').on('click', function (evt) {
			evt.preventDefault();
			
			$(".tab-pane").removeClass("active");
			$(".tab-btn").removeClass("active");
			
			$(this).parent().addClass("active in");
			$($(this).attr('href')).addClass("active");
			
			if($(this).hasClass('hasEditor')) {
				$(_news._elems.txtNewsContent).wysihtml5({
					"font-styles": true, //Font styling, e.g. h1, h2, etc. Default true
					"emphasis": true, //Italics, bold, etc. Default true
					"lists": true, //(Un)ordered lists, e.g. Bullets, Numbers. Default true
					"html": true, //Button which allows you to edit the generated HTML. Default false
					"link": true, //Button to insert a link. Default true
					"image": true, //Button to insert an image. Default true
					"color": true //Button to change color of font  
				});	
			}
		});
		
		$(_news._elems.newsTabs + ' a:first').trigger('click');

		_news.form.validators = $(_news._elems.newsFormElements).validator({
			effect: 'floatingWall',
			container: window._elems.errorContainer,
			errorInputEvent: null,
		});
		
		$(_news._elems.txtDatePublished).datepicker({
			changeMonth: true,
			numberOfMonths: 3,
			dateFormat: 'd-m-yy',
			onSelect: function(selectedDate) {
				processDataOnDatePickerSelect(selectedDate, this);
				$(_news._elems.txtDateExpired).datepicker("option", "minDate", selectedDate);
				$(_news._elems.txtDateExpired).trigger('change');
			}
		});
		$(_news._elems.txtDateExpired).datepicker({
			defaultDate: "+1w",
			changeMonth: true,
			numberOfMonths: 3,
			dateFormat: 'd-m-yy',
			onSelect: function(selectedDate) {
				processDataOnDatePickerSelect(selectedDate, this);
				$(_news._elems.txtDatePublished).datepicker("option", "maxDate", selectedDate);
				$(_news._elems.txtDatePublished).trigger('change');
			}
		});
	};
	oFn.getNews = function(_callback) {
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
	oFn.deleteNews = function(newsId, _callback) {
		var data = {
			clientId: -1,
			newsId: newsId
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
	oFn.renderListItemView = function(cvtNewsItem) {
		//trace(cvtNewsItem);
		var newsItemView = new _news.NewsItemView({ 
			el: $(_news._elems.newsItemContainer),
			model: cvtNewsItem,
			id: 'newsItem-' + cvtNewsItem.id
		});
		newsItemView.newsId = cvtNewsItem.id;
		newsItemView.events = {};
		newsItemView.events['click li[rel="' + cvtNewsItem.id + '"] a.action.edit'] = 'editItem';
		newsItemView.events['click li[rel="' + cvtNewsItem.id + '"] a.action.delete'] = 'deleteItem';
		newsItemView.delegateEvents();
		newsItemView.render();
		_news.itemViewCollection.push(newsItemView);
	};
	oFn.init = function () {
		_news.newsRouter = new _news.NewsRouter();
		loadData(function () {
			setupEvents();	
			Backbone.history.start();
			_news.newsRouter.navigate("home", {trigger: true});
		});
	}
	oFn.insertCategory = function(categoryName, _callback) {
		var sData = {
			clientId: _elems.clientId,
			newsCategory: {
				NewsCategoryId: 0,
				NewsCategoryName: categoryName,
				NewsCategoryDescription: categoryName
			}
		};
		var jData = JSON.stringify(sData);
		var wsUrl = addNewsCategoryUrl;		

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
		for (var i = 0; i < _news.itemViewCollection.length; i++) {
			_news.itemViewCollection[i].close();
		}
		_news.itemViewCollection = [];
	};
}(window._news.fn = window._news.fn || {}));


$(document).ready(function() {	
	_news.fn.init();
});

