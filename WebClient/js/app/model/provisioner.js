Ext.define('App.model.provisioner', {
    extend: 'Ext.data.Model',
    idProperty: 'Id',
    idgen: {
        isGenerator: true,
        type: 'default',

        generate: function () {
            return this;
        },
        getRecId: function (rec) {
            return rec.internalId;
        }
    },
    fields: [
        {name: 'Id', type: 'int' },
        { name: 'Name', type: 'string' }
    ]
});
