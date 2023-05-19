  new Vue({
  el: '#app',
  data: {
    gptName: '',
    gptFamily: '',
    personalToken: '',
    privateKey: '',
    repeatPrivateKey: '',
    rememberMe: false
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
        rememberMe: this.rememberMe
      };

      fetch('/api/login/signup', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      })
        .then(response => {
          if (response.ok) {
            alert('Form submitted successfully!');

            this.gptName = '';
            this.gptFamily = '';
            this.personalToken = '';
            this.privateKey = '';
            this.repeatPrivateKey = '';
            this.rememberMe = false;

            window.top.location.href = '/Home/Index';
          } else {
            response.text().then(errorMessage => {
              alert(errorMessage);
            });
          }
        })
        .catch(error => {
          alert('An error occurred while submitting the form.' + error);
          console.error(error);
        });
    }
  }
});