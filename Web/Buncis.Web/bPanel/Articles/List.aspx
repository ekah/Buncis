<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Articles.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_articles.js" type="text/javascript"></script>
	<script type="text/template" id="article-item-template">
		<li rel={{cid}}>
			<p>Title</p>
		</li>
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div class="buncisContentHeader">
        <h3>Articles</h3>
    </div>
    <div class="buncisContentBody">
        <div class="actionContent">
            <a href="javascript:void(0);" id="aAddArticle" class="button-action addArticle">
                <span class="icon-plus">Add Article</span>
            </a>
        </div>
        <div class="innerContent">
			<div class="article-list-wrapper">
				<ul class="test">
				</ul>
				<div style="display:none">
					<ul class="article-list">
						<li class="article-item-wrapper">
							<div class="article-item">
								<div class="left" style="width:90%">
									<div class="article-title">Distinctively underwhelm efficient experiences without.</div>
									<div class="article-teaser">Authoritatively benchmark plug-and-play leadership skills vis-a-vis seamless quality vectors. Continually pontificate intermandated services before intuitive models.</div>
									<div class="article-info">
										<div>Conveniently impact business process improvements.</div>
										<div>Conveniently impact business process improvements.</div>
									</div>
								</div>
								<div class="left">
									right
								</div>
								<div style="clear:both"></div>
							</div>
							<div class="article-edit-container"></div>
						</li>				
					</ul>
				</div>
			</div>
        </div>
    </div>
	
	<div style="display:none">
		<script type="text/template" id="article-edit-template">
			<div>
				<a href="#" class="close-view-area">Cancel</a>
				<a href="#">Save</a>
			</div>
			<div>
				<label>Article Title:</label>					
				<input type="text" id="txtArticleTitle" name="txtArticleTitle"></input>
			</div>
			<div>
				<label>Article Teaser:</label>
				<input type="text" id="txtArticleTeaser" name="txtArticleTeaser"></input>
			</div>				
			<div>
				<label>Friendly Url:</label>
				<input type="text" id="txtArticleUrl" name="txtArticleUrl"></input>
			</div>
			<div>
				<label>Article Content:</label>
				<textarea id="txtArticleContent" name="txtArticleContent"></textarea>
			</div>		
		</script>		
		<div id="article-edit-section">
			
		</div>
	</div>
</asp:Content>
