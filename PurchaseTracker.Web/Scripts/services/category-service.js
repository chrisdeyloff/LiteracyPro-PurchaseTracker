function CategoryService() {
    var self = this;

    self.getAll = async function () {
        return await $.ajax({
            method: 'get',
            url: 'api/category',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    };
}

var categoryService = new CategoryService();
