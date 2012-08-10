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
		newsDate: '.newsDate',
		btnSaveNews: '#btnSaveNews',
		btnAddNews: '#aAddNews',
		newsListWrapper: '.news-list-wrapper',
		newsEditPopupTemplate: '#news-edit-popup-template',
		newsConfirmDeletePopupTemplate: '#news-confirmDelete-popup-template',
		newsItemTemplate: '#news-item-template',
		newsItemContainer: ".newsItem-container"
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
		model: oNews.newsItem,
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
		datePublished: '', // display date as in 4 Aug 2012
		dateExpired: '',
		dateCreated: '',
		dateLastUpdated: '',
		friendlyUrl: '',
		oDatePublished: '', // epoch date from server
		oDateExpired: '',
		tDatePublished: '', // display date as in 4-8-2012
		tDateExpired: '',
		eDatePublished: '', // the actual date object 
		eDateExpired: '',
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
		edit: function(event) {
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
		delete: function(event) {
			var deletePopupView = new _news.NewsDeleteView({
				el: $(_news._elems.deletePopup),
				model: this.model
			});
			deletePopupView.render();
			globalShowPopup(200, 400, _news._elems.deletePopup, 'Delete News', 
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
			var nTitle = $(_news._elems.txtNewsTitle).val();
			var nTeaser = $(_news._elems.txtNewsTeaser).val();
			var nUrl = $(_news._elems.txtNewsUrl).val();
			var nContent = $(_news._elems.txtNewsContent).val();
			var nPublished = $(_news._elems.txtDatePublished).val();
			var nExpired = $(_news._elems.txtDateExpired).val();
			var oPublished = $(_news._elems.txtDatePublished).attr('rel');
			var oExpired = $(_news._elems.txtDateExpired).attr('rel');
			var dPublished = new Date(oPublished);
			var dExpired = new Date(oExpired);
			var tzo = parseInt((dPublished.getTimezoneOffset() / (-60)), 10);
			var itzo = tzo < 10 ? ('0' + tzo) : ('' + tzo);
			var stzo = tzo < 0 ? '-' : '+';
			var eNews = this.model;
			
			eNews.set('newsTitle', nTitle);
			eNews.set('newsTeaser', nTeaser);
			eNews.set('friendlyUrl', nUrl);
			eNews.set('newsContent', nContent);
			eNews.set('tDatePublished', nPublished);
			eNews.set('tDateExpired', nExpired);
			eNews.set('oDatePublished', '/Date(' + dPublished.getTime() + stzo + itzo + '00)/');
			eNews.set('oDateExpired', '/Date(' + dExpired.getTime() + stzo + itzo + '00)/');			
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
			'click #deleteNews-confirm': 'cDelete'
		},
		render: function(event) {
			var template = _.template($(_news._elems.newsConfirmDeletePopupTemplate).html(), this.model, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));
			return this;
		},
		cDelete: function(event) {
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
	var listWebServiceUrl = '/webservices/news.svc/bPanelGetNewsList?clientid=' + _elems.clientId;	
	var editWebServiceUrl = '/webservices/news.svc/bPanelUpdateNews';	
	var addWebServiceUrl = '/webservices/news.svc/bPanelInsertNews';	
	var deleteWebServiceUrl = '/webservices/news.svc/bPanelDeleteNews';	

	oFn.setupEvents = function() {
		$(_news._elems.btnAddNews).click(function(event) {
			event.preventDefault();
			var currentDate = new Date();
			var currentDatePlusOneMonth = _helpers.convertEpochToDate((new Date()).setMonth(currentDate.getMonth() + 1));
			var defNewsItem = new _news.NewsItem({
				newsId: -1,
				newsTitle: '',
				newsTeaser: '',
				newsContent: '',
				oDatePublished: '',
				oDateExpired: '',
				datePublished: '',
				dateExpired: '',
				eDatePublished: currentDate,
				eDateExpired: currentDatePlusOneMonth,
				tDatePublished: _helpers.convertDateToString(currentDate),
				tDateExpired: _helpers.convertDateToString(currentDatePlusOneMonth),
				friendlyUrl: ''
			});
			var popupView = new _news.NewsFormView({
				el: $(_news._elems.editPopup),
				model: defNewsItem
			});
			popupView.render();

			_news.fn.showFormPopup(_news._elems.editPopup, 'Add News', 
				function() {
					_news.fn.prepareEditForm(currentDate, currentDatePlusOneMonth);
				}, 
				function() {
					popupView.undelegateEvents();
					$(popupView.el).empty();
				}
			);
		});	
	};
	oFn.prepareEditForm = function(published, expired) {
		_news.form.reset();
		if(!_news.form.wizardHasBeenInitialized) {
			_news.form.wizard = $(_news._elems.newsWizards).smartWizard({
				keyNavigation: false,
				enableAllSteps: true,
				enableFinishButton: false, 
				labelNext: '',
				labelPrevious: '',
				labelFinish: '',
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

		var startDate = '';
		var endDate = '';
		var currentDate = new Date();
		if(published) {			
			startDate = published.getDate() + '-' + (published.getMonth() + 1) + '-' + published.getFullYear();
		}
		else {			
			startDate = currentDate.getDate() + '-' + (currentDate.getMonth() + 1) + '-' + currentDate.getFullYear();
		}
		if(expired) {
			endDate = expired.getDate() + '-' + (expired.getMonth() + 1) + '-' + expired.getFullYear();
		}
		else {
			endDate = currentDate.getDate() + '-' + (currentDate.getMonth() + 1) + '-' + currentDate.getFullYear();	
		}
		
		$(_news._elems.newsDate).DatePicker({
			flat: false,
			date: [startDate, endDate],	
			current: startDate,
			format: 'd-m-Y',
			calendars: 3,
			mode: 'range',
			onChange: function(formatted, dates) {
				$(_news._elems.txtDatePublished).val(formatted[0]);
				$(_news._elems.txtDateExpired).val(formatted[1]);		
				$(_news._elems.txtDatePublished).attr('rel', dates[0]);
				$(_news._elems.txtDateExpired).attr('rel', dates[1]);
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
				DatePublished: oData.get('oDatePublished'),
				DateExpired: oData.get('oDateExpired')
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
					oDatePublished: iNewsItem.DatePublished,
					oDateExpired: iNewsItem.DateExpired,
					datePublished: iNewsItem.DisplayDatePublished,
					dateExpired: iNewsItem.DisplayDateExpired,		
					eDatePublished: _helpers.convertEpochToDate(_helpers.cleanDotNetDateJson(iNewsItem.DatePublished)).toString(),
					eDateExpired: _helpers.convertEpochToDate(_helpers.cleanDotNetDateJson(iNewsItem.DateExpired)).toString(),
					tDatePublished: _helpers.convertEpochToString(_helpers.cleanDotNetDateJson(iNewsItem.DatePublished)),
					tDateExpired: _helpers.convertEpochToString(_helpers.cleanDotNetDateJson(iNewsItem.DateExpired)),
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
		newsItemView.events['click li[rel="' + cvtNewsItem.id + '"] a.action-edit'] = 'edit';
		newsItemView.events['click li[rel="' + cvtNewsItem.id + '"] a.action-delete'] = 'delete';
		newsItemView.delegateEvents();
		newsItemView.render();
	};
}(window._news.fn = window._news.fn || {}));


$(document).ready(function() {	
	_news.fn.loadData();
	_news.fn.setupEvents();
});

