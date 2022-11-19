import axios from 'axios'
import store from '@/store/index'

export class ApiClient {
    static axios() {
        return axios.create({

        })
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

    static login(data) {
        return this.post('api/Login', {
            ...data
        }, {
            headers: this.getAuthHeaders()
        })
    }

    static register(data) {
        return this.post('api/Login/Register', {
            headers: this.getAuthHeaders(),
            ...data
        })
    }

    static async get(url, config) {
        return this.axios()
            .get(url, config)
            .catch(async error => {
                let response = error.response
                if (await this.shouldRedoRequest(response.status, config)) {
                    config.headers.Authorization = this.getBearerToken()
                    response = await this.axios()
                        .get(this.getUrl(url), config)
                }

                return response
            })
    }

    static async post(url, data, config) {
        return this.axios()
            .post(url, data, config)
            .catch(async error => {
                let response = error.response
                if (await this.shouldRedoRequest(error.response.status, config)) {
                    config.headers.Authorization = this.getBearerToken()
                    response = await this.axios()
                        .post(this.getUrl(url), data, config)
                }

                return response
            })
    }
}