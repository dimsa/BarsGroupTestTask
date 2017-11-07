Ext.define('App.controller.supplies', {
    extend: 'Ext.app.Controller',
    stores: [
        'App.model.supplyStore'
    ],
    views: [
        'App.view.supplies'
    ],
    refs: [
        {
            ref: 'addButton',
            selector: 'button#addSupplyButton'
        }
    ],
    grid: undefined,
    viewport: undefined,
    init: function (app) {
        console.log('suppliesControllerInit');
    },
    renderTo: function (viewport) {
        var store = this.getStore('App.model.supplyStore');
        var gr = this.getView('App.view.supplies');
        this.grid = Ext.create(gr);
        this.grid.bindStore(store);
        this.viewport = viewport;
        this.addComponent(this.grid);
        this.getAddButton().on('click', this.add, this);
    },
    addComponent: function (component) {
        this.viewport.add(component);
    },
    add: function (button) {
        var store = this.getStore('App.model.supplyStore');
        var pr = Ext.create('App.model.supply', { Id: 0, Name: "Новый объект" });
        // Поле должно автоматически ставится в true, но этого не происходит.
        pr.phantom = true;
        store.add(pr);
    },
});
