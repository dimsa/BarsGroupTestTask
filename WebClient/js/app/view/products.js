var cellProductsEditing = Ext.create('Ext.grid.plugin.CellEditing', {
    listeners: {
        beforeedit: function (plugin, edit) {
            if (edit.column.xtype == 'actioncolumn') {
                return false;
            }
        }
    }
});

Ext.define('App.view.products', {
    extend: 'Ext.grid.Panel',
    title: 'Редактирование списка товаров',
    plugins: [cellProductsEditing],
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
            dataIndex: 'Name',
            editor: {
                xtype: 'textfield',
                allowBlank: false
            }
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
            items: [
                {
                    icon: 'js/vendor/extjs/examples/shared/icons/fam/cog_edit.png', // Use a URL in the icon config
                    tooltip: 'Edit',
                    handler: function(grid, rowIndex, colIndex) {
                        console.log(cellProductsEditing);
                        if (cellProductsEditing.editing === true) {
                            cellProductsEditing.editing = false;
                            cellProductsEditing.cancelEdit();
                        } else {
                            cellProductsEditing.startEdit(rowIndex, 1);
                        }
                    }
                }, {
                    icon: 'js/vendor/extjs/examples/restful/images/delete.png',
                    tooltip: 'Delete',
                    handler: function(grid, rowIndex, colIndex) {
                        var rec = grid.getStore().getAt(rowIndex);
                        grid.getStore().remove(rec);
                    }
                }
            ]
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
    }, {
        xtype: 'pagingtoolbar',
        store: Ext.data.StoreManager.get("App.model.productStore"),
        dock: 'bottom',
        displayInfo: true,
        beforePageText: 'Страница',
        afterPageText: 'из {0}',
        displayMsg: '{0} - {1} из {2}'
    }]
});
