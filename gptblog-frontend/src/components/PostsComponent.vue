<template>
    <div class="container flex-grow-1 my-4">
      <div class="row">
        <div v-for="post in posts" :key="post.id" class="col-md-6">
          <div class="card mb-4">
            <div class="fixed-height-container">
              <img class="card-img-top" :src="post.imageLink" alt="Post image">
            </div>
            <div class="card-body">
              <h2 class="card-title">{{ post.title }}</h2>
              <p class="card-text">{{ post.description }}</p>
              <form @submit.prevent="readPost(post.id)">
                <button type="submit" class="btn btn-primary">Read more &rarr;</button>
              </form>
            </div>
            <div class="card-footer text-muted">
              Posted by {{ post.author }} <a href="#"></a> {{ post.creationTime }}
            </div>
            <template v-if="post.author === currentUser">
              <form @submit.prevent="removePost(post.id)">
                <input type="hidden" name="postId" :value="post.id" />
                <button type="submit" class="btn btn-primary">Remove</button>
              </form>
            </template>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        posts: [],
        currentUser: '',
      };
    },
    mounted() {
      this.currentUser = this.getCookieValue('user');
      this.fetchPosts();
    },
    methods: {
      fetchPosts() {
        fetch('http://localhost:7064/api/posts/allposts')
          .then(response => response.json())
          .then(data => {
            this.posts = data;
          })
          .catch(error => {
            console.error('Error:', error);
          });
      },
      readPost(postId) {
        console.log(postId);
      },
      removePost(postId) {
    fetch('http://localhost:7064/api/posts/removepost', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ postId: postId })
    })
      .then(response => response.json())
      .then(data => {
        alert('Post removed successfully');
        console.log('Post removed successfully' + data);
        window.location.reload();
      })
      .catch(error => {
        alert('Error removing post: ' + error);
        console.error('Error removing post: ' + error);
      });
  },
      getCookieValue(name) {
        const cookies = document.cookie.split(';');
        for (let i = 0; i < cookies.length; i++) {
          const cookie = cookies[i].trim();
          if (cookie.startsWith(`${name}=`)) {
            return cookie.substring(name.length + 1);
          }
        }
        return '';
      },
    },
  };
  </script>
  