<script setup lang="ts">

</script>

<template>
    <header>
        <div class="content">
            <hgroup>
                <h1>LOGO</h1>
                <i>slogan</i>
            </hgroup>
        </div>
        <div class="overlay"></div>
    </header>

      <main>
          <section class="site">
              <nav>
                  <a href="App.vue">Home</a>
                  <a href="">Games</a>
                  <a href="">Work</a>
                  <a href="">Library</a>
                  <a href="Login.vue">Login</a>

              </nav>
              <blockquote>
                  <img src="http://d.gr-assets.com/authors/1397426898p5/203714.jpg" align="left">“I invented nothing new. I simply assembled the discoveries of other men behind whom were centuries of work. Had I worked fifty or ten or even five years before, I would have failed. So it is with every new thing. Progress happens when all the factors that make for it are ready, and then it is inevitable. To teach that a comparatively few men are responsible for the greatest forward steps of mankind is the worst sort of nonsense.”


                  ― Henry Ford
              </blockquote>
          </section>
    </main>
</template>

<style scoped>
    html {
        font: 1em/1.5 "Lato", sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-rendering: optimizelegibility;
    }

    body {
        font-size: 1.3em;
    }

    header {
        height: 100%;
        position: relative;
        overflow: hidden;
        background: url('banner.jpg') center no-repeat;
        background-size: cover;
    }

    header .content {
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        z-index: 1;
    }

    header h1, header h2 {
        margin: 0;
    }

    header h2 {
        text-transform: uppercase;
        margin-top: -.5em;
    }

    header hgroup {
        -webkit-transform: translate(-50%, -50%);
        -moz-transform: translate(-50%, -50%);
        -ms-transform: translate(-50%, -50%);
        -o-transform: translate(-50%, -50%);
        transform: translate(-50%, -50%);
        display: inline-block;
        text-align: center;
        position: absolute;
        top: 50%;
        left: 50%;
        color: #fff;
        border: 5px solid #fff;
        padding: .5em 3em;
        background-color: rgba(0, 0, 0, 0.2);
        z-index: 2;
    }

    header .overlay {
        position: absolute;
        top: 0;
        right: 0;
        left: 0;
        bottom: 0;
        background: #333 center no-repeat;
        background-size: cover;
        z-index: 0;
        opacity: 0;
        -webkit-filter: blur(4px);
    }

    img {
        margin-right: 20px
    }

    .site {
        padding: 20em 0;
        text-align: center;
        background-color: #efefef;
        font-size: .8em;
        color: #444;
        position: relative
    }

    .site a {
        color: #666;
        text-decoration: none;
    }

        .site a:hover {
            color: #222;
        }

    .site nav {
        position: absolute;
        top: 0;
        left: 0;
        background: #222;
        width: 100%
    }

    .site nav a {
        padding: 10px 30px;
        font-size: 1.3em;
        display: inline-block
    }

    .site nav a:hover {
        background: #333;
        color: #fff
    }
</style>
