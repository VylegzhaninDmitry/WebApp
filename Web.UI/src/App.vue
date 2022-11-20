<template>
    <div>
        <component :is="viewComponent"></component>
    </div>
</template>

<script>
    import LoginPage from '@/components/Login/LoginPage'
    import UsersList from '@/components/Admin/UsersList'

    const routes = {
        '/': LoginPage,
        '/users': UsersList
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
