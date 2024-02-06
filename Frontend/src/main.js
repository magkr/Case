import { createApp } from 'vue'
import App from './App.vue'
import router from './router.js'
import './output.css'
import { createPinia } from 'pinia'

export const pinia = createPinia()

createApp(App).use(router).use(pinia).mount('#app')
