var gridPageSize = 15;

//checks for a json redirect response instruction
function checkRedirect(response) {
    if (hasRedirect(response)) window.location.href = response.RedirectUrl;
}

function hasRedirect(response){
    return response && response.HasRedirectUrl;
}

//wrapper around ajax call to catch json redirect instructions
function ajaxWrapper(options) {
    options = $.extend({ cache: false }, options);
    return $.ajax(options).fail(function (err) {
        checkRedirect(err.responseJSON);
    });
}

function getGridDataFromUrl(gridOptions) {
    return function (options) {
        var extra = '';
        if (gridOptions.extraParameters) extra = gridOptions.extraParameters();
        if (gridOptions.url.indexOf('?') < 0) extra = '?' + extra;
        var ajaxOptions = {
            url: gridOptions.url + extra,
            data: dataMap(options.data, gridOptions),
            cache: false
        };
        ajaxWrapper(ajaxOptions)
            .then(function (result) {
                options.success(result);
                if (gridOptions.onLoaded) {
                    gridOptions.onLoaded(result);
                }
            }, function (data) {
                options.error(data);
                if (gridOptions.onLoadFailed) {
                    gridOptions.onLoadFailed(data);
                }
            });
    };
};

function dataMap(data, gridOptions) {

    var d = {};
    if (gridOptions.type == 'odata-v4') {
        d = kendo.data.transports['odata-v4'].parameterMap(data);
        delete d['$inlinecount'];
        d['$count'] = true;
    }
    if (gridOptions.searchElementId) {
        d.search = $('#' + gridOptions.searchElementId).val();
    }
    return d;
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
            handleHelp();
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

            // show.bs.modal event has to be specified before building the .modal
            mdiv.one('show.bs.modal', function () {
                if (shownFunction) {
                    shownFunction();
                }
                $.fn.modal.Constructor.prototype.enforceFocus = function () { };
            }).modal({
                backdrop: 'static',
                keyboard: false
            }).one('hide.bs.modal', function (e) {
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


// for 'fire and forget' modal links, where no result is captured
// for dynamically added html (e.g. handlebars) the modallink binding will work using: $('body').on('click', 'a[data-modallink]', function (e) {
function findModalLinks() {
    $('body').on('click', 'a[data-modallink]', function (e) {
        if (!$(e.target).prop('disabled')) {
            $(e.target).prop('disabled', true);
            e.preventDefault();
            ajaxWrapper({
                url: $(this).data('href'),
                cache: false
            }).done(function (result) {
                var tempDiv = $(result); //tempDiv include all elements & script
                $('body').append(tempDiv);
                handleHelp();
                var mdiv = tempDiv.filter('.modal');
                modalStack.push(mdiv);
                // show.bs.modal event has to be specified before building the .modal
                mdiv.on('show.bs.modal', function () {
                    $.fn.modal.Constructor.prototype.enforceFocus = function () { };
                }).modal({
                    backdrop: 'static',
                    keyboard: false
                }).on('hide.bs.modal', function () {
                    tempDiv.remove(); //remove all elements which were added
                    modalStack.pop();
                });

                $(e.target).prop('disabled', false);
            });
        }
    });
}

function handleHelp() {
    $('.help-vert').on('click', function () {
        var div = $(this).parent();
        if (div.hasClass('help-show'))
            div.removeClass('help-show');
        else
            div.addClass('help-show');
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
        if (date == "" || date == null) return "";
        var ret = new Date(date).toLocaleString();
        if (ret == "Invalid Date") ret = new Date(date.replace(' ', 'T')).toLocaleString(); //IE...
        return ret;
    }
    catch (ex) {
        return "";
    }
}

function dateStringNoTime(date) {
    try {
        if (date == "" || date == null) return "";
        var ret = new Date(date).toLocaleDateString();
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
function loadGridSort(options) {
    if (options.resetSort) {
        options.resetSort = false;
        return null;
    }
    try {
        return JSON.parse(sessionStorage["gridSort-" + options.gridElementId]);
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
    this.firstLoad = true;
    var self = this;

    if (this.options.jumpToRow) this.options.jumpToPage = getPageFromRow(this.options.jumpToRow, gridPageSize);

    //pass through options to kendo and hook up events
    this.makeGrid = function () {
        if (this.loaded) return;
        this.loaded = true;
        var o = {
            dataSource: {
                transport: {
                    read: getGridDataFromUrl(this.options)
                },
                schema: this.options.schema,
                sort: loadGridSort(this.options) || this.options.defaultSort,
            },
            height: 300,
            selectable: "row",
            filterable: false,
            sortable: true,
            navigatable: true,
            columns: options.columns,
            dataBound: this.dataBound,
            change: this.change
        }
        if (this.options.type) o.dataSource.type = this.options.type;
        if (this.options.serverSorting) o.dataSource.serverSorting = this.options.serverSorting;
        if (this.options.serverPaging) {
            o.dataSource.serverPaging = this.options.serverPaging;
            o.pageable = { pageSize: gridPageSize }
        }
        else {
            o.pageable = {
                numeric: false,
                previousNext: false,
                messages: { display: "{2} rows" }
            }
        }
        self.grid = $("#" + this.options.gridElementId).kendoGrid(o).data("kendoGrid");

        setupUpDownNavigation();

        $('#' + this.options.searchButtonId).click(function () {
            self.refreshGrid();
        });

        function setupUpDownNavigation() {
            var arrows = [38, 40];
            self.grid.table.on("keydown", function (e) {
                if (arrows.indexOf(e.keyCode) >= 0) {
                    setTimeout(function () {
                        self.grid.select($("#" + self.options.gridElementId + "_active_cell").closest("tr"));
                    });
                }
            })
            self.grid.table.focus();
        }
    };

    this.refreshGrid = function () {
        self.grid.dataSource.read();
        self.grid.dataSource.page(1);
        self.firstLoad = true;
    }

    this.dataBound = function (e) {
        saveGridSort(self.grid, self.options.gridElementId);

        var gridData = self.grid.dataSource.data();
        if (gridData.length == 0) {
            if (self.options.panels) {
                for (var p in self.options.panels) {
                    $('#' + self.options.panels[p]).addClass("hidden");
                }
            }
        } else {
            if (self.options.jumpToPage != null && self.options.jumpToPage != "") {
                var p = self.options.jumpToPage;
                self.options.jumpToPage = null;
                self.grid.dataSource.page(p); //this causes dataBound to fire again
            }
            else {
                if (self.options.jumpToId != null && self.options.jumpToId != "") {
                    for (var i = 0; i < gridData.length; i++) {
                        if (self.options.jumpToId == gridData[i][self.options.schema.model.id] || self.options.jumpToId.replace(/-/g, "") == gridData[i][self.options.schema.model.id]) {
                            self.scrollToRow(gridData[i]);
                            self.options.jumpToId = null; //make sure this is one off
                            break;
                        }
                    }
                } else {
                    if (self.firstLoad) {
                        self.selectFirstRow();
                    }
                    else
                        self.scrollToRow(self.selectedItem);
                }
            }
        }
        self.firstLoad = false;
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
            if (self.options.change) self.options.change(dataItem); //any custom data binding
        }
    };

    this.scrollToRow = function (item) {
        if (!this.grid || !item) return;
        var gridItem = this.grid.dataSource.get(item.id);
        if (gridItem) {
            var row = this.grid.tbody.find("tr[data-uid='" + gridItem.uid + "']");
            this.grid.select(row);

            var scrollContentOffset = this.grid.tbody.offset().top;
            var selectContentOffset = this.grid.select().offset().top;
            var distance = selectContentOffset - scrollContentOffset;

            this.grid.content.animate({
                scrollTop: distance
            }, 400);
        }
    };

    this.selectFirstRow = function () {
        if (!this.grid) return;
        var row = this.grid.tbody.find("tr:first");
        if (row) this.grid.select(row);
    };
}

function showHistory(selector, dataItem) {
    $(selector).empty();
    for (var i = 0; i < dataItem.History.length; i++) {
        var h = dataItem.History[i];
        var active = ' (' + (h.WasActive ? 'Active' : 'Inactive') + ')';
        var notes = h.Notes == '' ? '' : ': "' + h.Notes + '"';
        var item = '<div>' + dateString(h.StatusChangedOn) + ' <strong>' + h.StatusTypeValue.Name + '</strong>' + active + ' by ' + h.StatusChangedBy + notes + '</div>';
        $(selector).append(item);
    }
}

function showDuplicates(selector, headingSelector, dataItem) {
    $(selector).empty();
    $(headingSelector).children().remove();
    if (dataItem.Duplicates.length == 0) {
        $(selector).append("<div>None</div>");
    }
    else {
        $(headingSelector).append("<i class='fa fa-exclamation-triangle' style='color:red;'></i>");
        for (var i = 0; i < dataItem.Duplicates.length; i++) {
            var d = dataItem.Duplicates[i];
            var active = ' (' + (d.IsActive ? 'Active' : 'Inactive') + ')';
            var item = '<div><strong>' + d.Name + ':</strong> ' + d.Status + active + ' created ' + dateString(d.Created) + '</div>';
            $(selector).append(item);
        }
    }
}

function formatCurrency(val) {
    return accounting.formatMoney(val, "£ ", 2);
}

var findAddress = function (opts) {

    this.postcodelookup = $(opts.postcodelookup);
    this.companyName = $(opts.companyName);
    this.line1 = $(opts.line1);
    this.line2 = $(opts.line2);
    this.town = $(opts.town);
    this.county = $(opts.county);
    this.postcode = $(opts.postcode);
    this.additional = $(opts.additionalAddress);

    this.manualAddress = $(opts.manualAddress);
    this.resList = $(opts.resList);
    this.manAddRow = $(opts.manAddRow);
    this.noMatch = $(opts.noMatch);
    this.findAddressButton = $(opts.findAddressButton);

    var self = this;

    this.setup = function () {
        self.manAddRow.hide();
        self.noMatch.hide();
        self.resList.prop('disabled', true);

        self.manualAddress.change(function () {
            self.lockFields(!this.checked);
        });

        self.resList.change(function () {
            var selOpt = self.resList.find(":selected");
            var x = selOpt.attr('data-Opt');
            if (x) {
                if (x == "manual") {
                    self.clearForm();
                }
            }
            else {
                self.manAddRow.show();
                self.checkMan(false);
                if (self.companyName.length > 0) self.companyName.val(selOpt.attr('data-Company')).valid();
                if (self.line1.length > 0) self.line1.val(selOpt.attr('data-Line1')).valid();
                if (self.line2.length > 0) self.line2.val(selOpt.attr('data-Line2')).valid();
                if (self.town.length > 0) self.town.val(selOpt.attr('data-PostTown')).valid();
                if (self.county.length > 0) self.county.val(selOpt.attr('data-County')).valid();
                if (self.postcode.length > 0) self.postcode.val(selOpt.attr('data-Postcode')).valid();
            }
        });

        self.findAddressButton.click(function () {
            var pc = self.postcodelookup.val().trim();

            if (pc == "") return;

            self.findAddressButton.prop('disabled', true);

            ajaxWrapper({
                url: self.findAddressButton.data('url'),
                data: {
                    postcode: pc,
                    __RequestVerificationToken: self.findAddressButton.data('requestverificationtoken')
                },
                type: 'POST'
            })
            .always(function () {
                self.resList.empty();
                self.findAddressButton.prop('disabled', false);
                self.checkMan(false);
            })
            .done(function (result) {
                self.noMatch.hide();
                self.resList.prop('disabled', false);
                if (result && result.length > 0) {
                    self.resList.append($("<option data-Opt='none'>Please select an address:</option>"));
                    self.resList.append($("<option data-Opt='manual'>Address not listed, please enter manually</option>"));
                    $.each(result, function (i, item) {
                        var opt = $("<option>" + item.FullAddress + "</option>");
                        opt.attr('data-Company', item.Company);
                        opt.attr('data-Line1', item.Line1);
                        opt.attr('data-Line2', item.Line2);
                        opt.attr('data-PostTown', item.PostTown);
                        opt.attr('data-County', item.County);
                        opt.attr('data-Postcode', item.Postcode);
                        self.resList.append(opt);
                    });
                }
                else {
                    self.lookupFailed();
                }
            })
            .fail(function (err) {
                if (!hasRedirect(err.responseJSON)) self.lookupFailed();
            });
        });
    }

    this.clearForm = function () {
        self.manAddRow.hide();
        self.checkMan(true);
        self.companyName.val('');
        self.line1.val('');
        self.line2.val('');
        self.town.val('');
        self.county.val('');
        self.postcode.val('');
    }

    this.checkMan = function (check) {
        self.manualAddress.prop('checked', check);
        self.lockFields(!check);
    }

    this.lockFields = function (lock) {
        self.line1.attr('readonly', lock);
        self.line2.attr('readonly', lock);
        self.town.attr('readonly', lock);
        self.county.attr('readonly', lock);
        self.postcode.attr('readonly', lock);
        self.additional.attr('readonly', lock);
    }

    this.lookupFailed = function () {
        self.noMatch.show();
        self.resList.prop('disabled', true);
        self.clearForm();
    }
}

function makeDatePicker(inputSelector, settings, onEvents) {
    var inp = $(inputSelector);

    var defaultSettings = {
        dateFormat: "yy-mm-ddT00:00:00.0000000",
        changeMonth: true,
        changeYear: true,
        yearRange: "-110:+0",
        showButtonPanel: true,
        prevText: "<i class=\"fa fa-chevron-left\"></i>",
        nextText: "<i class=\"fa fa-chevron-right\"></i>",
        onSelect: function (date, inst) {
            inp.data("val", date);
            inp.val(dateStringNoTime(date));
            $(this).valid();
            if (onEvents && onEvents.onSelect) {
                onEvents.onSelect(date, inst);
            }
        },
        showOn: ''
    };

    var settings = _.extend({}, defaultSettings, settings);

    inp.datepicker(settings);
    var fullVal = inp.val();
    inp.data("val", fullVal);
    inp.val(dateStringNoTime(fullVal));

    inp.on('focus', function () {
        var orig = inp.val();
        inp.val(inp.data("val"));
        inp.datepicker('show');
        inp.val(orig);
    });
}

function fixDate(array, name, inputSelector) {
    for (i in array) {
        if (array[i].name == name) {
            array[i].value = $(inputSelector).data("val");
            break;
        }
    }
}

function checkWizardValid(wizard, selector) {
    return function () {
        var form = $(selector);
        if (!form.valid()) {
            var invalidInputs = $(form.find('.tab-pane .state-error')[0]);
            var tabId = $(invalidInputs.parents('.tab-pane')[0]).attr('id');
            wizard.bootstrapWizard('show', tabId);
            return false;
        }
        form.submit();
    }
}

// returns: ~/Areas/[area]/Views/[controller]/[view].cshtml
// example: ~/Areas/Admin/Views/Messages/_conversationsTmpl.cshtml
// or: ~/Views/Home/_myView.cshtml
function getRazorViewPath(viewName, controller, area) {
    var result = '~';
    if (area) {
        result += '/Areas/' + area;
    }
    result += '/Views/' + controller + '/' + viewName + '.cshtml';
    return result;
}

String.prototype.lines = function () { return this.split(/\r*\n/); }
String.prototype.lineCount = function () { return this.lines().length; }

function getPageFromRow(row, pageSize) {
    return Math.floor((row - 1) / pageSize) + 1;
}

function guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
}

function populateCompany(dataItem) {
    if (!!dataItem.CreatedOn) dataItem.CreatedOnDisplay = dateString(dataItem.CreatedOn);
    if (!!dataItem.PinCreated) dataItem.PinCreatedDisplay = dateString(dataItem.PinCreated);
    if (dataItem.TradingNames.length > 0) {
        dataItem.TradingNamesDisplay = dataItem.TradingNames.slice();
    }
    dataItem.SystemAdminNameDisplay = (dataItem.OrganisationAdminSalutation || "") + " " + (dataItem.OrganisationAdminFirstName || "") + " " + (dataItem.OrganisationAdminLastName || "");
    dataItem.RegulatorNameDisplay = dataItem.Regulator || "";
    if (dataItem.RegulatorNameDisplay.toLowerCase() == 'other') dataItem.RegulatorNameDisplay = dataItem.RegulatorOther;
    dataItem.StatusChangedOnDisplay = dateString(dataItem.StatusChangedOn);
    if (!!dataItem.VerifiedOn) dataItem.VerifiedOnDisplay = dateString(dataItem.VerifiedOn);
}

var defTmpl = function (path, states, types) {
    for (var i = 0; i < states.length; i++) {
        this[states[i]] = {};
        for (var j = 0; j < types.length; j++) {
            this[states[i]][types[j].description] = $.Deferred();
            getIt(this[states[i]][types[j].description], states, types, i, j);
        }
    }

    function getIt(d, states, types, i, j) {
        ajaxWrapper({ url: $('#content').data("templateurl") + '?view=' + getRazorViewPath(states[i] + '_Tmpl', path + types[j].name, 'Admin') })
            .done(function (res) { d.resolve(Handlebars.compile(res)); });
    }
}

function showtoastrError(){
    toastr.error("Sorry, something went wrong. This issue has been logged and will be investigated by our team.<br />In the meantime, please go back and try again.", "Error",
        {
            timeOut: 0,
            extendedTimeOut: 0,
            closeButton: true
        });
}

if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
              ? args[number]
              : match
            ;
        });
    };
}