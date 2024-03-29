/*import { createApp } from 'vue';
import UserComp from './components/UserComp.vue';

const app = createApp({});
app.component('user-view', UserComp);
app.config.productionTip = false;

// Make Vue instance available globally if needed
window.Vue = app;
*/


import { createApp } from 'vue';
/*import App from './App.vue';*/
import UserComp from './components/UserComp.vue';
import GroupComp from './components/GroupComp.vue';

const usercomp = createApp(UserComp);
const groupcomp = createApp(GroupComp);

/*app.component(UserComp, 'user-view');*/
window.usercomp = usercomp;
window.groupcomp = groupcomp;
