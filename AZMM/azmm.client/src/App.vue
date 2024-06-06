<script setup lang="ts">
    import { ref, computed } from 'vue';
    import Login from './Login.vue';
    import Registration from './Registration.vue';
    import Games from './Games.vue';
    import Library from './Library.vue';
    import Work from './Work.vue';
</script>

<template>
    <header>
        <h1>AZMM App-Store</h1>
    </header>

    <nav>
        <router-link to="/">Home</router-link>
        <router-link to="/games">Games</router-link>
        <router-link to="/library">Library</router-link>
        <router-link to="/work">Work</router-link>
        <router-link to="/login">Login</router-link>
        <router-link to="/registration">Registration</router-link>
    </nav>

    <main>
        <router-view></router-view>
    </main>

    <footer>
        <p>© AZMM-Appstore</p>
    </footer>

</template>
