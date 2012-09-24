<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ComingSoon.aspx.cs"
	Inherits="Buncis.Web.ComingSoon" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
	<title>Breakthrough Ministries</title>
	<link href="/styles/normalize.css" rel="stylesheet" />
	<link href="/styles/bm.css" rel="stylesheet" />
	<script src="/scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
	<style type="text/css">
		html, body
		{
			height: 100%;
		}
		.ulogo {
			margin: 20px auto 0px;			
			width: 300px;
		}		
		.ulogo span 
		{			
			font-size: 38px;
			vertical-align: top;
			line-height: 60px;
		}
		.comingsoon
		{
			margin: 20px auto 0px;			
			width: 800px;
			padding: 0px 0px 50px;
			border-radius: 10px;
			-moz-border-radius: 10px;
			-webkit-border-radius: 10px;
			background-color: #504375;
		}
		.comingsoon .uheader {
			padding: 30px 50px 0px;
		}
		.comingsoon h1 {
			font-size: 20px;
		}		
		.comingsoon h2 {
			font-size: 38px;
		}		
		.comingsoon .info 
		{
			border-top: 1px solid yellow;
			border-bottom: 1px solid yellow;
			width: 100%;
			background-color: #30222f;	
			padding: 20px 0px 20px;		
		}
		.comingsoon .info p 
		{
			padding: 0px 50px;
			font-size: 20px;
		}
		
		.uTop {
			margin: 0px auto 0px;			
			width: 800px;
			height: 30px;
			background-color: #504375;
			border-bottom-left-radius: 10px;
			-moz-border-bottom-left-radius: 10px;
			-webkit-border-bottom-left-radius: 10px;			
			border-bottom-right-radius: 10px;
			-moz-border-bottom-right-radius: 10px;
			-webkit-border-bottom-right-radius: 10px;
		}
		.ufloat {
			margin-left: 600px;	
			background-color: #504375;
			height: 80px;
			width: 150px;
			border-bottom-left-radius: 10px;
			-moz-border-bottom-left-radius: 10px;
			-webkit-border-bottom-left-radius: 10px;			
			border-bottom-right-radius: 10px;
			-moz-border-bottom-right-radius: 10px;
			-webkit-border-bottom-right-radius: 10px;
		}
		.ufloat img 
		{
			display: block;
			margin: auto;
			padding: 10px;			
		}
		.ufooter 			
		{
			/*
			position: fixed;
			bottom: 0px;
			*/
			padding-top: 30px;
			padding-bottom: 30px;
			width: 100%;
		}
		.ufooter-wrapper 
		{
			min-height: 100px;	
			margin: 0px auto 0px;						
			width: 800px;
			background-color: #504375;
			border-radius: 10px;
			-moz-border-radius: 10px;
			-webkit-border-radius: 10px;						
		}
		.ucontact-us {
			float: left;
			padding: 20px;
		}
		.usocial {
			float: left;
			padding: 20px;
		}
		.usocial span {
			display: block;
			float: left;
			padding: 0px 4px;
		}
		.ucopyright {
		 	float:right;
		 	padding: 20px;
		}
	</style>
</head>
<body>
	<%--<div class="uTop">
		<div class="ufloat">
			<img src="/images/bm/construction.png"/>
		</div>
	</div>--%>
	<div class="ulogo">
		<img src="/images/bm/comingsoon.png" />
		<span>Time Flies</span>
	</div>
	<div class="comingsoon">
		<div class="uheader">
			<h2>Breakthrough Ministry</h2>
			<h2>We are currently under construction</h2>
		</div>
		<div class="info">
			<p>Sorry, we are currently developing this site.</p>
			<p>Wait for us! We are coming soon!</p>
		</div>
	</div>
	<div class="ufooter">
		<div class="ufooter-wrapper">
			<div class="ucontact-us">
				Contact Us: <br/>
				Sekretariat Breakthrough Ministry <br/>
				Jln. Mahendradata no. 10 B, Denpasar, Bali
			</div>
			<div class="usocial">
				<span>Our Social Network:</span>
				<span><img src="/images/bm/facebook_pic.png"/></span>
				<span><img src="/images/bm/twitter_pic.png"/></span>
			</div>
			<div class="ucopyright">
				<span>Copyright</span>
				<span>Buncis 2012</span>
			</div>
		</div>
	</div>
</body>
</html>
