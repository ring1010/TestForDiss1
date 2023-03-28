<template>
    <div>
        <!-- Green menu bar with 4 elements -->
      

    
        <div class="heading">
            <h1>Plant</h1>
        </div>

    
        <div class="horizontal-stripe"></div>

        <!-- Buttons Edit and Add -->
        <div class="btngroup" >
            <button type="button" class="btn btn-link" >Add</button>
            <button type="button" class="btn btn-link">Edit</button>
        </div>

      
        <table class="table">
            <thead>
                <tr>
                    <th>Plat Code</th>
                    <th>Plat Name</th>
                    <th>Description</th>
                    <th>TimeZone</th>
                    <th>Country</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(plant, index) in plants" :key="index">
                    <td>{{ plant.Id }}</td>
                    <td>{{ plant.Name }}</td>
                    <td>{{ plant.Description }}</td>
                    <td>{{ plant.TimeZone }}</td>
                    <td>{{ plant.Country }}</td>
                </tr>
            </tbody>
        </table>

        <!-- Popup form for adding new plant -->
        <div v-if="showPopup" class="popup">
            <div class="popup-content">
                <h2>Add New Plant</h2>
                <form @submit.prevent="addPlant">
                    <div class="form-group">
                        <label for="code">Plant Code</label>
                        <input type="text" id="code" v-model="newPlant.code" required>
                    </div>
                    <div class="form-group">
                        <label for="description">Description</label>
                        <input type="text" id="description" v-model="newPlant.description" required>
                    </div>
                    <div class="form-group">
                        <label for="timezone">Timezone</label>
                        <input type="text" id="timezone" v-model="newPlant.timezone" required>
                    </div>
                    <div class="form-group">
                        <label for="carrey">Carrency</label>
                        <input type="text" id="carrey" v-model="newPlant.carrey" required>
                    </div>
                    <button type="submit" @click ="openPopup">Add</button>
                    <button type="button" @click="closePopup">Cancel</button>
                </form>
            </div>
        </div>
    </div>
</template>

<script src="https://unpkg.com/axios@1.1.2/dist/axios.min.js"></script>

<script lang="js">
    import Vue from 'vue';

    export default Vue.extend({
        name: "PlantManagement",
        data() {
            return {
                post: {},
                showPopup: false,
                plants: [
                    {
                        id: "001",
                        name: "fff",
                        countryId: 0,
                        description: "Plant 1",
                        timezone: 3,
                        country: "Carrey 1",
                        productions: null
                    },
                    {
                        id: "002",
                        name: "fff",
                        countryId: 0,
                        description: "Plant 2",
                        timezone: 3,
                        country: null,
                        productions: null
                    },
                    {
                        id: "003",
                        name: "fff",
                        countryId: 0,
                        description: "Plant 3",
                        timezone: 3,
                        country: "Carrey 3",
                        productions: null
                    },

                ],
                newPlant: {
                    id: "",
                    name: "",
                    countryId: 0,
                    description: "",
                    timezone: 3,
                    country: "",
                    productions: null
                },
                isAddPopupOpen: false,
            };
        },
        created() {
             //fetch the data when the view is created and the data is
             //already being observed
            this.fetchData();
        },
        mounted() {
           //// this.plants = [],
           // let pl = [];
           //     axios.get('https://localhost:7171/api/plants')
           //         .then(response => {
           //             this.plants.push(...response);
           //             pl.push(...response); 
           //             console.log( "Это ответ")
           //         })
           //         .catch((error) => {
           //             // Handle errors here
           //             console.log(error);
           //         });

          
        },
        watch: {
            // call again the method if the route changes
           // '$route': 'fetchData'
             '$route': 'fetchData1'
        },
        methods: {
        
            fetchData() {
                this.plants = null;
                this.loading = true;
                fetch('https://localhost:7171/api/Plants')
                    .then(r => r.json())
                    .then(json => {
                        this.plants = json;
                        this.loading = false;
                        return;
                    });
            },
            addPlant() {
                this.isAdd
                axios.post('/api/plants', formData)
                    .then(() => {
                        // Reset the form and close the modal
                        this.resetForm();
                        this.isAdd = false;
                        // Fetch the updated data from the server
                        this.fetchData();
                    })
                    .catch((error) => {
                        // Handle errors here
                        console.error(error);
                    })
            },

            openPopup() {
                this.showPopup = true;

            }
        },
    });
</script>


<style>
.menu-bar {
  display: flex;
  justify-content: space-between;
  width: 100%;
  background-color: #5cb85c;
  color: white;
  padding: 10px;
}
    nav {
        display: flex; /* Расположение элементов в ряд */
        justify-content: space-between; /* Выравнивание элементов по горизонтали */
        align-items: center; /* Выравнивание элементов по вертикали */
        padding: 10px; /* Отступы внутри меню */
    }

        /* Стиль для пунктов меню */
        nav a {
            text-decoration: none; /* Убираем подчеркивание */
            color: white; /* Цвет текста */
            font-size: 16px; /* Размер шрифта */
            margin-right: 20px; /* Отступ между пунктами меню */
        }

    .btngroup {
        text-align: left;
        
    }  
.menu a {
  color: white;
  text-decoration: none;
  margin: 0 10px;
}

.title {
  font-size: 24px;
  font-weight: bold;
  margin-top: 20px;
}

.form {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 20px;
}

.form input {
  width: 100%;
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  border: none;
  box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.3);
}

.form label {
  font-weight: bold;
  margin-bottom: 10px;
}

.form button {
  background-color: #5cb85c;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-top: 10px;
}

.table {
  margin-top: 20px;
  width: 100%;
  border-collapse: collapse;
}

.table th, .table td {
  padding: 10px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

.table th {
  background-color: #f2f2f2;
  font-weight: bold;
}

.table tr:hover {
  background-color: #f5f5f5;
}

.modal {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 9999;
}

.modal-content {
  background-color: white;
  padding: 20px;
  border-radius: 5px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.5);
}

.modal label {
  font-weight: bold;
  margin-bottom: 10px;
}

.modal input {
  width: 100%;
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  border: none;
  box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.3);
}

.modal button {
  background-color: #5cb85c;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-top: 10px;
}
    .container {
        display: flex;
        flex-direction: column;
        align-items: center;
        margin-top: 50px;
    }

</style>
