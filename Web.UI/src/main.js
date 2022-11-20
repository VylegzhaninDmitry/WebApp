import Vue from 'vue'
import App from './App.vue'

import { BootstrapVue, BootstrapVueIcons } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import './assets/styles/main.scss'
import './assets/styles/login.scss'
import store from '@/store/index'

Vue.use(BootstrapVue)
Vue.use(BootstrapVueIcons)

new Vue({
    el: '#app',
    render(h) { return h(App) },
    store
})
