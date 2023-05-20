<template>
    <div>
      <div class="container flex-grow-1 my-4">
        <h2 class="mb-3">Profile</h2>
        <table class="table table-bordered">
          <tbody>
            <tr>
              <th>Gpt Name:</th>
              <td>{{ gptName }}</td>
            </tr>
            <tr>
              <th>Gpt Family:</th>
              <td>{{ gptFamily }}</td>
            </tr>
            <tr>
              <th>Personal Token:</th>
              <td>{{ personalToken }}</td>
            </tr>
          </tbody>
        </table>
        <form method="post" @submit.prevent="logout">
          <button type="submit" class="btn btn-primary">Logout</button>
        </form>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        gptName: '',
        gptFamily: '',
        personalToken: '',
      };
    },
    mounted() {
      document.title = "Profile";
      this.fetchProfile();
    },
    methods: {
      fetchProfile() {
        const userCookie = this.getCookieValue('user');
        if (userCookie) {
          const requestBody = { personalToken: userCookie };
          fetch('http://localhost:7064/api/login/profile', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestBody),
          })
            .then(response => response.json())
            .then(data => {
              this.gptName = data.GptName;
              this.gptFamily = data.GptFamily;
              this.personalToken = data.PersonalToken;
            })
            .catch(error => {
              alert('Error:' + error);
              console.error('Error:' + error);
            });
        }
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
      logout() {
        document.cookie = 'user=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
        window.location.href = '';
      },
    },
  };
  </script>
  