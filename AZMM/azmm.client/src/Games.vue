<template>
    <br />

    <h1 style="color:cornflowerblue">Games</h1>
    <hr />

    <div class="grid-container">
        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/minecraft.jpg" class="card-img-top" alt="notepad++ logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">Minecraft</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/falldies.png" class="card-img-top" alt="notepad++ logo" style="width: 100px; height: 100px; margin-left: 36px; padding-top: 5px">

                <div class="card-body">
                    <h5 class="card-title">Falldies</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>
            
        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/mr.tomato.png" class="card-img-top" alt="notepad++ logo" style="width: 100px; height: 100px; margin-left: 36px; padding-top: 5px">

                <div class="card-body">
                    <h5 class="card-title">Mr. Tomato</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/ms.lemon.png" class="card-img-top" alt="notepad++ logo" style="width: 100px; height: 100px; margin-left: 36px; padding-top: 5px">

                <div class="card-body">
                    <h5 class="card-title">Ms. Lemon</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>


        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/jigsaw.png" class="card-img-top" alt="VS-Code logo" style="width: 100px; height: 100px; margin-left: 36px; padding-top: 5px">

                <div class="card-body">
                    <h5 class="card-title">Jigsaw-Puzzle</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>

        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/manicdigger.png" class="card-img-top" alt="VS-Code logo" style="width: 100px; height: 100px; margin-left: 36px; padding-top: 5px">

                <div class="card-body">
                    <h5 class="card-title">ManicDigger</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/blaster.png" class="card-img-top" alt="VS-Code logo" style="width: 100px; height: 100px; margin-left: 36px; padding-top: 5px">

                <div class="card-body">
                    <h5 class="card-title">     Blaster</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/yoshi.png" class="card-img-top" alt="VS-Code logo" style="width: 100px; height: 100px; margin-left: 36px; padding-top: 5px">

                <div class="card-body">
                    <h5 class="card-title">Yoshi</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>
    </div>

</template>

<script setup lang="ts">

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
