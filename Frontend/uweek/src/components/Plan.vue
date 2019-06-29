<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Plan</v-toolbar-title>
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
                    <v-text-field v-model="name" label="Nombres"></v-text-field>
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
      <v-data-table :headers="headers" :items="plans" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.name }}</td>
        </template>
        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
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
      plans: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombres", value: "name", sortable: false }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      id: '',
      name:''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Plan" : "Actualizar Plan";
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
      let me=this;
      axios
      .get("api/plans")
      .then(function(response){me.plans=response.data;})
      .catch(function(error){console.log(error);});
    },
    editItem(item) {
      //TODO
      this.id=item.id;
      this.name=item.name;

      this.editItem=1;
      this.dialog=true;
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.name = "";
    },
    guardar() {
     //TODO
     if(this.editItem> -1){
         let me =this;
         axios
         .put("api/plans",{
             id:me.id,
             name:me.name
         })
         .then(function(response){
             me.close();
             me.listar();
             me.limpiar();
         })
         .catch(function(error){
             console.log(error);
         });
     }
     else {
         let me=this;
         axios
         .post("api/plans",{
             name:me.name
         })
         .then(function(response){
             me.close();
             me.listar();
             me.limpiar();
         })
         .catch(function(error){
             console.log(error);
         });

     }
    }
  }
};
</script>
