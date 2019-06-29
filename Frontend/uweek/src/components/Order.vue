<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Ordenes</v-toolbar-title>
        <v-divider class="mx-2" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field
          class="text-xs-center"
          v-model="search"
          append-icon="search"
          label="Búsqueda"
          single-line
          hide-details
        ></v-text-field>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px">
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                    
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="DishId" label="DishId"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="SuscriptionId" label="SuscriptionId"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Dentrega" label="Dentrega"></v-text-field>
                  </v-flex>

                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-data-table :headers="headers" :items="orders" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.dishId }}</td>
          <td>{{ props.item.suscriptionId }}</td>
          <td>{{ props.item.dentrega }}</td>

        </template>
        <template slot="no-data">
          <v-btn color="primary" @click="listar">Actualizar</v-btn>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      orders: [],
      dialog: false,
      headers: [
         { text: "Opciones", value: "opciones", sortable: false },
        { text: "DishId", value: "DishId", sortable: false },
        { text: "SuscriptionId", value: "SuscriptionId", sortable: false },
        { text: "Dentrega", value: "Dentrega", sortable: false },
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      
      DishId:'',
      SuscriptionId:'',
      Dentrega:''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nueva Orden" : "Actualizar Orden";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    //TODO
    this.listar();
  },
  methods: {
    listar() {
      //TODO
      let me = this;
      axios
        .get("api/order")
        .then(function(response){
            me.orders = response.data;
        })
        .catch(function(error){
            console.log(error);
        })
    },
    editItem(item) {
      //TODO
      this.DishId = item.DishId;
      this.SuscriptionId = item.SuscriptionId;
      this.Dentrega = item.Dentrega;
      
      this.editItem = 1;
      this.dialog = true;
    },

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.DishId = "";
      this.SuscriptionId = "";
      this.Dentrega = "";
    },
    guardar() {
     //TODO
        if(this.editItem > -1){
         let me = this;
         axios
            .put("api/order",{
                DishId: me.DishId,
                SuscriptionId: me.SuscriptionId,
                Dentrega: me.Dentrega
            })
            .then(function(response){
                me.close();
                me.listar();
                me.limpiar();
            })
            .catch(function(error){
                console.log(error)
            });
        }else{
            //codigo para guardar
            let me = this;
            axios
                .post("api/order",{
                    DishId: me.DishId,
                    SuscriptionId: me.SuscriptionId,
                    Dentrega: me.Dentrega
                })
                
                .then(function(response){
             me.close();
             me.listar();
             me.limpiar();
         })
                .then(function(response){
                    console.log(error);
                });
        }
    }
  }
};
</script>