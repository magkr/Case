import { createRouter, createWebHistory } from 'vue-router'
import Login from './components/Login.vue'
import CreateUserProfile from './components/CreateUserProfile.vue'
import UserProfile from './components/UserProfile.vue'
import UserProfileWrapper from './components/UserProfileWrapper.vue'

const routes = [
    {
        path: '/opret',
        name: 'create',
        component: CreateUserProfile
    },
    {
        path: '/',
        name: 'login',
        component: Login
    },
    {
        path: '/bruger',
        component: UserProfileWrapper,
        children: [
            {
                path: ':email',
                name: 'user',
                component: UserProfile,
            },
            {
                path: '',
                redirect: { name: 'login' },∏
            },
        ]
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
