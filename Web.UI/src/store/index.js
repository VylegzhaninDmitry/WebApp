import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        showPreloader: true,
        accessToken: localStorage.getItem('accessToken'),
        expiresIn: localStorage.getItem('expiresIn'),
        refreshToken: localStorage.getItem('refreshToken'),
        user: localStorage.getItem('user')
    },
    mutations: {
        setShowPreloader(state, payload) {
            state.showPreloader = payload
        },

        setAccessToken(state, payload) {
            localStorage.setItem('accessToken', payload)
            state.accessToken = payload
        },

        setExpiresIn(state, payload) {
            localStorage.setItem('expiresIn', payload)
            state.expiresIn = payload
        },

        setRefreshToken(state, payload) {
            localStorage.setItem('refreshToken', payload)
            state.refreshToken = payload
        },
    },

    actions: {
        authorize(context, payload) {
            context.commit('setAccessToken', payload)
            //context.commit('setExpiresIn', payload.expires_in)
            //context.commit('setRefreshToken', payload.refresh_token)

            //const user = await ApiClient.user()

            //context.commit('setUser', user.data.data)
        },
    }
});

export default store