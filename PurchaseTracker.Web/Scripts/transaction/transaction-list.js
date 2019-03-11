var transactionListViewModel = kendo.observable({
    transactions: [],
    categories: [],
    numTransactions: 0,
    totalAmountValue: '',
    averageAmountValue: '',
    init: async function () {
        console.log("view init");
        try {
            this.categories = await categoryService.getAll();
            console.log("categories - ", JSON.stringify(this.categories))

            let dataSource = new kendo.data.DataSource({
                data: this.transactions,
                pageSize: 21,
                sort: { field: "purchaseDate", dir: "desc" }
            });

            $("#pager").kendoPager({
                dataSource: dataSource
            });

            $("#listView").kendoListView({
                dataSource: dataSource,
                template: kendo.template($("#transactionListItemTemplate").html())
            })
            .delegate(".transaction-item-edit", "click", function (e) {
                var listView = $("#listView").getKendoListView();
                var itemContainer = $(e.target).closest(".row");
                var item = listView.dataItem(itemContainer);
                transactionDetailViewModel.set("categories", transactionListViewModel.categories);
                transactionDetailViewModel.set("data", item);
                router.navigate("/detail");
                e.preventDefault();
            })
            .delegate(".transaction-item-delete", "click", async function (e) {
                var listView = $("#listView").getKendoListView();
                var itemContainer = $(e.target).closest(".row");
                var item = listView.dataItem(itemContainer);
                await transactionService.delete(item.id);
                transactionListViewModel.show();
                e.preventDefault();
            });

            await this.show();
        }
        catch (error) {
            alert(error);
        }
    },

    show: async function () {
        console.log("view show");
        debugger;
        var listView = $("#listView").data("kendoListView");
        if (listView) {
            this.transactions = await transactionService.getAll();
            this.transactions.forEach(i => {
                i.purchaseDate = new Date(Date.parse(i.purchaseDate));
                i.createdDate = new Date(Date.parse(i.createdDate));
                if (i.updatedDate) { i.updatedDate = new Date(Date.parse(i.updatedDate)); }
            });

            listView.dataSource.data(this.transactions);
            listView.refresh();

            this.set("numTransactions", this.transactions.length);
            this.totalAmountString();
            this.averageAmountString();
        }

        var pager = $("#pager").data("kendoPager");
        if (pager) {
            pager.dataSource.data(this.transactions);
            pager.refresh();
        }
    },

    totalAmount: function () {
        debugger;
        let result = (this.transactions.length > 0) ? this.transactions.map(i => i.purchaseAmount).reduce((total, num) => total + num) : 0;
        return result;
    },

    totalAmountString: function () {
        debugger;
        let result = this.totalAmount();
        result = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD', minimumFractionDigits: 2 }).format(result);
        this.set("totalAmountValue", result);
    },

    averageAmount: function () {
        debugger;
        let result = this.totalAmount() / this.transactions.length;
        return result;
    },

    averageAmountString: function () {
        debugger;
        let result = this.averageAmount();
        result = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD', minimumFractionDigits: 2 }).format(result);
        this.set("averageAmountValue", result);
    },

    addClick: function (e) {
        let newTransaction = {
            id: 0,
            categoryId: 0,
            payeeName: null,
            purchaseAmount: 0.00,
            purchaseDate: new Date(),
            memo: null,
            createdDate: new Date()
        };

        transactionDetailViewModel.set("categories", this.categories);
        transactionDetailViewModel.set("data", newTransaction);
        router.navigate("/detail");
        e.preventDefault();
    }
});

var transactionListView = new kendo.View("transactionListTemplate",
    {
        model: transactionListViewModel,
        init: transactionListViewModel.init.bind(transactionListViewModel),
        show: transactionListViewModel.show.bind(transactionListViewModel)
    });

router.route("/", function () {
    layout.showIn("#content", transactionListView);
});
