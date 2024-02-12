import Vue from 'vue'

Vue.component('user-view', require('./components/UserComp.vue').default);

Vue.config.productionTip = false

window.Vue = Vue