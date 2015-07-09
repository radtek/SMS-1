//checks for a json redirect response instruction
function checkRedirect(response) {
    if (response && response.HasRedirectUrl) window.location.href = response.RedirectUrl;
}

//wrapper around ajax call to catch json redirect instructions
function ajaxWrapper(options) {
    return $.ajax(options).fail(function (err) {
        checkRedirect(err.responseJSON);
    });
}

//reurns a function to use in kendo grid - call options.success for kendo
function getGridDataFromUrl(url) {
    return function (options) {
        ajaxWrapper({
            url: url,
            cache: false
        }).done(function (result) {
            options.success(result);
        });
    };
}

var modalStack = [];

//shows a modal, invoking the appropriate function when a button on the modal is clicked
function handleModal(options, handlers, fixScroll, defaultHandler, shownFunction) {
    options.cache = false;
    ajaxWrapper(options).done(function (result) {
        if (result && result.result == "ok") {
            if (defaultHandler) handlers[defaultHandler]();
        }
        else {
            var tempDiv = $(result); //tempDiv includes all elements & script
            $('body').append(tempDiv);
            var mdiv = tempDiv.filter('.modal');
            modalStack.push(mdiv);

            //attach handlers
            var vals = [];
            for (var id in handlers) {
                vals[id] = false;
                $('#' + id).on('click.handleModal', { id: id }, function (e) {
                    vals[e.data.id] = true;
                });
            }

            mdiv.modal({
                backdrop: 'static',
                keyboard: false
            }).one('shown.bs.modal', function () {
                if (shownFunction) shownFunction();
            }).one('hidden.bs.modal', function (e) {
                if (fixScroll) $('body').addClass('modal-open');

                for (var id in handlers) {
                    $('#' + id).off('click.handleModal');
                    if (vals[id]) {
                        handlers[id]();
                    }
                }

                tempDiv.remove(); //remove all elements which were added
                modalStack.pop();
            });
        }
    });
}


//for 'fire and forget' modal links, where no result is captured
function findModalLinks() {
    $('a[data-modallink]').on('click', function (e) {
        if (!$(e.target).prop('disabled')) {
            $(e.target).prop('disabled', true);
            e.preventDefault();
            ajaxWrapper({
                url: $(this).data('href'),
                cache: false
            }).done(function (result) {
                var tempDiv = $(result); //tempDiv include all elements & script
                $('body').append(tempDiv);
                var mdiv = tempDiv.filter('.modal');
                modalStack.push(mdiv);

                mdiv.modal({
                    backdrop: 'static',
                    keyboard: false
                }).on('hidden.bs.modal', function () {
                    tempDiv.remove(); //remove all elements which were added
                    modalStack.pop();
                });

                $(e.target).prop('disabled', false);
            });
        }
    });
}

//function hideParentModal() {
//    //the child modal hasn't been hidden yet
//    modalStack[modalStack.length - 2].modal('hide');
//};

function hideCurrentModal() {
    modalStack[modalStack.length - 1].modal('hide');
};

function dateString(date) {
    try {
        var ret = new Date(date).toLocaleString();
        if (ret == "Invalid Date") ret = new Date(date.replace(' ', 'T')).toLocaleString(); //IE...
        return ret;
    }
    catch (ex) {
        return "";
    }
}

//save the grid sort in session storage
function saveGridSort(grid, gridElementId) {
    var sort = grid.getOptions().dataSource.sort;
    sessionStorage["gridSort-" + gridElementId] = JSON.stringify(sort);
}

//load the sort state for a grid
function loadGridSort(gridElementId) {
    try {
        return JSON.parse(sessionStorage["gridSort-" + gridElementId]);
    }
    catch (ex) {
        return null;
    }
}

//sets up tab page click events & loads relevant grids once tabs are shown.
var tabItem = function (tabId, tabs) {
    this.tabId = tabId;
    this.tabs = tabs;
    var self = this;

    this.makeTab = function () {
        var allTabElements = $('#' + this.tabId + ' a');

        allTabElements.click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        });

        allTabElements.on('shown.bs.tab', function (e) {
            for (var t in self.tabs) {
                if ($(e.target).attr('href') == '#' + t) {
                    for (var g in self.tabs[t].grids) self.tabs[t].grids[g].makeGrid();
                }
            }
        });
    };

    this.showTab = function (index) {
        var i = index || 0;
        $('#' + this.tabId + ' li:eq(' + i + ') a').tab('show');
    };

};

//sets up a grid, including:
// initial load
// persisting sorted columns
// jumping to a particular row following an action
// maintaining selection on sort
// displaying panels when row selected
var gridItem = function (options) {
    this.options = options;
    this.loaded = false;
    this.selectedItem = null;
    this.grid = null;
    var self = this;

    //pass through options to kendo and hook up events
    this.makeGrid = function () {
        if (this.loaded) return;
        this.loaded = true;
        this.grid = $("#" + this.options.gridElementId).kendoGrid({
            dataSource: {
                transport: {
                    read: getGridDataFromUrl(this.options.url)
                },
                schema: this.options.schema,
                sort: loadGridSort(this.options.gridElementId) || this.options.defaultSort
            },
            height: 300,
            selectable: "row",
            filterable: false,
            sortable: true,
            //navigatable: true,
            pageable: {
                numeric: false,
                previousNext: false,
                messages: { display: "{2} rows" }
            },
            columns: options.columns,
            dataBound: this.dataBound,
            change: this.change
        }).data("kendoGrid");
    };

    this.dataBound = function (e) {
        saveGridSort(self.grid, self.options.gridElementId);

        var gridData = self.grid.dataSource.data();
        if (gridData.length == 0) return;

        if (self.options.jumpToId != null && self.options.jumpToId != "") {
            for (var i = 0; i < gridData.length; i++) {
                if (self.options.jumpToId.replace(/-/g, "") == gridData[i][self.options.schema.model.id]) {
                    self.scrollToRow(gridData[i]);
                    self.options.jumpToId = null; //make sure this is one off
                    break;
                }
            }
        } else {
            self.scrollToRow(self.selectedItem);
        }
    };

    this.change = function (e) {
        var selectedRows = self.grid.select();
        if (selectedRows.length == 1) {
            var dataItem = self.grid.dataItem(selectedRows[0]);
            self.selectedItem = dataItem;
            if (self.options.panels) {
                for (var p in self.options.panels) {
                    $('#' + self.options.panels[p]).removeClass("hidden");
                }
            }
            self.options.change(dataItem); //any custom data binding
        }
    };

    this.scrollToRow = function (item) {
        if (!this.grid || !item) return;
        var row = this.grid.tbody.find("tr[data-uid='" + item.uid + "']");
        this.grid.select(row);

        var scrollContentOffset = this.grid.tbody.offset().top;
        var selectContentOffset = this.grid.select().offset().top;
        var distance = selectContentOffset - scrollContentOffset;

        this.grid.content.animate({
            scrollTop: distance
        }, 400);
    };
}

