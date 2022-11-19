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
                        <div v-if="!registerActive" class="card login" :class="{ error: emptyFields }">
                            <h1>Войти</h1>
                            <div class="form-group">
                                <input v-model="emailLogin" type="email" class="form-control" placeholder="Email" required>
                                <input v-model="passwordLogin" type="password" class="form-control" placeholder="Пароль" required>
                                <input type="submit" class="btn btn-primary" @click="login">
                                <p>
                                    Нет аккаунта? <a href="#" @click="registerActive = !registerActive, emptyFields = false">Зарегистрироваться</a>
                                </p>
                                <p><a href="#">Забыли пароль?</a></p>
                            </div>
                        </div>

                        <div v-else class="card register" :class="{ error: emptyFields }">
                            <h1>Зарегистрироваться</h1>
                            <form class="form-group">
                                <input v-model="emailReg" type="email" class="form-control" placeholder="Email" required>
                                <input v-model="passwordReg" type="password" class="form-control" placeholder="Пароль" required>
                                <input v-model="confirmReg" type="password" class="form-control" placeholder="Подтвердите пароль" required>
                                <input class="btn btn-primary" @click="register">
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
                emptyFields: false
            }
        },

        methods: {
            login() {
                if (this.emailLogin === "" || this.passwordLogin === "") {
                    this.emptyFields = true;
                } else {
                    ApiClient.login({ userName: this.emailLogin, password: this.passwordLogin })
                        .then((response) => {
                            if (response.status === 200) {
                                this.$store.dispatch('authorize', response.data)
                            }
                        })
                    //alert("You are now logged in");
                }
            },

            register() {
                if (this.emailReg === "" || this.passwordReg === "" || this.confirmReg === "" || (this.passwordReg !== this.confirmReg)) {
                    this.emptyFields = true;
                } else {
                    ApiClient.register({ userName: this.emailLogin, password: this.passwordLogin })
                    //alert("You are now registered");
                }
            }
        }
    }
</script>