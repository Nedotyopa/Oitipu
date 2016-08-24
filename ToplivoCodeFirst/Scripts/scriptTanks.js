/// <reference path="jquery.jqGrid.js" />
$(function () {
    $("#jqGrid").jqGrid({
        url: "/JQGridTanks/GetTanks",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['TankID', 'Емкость', 'Объем', 'Вес', 'Материал', 'Изображение'],
        colModel: [
            { key: true, hidden: true, name: 'TankID', index: 'TankID', editable: true },
            { key: false, name: 'TankType', index: 'TankType', sortable: true, editable: true, search: true},
            { key: false, name: 'TankVolume', index: 'TankVolume', sortable: false, formatter: 'number', formatoptions: { decimalSeparator: "," }, unformat: unformatNumber1, editable: true, search: false},
            { key: false, name: 'TankWeight', index: 'TankWeight', sortable: false, formatter: 'number', formatoptions: { decimalSeparator: "," }, unformat: unformatNumber2, editable: true, search: false },
            { key: false, name: 'TankMaterial', index: 'TankMaterial', sortable: true, editable: true, search: true },
            { key: false, name: 'TankPicture', index: 'TankPicture', sortable: false, edittype: 'file', editable: true, formatter: imageFormat, search: false }
                    ],
        pager: jQuery('#jqControls'),
        rowNum: 10,        
        rowList: [15, 25, 35, 45],
        sortname: "TankType",
        sortorder: "desc",
        height: '100%',
        viewrecords: true,
        caption: 'Емкости',
        emptyrecords: 'Нет записей',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', {
        edit: true,
        edittext: "Редактировать",
        view: true,
        viewtext: "Смотреть",
        add: true,
        addtext: "Добавить",
        del: true,
        deltext: "Удалить",
        search: true,
        searchtext: "Найти",
        refresh: true,
        refreshtext: "Обновить"
    },
        {
            zIndex: 100,
            url: '/JQGridTanks/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/JQGridTanks/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/JQGridTanks/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Вы уверены, что хотите удалить... ? ",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            caption: "Поиск",
            sopt: ['cn']
        });
});

function unformatNumber1(cellvalue, options) {

    return cellvalue.replace(".", ",");
}
function unformatNumber2(cellvalue, options) {

    return cellvalue.replace(".", ",");
}

function imageFormat(cellvalue, options, rowObject) {
    return '<img src=/Images/' + cellvalue + ' alt="Фотография отсутствует" width="25" height="25">';
}