$(document).ready(function () {

    $('#driverCheckBox').change(function () {
        if ($('#driverCheckBox:checked').length) {

            $('.adminCheck').prop('checked', false);
            $('.adminCheck').attr('disabled', true);

            $('#driverForm').attr('hidden', false);

        } else {
            $('.adminCheck').attr('disabled', false);
            $('#driverForm').attr('hidden', true);
        }
    });

    $('#adminCheckBox').change(function () {
        if ($('#adminCheckBox:checked').length) {

            $('.driverCheck').prop('checked', false);
            $('.driverCheck').attr('disabled', true);

            $('#driverForm').attr('hidden', true);

        } else {
            $('.driverCheck').attr('disabled', false);
            
        }
    });
});