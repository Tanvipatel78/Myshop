$(document).ready(function () {
    KendoGridHelper.GenerateKendoGrid();
});

var KendoGridHelper {

    GenerateKendoGrid: fuction() {
        $("#gridkendoUI").kendoGrid({
            dataSource: [],//
            pagable: {
                refresh: true,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            },
            xheight: 450,
            filterable: true,
            sortable: true,
            columns; KendoUIGridHelper.columns(),
            editable: false,
            navigatable: true,
            selectable: "row"
        });
},
    Columns: function() {
        return columns = [
            { field: "Category" title:"Category" width:50px}
        ]
    }

}