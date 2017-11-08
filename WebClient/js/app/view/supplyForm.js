Ext.define('App.view.supplyForm', {
    extend: 'Ext.window.Window',

    id: 'supplyWindow',
    border: 0,
    height: 150,
    width: 400,
    resizable: false,
    modal: true,
    closable: false,
    title: 'Редактирование/создание поставок',

    layout: 'fit',
    items: [
        {
            xtype: 'form',
            layout: 'column',
            itemId: 'formPanel',
            defaults: {
                columnWidth: 1,
                allowBlank: false,
                style: {
                    marginBottom: '5px'
                }
            },
            bodyStyle: {
                padding: '5px'
            },
            items: [
		        {
		            xtype: 'datefield',
		            fieldLabel: 'Дата поставки',
		            itemId: 'date',
		            name: 'date',
		            format: 'd.m.Y'
		        },
		        {
		            xtype: 'combobox',
		            fieldLabel: 'Товар',
		            itemId: 'product',
		            name: 'product',
                    store: Ext.create('App.model.productStore', { pageSize: 0 }),
		            displayField: 'Name',
                    valueField: 'Id',
                    queryMode: 'local'
		        },
		         {
		             xtype: 'combobox',
		             fieldLabel: 'Поставщик',
		             itemId: 'provisioner',
		             name: 'provisioner',
                     store: Ext.create('App.model.provisionerStore', { pageSize: 0 }),
		             displayField: 'Name',
		             valueField: 'Id',
		             queryMode: 'local'
		         }
            ]
        }
    ],

    buttons: [{
        text: 'Сохранить',
        itemId: 'saveButton',
        handler: function () {

        }
    }, {
        text: 'Отмена',
        itemId: 'cancelButton',
        handler: function () {


        }
    }]


});
