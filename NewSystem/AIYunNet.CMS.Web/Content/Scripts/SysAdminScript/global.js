
﻿///Dialog Util
(function ()
{
	var _dialogArray = [];
	var typeDef =
		{
			'default': BootstrapDialog.TYPE_DEFAULT,
			'info': BootstrapDialog.TYPE_INFO,
			'primary': BootstrapDialog.TYPE_PRIMARY,
			'success': BootstrapDialog.TYPE_SUCCESS,
			'warning': BootstrapDialog.TYPE_WARNING,
			'danger': BootstrapDialog.TYPE_DANGER
		};

	function alertInfo(msg)
	{
		swal(msg);
	}

	function confirmEx(msg)
	{
		var ret = false;
		BootstrapDialog.confirm(msg, function (result)
		{
			ret = result;
		});

		return ret;
	}

	function popUp(url, title, type, width, height, callback, refreshPage)
	{
		if (!width)
		{
			width = 600;
		}
		if (!height)
		{
			height = 400;
		}
		var frameWidth = width;
		var frameHeight = height - 15;

		var $message = $("<iframe id=\"framePopup\" style=\"border: 0px; padding: 0px; margin: 0px; width: " + frameWidth + "px;height:" + frameHeight + "px\"></iframe>").attr("src", url);
		popUpHtml($message, title, type, width, height, callback, refreshPage);
	}

	function popUpHtml(html, title, type, width, height, callback, refreshPage)
	{
		if (!title)
		{
			title = "System Message";
		}

		var dlgType = BootstrapDialog.TYPE_PRIMARY;
		if (type && typeDef[type])
		{
			dlgType = typeDef[type];
		}

		var cssStyle = "",
			cssClass = "customDiaglog-" + width + "-" + height;
		if (width && !isNaN(width))
		{
			cssStyle += "." + cssClass + " .modal-dialog{width:" + width + "px;}";
		}
		if (height && !isNaN(height))
		{
			cssStyle += "." + cssClass + " .modal-dialog .modal-content .modal-body{height:" + (height - 10) + "px;overflow-y:auto;overflow-x:hidden;margin:0px;padding:0px;}";
		}
		cssStyle += "</style>";
		cssStyle = '<style type=\"text/css\">' + cssStyle;
		$($("head")[0]).append(cssStyle);

		cssClass = cssClass + " popuppage";

		if (localStorage["isNightMode"] == '1')
		{
			cssClass += ' night-dialog ';
		}

		var dialog = new BootstrapDialog({
			title: title,
			type: dlgType,
			message: html,
			cssClass: cssClass
		});

		var dialogObj = {};
		dialogObj['dialog'] = dialog;
		dialogObj['callback'] = callback;
		dialogObj['refreshPage'] = refreshPage;
		_dialogArray.push(dialogObj);

		dialog.open();
	}

	function closePopUp(ret)
	{
		if (_dialogArray.length == 0)
		{
			return;
		}

		var dialogObj = _dialogArray.pop();
		var dialog = dialogObj['dialog']
		if (dialog)
		{
			dialog.close();
		}

		var callback = dialogObj['callback'], refreshPage = dialogObj['refreshPage'];
		if (typeof (callback) == 'function')
		{
			callback.call(null, ret);
		}

		if (refreshPage)
		{
			window.location.href = window.location.href;
		}
	}

	window.alertInfo = alertInfo;
	window.confirmEx = confirmEx;
	window.popUp = popUp;
	window.popUpHtml = popUpHtml;
	window.closePopUp = closePopUp;
})();

//Cookie Util
var CookieUtil = {
	get: function (name)
	{
		var cookieName = encodeURIComponent(name) + "=",
			cookieStart = document.cookie.indexOf(cookieName),
			cookieValue = null;

		if (cookieStart > -1)
		{
			var cookieEnd = document.cookie.indexOf(";", cookieStart);
			if (cookieEnd == -1)
			{
				cookieEnd = document.cookie.length;
			}
			cookieValue = decodeURIComponent(document.cookie.substring(cookieStart + cookieName.length, cookieEnd));
		}

		return cookieValue;
	},

	set: function (name, value, expires, path, domain, secure)
	{
		var cookieText = encodeURIComponent(name) + "=" +
			encodeURIComponent(value);

		if (expires instanceof Date)
		{
			cookieText += "; expires=" + expires.toGMTString();
		}

		if (path)
		{
			cookieText += "; path=" + path;
		}

		if (domain)
		{
			cookieText += "; domain=" + domain;
		}

		if (secure)
		{
			cookieText += "; secure";
		}

		document.cookie = cookieText;
	},

	unset: function (name, path, domain, secure)
	{
		this.set(name, "", new Date(0), path, domain, secure);
	}
};