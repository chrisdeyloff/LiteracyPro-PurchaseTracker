function TransactionService() {
    var self = this;

    self.getAll = async function () {
        return await $.ajax({
            method: 'get',
            url: 'api/transaction',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    };

    self.create = async function (transaction) {
        return await $.ajax({
            method: 'post',
            url: 'api/transaction',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(transaction),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    };

    self.update = async function (transaction) {
        return await $.ajax({
            method: 'put',
            url: 'api/transaction',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(transaction),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });
    };

    self.delete = async function (id) {
        return await $.ajax({
            method: 'delete',
            url: `api/transaction/${id}`,
        });
    };
}

var transactionService = new TransactionService();
