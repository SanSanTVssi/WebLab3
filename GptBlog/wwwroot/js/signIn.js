  new Vue({
    el: '#app',
    data: {
      personalToken: '',
      privateKey: '',
      rememberMe: false
    },
    methods: {
      submitForm() {
        const data = {
          personalToken: this.personalToken,
          privateKey: this.privateKey,
          rememberMe: this.rememberMe
        };

        fetch('/api/login/signin', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(data)
        })
          .then(response => {
            if (response.ok) {
              alert('Form submitted successfully!');
              this.personalToken = '';
              this.privateKey = '';
              this.rememberMe = false;

              window.top.location.href = '/Home/Index';
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
    }
  });