using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Web.Common.DataTransferObject;

namespace Buncis.Web.WebServices.Contracts
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INews" in both code and config file together.
	[ServiceContract]
	public interface IArticles
	{
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<IEnumerable<DtoBuncisArticle>> BPGetArticles(int clientId);

		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisArticle> BPGetArticle(int clientId, int articleId);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisArticle> BPUpdateArticle(int clientId, DtoBuncisArticle article);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisArticle> BPInsertArticle(int clientId, DtoBuncisArticle article);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response BPDeleteArticle(int clientId, int articleId);

		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<IEnumerable<DtoBuncisArticleCategory>> BPGetArticleCategories(int clientId);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisArticleCategory> BPInsertArticleCategory(int clientId, DtoBuncisArticleCategory articleCategory);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisArticleCategory> BPUpdateArticleCategory(int clientId, DtoBuncisArticleCategory articleCategory);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		string GetArticleUrl(int articleId, string articleTitle);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response BPDeleteArticleCategory(int clientId, int articleCategoryId);
	}
}
