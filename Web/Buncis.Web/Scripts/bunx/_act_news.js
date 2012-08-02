News = Ember.Application.create();

News.NewsItem = Ember.Object.extend({
	newsId: 0,
	newsTitle: '',
	newsTeaser: '',
	newsContent: '',
	datePublished: '',
	dateExpired: '',
	dateCreated: '',
	dateLastUpdated: '',
	friendlyUrl: '',
	oDatePublished: '',
	oDateExpired: '',
	tDatePublished: '',
	tDateExpired: ''
});

News.newsController = Ember.Object.create({
	newsList: [],
	loadData: function() {
		this.newsList = [];
		News.fn.getNews(function(result) {
			var converted = [];
			for(var i = 0; i < result.length; i++) {				
				var iNewsItem = result[i];
				var newNewsItem = News.NewsItem.create({					
					newsId: iNewsItem.NewsId,
					newsTitle: iNewsItem.NewsTitle,
					newsTeaser: iNewsItem.NewsTeaser,
					newsContent: iNewsItem.NewsContent,
					oDatePublished: iNewsItem.DatePublished,
					oDateExpired: iNewsItem.DateExpired,
					datePublished: iNewsItem.DisplayDatePublished,
					dateExpired: iNewsItem.DisplayDateExpired,					
					tDatePublished: window._helpers.convertEpochToString(window._helpers.cleanDotNetDateJson(iNewsItem.DatePublished)),
					tDateExpired: window._helpers.convertEpochToString(window._helpers.cleanDotNetDateJson(iNewsItem.DateExpired)),
					//dateCreated: window._helpers.convertEpochToString(window._helpers.cleanDotNetDateJson(iNewsItem.DateCreated)),
					//dateLastUpdated: window._helpers.convertEpochToString(window._helpers.cleanDotNetDateJson(iNewsItem.DateLastUpdated)),
					friendlyUrl: iNewsItem.FriendlyUrl
				});
				converted.push(newNewsItem);
			}
			News.newsController.set('newsList', converted);
		});
	}, 	
	editedNews: {},
	addNews: function(json) {
		var newNews = News.NewsItem.create({					
			newsId: json.NewsId,
			newsTitle: json.NewsTitle,
			newsTeaser: json.NewsTeaser,
			newsContent: json.NewsContent,
			oDatePublished: json.DatePublished,
			oDateExpired: json.DateExpired,
			datePublished: json.DisplayDatePublished,
			dateExpired: json.DisplayDateExpired,					
			tDatePublished: window._helpers.convertEpochToString(window._helpers.cleanDotNetDateJson(json.DatePublished)),
			tDateExpired: window._helpers.convertEpochToString(window._helpers.cleanDotNetDateJson(json.DateExpired)),			
			friendlyUrl: json.FriendlyUrl
		});
		var list = News.newsController.get('newsList');
		list.push(newNews);
	}
});

News.NewsListView = Ember.View.extend({
	edit: function(event) {
		var editView = News.NewsItemEditedView.create();				
		News.newsController.set('editedNews', event.view.content);
		editView.appendTo(_news._elems.editPopup);		

		News.fn.showFormPopup(_news._elems.editPopup, 'Edit News', 
			function() {	
				$(_news._elems.btnSaveNews).attr('rel', 'edit');				
				News.fn.prepareEditForm();
			}, 
			function() {		
				editView.remove();
			}
		);
	},
	delete: function(event) {

	}
});

News.NewsItemEditedView = Ember.View.extend({
	templateName: 'newsItemEditTemplate',
	newsItemEditedBinding: Ember.Binding.oneWay('News.newsController.editedNews'),
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

		var eNews = this.get('newsItemEdited');
		eNews.set('newsTitle', nTitle);
		eNews.set('newsTeaser', nTeaser);
		eNews.set('friendlyUrl', nUrl);
		eNews.set('newsContent', nContent);

		eNews.set('tDatePublished', nPublished);
		eNews.set('tDateExpired', nExpired);		
		
		//eNews.set('datePublished', dPublished);
		//eNews.set('dateExpired', dExpired);

		eNews.set('oDatePublished', '/Date(' + dPublished.getTime() + stzo + itzo + '00)/');
		eNews.set('oDateExpired', '/Date(' + dExpired.getTime() + stzo + itzo + '00)/');
		
		News.fn.saveNews(eNews, function(result) {
			eNews.set('datePublished', result.DisplayDatePublished);
			eNews.set('dateExpired', result.DisplayDateExpired);

			$.colorbox.close();

			var msg = '';
			if(fMode === 'edit') {
				msg = 'Succesfully edited News data';
			}
			else {
				msg = 'Succesfully added new News';
			}

			$('.buncisContent').showMessage({
            	thisMessage: [msg],
            	position: 'absolute',
            	opacity: 100,
            	className: 'success'
			});
		});
	}
});


