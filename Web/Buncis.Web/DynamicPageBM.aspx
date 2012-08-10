﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/BMCustom.Master" AutoEventWireup="true" CodeBehind="DynamicPageBM.aspx.cs" Inherits="Buncis.Web.DynamicPageBM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
	<div class="body">
		<div class="wrapper">
			<div class="header">
				<h1>Lorem Ipsum</h1>
				<div class="header-desc">Lorem ipsum dolor sit amor..</div>
			</div>
				
			<div class="aux-menu">
				<span><a href="javascript:void(0);">Signup</a></span>
				<span><a href="javascript:void(0);">Login</a></span>					
				<div class="clearFloats"></div>
			</div>

			<div class="menu-container">
				<div class="frame-container menu">
					<div class="frame menu-frame"></div>
					<div class="frame-inside menu-inside">
						<ul>
							<li><a href="javascript:void(0);">Home</a></li>
							<li><a href="javascript:void(0);">Daily Bread</a></li>
							<li><a href="javascript:void(0);">Articles</a></li>
							<li><a href="javascript:void(0);">News</a></li>
							<li><a href="javascript:void(0);">Events</a></li>
							<li><a href="javascript:void(0);">About Us</a></li>
						</ul>
					</div>
				</div>
			</div>

			<div class="content-top">
				<div class="frame-container teaserImages">					
					<div class="frame teaserImages-frame"></div>
					<div class="frame-inside teaserImages-inside">
						<div class="slides_container">
							<img src="/images/bm/dummy1.png" />
							<img src="/images/bm/dummy2.png" />
							<img src="/images/bm/dummy3.png" />
							<img src="/images/bm/dummy4.png" />
						</div>
						<a href="javascript:void(0);" class="prev"><img src="/images/bm/previous.png" width="32" height="32" alt="Arrow Prev"></a>
						<a href="javascript:void(0);" class="next"><img src="/images/bm/next.png" width="32" height="32" alt="Arrow Next"></a>
					</div>
				</div>
				<div class="frame-container quotes">
					<div class="frame-label quotes-frame-label"><img src="/images/bm/quotes-label.png"/><span>Quotes</span></div>					
					<div class="frame quotes-frame"></div>
					<div class="frame-inside quotes-inside">
						<div class="quotes-content">
							Competently strategize intuitive intellectual capital via emerging solutions. Rapidiously synergize cost effective results vis-a-vis multifunctional collaboration and idea-sharing. Professionally procrastinate best-of-breed communities through turnkey schemas. Professionally promote extensive methodologies before exceptional ideas. Dynamically harness customized functionalities without competitive deliverables.
						</div>
					</div>
				</div>
			</div>		

			<div class="content-mid">
				<div class="frame-container dailyBread">
					<div class="frame-label dailyBread-frame-label"><img src="/images/bm/bible-label.png"/><span>Daily Bread</span></div>
					<div class="frame dailyBread-frame"></div>
					<div class="frame-inside dailyBread-frameInside">
						<div class="dailyBread-verse">
							<div class="dailyBread-verse-title">Mat</div>
							<div class="dailyBread-verse-num">
								<div class="dailyBread-verse-num-left">10</div>
								<span>:</span>
								<div class="dailyBread-verse-num-right">1</div>
							</div>
						</div>
						<div class="dailyBread-content">
							Proactively target customized interfaces before unique initiatives. Rapidiously formulate market positioning data via ubiquitous action items. Proactively fashion customer directed vortals rather than state of the art models. Authoritatively actualize magnetic total linkage rather than enterprise-wide testing procedures. Compellingly recaptiualize distinctive products whereas an expanded array of products.
						</div>
						<div class="dailyBread-pic">
							<img src="/images/bm/verse.jpg" />
						</div>			
						<div class="clearFloats"></div>				
					</div>
				</div> 
			</div>	
		</div>					
	</div>
	<div class="body2">
		<div class="wrapper">
			<div class="content-bottom">
				<div class="frame-container article">
					<div class="frame-label article-frame-label"><img src="/images/bm/article-label.png"/><span>Articles</span></div>
					<div class="frame article-frame"></div>
					<div class="frame-inside article-frameInside">
						<div class="article-content">
							<p>
							Appropriately coordinate next-generation methodologies before orthogonal products. Distinctively transition client-centric web-readiness before optimal benefits. Interactively promote adaptive users rather than mission-critical e-business. Appropriately underwhelm front-end e-business after error-free systems. Competently recaptiualize front-end products whereas competitive sources.
							</p><p>
							Enthusiastically syndicate empowered strategic theme areas and client-centric experiences. Progressively implement bricks-and-clicks web-readiness without real-time solutions. Dynamically e-enable world-class products without premium bandwidth. Conveniently impact web-enabled paradigms with economically sound internal or "organic" sources. Appropriately integrate corporate systems rather than timely customer service.
							</p><p>
							Dramatically re-engineer compelling models without an expanded array of ROI. Conveniently fabricate standards compliant systems rather than vertical platforms. Seamlessly fabricate timely technologies rather than holistic internal or "organic" sources. Enthusiastically monetize installed base benefits with emerging leadership. Professionally engineer team driven vortals through bricks-and-clicks niches.
							</p>
						</div>
					</div>
				</div>
				<div class="frame-container feeds">
					<div class="frame-label feeds-frame-label"><img src="/images/bm/current-label.png"/><span>Stream</span></div>
					<div class="frame feeds-frame"></div>
					<div class="frame-inside feeds-frameInside">
						<div class="feeds-content">
							<ul>
								<li>Holisticly empower optimal.</li>
								<li>Holisticly empower optimal.</li>
								<li>Holisticly empower optimal.</li>
								<li>Holisticly empower optimal.</li>
								<li>Holisticly empower optimal.</li>
								<li>Holisticly empower optimal.</li>
							</ul>
						</div>
					</div>
				</div>
				<div class="spc-buttons">
					<div class="big-icon"><img src="/images/bm/announcements_pic.png" /><span>Announcements</span></div>
					<div class="big-icon"><img src="/images/bm/schedule_pic.png" /><span>Schedules</span></div>
					<div class="big-icon"><img src="/images/bm/community_pic.png" /><span>Communities</span></div>
					<div class="clearFloats"></div>
				</div>
			</div>				
			<div class="footer">
				<div class="contact-us">
					Contact Us: <br/>
					Sekretariat Breakthrough Ministry <br/>
					Jln. Mahendradata no. 10 B, Denpasar, Bali
				</div>
				<div class="social">
					<span>Our Social Network:</span>
					<span><img src="/images/bm/facebook_pic.png"/></span>
					<span><img src="/images/bm/twitter_pic.png"/></span>
				</div>
				<div class="copyright">
					<span>Copyright</span>
					<span>Buncis 2012</span>
				</div>
				<div class="clearFloats"></div>
			</div>
		</div>
	</div>
</asp:Content>
