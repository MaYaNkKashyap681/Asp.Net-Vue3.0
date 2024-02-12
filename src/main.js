/*import { createApp } from 'vue';
import UserComp from './components/UserComp.vue';

const app = createApp({});
app.component('user-view', UserComp);
app.config.productionTip = false;

// Make Vue instance available globally if needed
window.Vue = app;
*/


import { createApp } from 'vue';
import App from './App.vue';
import UserComp from './components/UserComp.vue';

const app = createApp(App);

app.component(UserComp, 'user-view');

window.app = app;
