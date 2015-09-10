$(function () {
    var shownMessage = false;
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    var statementGrid = new gridItem(
    {
        gridElementId: 'statementGrid',
        url: $('#statementGrid').data("url"),
        schema: { data: "Items", total: "Count", model: { id: "TransactionOrderID" } },
        type: 'odata-v4',
        serverSorting: true,
        serverPaging: true,
        defaultSort: { field: "BalanceOn", dir: "asc" },
        panels: ['rPanel'],
        change: txChange,
        onLoadFailed: function (data) {
            console.log(data);
        },
        extraParameters: function () {
            var selectedDateRange = getSelectedDateRange();
            return "&from=" + selectedDateRange.from + "&to=" + selectedDateRange.to + "&orgID=" + $('#orgID').val() + "&creditsOnly=" + $('#creditsOnly').val();
        },
        columns: [
            {
                field: "InvoiceReference",
                title: "Reference",
                sortable: false
            },
            {
                field: "Amount",
                title: "Amount",
                sortable: false
            },
            {
                field: "Balance",
                title: "Balance",
                sortable: false
            },
            {
                field: "BalanceOn",
                title: "Date",
                template: function (dataItem) { return dateString(dataItem.BalanceOn); }
            },
            {
                field: "CreatedByName",
                title: "Created By",
                sortable: false
            }
        ]
    });

    var companies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('Name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        identify: function (datum) {
            return datum.OrganisationID;
        },
        remote: {
            url: $('#orgSearch').data("url") + '?search=%QUERY',
            wildcard: '%QUERY',
            transform: function (response) {
                return response.Items;
            }
        }
    });

    findModalLinks();
    setupDateRangeInputs();
    statementGrid.makeGrid();
    setupAutocomplete();
    setupForm();
});

function applyFilter() {
    statementGrid.refreshGrid();
}

function getSelectedDateRange() {
    var dateFrom = moment($('#from').val(), 'DD/MM/YYYY').format('YYYY-MM-DD');
    var dateTo = moment($('#to').val(), 'DD/MM/YYYY').format('YYYY-MM-DD');
    return {
        from: dateFrom,
        to: dateTo
    };
}

//data binding for the panes beneath each grid
function txChange(dataItem) {
    $("p#ddReference").text(dataItem.InvoiceReference || "");
    $("p#ddAmount").text(dataItem.Amount || "");
    $("p#ddDate").text(dateString(dataItem.BalanceOn) || "");
    $("p#ddCreatedBy").text(dataItem.CreatedByName || "");
}

function setupAutocomplete() {
    $('#orgSearch').typeahead({
        minLength: 1,
        highlight: true,
        hint: false
    }, {
        display: 'Name',
        source: companies,
        templates: {
            empty: [
                '<div class="empty-message">',
                'Unable to find any company that match the current query',
                '</div>'
            ].join('\n')
        }
    })
        .on("typeahead:selected typeahead:autocompleted", function (e, datum) {
            $('#orgID').val(datum.OrganisationID);
            $("#amendCreditButton").attr('disabled', false);
            $("#amendCreditButton").data('href', '@Url.Action("ViewAmendCredit", "Finance", new {area = "Admin"})' + "?orgId=" + datum.OrganisationID);
            applyFilter();
        })
        .on('typeahead:asyncrequest', function () {
            $('#orgSearch').parent().siblings('.typeahead-spinner').show();
        })
        .on('typeahead:asynccancel typeahead:asyncreceive', function () {
            $('#orgSearch').parent().siblings('.typeahead-spinner').hide();
        });
}

function setupDateRangeInputs() {
    $.becDateRange({
        dateFromInputSelector: "#from",
        dateToInputSelector: "#to",
        dateFromShowButtonSelector: "#from ~ .input-group-addon",
        dateToShowButtonSelector: "#to ~ .input-group-addon"
    });
}

function setupForm() {
    var creditSearchForm = $("#creditSearchForm");
    $("#submitCreditSearch").click(function (e) {
        creditSearchForm.submit();
    });
    creditSearchForm.validate({
        ignore: '.skip',
        rules: {
            from: {
                required: true,
                dateGB: true
            },
            to: {
                required: true,
                dateGB: true
            },
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        },

        submitHandler: applyFilter
    });
}