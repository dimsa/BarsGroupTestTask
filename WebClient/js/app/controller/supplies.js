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
        },
        {
            ref: 'refreshButton',
            selector: 'button#refreshSupplyButton'
        }
    ],
    requires: [
        'App.controller.supplyForm'
    ],
    grid: undefined,
    viewport: undefined,
    init: function (app) {
        console.log('suppliesControllerInit');

        this.control({
            '#supplyGrid actioncolumn': {
                'SUPPLY_EDITED': function(e) {
                    var controller = this.application.getController('App.controller.supplyForm');

                    // TODO: проверить, не может ли прийти другой формат даты
                    var date = Ext.Date.parse(e.raw.TimeStamp, 'Y-d-mTH:i:s');
                     controller.show(
                        {
                            id: e.raw.Id,
                            product: e.raw.Product.Id,
                            provisioner: e.raw.Provisioner.Id,
                            date: Ext.Date.format(date, 'd.m.Y')
                        }
                    );

                    this.application.on('FORM_CONTROLLER_APPLY', this.onFormControllerAddOrUpdate, this);
                    this.application.on('FORM_CONTROLLER_CLOSED', this.onFormControllerClosed, this);
                }
            }
        });

    },
    renderTo: function (viewport) {
        var store = this.getStore('App.model.supplyStore');
        var gr = this.getView('App.view.supplies');
        this.grid = Ext.create(gr);
        this.grid.bindStore(store);
        this.viewport = viewport;
        this.addComponent(this.grid);
        this.getAddButton().on('click', this.add, this);
        this.getRefreshButton().on('click', this.refresh, this);
    },
    addComponent: function (component) {
        this.viewport.add(component);
    },
    add: function (button) {
        var controller = this.application.getController('App.controller.supplyForm');
        controller.show();

        this.application.on('FORM_CONTROLLER_APPLY', this.onFormControllerAddOrUpdate, this);
        this.application.on('FORM_CONTROLLER_CLOSED', this.onFormControllerClosed, this);
    },

    refresh: function (button) {
        var store = this.getStore('App.model.supplyStore');
        store.load();
    },

    onFormControllerAddOrUpdate: function (values) {
        var date = values.date;
        var store = this.getStore('App.model.supplyStore');

        console.log(values);
        if (values.id === undefined) {
            var pr = Ext.create('App.model.supply', {
                Id: 0,
                TimeStamp: Ext.Date.parse(values.date, 'd.m.Y'),
                Product: { Id: values.product },
                Provisioner: { Id: values.provisioner }
            });

            // Поле должно автоматически ставится в true, но этого не происходит.
            pr.phantom = true;
            store.add(pr);            
        } else {
            var updatable = store.findRecord('Id', values.id);
            updatable.set('TimeStamp', values.date);
            updatable.set('Product', { Id: values.product });
            updatable.set('Provisioner', { Id: values.provisioner });
            updatable.commit();
            // Почему-то не устанавливается флаг dirty сам. И поэтому без него не происходит запроса
            updatable.dirty = true;
        }

        store.sync({
            failure: function(data) {
                store.rejectChanges();
                store.load();
                var responseCode = data.exceptions[0].error.status;
                if (responseCode === 409) {
                    alert(
                        'Вы пытаетесь добавить/обновить данные таким образом, что получаете дубликат. Дата, Товар и Поставщик должны быть совместно уникальны.');
                } else {
                    alert(
                        'Произошла непредвиденная ошибка');
                }
            },
            success: function (data) {
                store.load();
            }
        });
    },
    onFormControllerClosed: function () {
        this.application.un('FORM_CONTROLLER_APPLY', this.onFormControllerAddOrUpdate, this);        
        this.application.un('FORM_CONTROLLER_CLOSED', this.onFormControllerClosed, this);
    },
});
