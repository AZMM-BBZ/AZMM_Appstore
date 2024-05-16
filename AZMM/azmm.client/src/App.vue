<script setup lang="ts">
    import { ref, computed } from 'vue'
    import Login from './Login.vue'
    import Registration from './Registration.vue'
    import Games from './Games.vue'
    import Library from './Library.vue'
    import Work from './Work.vue'

    const routes = {
        '/games': Games,
        '/work': Work,
        '/library': Library,
        '/login ': Login,
        '/registration': Registration
    }

    const currentPath = ref(window.location.hash)

    window.addEventListener('hashchange', () => {
        currentPath.value = window.location.hash
    })

    const currentView = computed(() => {
        return routes[currentPath.value.slice(1) || '/']
    })

</script>

<template>
    <header>
        <h1>AZMM App-Store</h1>
    </header>

    <main>
        <div>
            <a href="#/">Home</a> |
            <a href="/games">Games</a> |
            <a href="/work">Work</a> |
            <a href="/library">Library</a> |
            <a href="/login">Login</a> |
            <a href="/registration">Registration</a> |
            <component :is="currentView" />
        </div>
        <br />
    </main>
</template>

