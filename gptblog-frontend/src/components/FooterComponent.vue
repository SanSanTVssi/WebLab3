<template>
    <footer class="footer fixed-bottom bg-light">
        <p class="m-0 text-center">Gpt Blog &copy; 40145</p>
    </footer>
</template>

<script>
export default {
  name: 'FooterComponent',
  computed: {
    isUserLoggedIn() {
      return document.cookie.includes('user');
    },
  }
};
</script>

<style>

</style>