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
                        <div v-if="!registerActive" class="card login" v-bind:class="{ error: emptyFields }">
                            <h1>Войти</h1>
                            <div class="form-group">
                                <input v-model="emailLogin" type="email" class="form-control" placeholder="Email" required>
                                <input v-model="passwordLogin" type="password" class="form-control" placeholder="Пароль" required>
                                <input type="submit" class="btn btn-primary" @click="doLogin">
                                <p>
                                    Нет аккаунта? <a href="#" @click="registerActive = !registerActive, emptyFields = false">Зарегистрироваться</a>
                                </p>
                                <p><a href="#">Забыли пароль?</a></p>
                            </div>
                        </div>

                        <div v-else class="card register" v-bind:class="{ error: emptyFields }">
                            <h1>Зарегистрироваться</h1>
                            <form class="form-group">
                                <input v-model="emailReg" type="email" class="form-control" placeholder="Email" required>
                                <input v-model="passwordReg" type="password" class="form-control" placeholder="Password" required>
                                <input v-model="confirmReg" type="password" class="form-control" placeholder="Confirm Password" required>
                                <input type="submit" class="btn btn-primary" @click="doRegister">
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
            doLogin() {
                if (this.emailLogin === "" || this.passwordLogin === "") {
                    this.emptyFields = true;
                } else {
                    alert("You are now logged in");
                }
            },

            doRegister() {
                if (this.emailReg === "" || this.passwordReg === "" || this.confirmReg === "") {
                    this.emptyFields = true;
                } else {
                    alert("You are now registered");
                }
            }
        }
    }
</script>