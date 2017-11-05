Ext.define('App.controller.products', {
    extend: 'Ext.app.Controller',
    stores: [
        'App.model.productStore'
    ],
    views: [
        'App.view.products'
    ],
    refs: [
        {
            ref: 'addButton',
            selector: 'button#addButton'
        }
    ],
    grid: undefined,
    viewport: undefined,
    init: function (app) {
        console.log('productsControllerInit');
    },
    renderTo: function (viewport) {
        var store = this.getStore('App.model.productStore');
        var gr = this.getView('App.view.products');
        this.grid = Ext.create(gr);
        this.grid.bindStore(store);
        this.viewport = viewport;
        this.addComponent(this.grid);
        this.getAddButton().on('click', this.add, this);
    },
    addComponent: function (component) {
        this.viewport.add(component);
        this.viewport.doLayout();
    },
    add: function (button) {
        alert(button);
    },
});
