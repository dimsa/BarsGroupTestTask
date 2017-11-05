Ext.define('App.model.product', {
    extend: 'Ext.data.Model',
    fields: [
        {name: 'Id', type: 'int' },
        { name: 'Name', type: 'string' },
        { name: 'Code', type: 'string' },
    ]
});
