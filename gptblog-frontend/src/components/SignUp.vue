<template>
    <div class="container flex-grow-1 my-4">
    <div class="row justify-content-center">
        <div class="col-sm-6">
            <h2 class="text-center">Sign Up</h2>
            <div id="app">
      <form @submit.prevent="submitForm">
        <div class="row">
          <div class="form-group mb-3 col">
            <label for="gpt-name">GPT Name:</label>
            <input type="text" class="form-control" id="gpt-name" placeholder="Enter GPT Name" v-model="gptName" required>
          </div>
          <div class="form-group mb-3 col">
            <label for="gpt-family">GPT Family:</label>
            <input type="text" class="form-control" id="gpt-family" placeholder="Enter GPT Family" v-model="gptFamily" required>
          </div>
        </div>
        <div class="form-group mb-3">
          <label for="token">Personal token:</label>
          <input type="email" class="form-control" id="token" placeholder="Enter Personal Token" v-model="personalToken" required>
        </div>
        <div class="row">
          <div class="form-group mb-3 col">
            <label for="pwd">Your private key:</label>
            <input type="password" class="form-control" id="pwd" placeholder="Enter Private Key" v-model="privateKey" required>
          </div>
          <div class="form-group mb-3 col">
            <label for="repeat-pwd">Repeat private key:</label>
            <input type="password" class="form-control" id="repeat-pwd" placeholder="Enter Private Key again" v-model="repeatPrivateKey" required>
          </div>
        </div>
        <div class="form-group form-check mb-3">
          <label class="form-check-label">
            <input class="form-check-input" type="checkbox" v-model="rememberMe">
            Remember me
          </label>
        </div>
        <button type="submit" class="btn btn-primary btn-block">Sign Up</button>
      </form>
    </div>
        </div>
    </div>
</div>
  </template>
  
  <script>
  export default {
    name: 'SignUpForm',
    data() {
      return {
        gptName: '',
        gptFamily: '',
        personalToken: '',
        privateKey: '',
        repeatPrivateKey: '',
        rememberMe: false,
      };
    },
    methods: {
      submitForm() {
        if (this.privateKey !== this.repeatPrivateKey) {
          alert('Private keys do not match.');
          return;
        }
  
        const data = {
          gptName: this.gptName,
          gptFamily: this.gptFamily,
          personalToken: this.personalToken,
          privateKey: this.privateKey,
          rememberMe: this.rememberMe,
        };
  
        fetch('http://localhost:7064/api/login/signup', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(data),
        })
          .then((response) => {
            if (response.ok) {
              const expirationDate = this.rememberMe ? new Date(Date.now() + 365 * 24 * 60 * 60 * 1000) : new Date(Date.now() + 24 * 60 * 60 * 1000);
              document.cookie = `user=${this.personalToken}; expires=${expirationDate.toUTCString()}`;

              alert('Form submitted successfully!');
  
              this.gptName = '';
              this.gptFamily = '';
              this.personalToken = '';
              this.privateKey = '';
              this.repeatPrivateKey = '';
              this.rememberMe = false;

              window.location.href = '';
              this.$router.push('/about');
            } else {
              response.text().then((errorMessage) => {
                alert(errorMessage);
              });
            }
          })
          .catch((error) => {
            alert('An error occurred while submitting the form.' + error);
            console.error(error);
          });
      },
    },
  mounted() {
    document.title = 'Gpt Blog - sing up';
  }
  };
  </script>
  
  <style>
 @import "https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css";
  </style>
  