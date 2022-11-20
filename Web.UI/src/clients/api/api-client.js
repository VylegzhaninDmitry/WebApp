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

    static blockUser(id) {
        return this.post('api/Admin/BlockUser', { id } , {
            headers: this.getAuthHeaders()
        })
    }

    static verifyUser(id) {
        return this.post('api/Admin/VerifyUser', { id }, {
            headers: this.getAuthHeaders()
        })
    }

    static getAllUsers({ pageNumber, pageSize }) {
        return this.get(`api/Admin/GetAllUsers?PageNumber=${pageNumber}&PageSize=${pageSize}`, {
            headers: this.getAuthHeaders()
        })
    }

    static register(data) {
        return this.post('api/Login/Register', {
            ...data
        }, {
            headers: this.getAuthHeaders()
        })
    }

    static async get(url, config) {
        return this.axios()
            .get(url, config)
            .catch(async error => {
                let response = error.response
                console.log(error)

                return response
            })
    }

    static async post(url, data, config) {
        return this.axios()
            .post(url, data, config)
            .catch(async error => {
                let response = error.response

                return response
            })
    }
}