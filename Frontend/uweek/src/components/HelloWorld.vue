<template>
  <v-container>
    <v-layout
      text-xs-center
      wrap
    >
    <v-flex xs12>
        <v-img style="margin-left:-780px;height:150px;weight:700px"
          :src="require('../assets/logo.png')"
          class="my-3"
          contain
         
        
        ></v-img>
      </v-flex>

   <v-flex mb-4>
        <h1 class="display-2 font-weight-bold mb-3" style=" text-align:left">
         TE GUSTARIA PREPARAR<br> EL ALMUERZO EN TIEMPO<br> RECORD? 
        </h1>
        <p style="font-weight:lighter;font-size:40px;text-align:left">Recibe ingredientes y recetas...<br> ¡Sé tu mismo el chef!</p>
        
        <v-flex xs12>
        <v-img style="margin-top:-450px;margin-left:610px;margin-right:0px"
          :src="require('../assets/spaguetti.jpg')"
          class="my-9"
          contain
          height="450"
        ></v-img>
      </v-flex>
      </v-flex>

      
   
      

      
    </v-layout>
  </v-container>
</template>

<script>
  export default {
    data: () => ({
      ecosystem: [
        {
          text: 'vuetify-loader',
          href: 'https://github.com/vuetifyjs/vuetify-loader'
        },
        {
          text: 'github',
          href: 'https://github.com/vuetifyjs/vuetify'
        },
        {
          text: 'awesome-vuetify',
          href: 'https://github.com/vuetifyjs/awesome-vuetify'
        }
      ],
      importantLinks: [
        {
          text: 'Documentation',
          href: 'https://vuetifyjs.com'
        },
        {
          text: 'Chat',
          href: 'https://community.vuetifyjs.com'
        },
        {
          text: 'Made with Vuetify',
          href: 'https://madewithvuetifyjs.com'
        },
        {
          text: 'Twitter',
          href: 'https://twitter.com/vuetifyjs'
        },
        {
          text: 'Articles',
          href: 'https://medium.com/vuetify'
        }
      ],
      whatsNext: [
        {
          text: 'Explore components',
          href: 'https://vuetifyjs.com/components/api-explorer'
        },
        {
          text: 'Select a layout',
          href: 'https://vuetifyjs.com/layout/pre-defined'
        },
        {
          text: 'Frequently Asked Questions',
          href: 'https://vuetifyjs.com/getting-started/frequently-asked-questions'
        }

      ]
    })
  }
</script>

<style>

</style>