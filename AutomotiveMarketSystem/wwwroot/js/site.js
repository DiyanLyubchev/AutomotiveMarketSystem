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

//$("#uploadImage").click(function () {
//    const currentCarId = $("#uploadImage").val();
//    const carImagePath = $('#imagePath').val();

//    $.ajax({
//        url: '/Car/UploadImage',
//        data: { imagepath: carImagePath, carId: currentCarId },
//        type: 'Get',
//        dataType: 'json',
//    });
//});

$(function () {
    $('#imageUpload').fileupload({
        dataType: 'json',
        done: function (e, data) {
            $.each(data.result.file, function (index, file) {
                $('<p/>').text(image.name).appendTo(document.body);
            });
        }
    });
});

