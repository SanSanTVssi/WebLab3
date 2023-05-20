<template>
  <title>GptBlog</title>
  <div id="app">
    <HeaderComponent />
    <router-view></router-view>
    <FooterComponent />
  </div>
</template>

<script>

import HeaderComponent from './components/HeaderComponent.vue'
import FooterComponent from './components/FooterComponent.vue'

export default {
  name: 'App',
  components: {
    HeaderComponent,
    FooterComponent
  }
}
</script>

<style>
@import "https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css";
html {
  font-size: 14px;
}

@media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

html {
  position: relative;
  min-height: 100%;
}

body {
  margin-bottom: 60px;
  background-color: magenta;
}

.fixed-height-container img {
  height: 350px;
  object-fit: cover;
  object-position: center;
}

.router-link-exact-active {
  color: red; 
  font-weight: bold;
}
</style>
