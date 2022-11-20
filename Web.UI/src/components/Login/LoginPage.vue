<template>
    <div id="app">
        <div class="login-page">
            <transition name="fade">
                <div v-if="!registerActive" class="wallpaper-login"></div>
            </transition>
            <div class="wallpaper-register"></div>

            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-8 mx-auto">
                        <div v-if="!registerActive" class="card login">
                            <h1>Войти</h1>
                            <p style="color:red">{{errorMessage}}</p>
                            <div class="form-group">
                                <input v-model="emailLogin" type="email" class="form-control" placeholder="Email" required>
                                <input v-model="passwordLogin" type="password" class="form-control" placeholder="Пароль" required>
                                <input type="submit" class="btn btn-primary" @click="login" value="Войти">
                                <p>
                                    Нет аккаунта? <a href="#" @click="registerActive = !registerActive, emptyFields = false">Зарегистрироваться</a>
                                </p>
                            </div>
                        </div>

                        <div v-else class="card register">
                            <h1>Зарегистрироваться</h1>
                            <p style="color:red">{{errorMessage}}</p>
                            <form class="form-group">
                                <input v-model="emailReg" type="email" class="form-control" placeholder="Email" required>
                                <input v-model="passwordReg" type="password" class="form-control" placeholder="Пароль" required>
                                <input v-model="confirmReg" type="password" class="form-control" placeholder="Подтвердите пароль" required>
                                <input type="submit" class="btn btn-primary" @click="register" value="Зарегистрироваться">
                                <p>
                                    Уже есть аккаунт? <a href="#" @click="registerActive = !registerActive, emptyFields = false">Войти</a>
                                </p>
                            </form>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>

<script>
    import { ApiClient } from '@/clients/api/api-client.js'
    export default {
        name: 'LoginPage',
        data() {
            return {
                registerActive: false,
                emailLogin: "",
                passwordLogin: "",
                emailReg: "",
                passwordReg: "",
                confirmReg: "",
                emptyFields: false,
                errorMessage: ""
            }
        },

        watch: {
            emailLogin() {
                this.clearErrorMessage()
            },
            passwordLogin() {
                this.clearErrorMessage()
            },
            registerActive() {
                this.clearErrorMessage()
                this.clearnFields()
            }
        },

        methods: {
            clearErrorMessage() {
                this.errorMessage = ''
            },

            clearnFields() {
                this.emailLogin = ''
                this.passwordLogin = ''
                this.passwordReg = ''
                this.emailReg = ''
            },

            login() {
                if (this.emailLogin === "" || this.passwordLogin === "") {
                    this.emptyFields = true;
                } else {
                    ApiClient.login({ email: this.emailLogin, password: this.passwordLogin })
                        .then((response) => {
                            if (response.status === 200) {
                                this.$store.dispatch('authorize', response.data)
                            }

                            if (response.status === 404) {
                                this.errorMessage = "Неверный логин или пароль."
                            }

                            if (response.status === 401) {
                                this.errorMessage = 'Вы ещё не авторизованы администартором'
                            }
                        })
                }
            },

            register() {
                const passwordsNotMatch = this.passwordReg !== this.confirmReg;
                if (this.emailReg === "" || this.passwordReg === "" || this.confirmReg === "" || passwordsNotMatch) {
                    this.errorMessage = passwordsNotMatch ? "Пароли не совпадают" : 'Заполните все поля'
                    this.emptyFields = true;
                } else {
                    ApiClient.register({ email: this.emailReg, password: this.passwordReg })
                        .then((response) => {
                            if (response.status === 200) {
                                this.registerActive = false
                            }
                        })
                }
            }
        }
    }
</script>