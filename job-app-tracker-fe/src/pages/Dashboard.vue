<template>
  <div class="container mt-4">
    <h2>Job Applications</h2>
    <router-link to="/add" class="btn btn-primary mb-3">Add New</router-link>

    <table class="table table-bordered">
      <thead>
        <tr>
          <th>Company</th>
          <th>Title</th>
          <th>Stage</th>
          <th>Applied</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="job in jobs" :key="job.id+job.title">
          <td>{{ job.company }}</td>
          <td>{{ job.title }}</td>
          <td>{{ job.stage }}</td>
          <td>{{ job.appliedOn }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { getAllJobs } from './../services/jobService'
import type { JobApplication } from './../types/JobApplication'

const jobs = ref<JobApplication[]>([])

onMounted(async () => {
  jobs.value = await getAllJobs()
})
</script>
