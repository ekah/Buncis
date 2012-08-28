﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Buncis.Framework.Core.SupportClasses;
using Buncis.Web.Common.DataTransferObject;

namespace Buncis.Web.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INews" in both code and config file together.
	[ServiceContract]
	public interface INews
	{
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<IEnumerable<DtoBuncisNews>> bPanelGetNewsList(int clientId);

		//[OperationContract]
		//[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		//Response<oBuncisNews> bPanelGetNews(int clientId, int newsId);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisNews> bPanelUpdateNews(int clientId, DtoBuncisNews news);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response<DtoBuncisNews> bPanelInsertNews(int clientId, DtoBuncisNews news);

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		Response bPanelDeleteNews(int clientId, int newsId);

		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
		Response<IEnumerable<DtoBuncisNews>> GetPublishedNewsList(int clientId);
	}
}
