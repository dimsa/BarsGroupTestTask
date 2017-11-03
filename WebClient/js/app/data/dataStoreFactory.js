Ext.define('App.Data.DataStoreFactory', {
    config: {  
    },
    constructor: function () {
        this.initConfig();
    },
    getStore: function () {
        return Ext.create('Ext.data.ArrayStore', {
            fields: [
                { name: 'company' },
                { name: 'price', type: 'float' },
                { name: 'change', type: 'float' },
                { name: 'pctChange', type: 'float' },
                { name: 'lastChange', type: 'date', dateFormat: 'n/j h:ia' }
            ],
            data: Ext.create('App.Data.DataStub').values
        });
    }
});

