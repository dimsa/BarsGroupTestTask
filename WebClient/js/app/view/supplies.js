Ext.define('App.view.supplies', {
    extend: 'Ext.grid.Panel',
    title: 'Редактирование списка поставок',

    columns: [
        {
            text: 'Идентификатор',
            width: 100,
            sortable: true,
            hideable: false,
            dataIndex: 'Id'
        },
        {
            text: 'Дата',
            width: 150,
            sortable: true,
            hideable: false,
            dataIndex: 'TimeStamp',
            type: 'date',
            renderer: Ext.util.Format.dateRenderer('d.m.Y')
        },
        {
            text: 'Товар',
            width: 300,
            xtype: 'templatecolumn',
            sortable: true,
            hideable: false,
            dataIndex: 'Product',
            tpl: '({Product.Id}) {Product.Name}, Код: {Product.Code}'
        },
        {
            text: 'Поставщик',
            width: 300,
            xtype: 'templatecolumn',
            sortable: true,
            hideable: false,
            dataIndex: 'Provisioner',
            tpl: '({Provisioner.Id}) {Provisioner.Name}'
        },
        {
            xtype: 'actioncolumn',
            width: 50,
            items: [{
                icon: 'js/vendor/extjs/examples/shared/icons/fam/cog_edit.png',
                tooltip: 'Edit',
                handler: function (grid, rowIndex, colIndex) {
                    console.log(grid);
                    var rec = grid.getStore().getAt(rowIndex);
                    rec.set('Name', 'new value');
                    rec.commit();
                }
            }, {
                icon: 'js/vendor/extjs/examples/restful/images/delete.png',
                tooltip: 'Delete',
                handler: function (grid, rowIndex, colIndex) {
                    var rec = grid.getStore().getAt(rowIndex);
                    grid.getStore().remove(rec);
                }
            }]
        }
    ],
    dockedItems: [{
        xtype: 'toolbar',
        dock: 'top',
        items: [
            {
                xtype: 'button',
                name: 'add',
                text: 'Добавить поставку',
                itemId: 'addSupplyButton'
            },
            
            {
                xtype: 'button',
                name: 'refresh',
                text: 'Обновить',
                itemId: 'refreshSupplyButton'
            },
            {
                xtype: 'button',
                name: 'print',
                text: 'Печать',
                itemId: 'printSupplyButton'
            }
        ]
    }, {
        xtype: 'pagingtoolbar',
        store: Ext.data.StoreManager.get("App.model.supplyStore"),
        dock: 'bottom',
        displayInfo: true,
        beforePageText: 'Страница',
        afterPageText: 'из {0}',
        displayMsg: '{0} - {1} из {2}'
    }]
});
