import Vue from 'vue'
import Router from 'vue-router'
import PlantAdvisor from './components/PlantAdvisor.vue';
import Production from './components/Production.vue';
import Country from './components/Country.vue';
import Plant from './components/Plant.vue';
Vue.use(Router)
export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/Country', component: Country
        },
        {
            path: '/PlantAdvisor', component: PlantAdvisor
        },
        {
            path: '/Production', component: Production
        },
        {
            path: '/Plant', component: Plant
        }
    ]
});

