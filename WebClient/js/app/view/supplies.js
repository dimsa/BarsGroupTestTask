Ext.define('App.view.supplies', {
    extend: 'Ext.grid.Panel',
    title: 'Редактирование списка поставок',
    itemId: 'supplyGrid',
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
            items: [
                {
                    icon: 'js/vendor/extjs/examples/shared/icons/fam/cog_edit.png',
                    tooltip: 'Edit',
                    handler: function(grid, rowIndex, colIndex) {
                        var rec = grid.getStore().getAt(rowIndex);
                        this.fireEvent('SUPPLY_EDITED', rec);
                    }
                }, {
                    icon: 'js/vendor/extjs/examples/restful/images/delete.png',
                    tooltip: 'Delete',
                    handler: function(grid, rowIndex, colIndex) {
                        var rec = grid.getStore().getAt(rowIndex);
                        grid.getStore().remove(rec);
                        grid.getStore().sync();
                    }
                }
            ]
        }
    ],
    
    initComponent: function() {
        this.callParent(arguments);
    },
       
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
                itemId: 'printButton',
                menu: {
                    xtype: 'menu',
                    name: 'exportToXls',
                    text: 'Печать',
                    dock: 'top',
                    itemId: 'exportSuppliesToXlsButton',
                    items: [{
                            text: 'Word',
                            iconCls: 'edit',
                            handler: function() {
                                window.open("http://localhost:5344/api/export/doc", "_blank");
                            }
                        },
                        {
                            text: 'Excel',
                            iconCls: 'edit',
                            handler: function () {
                                window.open("http://localhost:5344/api/export/xls", "_blank");
                            }
                        }]
                }
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
