<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Subscripciones</v-toolbar-title>
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
                    <v-text-field v-model="UserId" label="UserId"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Qdays" label="qdays"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Qpeople" label="Qpeople"></v-text-field>
                  </v-flex>
                   <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Subcost" label="Subcost"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Dateinit" label="Dateinit"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Dateend" label="Dateend"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="Turndelivery" label="Turndelivery"></v-text-field>
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
      <v-data-table :headers="headers" :items="subscriptions" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.userId }}</td>
          <td>{{ props.item.qdays }}</td>
          <td>{{ props.item.qpeople }}</td>
          <td>{{ props.item.subcost }}</td>
          <td>{{ props.item.dateinit }}</td>
          <td>{{ props.item.dateend }}</td>
          <td>{{ props.item.turndelivery }}</td>

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
      subscriptions: [],
      dialog: false,
      headers: [
        
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Usuario", value: "UserId", sortable: false },
        { text: "CantDias", value: "qdays", sortable: false },
        { text: "CantPersonas", value: "Qpeople", sortable: false },
        { text: "Subcost", value: "Subcost", sortable: false },
        { text: "FechaInicial", value: "Dateinit", sortable: false },
        { text: "FechaFinal", value: "Dateend", sortable: false },
        { text: "TurnoDelivery", value: "Turndelivery", sortable: false }
      ],
      search: "",
      editedIndex: -1,

      //TODO:Model
      
      Id:'',
      UserId:'',
      Qdays:'',
      Qpeople:'',
       Subcost:'',
      Dateinit:'',
      Dateend:'',
      Turndelivery:''
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nueva Subscripción" : "Actualizar Subscripción";
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
        .get("api/suscription")
        .then(function(response){  me.subscriptions = response.data;
        })
        .catch(function(error){ console.log(error);
        })
    },
    editItem(item) {
      //TODO
      this.id = item.id;
      this.UserId = item.UserId;
      this.Qdays = item.Qdays;
      this.Qpeople = item.Qpeople;
      this.Subcost = item.Subcost;
      this.Dateinit = item.Dateinit;
      this.Dateend = item.Dateend;
      this.Turndelivery = item.Turndelivery;
      
      this.editItem = 1;
      this.dialog = true;
    },

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.UserId = "";
      this.Qdays ="";
      this.Qpeople = "";
      this.Subcost = "";
      this.Dateinit = "";
      this.Dateend ="";
      this.Turndelivery = "";
    },
    guardar() {
     //TODO
        if(this.editItem > -1){
         let me = this;
         axios
            .put("api/suscription",{
                id: me.id,
                UzserId: me.UserId,
                Qdays: me.Qdays,
                Qpeople: me.Qpeople,
                Subcost: me.Subcost,
                Dateinit: me.Dateinit,
                Dateend: me.Dateend,
                Turndelivery: me.Turndelivery
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
                .post("api/suscription",{
                    UserId: me.UserId,
                    Qdays: me.Qdays,
                    Qpeople: me.Qpeople,
                    Subcost: me.Subcost,
                    Dateinit: me.Dateinit,
                    Dateend: me.Dateend,
                    Turndelivery: me.Turndelivery
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