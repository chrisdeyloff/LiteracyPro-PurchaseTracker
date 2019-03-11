var transactionDetailViewModel = kendo.observable({
    data: {},
    categories: [],
    init: function () {
        console.log("view init", JSON.stringify(this.data));
        var validator = $("#transactionDetailContainer").kendoValidator().data("kendoValidator");
        $("#purchaseDate").kendoDatePicker({
            min: new Date(1950, 0, 1),
            max: new Date(2049, 11, 31)
        });
        $("#purchaseAmount").kendoNumericTextBox({
            format: "c2", //Define currency type and 2 digits precision
        });
        $("#category").kendoDropDownList({
            dataTextField: "name",
            dataValueField: "id",
            dataSource: this.categories,
            change: function (e) {
                transactionDetailViewModel.data.categoryId = this.value();
            }
        });
    },

    show: function () {
        console.log("view show", JSON.stringify(this.data));
        var dropdownlist = $("#category").data("kendoDropDownList");
        if (dropdownlist) {
            dropdownlist.dataSource.data(this.categories);
            dropdownlist.refresh();
        }
    },

    saveClick: async function () {
        console.log("save click");
        if (this.data.id <= 0) {
            await transactionService.create(this.data);
        }
        else {
            await transactionService.update(this.data);
        }
        history.back();
    },

    cancelClick: function () {
        console.log("cancel click");
        history.back();
    }
});

var transactionDetailView = new kendo.View("transactionDetailTemplate",
    {
        model: transactionDetailViewModel,
        init: transactionDetailViewModel.init.bind(transactionDetailViewModel),
        show: transactionDetailViewModel.show.bind(transactionDetailViewModel)
    });

router.route("/detail", function () {
    layout.showIn("#content", transactionDetailView);
});
