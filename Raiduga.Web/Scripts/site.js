$(document).ready(function () {
	$(".material-switch label").on('click', function () {
		var checkBox = $(this).prev('input[type="checkbox"');
		var checked = checkBox.is(':checked');
		checkBox.val(!checked);
	});

	try {
		$('.timepicker > input').timepicker();
	}
	catch (e) {

	}
});