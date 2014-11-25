$(function () {

	// courtesy http://stackoverflow.com/questions/16941104/remove-a-parameter-to-the-url-with-javascript
	var removeParam = function(key, sourceURL) {
		var rtn = sourceURL.split("?")[0],
			param,
			params_arr = [],
			queryString = (sourceURL.indexOf("?") !== -1) ? sourceURL.split("?")[1] : "";
		if (queryString !== "") {
			params_arr = queryString.split("&");
			for (var i = params_arr.length - 1; i >= 0; i -= 1) {
				param = params_arr[i].split("=")[0];
				if (param === key) {
					params_arr.splice(i, 1);
				}
			}
			rtn = rtn + "?" + params_arr.join("&");
		}
		return rtn;
	};

	var sanitizeFormInputs = function (arr) {
		for (var i = 0, len = arr.length; i < len; i++) {
			arr[i].value = encodeURIComponent(arr[i].value);
		}
		return arr;
	}

	// generic ajax submit handler for any challenege form
	var ajaxFormSubmit = function () {
		var $form = $(this).parent(".challenge-form");
		var $submitBtn = $(".challenge-form-submit");
		var $target = $($form.data("results-target"));
		var data = sanitizeFormInputs($form.serializeArray());
		$submitBtn.prop("disabled", true);
		
		var options = {
			url: $form.attr("action"),
			type: $form.attr("method"),
			data: data,
		};

		$.ajax(options).done(function (data) {
			$target.hide().html(data).fadeIn();
			$submitBtn.prop("disabled", false);
		});

		$.ajax(options).error(function (data) {
			$target.hide().html("Server error.  Make sure your data is valid and contact your system administrator.").fadeIn();
			$submitBtn.prop("disabled", false);
		});

		return false;
	};

	// generic function to click something when a certain key is pressed
	var keyPressedCheck = function (e, keycode, src, targetSelector) {
		var key = e.which;
		if (key == keycode)
		{
			src.find(targetSelector).click();
			return false;
		}
	}

	// click submit btn on form when enter key is pressed
	var enterKeyPressed = function (e) {
		return keyPressedCheck(e, 13, $(this), ".challenge-form-submit");
	};

	// click close btn when escape key is pressed
	var escapeKeyPressed = function (e) {
		return keyPressedCheck(e, 27, $(this),  ".challenge-form-close");
	};


	// hide/show a certain number of form inputs based off the inputCount.  To hide/show groups of inputs, simply pass a groupSize > 1
	// e.g. $("#dropdown-id").change(function () { toggleInputDisplay($(this), "1", "#form-id li", 2); });
	var toggleInputDisplay = function (self, defaultInputCount, formInputsSelector, groupSize) {
		var inputCount = self.val() || defaultInputCount;
		$(formInputsSelector).each(function (index) {
			if (index > Number(inputCount * groupSize)) {
				$(this).hide();
				$(this).find("input").val("");
			}
			else {
				$(this).show();
			}
		})
	}

	$(".challenge-form-submit").click(ajaxFormSubmit);
	$(".challenge-form").keypress(enterKeyPressed);

	$("#solid-shapes5").change(function () {
		toggleInputDisplay($(this), "1", "#solid-shapes li", 2);
	});
	$("#sudoku10").change(function () {
		toggleInputDisplay($(this), "9", "#sudoku li", 1);
	});
	$("#SelectedYear").change(function () {
		var url = removeParam("year", document.location.href);
		if (url.indexOf("?") > -1) {
			document.location.href = url + "&year=" + $(this).val() + "#portfolio";
		} else {
			document.location.href = url + "?year=" + $(this).val() + "#portfolio";
		}

		// TODO - update html partial instead of setting document.location.href as defined above
		//var selectedValue = $(this).val();
		//if (selectedValue) {
		//	$.ajax({
		//		type: 'GET',
		//		url: '@Url.Action("Index")',
		//		data: JSON.stringify({ year: selectedValue }),
		//		async: false,
		//		//contentType: 'application/json',
		//		//dataType: 'json',
		//		success: function (result) {
		//			$("#portfolio").html(result);
		//		},
		//		error: function (e) {
		//			alert(e.Message);
		//		}
		//	});
		//}
	});
	toggleInputDisplay($("#solid-shapes5"), "1", "#solid-shapes li", 2);
	toggleInputDisplay($("#sudoku10"), "9", "#sudoku li", 1);
});