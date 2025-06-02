import { createRouter, createWebHistory } from 'vue-router'
import Dashboard from '../pages/Dashboard.vue'
import JobForm from '../components/JobForm.vue'

export const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', component: Dashboard },
    { path: '/add', component: JobForm },
    { path: '/edit/:id', component: JobForm },
  ]
})
