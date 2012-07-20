News = Ember.Application.create();

var dummy = [ 
	{ newsTitle: 'hdar ea' },
	{ newsTitle: 'bfgs tds ra' },
	{ newsTitle: 'dar dsa' },
	{ newsTitle: 'nfgd tfds' },
	{ newsTitle: 'ghd gfd' },
	{ newsTitle: 'rdsa  ewa' },
	{ newsTitle: 'ghtd jhst' }
];

News.NewsItem = Ember.Object.extend({
	newsTitle: ''	
});

News.newsListController = Ember.ArrayController.create({
	content:[],
	add: function(title) {
		var newNewsItem = News.NewsItem.create({
			newsTitle: title
		});
		this.pushObject(newNewsItem);
	},
	loadData: function() {
		var self = this;
		for(var i = 0; i < dummy.length; i++) {
			self.add(dummy[i].newsTitle);	
		}		
	}
});

News.newsListController.loadData();

News.NewsListView = Ember.View.extend({
	templateName: 'news-list',
});


