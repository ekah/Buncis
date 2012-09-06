<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.News.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_news.js" type="text/javascript"></script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
    <div class="row">
        <div class="span12">
            <div class="buncisContentHeader well well-small">
                <h2>News</h2>
            </div>
        </div>
        <div class="span12">
            <div class="buncisContentBody well well-small">
                <div class="actionContent pull-right">
                    <a href="javascript:void(0);" id="aAddNews" class="addNews btn btn-warning">
                        <i class="icon-plus"></i>&nbsp;<span>Add News</span>
                    </a>
                </div>
                <div class="clearfix"></div>
                <div class="innerContent">
                    <!-- 
                    {% if(attributes.recentlyAdded) { %} 
						class="added" 
					{% } else if(attributes.recentlyEdited) { %} 
						class="edited" 
					{% } %}>
                    -->
			        <div class="news-list-wrapper">				
				        <ul class="news-item-container list-item-container">						
					        <script type="text/template" id="news-item-template">
						        <li rel="{{id}}" class="list-item">
							        <div>
								        <div class="pull-left leftSection">
                                            <dl class="dl-horizontal">
                                                <dt>Title</dt>
                                                <dd>{{attributes.newsTitle}}</dd>
                                                <dt>Teaser</dt>
                                                <dd>{{attributes.newsTeaser}}</dd>
                                                <dt>Published</dt>
                                                <dd>{{attributes.datePublished}}</dd>
                                                <dt>Expired</dt>
                                                <dd>{{attributes.dateExpired}}</dd>
                                            </dl>
                                            <div class="pull-right">
                                            {% if(attributes.recentlyAdded) { %} 
						                        <span class="label label-inverse">Recently Added</span>
					                        {% } %} 
                                            {% if(attributes.recentlyEdited) { %} 
						                        <span class="label">Recently Edited</span>
					                        {% } %}   
                                            </div>
                                            <div class="clearfix"></div>
								        </div>
								        <div class="pull-right rightSection">								
									        <div class="list-action">
                                                <a href="javascript:;" class="action action-edit edit btn btn-info">Edit</a> 
										        <a href="javascript:;" class="action action-delete delete btn btn-danger">Delete</a>										        
									        </div>	
                                            <div class="clearfix"></div>
								        </div>
							        </div>
							        <div class="clearfix"></div>
						        </li>
					        </script>
				        </ul>
			        </div>
                </div>
            </div>
        </div>
    </div>
	
    
    <div style="display:none">
        <!-- template add/edit news -->
		<script type="text/template" id="news-edit-popup-template">		
            <div class="modal-header">
                <h3>Modal header</h3>
            </div>
			<div class="popup-content modal-body">				
				<ul id="news-tabs" class="nav nav-tabs">
					<li class="tab-btn"><a href="#news-tab1" class="tabStart">Section 1: News Information</a></li>
					<li class="tab-btn"><a href="#news-tab2" class="hasEditor">Section 2: News Content</a></li>
				</ul>
                <div class="tab-content">
				    <div id="news-tab1" class="news-tab1 tab-pane">
					    <div class="form-item">
						    <label>News Title</label>
						    <input type="text" id="txtNewsTitle" name="txtNewsTitle"
							    data-message="News Title is required" required="required" 
                                class="input-xxlarge" 
							    value="{{attributes.newsTitle}}" />
					    </div>
					    <div class="form-item">
						    <label>News Teaser</label>
						    <textarea id="txtNewsTeaser" name="txtNewsTeaser" required="required"
							    data-message="News Teaser is required" required="required"
							    style="width:700px; height: 100px;">{{attributes.newsTeaser}}</textarea>
					    </div>
					    <div class="pull-left">
						    <div class="form-item">
							    <label>Date Published</label>
							    <input type="text" id="txtDatePublished" name="txtDatePublished" 
								    required="required" data-message="Date Published is required"                                     
								    value="{{attributes.formattedDatePublished}}" 
                                    rel="{{attributes.actualDatePublished}}" />
							    <span class="input-large uneditable-input">{{attributes.datePublished}}</span>
						    </div>							
					    </div>
					    <div class="pull-left">							
						    <div class="form-item">
							    <label>Date Expired</label>
							    <input type="text" id="txtDateExpired" name="txtDateExpired" 
								    required="required" data-message="Date Expired  is required" 
								    value="{{attributes.formattedDateExpired}}" 
                                    rel="{{attributes.actualDateExpired}}" />
							    <span class="input-large uneditable-input">{{attributes.dateExpired}}</span>
						    </div>							
					    </div>
                        <div class="clearfix"></div>
					    <div class="form-item">
						    <label>Friendly URL</label>
						    <input type="text" required="required" id="txtNewsUrl" 
							    class="input-xlarge" name="txtNewsUrl" required" required="required"
							    data-message="News Url is required" value="{{attributes.newsUrl}}" />
					    </div>				
				    </div>
				    <div id="news-tab2" class="news-tab2 tab-pane">
					    <div class="form-item hasHtmlArea">
						    <label>News Content</label>
						    <textarea id="txtNewsContent" 
							    name="txtNewsContent"
							    class="htmlarea"							
							    required="required"
							    data-message="News Content is required">{{attributes.newsContent}}</textarea>
					    </div>
				    </div>
                </div>
			</div>			
			<div class="modal-footer">				
				<a href="javascript:;" id="btnSaveNews" class="btn btn-primary">Save</a>                
                <a href="javascript:;" id="btnClose" class="popup-button-close btn btn-inverse">Close</a>
			</div>
		</script>
		
        <!-- template delete news -->
		<script type="text/template" id="news-confirmDelete-popup-template">
			<p>Are you sure you want to delete news <strong>{{attributes.newsTitle}}</strong>?</p>
			<div class="popup-button-wrapper buttonContainer">
        	    <a href="javascript:;" id="deleteNews-cancel" class="popup-button-close">No</a>
                <a href="javascript:;" id="deleteNews-confirm" class="">Yes</a>			    
            </div>
		</script>
    </div>    

    <div id="news-edit-popup" class="popup-wrapper modal hide fade"></div>
	<div id="news-delete-popup" class="popup-wrapper modal hide fade"></div>
</asp:Content>
