<template>
  <div class="container flex-grow-1 my-4">
    <div class="row justify-content-center">
        <div class="col-sm-6">
            <h2 class="text-center">Sign In</h2>
            <div>
    <form @submit.prevent="submitForm">
      <div class="form-group mb-3">
        <label for="email">Personal token:</label>
        <input type="text" class="form-control" id="email" v-model="personalToken" placeholder="Enter Personal token" required>
      </div>
      <div class="form-group mb-3">
        <label for="pwd">Private key:</label>
        <input type="password" class="form-control" id="pwd" v-model="privateKey" placeholder="Enter private key" required>
      </div>
      <div class="form-group form-check mb-3">
        <label class="form-check-label">
          <input class="form-check-input" type="checkbox" v-model="rememberMe"> Remember me
        </label>
      </div>
      <button type="submit" class="btn btn-primary btn-block">Sign In</button>
    </form>
    </div>
        </div>
    </div>
</div>
</template>

<script>
export default {
  data() {
    return {
      personalToken: '',
      privateKey: '',
      rememberMe: false
    }
  },
  methods: {
    submitForm() {
      const data = {
        personalToken: this.personalToken,
        privateKey: this.privateKey,
        rememberMe: this.rememberMe
      };

      fetch('http://localhost:7064/api/login/signin', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    // 'Access-Control-Allow-Origin': 'http://localhost:8080'
  },
  body: JSON.stringify(data)
})
  .then(response => {
    if (response.ok) {
      alert('Form submitted successfully!');
      
      const expirationDate = this.rememberMe ? new Date(Date.now() + 365 * 24 * 60 * 60 * 1000) : new Date(Date.now() + 24 * 60 * 60 * 1000);
      document.cookie = `user=${this.personalToken}; expires=${expirationDate.toUTCString()}`;

      this.personalToken = '';
      this.privateKey = '';
      this.rememberMe = false;

      window.location.href = '';
      // this.$router.push('/posts');
    } else {
      response.text().then(errorMessage => {
        alert(errorMessage);
      });
    }
  })
  .catch(error => {
    alert('An error occurred while submitting the form. ' + error);
    console.error(error);
  });

    }
  },
  mounted() {
    document.title = 'Gpt Blog - sing';
  }
}
</script>

<style scoped>
@import "https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css";
</style>
