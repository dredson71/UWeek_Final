<template>
  <v-app id="app">
    <v-navigation-drawer
      fixed
      :clipped="$vuetify.breakpoint.mdAndUp"
      app
      v-model="drawer"
    >
      <v-list dense>
        <template>
          <v-list-tile :to="{name:'home'}">
            <v-list-tile-action>
              <v-icon>home</v-icon>
            </v-list-tile-action>
            <v-list-tile-title>
              Inicio
            </v-list-tile-title>
          </v-list-tile>
        </template>

        <template>
          <v-list-group>
            <v-list-tile slot="activator">
              <v-list-tile-content>
                <v-list-tile-title>
                  Mantenimiento
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'plans'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Planes
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

             <v-list-tile :to="{ name: 'platos'}">
              <v-list-tile-action>
                <v-icon>restaurant_menu</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Platos
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

 <v-list-tile :to="{ name: 'ingredientes'}">
              <v-list-tile-action>
                <v-icon>local_grocery_store</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Ingredientes
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'clientes'}">
              <v-list-tile-action>
                <v-icon>directions_walk</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Clientes
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>


            <v-list-tile :to="{ name: 'allergies'}">
              <v-list-tile-action>
                <v-icon>local_hospital</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Alergias del cliente
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>


            <v-list-tile :to="{ name: 'subscriptions'}">
              <v-list-tile-action>
                <v-icon>local_atm</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Subscripciones
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>

            <v-list-tile :to="{ name: 'orders'}">
              <v-list-tile-action>
                <v-icon>table_chart</v-icon>
              </v-list-tile-action>
              <v-list-tile-content>
                <v-list-tile-title>
                  Ordenes
                </v-list-tile-title>
              </v-list-tile-content>
            </v-list-tile>


          </v-list-group>
        </template>
        
       
        
      </v-list>
    </v-navigation-drawer>
    <v-toolbar
      color="#000000"
      dark
      app
      :clipped-left="$vuetify.breakpoint.mdAndUp"
      fixed
    >
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <span class="hidden-sm-and-down">uWeek</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>apps</v-icon>
      </v-btn>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>
    <v-footer dark height="auto">
      <v-layout justify-center>
        <v-flex text-xs-center>
          <v-card flat tile color="#F2D98D" class="white--text">
            <v-card-text class="white--text pt-0" style="margin-left:20px">
             @UWEEK Derechos Reservados 2019 
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>

  </v-app>
</template>
<script>

export default {
  name: 'App',
  data () {
    return {
       drawer: true,
    }
  }
}
</script>
