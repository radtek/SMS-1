﻿var grid1, grid2, grid3;
$(function () {
    //set up grid options for the three grids. most are passed straight on to kendo grid.
    grid1 = new gridItem(
        {
            gridElementId: 'grid1',
            url: $('#grid1').data("url"),
            schema: { data: "list", total: "total", model: { id: "Id" } },
            columns: [
                    {
                        field: "Name",
                        title: "Company Name"
                    },
                    {
                        field: "Total",
                        title: "Total"
                    },
                    {
                        field: "LoggedIn",
                        title: "Logged In"
                    },
                    {
                        field: "Time.Value",
                        title: "Time to register",
                        template: function (dataItem) {
                            return kendo.htmlEncode(dataItem.Time.Text);
                        }
                    }
            ]
        });

    grid2 = new gridItem(
        {
            gridElementId: 'grid2',
            url: $('#grid2').data("url"),
            schema: { data: "list", total: "total", model: { id: "Id" } },
            columns: [
                    {
                        field: "Name",
                        title: "Company Name"
                    },
                    {
                        field: "Total",
                        title: "Total"
                    },
                    {
                        field: "LoggedIn",
                        title: "Logged In"
                    },
                    {
                        field: "Time.Value",
                        title: "Time to register",
                        template: function (dataItem) {
                            return kendo.htmlEncode(dataItem.Time.Text);
                        }
                    }
            ]
        });

    grid3 = new gridItem(
        {
            gridElementId: 'grid3',
            url: $('#grid3').data("url"),
            schema: { data: "list", total: "total", model: { id: "Id" } },
            columns: [
                    {
                        field: "Name",
                        title: "Company Name"
                    },
                    {
                        field: "Time.Value",
                        title: "Time to register",
                        template: function (dataItem) {
                            return kendo.htmlEncode(dataItem.Time.Text);
                        }
                    }
            ]
        });

    //findModalLinks();
    var tabs = new tabItem("myTab1",
        {
            s1: {
                grids: [grid1]
            },
            s2: {
                grids: [grid2]
            },
            s3: {
                grids: [grid3]
            },
        });

    //set up tabs
    tabs.makeTab();
    tabs.showTab($('#myTab1').data("selected"));

    $('#sources input').change(function () {
        var g = $('#reportGrid').data("kendoGrid");
        g.dataSource.transport.options.read.url = $('#reportGrid').data("url") + "&group=" + $(this).data("group");
    });
});
