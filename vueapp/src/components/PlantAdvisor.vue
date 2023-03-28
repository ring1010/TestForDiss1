<template>

    <div class="plant-advisor">
        <h2 class="title">Plant Advisor</h2>
        <div class="square-container">
            <router-link target="_ blank" to="./Production" class="square square1">
                <span>Production</span>
            </router-link>

            <router-link to="/Plant" class="square square2">
                <span>Plant</span>
            </router-link>
            <router-link target="_ blank" to="/Country" class="square square3">
                <span>Country</span>
            </router-link>
            <router-link to="/area4" class="square square4">
                <span>Area 4</span>
            </router-link>
        </div>
        <div><router-view /></div>

    </div>
</template>

<script>
    export default {
        name: 'App'
    }
</script>

<style>
    .container {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        height: 100vh;
    }

    .title {
        font-size: 2rem;
        color: green;
    }

    .square-links {
        display: flex;
        justify-content: space-around;
        margin: 2rem;
    }

    .square-link {
        width: 150px;
        height: 150px;
        background-color: #ccc;
    }
    .square-container {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        align-items: center;
        width: 400px;
        height: 400px;
        margin: 20px auto;
    }



</style>
