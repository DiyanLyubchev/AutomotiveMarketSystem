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