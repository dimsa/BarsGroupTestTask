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
    requires: [
        'App.controller.supplyForm'
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
        var controller = this.application.getController('App.controller.supplyForm');
        controller.show();

        this.application.on('FORM_CONTROLLER_ADD', this.onFormControllerAdd, this);
        this.application.on('FORM_CONTROLLER_CLOSED', this.onFormControllerClosed, this);
    },

    onFormControllerAdd: function (values) {
     
        var date = values.date;
        var store = this.getStore('App.model.supplyStore');

        console.log('store',store);
        var pr = Ext.create('App.model.supply', {
            Id: 0,
            TimeStamp: date,
            Product: { Id: values.product},
            Provisioner: { Id: values.provisioner}
        });        
        
        // Поле должно автоматически ставится в true, но этого не происходит.
        pr.phantom = true;
        store.add(pr);
        store.sync({
            failure: function (data) {
                store.rejectChanges();
                var responseCode = data.exceptions[0].error.status;
                if (responseCode === 409) {
                    alert(
                        'Вы пытаетесь добавить дубликат поставки. Дата, Товар и Поставщик должны быть совместно уникальны.');
                } else {
                    alert(
                        'Произошла непредвиденная ошибка');
                }
                console.log(data);
            }
        });


    },
    onFormControllerClosed: function () {
        this.application.un('FORM_CONTROLLER_ADD', this.onFormControllerAdd, this);
        this.application.un('FORM_CONTROLLER_EDIT', this.onFormControllerEdit, this);
        this.application.un('FORM_CONTROLLER_CLOSED', this.onFormControllerClosed, this);
    },
});
