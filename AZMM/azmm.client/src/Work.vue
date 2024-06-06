<template>
    <br />

    <h1 style="color:cornflowerblue">Work</h1>
    <hr />

    <div class="grid-container">
        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/Notepad++_Logo.png" class="card-img-top" alt="notepad++ logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">Notepad++</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/ditto.png" class="card-img-top" alt="notepad++ logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">Ditto</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/filezilla.png" class="card-img-top" alt="notepad++ logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">File-Zilla</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/office.png" class="card-img-top" alt="notepad++ logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">Office</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>


        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/visual-studio-code4470.jpg" class="card-img-top" alt="VS-Code logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">VS-Code</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>

        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/postman.png" class="card-img-top" alt="VS-Code logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">Postman</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/vs2022.jpg" class="card-img-top" alt="VS-Code logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">VS2022</h5>
                    <a href="#" class="btn btn-primary">Download</a>
                </div>
            </div>
        </div>

        <div class="container" style="width:200px;height:200px;">
            <div class="card">
                <img src="/src/assets/teams.jpg" class="card-img-top" alt="VS-Code logo" style="width:100px;height:100px;margin-left:36px;padding-top:5px">

                <div class="card-body">
                    <h5 class="card-title">Teams</h5>
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
