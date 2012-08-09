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

	oArticle.ArticleModel = Backbone.Model.extend({
		articleTitle: ''
	});

	oArticle.ArticleCollection = Backbone.Collection.extend({
		model: _article.ArticleModel
	});

	oArticle.ArticleItemView = Backbone.View.extend({
		articleItem: {},
		render: function () {
			//console.log(this);

			var template = _.template($("#article-item-template").html(), this, _helpers.underscoreTemplateSettings);
			this.$el.append($(template));

			return this;
		},
		testclick: function (event) {
			console.log(this);
		}
	});

	oArticle.init = function () {
		setupEvents();
		getData();
		renderCollection();
	};

	function setupEvents() {
		$(_article._elems.viewAreaCloseButtonSelector).click(function (evt) {
			evt.preventDefault();
			$(_article._elems.clonnedSelector).remove();
		});
		$(_article._elems.articleItemSelector).click(function (evt) {
			var $self = $(this);
			var cloned = $(_article._elems.templateSelector).clone(true);
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

	function getData() {
		var dummyCollection = new _article.ArticleCollection();
		for (var i = 0; i < 5; i++) {
			var dummyModel = new _article.ArticleModel({
				articleTitle: 'article ' + i
			})
			dummyCollection.add(dummyModel);
		}
		oCollection = dummyCollection;
	}

	function renderCollection() {
		var dummyCollection = oCollection;
		for (var i = 0; i < dummyCollection.length; i++) {
			var testView = new _article.ArticleItemView({ el: $(".test") });
			testView.events = {};
			testView.articleItem = dummyCollection.at(i);
			testView.events["click li[rel='" + testView.cid + "']"] = "testclick";
			testView.delegateEvents();
			//console.log(testView.events);
			testView.render();
		}
	}

} (window._article = window._article || {}));

$(document).ready(function () {
	_article.init();
});