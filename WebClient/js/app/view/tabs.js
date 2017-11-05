Ext.define('App.view.tabs', {
    extend: 'Ext.tab.Panel',
    width: 800,
    height: 400,
    activeTab: 0,
    plain: true,
    items: [
        {
            title: 'Редактирование товаров'
        },
        {
            title: 'Редактирование поставщиков'
        }
    ],
});
