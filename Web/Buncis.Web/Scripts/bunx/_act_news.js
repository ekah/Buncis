(function (oNews) {
	oNews._elems = {
		detailPopup: '#news-detail-popup',
		editPopup: '#news-edit-popup',
		deletePopup: '#news-delete-popup',
		newsWizards: '#news-wizard',
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
		newsItemContainer: '.newsItem-container'
	};
	oNews.form = {
		wizardHasBeenInitialized: false,
		validators: {},
		wizard: {},
		reset: function() {
			this.wizardHasBeenInitialized = false;
			this.validators = {};
			this.wizard = {};
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
		dateCreated: '',
		dateLastUpdated: '',
		friendlyUrl: '',
		epochDatePublished: '', // epoch date from server
		epochDateExpired: '',
		formattedDatePublished: '', // display date as in 4-8-2012
		formattedDateExpired: '',
		actualDatePublished: '', // the actual date object 
		actualDateExpired: '',
		recentlyAdded: false,
		recentlyEdited: false
	});
	oNews.NewsItemView = Backbone.View.extend({
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
			this.$el.prepend($(template));
			return this;
		},
		editItem: function(event) {
			var popupView = new _news.NewsFormView({
				el: $(_news._elems.editPopup),
				model: this.model
			});			
			popupView.render();

			_news.fn.showFormPopup(_news._elems.editPopup, 'Edit News', 
				function() {
					_news.fn.prepareEditForm();
					$(_news._elems.btnSaveNews).attr('rel', 'edit');
				}, 
				function() {
					popupView.undelegateEvents();
					$(popupView.el).empty();
				}
			);
		}, 
		deleteItem: function(event) {
			var deletePopupView = new _news.NewsDeleteView({
				el: $(_news._elems.deletePopup),
				model: this.model
			});
			deletePopupView.render();
			globalShowPopup(210, 400, _news._elems.deletePopup, 'Delete News', 
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
	oNews.NewsFormView = Backbone.View.extend({
		events: {
			'click #btnSaveNews': 'save'
		},
		render: function(event) {
			var template = _.template($(_news._elems.newsEditPopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		save: function(event) {
			var api = _news.form.validators.data("validator");
			var isValid = api.checkValidity();
			if(!isValid) {
				return false;
			}
			var fMode = $(_news._elems.btnSaveNews).attr('rel');
			var title = $(_news._elems.txtNewsTitle).val();
			var teaser = $(_news._elems.txtNewsTeaser).val();
			var url = $(_news._elems.txtNewsUrl).val();
			var content = $(_news._elems.txtNewsContent).val();
			var formattedPublished = $(_news._elems.txtDatePublished).val();
			var formattedExpired = $(_news._elems.txtDateExpired).val();
			var textPublished = $(_news._elems.txtDatePublished).attr('rel');
			var textExpired = $(_news._elems.txtDateExpired).attr('rel');
			var datePublished = new Date(textPublished);
			var dateExpired = new Date(textExpired);
			var tzo = parseInt((datePublished.getTimezoneOffset() / (-60)), 10);
			var itzo = tzo < 10 ? ('0' + tzo) : ('' + tzo);
			var stzo = tzo < 0 ? '-' : '+';
			var eNews = this.model;
			
			eNews.set('newsTitle', title);
			eNews.set('newsTeaser', teaser);
			eNews.set('friendlyUrl', url);
			eNews.set('newsContent', content);
			eNews.set('formattedDatePublished', formattedPublished);
			eNews.set('formattedDateExpired', formattedExpired);
			eNews.set('epochDatePublished', '/Date(' + datePublished.getTime() + stzo + itzo + '00)/');
			eNews.set('epochDateExpired', '/Date(' + dateExpired.getTime() + stzo + itzo + '00)/');			
			_news.fn.saveNews(eNews, function(result) {
				eNews.set('newsId', result.NewsId);
				eNews.set('datePublished', result.DisplayDatePublished);
				eNews.set('dateExpired', result.DisplayDateExpired);				

				$.colorbox.close();

				var msg = '';
				if(fMode === 'edit') {
					eNews.set('recentlyEdited', true);
					msg = 'Succesfully edited News data';
				}
				else {
					eNews.set('recentlyAdded', true);
					_news.newsList.add(eNews);
					_news.fn.renderListItemView(eNews);
					msg = 'Succesfully added new News';
				}
				globalShowMessages([msg]);
			});
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
			var newsId = parseInt(this.model.get('newsId'), 10);
			var newsTitle = this.model.get('newsTitle'); 
			_news.fn.deleteNews(newsId, function() {
				_news.newsList.remove(this.model);
				$(_news._elems.newsItemContainer).find('li[rel="' + newsId + '"]').remove();
				$.colorbox.close();				
				globalShowMessages(["System has succesfully deleted News " + newsTitle]);
			});
		}
	});
}(window._news = window._news || {}));


(function(oFn) {
	var listWebServiceUrl = '/webservices/news.svc/BPGetNewsList?clientid=' + _elems.clientId;	
	var editWebServiceUrl = '/webservices/news.svc/BPUpdateNews';	
	var addWebServiceUrl = '/webservices/news.svc/BPInsertNews';	
	var deleteWebServiceUrl = '/webservices/news.svc/BPDeleteNews';	

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

	oFn.setupEvents = function() {
		$(_news._elems.btnAddNews).click(function(event) {
			event.preventDefault();
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
				friendlyUrl: ''
			});
			var popupView = new _news.NewsFormView({
				el: $(_news._elems.editPopup),
				model: defNewsItem
			});
			popupView.render();

			_news.fn.showFormPopup(_news._elems.editPopup, 'Add News', 
				function() {
					_news.fn.prepareEditForm();
					$(_news._elems.txtDatePublished).trigger('change');
					$(_news._elems.txtDateExpired).trigger('change');
				}, 
				function() {
					popupView.undelegateEvents();
					$(popupView.el).empty();
				}
			);
		});	
		$(document).delegate(_news._elems.txtDatePublished, 'change', function() {
			dateInputChanged(this);
		});
		$(document).delegate(_news._elems.txtDateExpired, 'change', function() {
			dateInputChanged(this);
		});
	};
	oFn.prepareEditForm = function() {
		_news.form.reset();
		if(!_news.form.wizardHasBeenInitialized) {
			_news.form.wizard = $(_news._elems.newsWizards).smartWizard({
				keyNavigation: false,
				enableAllSteps: true,
				enableFinishButton: false, 
				labelNext: '',
				labelPrevious: '',
				labelFinish: '',
				transitionEffect: 'slideleft',
				onShowStep: function (step) {
					if($(_news._elems.txtNewsContent).is(':visible')) {
						$(_news._elems.txtNewsContent).htmlarea('dispose'); 
						$(_news._elems.txtNewsContent).htmlarea();
					}
				}
			});
			_news.form.wizardHasBeenInitialized = true;
		}
		else {
			$(_news._elems.newsTabs).find('a.tabStart').click();
		}
		_news.form.validators = $(_news._elems.newsFormElements).validator({
			effect: 'floatingWall',
			container: _elems.errorContainer,
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
	oFn.showFormPopup = function(selector, title, _completeCallback, _closedCallback) {
		globalShowPopup(662, 960, selector, title, _completeCallback, _closedCallback)
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
	oFn.saveNews = function(oData, _callback) {
		var sData = {
			clientId: _elems.clientId,
			news: {
				NewsId: oData.get('newsId'),
				NewsTitle: oData.get('newsTitle'),
				NewsTeaser: oData.get('newsTeaser'),
				NewsContent: oData.get('newsContent'),
				DisplayDateCreated: '',
				DisplayDatePublished: '',
				DisplayDateExpired: '',
				DisplayDateLastUpdated: '',
				FriendlyUrl: oData.get('friendlyUrl'),
				DateCreated: '/Date(1341158400000)/',
				DateLastUpdated: '/Date(1341158400000)/',
				DatePublished: oData.get('epochDatePublished'),
				DateExpired: oData.get('epochDateExpired')
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
	oFn.loadData = function() {
		_news.newsList = new _news.NewsCollection();
		oFn.getNews(function(result) {
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
					friendlyUrl: iNewsItem.FriendlyUrl
				});

				// put model instance to collections
				_news.newsList.add(cvtNewsItem);
				_news.fn.renderListItemView(cvtNewsItem);
			}
		});
	};
	oFn.renderListItemView = function(cvtNewsItem) {
		// set the view and render it
		var newsItemView = new _news.NewsItemView({ 
			el: $(_news._elems.newsItemContainer),
			model: cvtNewsItem,
			id: 'newsItem-' + cvtNewsItem.id
		});
		newsItemView.events = {};
		newsItemView.events['click li[rel="' + cvtNewsItem.id + '"] a.action-edit'] = 'editItem';
		newsItemView.events['click li[rel="' + cvtNewsItem.id + '"] a.action-delete'] = 'deleteItem';
		newsItemView.delegateEvents();
		newsItemView.render();
	};
}(window._news.fn = window._news.fn || {}));


$(document).ready(function() {	
	_news.fn.loadData();
	_news.fn.setupEvents();
});

