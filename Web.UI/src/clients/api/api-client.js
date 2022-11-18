import axios from 'axios'

export class ApiClient {
    static axios() {
        return axios.create({
            baseUrl: process.env.VUE_APP_API_URL
        })
    }

    static getUrl(path, base = false) {
        const baseUrl = base ? process.env.VUE_APP_API_BASE_URL : process.env.VUE_APP_API_URL

        return `${baseUrl}/${path}`
    }

    static getAccessToken() {
        return store.state.accessToken
    }

    static getRefreshToken() {
        return store.state.refreshToken
    }

    static getBearerToken() {
        return `Bearer ${this.getAccessToken()}`
    }

    static getAuthHeaders() {
        return {
            Authorization: this.getBearerToken()
        }
    }
}