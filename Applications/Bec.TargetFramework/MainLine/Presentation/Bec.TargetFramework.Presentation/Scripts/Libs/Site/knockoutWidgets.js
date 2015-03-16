(function () {
    ko.repeater = {
        pager: function (params, parent) {
            params = params || {};
            var self = this;

            self.parent = parent;
            self.displayProgressIndicator = ko.observable();
            self.pagePrefix = ko.observable(0);
            self.pageToDisplay = 10;
            self.pageSize = ko.observable(ko.unwrap(params.pageSize) || 10);
            self.totalItemsCount = ko.observable();
            self.currentPageIndex = ko.observable();

            self.currentPageIndex.subscribe(function (val) {
                self.displayProgressIndicator(true);
                $.get(self.parent.url,
                        {
                            pageIndex: val,
                            pageSize: self.pageSize()
                        },
                        function (response) {
                            var result = JSON.parse(response);
                        })
            });
        }
    }
})();