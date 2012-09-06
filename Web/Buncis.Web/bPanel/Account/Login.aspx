<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
	Inherits="Buncis.Web.bPanel.Account.Login" %>

<!DOCTYPE html>
<html>
<head>
	<title>Buncis</title>		
	<!--link rel="stylesheet" href="/styles/normalize.css" /-->
	<link rel="stylesheet" href="/styles/bun_x.css" />
    <link href="/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
	<script src="/scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/bootstrap/js/bootstrap.js" type="text/javascript"></script>
	<script src="/Scripts/modules/tools/validator.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var validators = $('#loginPanel input').validator({
				messageClass: 'alert alert-error error'
			});
        });        
    </script>
</head>
<body class="buncisBody">
	<form runat="server" id="formLogin" clientidmode="Static">		
		<div id="topBarWrapper">
            <div class="container">
                <div class="row">
                    <div class="span12">				        
					    <div id="topBar" class="row">
						    <div id="logo" class="span4"><img src="/images/logo.png" alt="Buncis Logo" /></div>
						    <div id="loginInfo" class="span3 offset3 pull-right">Login Info goes here</div>
						    <div class="clearfix"></div>
					    </div>
			        </div>
                </div>
            </div>			
		</div>
		<div id="contentWrapper">
            <div class="container">
                <div class="row">
                    <div class="span4 offset4">
						<fieldset id="loginPanel" class="well well-large">	
							<div>			
								<div class="form-item">
									<label class="medium">Username</label>
									<div>
										<input runat="server" id="txtUsername" type="text"
											required="required" class="medium" clientidmode="Static" 
											data-message="Username is required"/>
									</div>
								</div>
								<div class="form-item">
									<label class="medium">Password</label>
									<div>
										<input runat="server" id="txtPassword" type="text"
											required="required" class="medium" clientidmode="Static" 
											data-message="Password is required"/>
									</div>
								</div>		
								<div class="form-item buttonContainer pull-right">
									<input type="submit" class="button-gray login btn btn-primary" id="btnLogin" runat="server" clientidmode="Static" value="Login" />
									<input type="button" class="button-gray login btn" value="Reset" />
								</div>
							</div>
						</fieldset>
					</div>
                </div>
            </div>			
		</div>		
	</form>
</body>
</html>
