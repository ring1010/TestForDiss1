import Vue from 'vue'
import App from './App.vue'
import router from './router.js'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"



new Vue({
    router, // Add the router instance to the Vue instance
    render: h => h(App)
}).$mount('#app')
const express = require('express');
const cors = require('cors');

const app = express();

// 👇️ configure CORS
app.use(cors());
router.get("/", (req, res) => {
    req.setHeader("Access-Control-Allow-Origin", "*")
    res.setHeader("Access-Control-Allow-Credentials", "true");
    res.setHeader("Access-Control-Max-Age", "1800");
    res.setHeader("Access-Control-Allow-Headers", "content-type");
    res.setHeader("Access-Control-Allow-Methods", "PUT, POST, GET, DELETE, PATCH, OPTIONS");
});

app.get('https://localhost:7171/api/plants', function (req, res, next) {
    req.json({ msg: 'Access-Control-Allow-Origin' });
});

const PORT = 7171;

app.listen(PORT, function () {
    console.log(`CORS-enabled web server listening on port ${PORT}`);
});


