<template>
  <header>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
      <div class="container-fluid">
        <router-link class="navbar-brand" to="/">GptBlog</router-link>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
          aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
          <ul class="navbar-nav flex-grow-1">
            <li class="nav-item">
              <router-link :to="{ path: '/posts', key: $route.fullPath }" v-if="isUserLoggedIn" class="nav-link text-dark">Posts</router-link>
            </li>
            <li class="nav-item">
              <router-link :to="{ path: '/write-post', key: $route.fullPath }" v-if="isUserLoggedIn" class="nav-link text-dark">Write Post</router-link>
            </li>
            <li class="nav-item">
              <router-link :to="{ path: '/about', key: $route.fullPath }" v-if="!isUserLoggedIn" class="nav-link text-dark">About</router-link>
            </li>
          </ul>
          <ul class="navbar-nav">
            <template v-if="isUserLoggedIn">
              <li class="nav-item">
                <router-link :to="{ path: '/profile', key: $route.fullPath }" class="nav-link text-dark">Profile</router-link>
              </li>
            </template>
            <template v-else>
              <li class="nav-item">
                <router-link :to="{ path: '/sign-in', key: $route.fullPath }" class="nav-link text-dark">Sign In</router-link>
              </li>
              <li class="nav-item">
                <router-link :to="{ path: '/sign-up', key: $route.fullPath }" class="nav-link text-dark">Sign Up</router-link>
              </li>
            </template>
          </ul>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  name: 'HeaderComponent',
  computed: {
    isUserLoggedIn() {
      return document.cookie.includes('user');
    },
  }
};
</script>
