<template>
    <div>
        <component :is="viewComponent"></component>
    </div>
</template>

<script>
    import LoginPage from '@/components/Login/LoginPage'
    import UsersList from '@/components/Admin/UsersList'
    import MainPage from '@/components/Main/MainPage'

    const routes = {
        '/login': LoginPage,
        '/users': UsersList,
        '/main': MainPage
    }
    export default {
        name: 'App',
        components: {
            LoginPage,
            UsersList
        },

        data: () => ({
            currentRoute: window.location.pathname
        }),

        computed: {
            viewComponent() {
                return routes[this.currentRoute] || LoginPage
            }
        },

    }
</script>

<style>
</style>
