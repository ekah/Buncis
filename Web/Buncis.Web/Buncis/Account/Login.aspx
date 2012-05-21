<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
	Inherits="Buncis.Web.Buncis.Account.Login" %>

<!DOCTYPE html>
<head>
	<title>Buncis</title>		
	<link rel="stylesheet" href="/styles/normalize.css" />
	<link rel="stylesheet" href="/styles/bun_x.css" />
	<script src="/scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.tools.min.js" type="text/javascript"></script>
</head>
<body class="loginBody">
<form runat="server">
	<div id="topBarWrapper">
		<div id="topBar">
			<div id="logo"><img src="/images/logo.png" alt="Buncis Logo"></img></div>
			<div id="loginInfo">
				Login Info goes here
			</div>
		</div>		
	</div>
	<fieldset id="loginPanel" class="shadow-15 roundTop-5 roundBottom-5">	
		<div>			
			<div class="form-item">
				<label class="medium">Username</label>
				<div><input runat="server" id="txtUsername" type="text" required="required" class="medium" clientidmode="Static" /></div>
			</div>
			<div class="form-item">
				<label class="medium">Password</label>
				<div><input runat="server" id="txtPassword" type="text" required="required" class="medium" clientidmode="Static" /></div>
			</div>		
            <div class="form-item button-container">
                <input type="submit" value="Login" class="button-gray" id="btnLogin" runat="server" clientidmode="Static" />
            </div>
		</div>
	</fieldset>
</form>
</body>
</html>
