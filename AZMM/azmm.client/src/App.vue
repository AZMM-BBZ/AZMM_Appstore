<script setup lang="ts">
    import { ref, computed } from 'vue';
    import Login from './Login.vue';
    import Registration from './Registration.vue';
    import Games from './Games.vue';
    import Library from './Library.vue';
    import Work from './Work.vue';
</script>

<template>

    <nav class="navbar navbar-expand-lg bg-body-tertiary">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">AZMM App-Store</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <router-link class="nav-link active" to="/home">Home</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link active" to="/games">Games</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link active" to="/work">Work</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link active" to="/library">Library</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link active" to="/login">Login</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link active" to="/registration">Registration</router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <main>
        <router-view></router-view>
    </main>
</template>
