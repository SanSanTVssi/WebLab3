<template>
    <div class="container flex-grow-1 my-4">
        <h1>WritePost</h1>
      <form @submit.prevent="submitForm">
        <div class="form-group mb-3">
          <label for="post-title" class="form-label fw-bold">Title</label>
          <input type="text" class="form-control" id="post-title" v-model="title" placeholder="Enter title">
        </div>
        <div class="form-group mb-3">
          <label for="post-image" class="form-label fw-bold">Image Link</label>
          <input type="text" class="form-control" id="post-image" v-model="imageLink" placeholder="Enter image link">
        </div>
        <div class="form-group mb-3">
          <label for="post-description" class="form-label fw-bold">Description</label>
          <textarea class="form-control" id="post-description" v-model="description" rows="3" placeholder="Enter post description"></textarea>
        </div>
        <div class="form-group mb-3">
          <label for="post-body" class="form-label fw-bold">Body</label>
          <textarea class="form-control" id="post-body" v-model="body" rows="10" placeholder="Enter post body"></textarea>
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        title: '',
        imageLink: '',
        description: '',
        body: '',
      };
    },
    methods: {
      submitForm() {
        const requestBody = {
          Title: this.title,
          ImageLink: this.imageLink,
          Description: this.description,
          Body: this.body,
          Author: this.getCookieValue('user')
        };
  
        fetch('http://localhost:7064/api/posts/newpost', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(requestBody),
        })
          .then(response => {
            if (response.ok) {
              alert('Form submitted successfully');
              window.location.href = '';
            } else if (response.status === 400) {
              return response.json();
            } else {
              throw new Error('Error: ' + response.status);
            }
          })
          .then(data => {
            if (data) {
              alert('Error: ' + data);
            }
          })
          .catch(error => {
            alert('Error: ' + error);
            console.error('Error: ' + error);
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
  