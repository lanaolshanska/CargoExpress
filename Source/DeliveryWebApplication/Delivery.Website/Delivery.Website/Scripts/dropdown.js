$(document).ready(function () {
    $(".state").change(function () {
        var cities = $(this).closest(".place").find(".city");
        var selectedState = this.value;
        $.ajax({
            type: "GET",
            url: '/Public/Cargo/GetCities?stateId=' + selectedState,
            success: function (items) {
                cities.empty();
                items.forEach(item => {
                    cities.append($('<option>', {
                        value: item.Id,
                        text: item.Name
                    }, '</option>'));
                }
                );
            }
        });
    });
});
