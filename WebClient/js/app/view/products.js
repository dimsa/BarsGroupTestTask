Ext.define('App.view.products', {
    extend: 'Ext.grid.Panel',
    title: 'Редактирование списка товаров',
    columns: [
        {
            text: 'Идентификатор',
            width: 150,
            sortable: true,
            hideable: false,
            dataIndex: 'Id'
        },
        {
            text: 'Наименование',
            width: 300,
            sortable: true,
            hideable: false,
            dataIndex: 'Name'
        },
        {
            text: 'Код',
            width: 300,
            sortable: true,
            hideable: false,
            dataIndex: 'Code'
        },
        {
            xtype: 'actioncolumn',
            width: 50,
            items: [{
                icon: 'js/vendor/extjs/examples/shared/icons/fam/cog_edit.png',  // Use a URL in the icon config
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
                text: 'Добавить товар',
                itemId: 'addProductButton'
            }
        ]
    }]
});
