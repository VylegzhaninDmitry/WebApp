<template>
    <tr>
        <td>{{ user.id }}</td>
        <td>{{ user.name }}</td>
        <td>{{ user.email }}</td>
        <td>
            <b-button v-if="user.isVerified === false" class="action-button" style="width:100%" variant="success" size="sm" @click="verifyUser">
                Подтвердить
            </b-button>
            <b-icon v-else :icon="verifiedIcon"></b-icon>
        </td>
        <td>
            <b-button class="action-button" style="width:100%" size="sm"
                      :variant="user.isBlocked ? 'success' : 'danger'"
                      @click="blockUser">
                {{user.blocked ? 'Разблокировать' : 'Заблокировать'}}
            </b-button>
        </td>
    </tr>
</template>
<script>
    import { ApiClient } from "@/clients/api/api-client"
    export default {
        name: 'UserItem',
        props: {
            user: {
                type: Object,
                required: true
            }
        },

        computed: {
            verifiedIcon() {
                return this.user.isVerified ? 'patch-check' : 'exclamation-triangle'
            },
            blockedIcon() {
                return this.user.isBlocked ? 'lock' : 'unlock'
            }
        },

        methods: {
            blockUser() {
                ApiClient.blockUser(this.user.id).then((response) => {
                    if (response.status === 200) {
                        this.$emit('update', { ...this.user, isBlocked: !this.user.isBlocked })
                    }
                })
            },
            verifyUser() {
                ApiClient.verifyUser(this.user.id).then((response) => {
                    if (response.status === 200) {
                        this.$emit('update', { ...this.user, isVerified: true })
                    }
                })
            }
        }
    }
</script>
<style>
    body {
        font-family: Helvetica Neue, Arial, sans-serif;
        font-size: 14px;
        color: #444;
    }

    table {
        border: 2px solid #42b983;
        border-radius: 3px;
        background-color: #fff;
        text-align: center;
    }

    th {
        background-color: #42b983;
        color: rgba(255, 255, 255, 0.66);
        cursor: pointer;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
    }

    td {
        background-color: #f9f9f9;
        text-align: center;
    }

    th, td {
        min-width: 120px;
        padding: 10px 20px;
    }

    .action-button {
        margin: 2px
    }
</style>