var cellProvisionerEditing = Ext.create('Ext.grid.plugin.CellEditing', {    
    listeners: {
        beforeedit: function(plugin, edit) {
            if (edit.column.xtype == 'actioncolumn') {
                return false;
            }            
        }
    }
});

Ext.define('App.view.provisioners', {
    extend: 'Ext.grid.Panel',
    title: 'Редактирование списка поставщиков',
    plugins: [cellProvisionerEditing],
    selType: 'cellmodel',
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
            xtype: 'actioncolumn',
            width: 50,
            items: [{
                icon: 'js/vendor/extjs/examples/shared/icons/fam/cog_edit.png',  // Use a URL in the icon config
                tooltip: 'Edit',
                handler: function (grid, rowIndex, colIndex) {
                    console.log(cellProvisionerEditing);
                    if (cellProvisionerEditing.editing === true) {
                        cellProvisionerEditing.editing = false;
                        cellProvisionerEditing.cancelEdit();
                    } else {
                        cellProvisionerEditing.startEdit(rowIndex, 1);                       
                    }
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
                text: 'Добавить поставщика',
                itemId: 'addProvisionerButton'
            }
        ]
    }]
});
