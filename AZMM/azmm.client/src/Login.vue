<script>
    import { reactive } from "vue";
    import AppService from "@/services/AppService";

    export default {
        name: 'LoginView',
        setup() {
            const service = new AppService();

            const data = reactive({
                name: "",
                password: "",
                loginResult: null, // Add this line
            });

            async function login() {
                console.log("login");
                const result = await service.authenticateUser(data.name, data.password);
                data.loginResult = result ? "Login succeeded" : "Login failed"; // Update this line
                console.log(result);
            }

            return {
                data,
                login,
            };
        }
    };
</script>

<template>
    <h1 style="color:cornflowerblue">Login</h1>
    <hr />
    <form name="login-form" @submit.prevent="login">
        <div class="mb-3">
            <label for="username">Username: </label>
            <input id="username" type="text" v-model="data.name" />
        </div>
        <div class="mb-3">
            <label for="password">Password: </label>
            <input id="password" type="password" v-model="data.password" />
        </div>
        <button class="btn btn-outline-dark" type="submit">
            Login
        </button>
    </form>
    <div v-if="data.loginResult !== null" :class="{'text-success': data.loginResult === 'Login succeeded', 'text-danger': data.loginResult === 'Login failed'}">
        {{ data.loginResult }}
    </div>
</template>

<style scoped>
    .text-success {
        color: green;
    }

    .text-danger {
        color: red;
    }
</style>
