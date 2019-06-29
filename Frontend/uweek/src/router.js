import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'

import Plans from './components/Plan.vue'
import Allergy from './components/Allergy.vue'
import Dish from './components/Dish.vue'
import Ingredient from './components/Ingredient.vue'
import Order from './components/Order.vue'
import Subscription from './components/Subscription.vue'
import User from './components/User.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/plans',
      name: 'plans',
      component: Plans
    },
    {
      path: '/platos',
      name: 'platos',
      component: Dish
    },
    {
      path: '/ingredientes',
      name: 'ingredientes',
      component: Ingredient
    },
    {
      path: '/clientes',
      name: 'clientes',
      component: User
    },
    {
      path: '/allergies',
      name: 'allergies',
      component: Allergy
    },
    {
      path: '/subscriptions',
      name: 'subscriptions',
      component: Subscription
    },
    {
      path: '/orders',
      name: 'orders',
      component: Order
    }
  ]
})
