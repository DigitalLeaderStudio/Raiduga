var schedule = (function () {

	var $affiliateSelect,
		$serivceSelect,
		$courseSelect,
		$timepicker,
		$toTimeSpan;

	function _loadCourses(id) {
		var affiliateId = $affiliateSelect.val();
		var serviceId = $serivceSelect.val();

		$.ajax({
			type: 'POST',
			url: "/Admin/Schedule/GetCourses",
			data: { affiliateId: affiliateId, serviceId: serviceId }
		}).done(function (data) {
			var $target = $courseSelect;
			$target.find('option').remove();
			$.each(data, function (index, value) {
				var duration = moment.duration(value.Duration);
				var strDuration = moment(duration._data).format("HH:mm");
				$target.append('<option value="' + value.Id + '" duration="' + strDuration + '">' + value.Name + '</option>');
			});
		});
	}

	function _timeChange(e) {
		var selectedOption = $courseSelect.find('option:selected');
		var courseDuration = moment.duration($(selectedOption).attr('duration'));

		var newToTime = courseDuration.add(moment.duration(e.time));

		$toTimeSpan.html(moment(newToTime._data).format('HH:mm'));
	}

	function _bindEvents() {
		$affiliateSelect.on('change', _loadCourses);
		$serivceSelect.on('change', _loadCourses);
		$timepicker.on('changeTime.timepicker', _timeChange);
	}

	function _init() {
		$affiliateSelect = $('select[data-affiliate]');
		$serivceSelect = $('select[data-service]');
		$courseSelect = $('select[data-course]');
		$timepicker = $('.bootstrap-timepicker');
		$toTimeSpan = $('#to-time');

		_bindEvents();
	}


	return {
		init: _init
	}
})();


$(function () { schedule.init(); });