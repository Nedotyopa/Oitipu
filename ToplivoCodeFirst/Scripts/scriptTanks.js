/// <reference path="jquery.jqGrid.js" />
$(function () {
    $("#jqGrid").jqGrid({
        url: "/JQGridTanks/GetTanks",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['TankID', 'Название', 'Объем', 'Вес', 'Материал', 'Изображение'],
        colModel: [
            { key: true, hidden: true, name: 'TankID', index: 'TankID', editable: true },
            { key: false, name: 'TankType', index: 'TankType', sortable: true, editable: true },
            { key: false, name: 'TankVolume', index: 'TankVolume', editable: true },
            { key: false, name: 'TankWeight', index: 'TankWeight', editable: true },
            { key: false, name: 'TankMaterial', index: 'TankMaterial', editable: true },
            { key: false, name: 'TankPicture', index: 'TankPicture', editable: true }
                    ],
        pager: jQuery('#jqControls'),
        rowNum: 10,        
        rowList: [10, 20, 30, 40, 50],
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


