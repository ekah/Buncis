﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WysiwygToolbar.ascx.cs" Inherits="Buncis.Web.UserControls.Component.WysiwygToolbar" %>

<div id="wysihtml5-toolbar" style="display: none;">
	<a data-wysihtml5-command="bold">bold</a>
	<a data-wysihtml5-command="italic">italic</a>
	<!-- Some wysihtml5 commands require extra parameters -->
	<a data-wysihtml5-command="foreColor" data-wysihtml5-command-value="red">red</a>
	<a data-wysihtml5-command="foreColor" data-wysihtml5-command-value="green">green</a>
	<a data-wysihtml5-command="foreColor" data-wysihtml5-command-value="blue">blue</a>
	<!-- Some wysihtml5 commands like 'createLink' require extra paramaters specified by the user (eg. href) -->
	<a data-wysihtml5-command="createLink">insert link</a>
	<div data-wysihtml5-dialog="createLink" style="display: none;">
		<label>
			Link:
			<input data-wysihtml5-dialog-field="href" value="http://" class="text">
		</label>
		<a data-wysihtml5-dialog-action="save">OK</a> <a data-wysihtml5-dialog-action="cancel">Cancel</a>
	</div>
</div>