<template>
    <div>
        <!-- Green menu bar with 4 elements -->
        <div class="menu-bar">
            <nav class="navbar navbar-light" style="background-color: #5cb85c;">
                <router-link target="_ blank" to="./PlantAdvisor" class="square square1">
                    <span>PlantAdvisor</span>
                </router-link>
                <router-link target="_ blank" to="./Production" class="square square1">
                    <span>Production</span>
                </router-link>
                <router-link to="/Plant" class="square square2">
                    <span>Plant</span>
                </router-link>
                <router-link target="_ blank" to="/Country" class="square square3">
                    <span>Country</span>
                </router-link>

            </nav>

        </div>

        <!--<div class="plant-advisor">
        <h2 class="title">Plant Advisor</h2>
        <div class="square-container">


                           <router-view />
            <router-link to="/area4" class="square square4">
                <span>Area 4</span>
            </router-link>
        </div>-->
        <router-view />

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
</style>
