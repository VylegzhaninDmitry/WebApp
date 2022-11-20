<template>
    <table>
        <thead>
            <tr>
                <th>id</th>
                <th>Имя</th>
                <th>Email</th>
                <th>Подтверждён</th>
                <th>Блокировка</th>
            </tr>
        </thead>
        <tbody>
            <user-item v-for="user in users" :user="user" :key="user.id" @update="user = $event"/>
        </tbody>
    </table>
</template>
<script>
import UserItem from '@/components/Admin/UserItem'
import { ApiClient } from "../../clients/api/api-client"
export default {
        name: 'UsersList',

        components: {
            UserItem
        },

        data: () => ({
            users: [],
            pageNumber: 1,
            pageSize: 10,
            totalPages: 0,
        }),

        created() {
            ApiClient.getAllUsers({ pageNumber: this.pageNumber, pageSize: this.pageSize }).then((response) => {
                if (response.status === 200) {
                    this.users = response.data.data
                }
            })
        }
}
</script>