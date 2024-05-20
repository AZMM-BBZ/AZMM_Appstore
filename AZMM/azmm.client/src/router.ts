import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import Login from './Login.vue'
import Registration from './Registration.vue'
import Games from './Games.vue'
import Library from './Library.vue'
import Work from './Work.vue'

const routes: Array<RouteRecordRaw> = [
    {
        path: '',
        name: 'login',
        component: Login
    },
    {
        path: '/login',
        name: 'login',
        component: Login
    },
    {
        path: '/games',
        name: 'Games',
        component: Games
    },
    {
        path: '/work',
        name: 'Work',
        component: Work
    },
    {
        path: '/library',
        name: 'Library',
        component: Library
    },
    {
        path: '/registration',
        name: 'Registration',
        component: Registration
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
