<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>User</v-toolbar-title>
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
                    <v-text-field v-model="Name" label="Name"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Password" label="Password"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Address" label="Address"></v-text-field>
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
      <v-data-table :headers="headers" :items="clientes" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.name }}</td>
          <td>{{ props.item.password }}</td>
          <td>{{ props.item.address }}</td>>
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
      clientes: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Name", value: "Name", sortable: false },
        { text: "Password", value: "Password", sortable: false },
        { text: "Address", value: "Address" }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      id: '',
      Name:'',
      Password:'',
      Address:''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Usuario" : "Actualizar Usuario";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();

  },
  methods: {
    listar() {
      let me=this;
      axios
      .get("api/users")
      .then(function(response){me.clientes=response.data;})
      .catch(function(error){console.log(error);});
    },
    editItem(item) {
      this.id = item.id;
      this.Name=item.Name;
      this.Password=item.Password;
      this.Address=item.Address;

      this.editItem=1;
      this.dialog=true;
    },
    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.Name = "";
      this.Password = "";
      this.Address = "";
    },
    guardar() {
     if(this.editItem> -1){
         let me =this;
         axios
         .put("api/users",{
             id:me.id,
             Name:me.Name,
             Password:me.Password,
             Address:me.Address
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
         .post("api/users",{
             Name:me.Name,
             Password:me.Password,
             Address:me.Address
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
