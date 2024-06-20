<style scoped>
</style>

<script>
    import { reactive } from "vue";
    import AppService from "@/services/AppService";

    export default {
        name: 'RegistrationView',
        setup() {
            const service = new AppService();

            const data = reactive({
                name: "",
                password: "",
                regResult: null
            });

            function registrated() {
                console.log("Registrated");
                service.addUser({ uid: 0, name: data.name, password: data.password, owenedApps: [] }).then(result => {
                    data.regResult = result ? "Registration succeeded" : "Registration failed"; // Update this line
                });
            }

            return {
                data,
                registrated
            };
        }
    };
</script>

<template>
    <h1 style="color:cornflowerblue">Registration</h1>
    <hr />
    <form name="login-form" @submit.prevent="registrated">
        <div class="mb-3">
            <label for="username">Username: </label>
            <input id="username" type="text" v-model="data.name" />
        </div>
        <div class="mb-3">
            <label for="password">Password: </label>
            <input id="password" type="password" v-model="data.password" />
        </div>
        <button class="btn btn-outline-dark" type="submit">
            Registrated
        </button>
        <div v-if="data.regResult !== null" :class="{'text-success': data.regResult === 'Login succeeded', 'text-danger': data.regResult === 'Login failed'}">
            {{ data.regResult }}
        </div>
    </form>
</template>
