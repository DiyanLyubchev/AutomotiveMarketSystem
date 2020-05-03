function populateBrand(carBrandId, targetSelectId) {
    $.getJSON(`/home/getModels?brandId=${carBrandId}`)
        .then(brands => {
            const select = $(`#${targetSelectId}`);
            let options = '<option>Select Model</option>';
            brands.forEach(model => {
                options += `<option value="${model.id}">${model.modelName}</option>`;
            });
            select.html(options);
        });
};

$("#advetisement").click(function () {
    const carId = $("#advetisement").val();

    $.ajax({
        url: '/Advertisement/CreateAdvertisement',
        data: { newCarId: carId },
        type: 'Post',
        dataType: 'json',
        success: function () {
            window.location.href = "/home/index";
        }
    });
});