Ext.require([
    'Ext.grid.*',
    'Ext.data.*',
    'Ext.util.*',
    'Ext.state.*'
]);

Ext.Loader.setPath('App', 'js/app');
Ext.Loader.setConfig({
    enabled: true,
    path: { 'App': 'js/app' }
});


Ext.onReady(function () {
    Ext.QuickTips.init();

    // sample static data for the store 

    /**
     * Custom function used for column renderer
     * @param {Object} val
     */
    function change(val) {
        if (val > 0) {
            return '<span style="color:green;">' + val + '</span>';
        } else if (val < 0) {
            return '<span style="color:red;">' + val + '</span>';
        }
        return val;
    }

    /**
     * Custom function used for column renderer
     * @param {Object} val
     */
    function pctChange(val) {
        if (val > 0) {
            return '<span style="color:green;">' + val + '%</span>';
        } else if (val < 0) {
            return '<span style="color:red;">' + val + '%</span>';
        }
        return val;
    }

    var storeFactory = Ext.create('App.Data.DataStoreFactory');
    var store = storeFactory.getStore();

    console.log(store);

    // create the Grid
    var grid = Ext.create('Ext.grid.Panel', {
        store: store,
        columnLines: true,
        columns: [{
            xtype: 'rownumberer'
        }, {
            text: 'Company<br>Name', // Two line header! Test header height synchronization!
            locked: true,
            width: 200,
            sortable: false,
            dataIndex: 'company'
        }, {
            text: 'Price',
            lockable: false,
            width: 125,
            sortable: true,
            renderer: 'usMoney',
            dataIndex: 'price'
        }, {
            text: 'Change',
            width: 125,
            sortable: true,
            renderer: change,
            dataIndex: 'change'
        }, {
            text: '% Change',
            width: 125,
            sortable: true,
            renderer: pctChange,
            dataIndex: 'pctChange'
        }, {
            text: 'Last Updated',
            width: 135,
            sortable: true,
            renderer: Ext.util.Format.dateRenderer('m/d/Y'),
            dataIndex: 'lastChange'
        }],
        bbar: Ext.create('App.Ui.PagingTool').getPagingTool(store),
        height: 350,
        width: 600,
        title: 'Locking Grid Column',
        renderTo: 'grid-example',
        viewConfig: {
            stripeRows: true
        }
    });
});