(function (news) {
	news.form = {
		wizardHasBeenInitialized: false,
		validators: {},
		wizard: {},
		reset: function() {
			this.wizardHasBeenInitialized = false;
			this.validators = {};
			this.wizard = {};
		}
	};
	news.setupEvents = function() {
		$(_news._elems.btnAddNews).click(function(event) {
			event.preventDefault();
			
			var editView = News.NewsItemEditedView.create();				
			var newTemplate = News.NewsItem.create(); 
			News.newsController.set('editedNews', newTemplate);
			editView.appendTo(_news._elems.editPopup);		

			News.fn.showFormPopup(_news._elems.editPopup, 'Add News', 
				function() {	
					$(_news._elems.btnSaveNews).attr('rel', 'add');

					var currentDate = new Date();
					var currentDatePlusOneMonth = _helpers.convertEpochToDate((new Date()).setMonth(currentDate.getMonth() + 1));		
					News.fn.prepareEditForm(currentDate, currentDatePlusOneMonth);
					$(_news._elems.txtDatePublished).val(_helpers.convertDateToString(currentDate));
					$(_news._elems.txtDateExpired).val(_helpers.convertDateToString(currentDatePlusOneMonth));
					$(_news._elems.txtDatePublished).attr('rel', currentDate);
					$(_news._elems.txtDateExpired).attr('rel', currentDatePlusOneMonth);
				}, 
				function() {		
					editView.remove();
				}
			);
		});	
	};
}(window._news = window._news || {}));


(function(oFn) {
	var clientId = _news._elems.clientId;
	var listWebServiceUrl = '/webservices/news.svc/bPanelGetNewsList?clientid=' + clientId;	
	var editWebServiceUrl = '/webservices/news.svc/UpdateNews';	
	var addWebServiceUrl = '/webservices/news.svc/InsertNews';	

	oFn.prepareEditForm = function(published, expired) {
		var news = window._news;
		news.form.reset();
		if(!news.form.wizardHasBeenInitialized) {
			news.form.wizard = $(news._elems.newsWizards).smartWizard({
				keyNavigation: false,
				enableAllSteps: true,
				enableFinishButton: false, 
				labelNext: '',
				labelPrevious: '',
				labelFinish: '',
				onShowStep: function (step) {
					if($(news._elems.txtNewsContent).is(':visible')) {
						$(news._elems.txtNewsContent).htmlarea('dispose'); 
						$(news._elems.txtNewsContent).htmlarea();
					}
				}
			});
			news.form.wizardHasBeenInitialized = true;
		}
		else {
			$(news._elems.newsTabs).find('a.tabStart').click();
		}
		news.form.validators = $(news._elems.newsFormElements).validator({
			effect: 'floatingWall',
			container: window._elems.errorContainer,
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
		
		$(news._elems.newsDate).DatePicker({
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
		$.colorbox({
			height: 662,
			width: 960,
			title: title,
			href: selector,
			inline: true,
			overlayClose: false,
			scrolling: false,
			onComplete: function() {
				if(_completeCallback) {
					_completeCallback();
				}
			},
			onClosed: function() {
				if(_closedCallback) {
					_closedCallback();
				}
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
	oFn.saveNews = function(oData, _callback) {
		var sData = {
			clientId: _news._elems.clientId,
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
		$.ajax({
			type: "POST",
			url: wsUrl,
			data: jData,
			dataType: 'json',
            contentType: 'text/json',
			success: function (result) {
				console.log(result);
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
}(window.News.fn = window.News.fn || {}));


$(document).ready(function() {
	News.newsController.loadData();	
	_news.setupEvents();
});

