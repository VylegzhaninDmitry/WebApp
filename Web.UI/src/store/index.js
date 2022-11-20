import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        accessToken: localStorage.getItem('accessToken'),
        user: localStorage.getItem('user')
    },
    mutations: {
        setAccessToken(state, payload) {
            localStorage.setItem('accessToken', payload)
            state.accessToken = payload
        }
    },

    actions: {
        authorize(context, payload) {
            context.commit('setAccessToken', payload)
            //const user = await ApiClient.user()

            context.commit('setUser', user.data.data)
        },
    }
});

export default store