<template>
    <br />

    <h1 style="color:cornflowerblue">Games</h1>
    <hr />
    <div class="grid-container">
        <div class="container" style="width:200px;height:200px;" v-for="app in data.apps">
            <div class="card">
                <img :src="app.imageUrl" class="card-img-top" alt="notepad++ logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">{{app.name}}</h5>
                    <button class="btn btn-primary" @click="downloadApp(app.aid)">Download</button>
                </div>
            </div>
        </div>
    </div>

</template>

<script setup lang="ts">
    import AppService from "@/services/AppService";
    import { onMounted, reactive } from "vue";
    import { useRouter } from "vue-router";

    const service = new AppService();
    const router = useRouter();

    const data = reactive({
        apps: [],
    });

    onMounted(() => {
        service.getCurrentUser().then(x => {
            if (!x) {
                {
                    router.push("/login")
                }
            }
            else {
                service.getAppWithCategory(1).then((ownedApps: any) => {
                    console.log(ownedApps.data);
                    data.apps = ownedApps.data
                });
            }
        });
    });

    function downloadApp(appId: number) {
        service.downloadApp(appId).then(x => {
            console.log(x);
        });
    }
    
</script>

<style scoped>
    .grid-container {
        display: grid;
        grid-template-columns: auto auto auto auto;
        gap: 50px;
        background-color: #ffffff;
        padding: 50px;
    }

        .grid-container > div {
            background-color: rgba(255, 255, 255, 0.8);
            border: 0px solid black;
            text-align: center;
            font-size: 30px;
        }
</style>
