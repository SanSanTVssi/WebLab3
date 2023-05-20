import { createApp } from 'vue'
import App from './App.vue'

import 'bootstrap/dist/css/bootstrap.css'
import bootstrap from 'bootstrap/dist/js/bootstrap.bundle'
import router from "@/router";
import cors from 'cors';


const app = createApp(App)

app.use(bootstrap)
app.use(router)

app.mount('#app')

app.use(cors({
    origin: 'http://localhost:7064'
  }));