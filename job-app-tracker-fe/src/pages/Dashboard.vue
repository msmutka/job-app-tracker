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
          <td>{{ formatDate(job.appliedOn) }}</td>
            <td>
              <div class="btn-group" role="group">
                <button class="btn btn-success" @click="editJob(job)">Edit</button>
                <button class="btn btn-danger" @click="deleteJob(job.id)">Delete</button>
              </div>
          </td>
        </tr>
      </tbody>
    </table>
    <div v-if="loading" class="position-absolute top-0 start-0 w-100 h-100 d-flex justify-content-center align-items-center bg-white bg-opacity-75">
      <div class="spinner-border text-primary" role="status">
        <span class="visually-hidden">Loading...</span>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRouter } from 'vue-router'
import * as jobService from './../services/jobService'
import type { JobApplication } from './../types/JobApplication'

const router = useRouter()
const jobs = ref<JobApplication[]>([])

let loading: boolean = true;

function editJob(job: JobApplication) {
  router.push({ path: `/edit/${job.id}` }); //TODO
}

async function deleteJob(id: string | undefined) {
  if (id === undefined) {
    alert("This job application doesn't exists")
    return
  }
  if (confirm('Delete this job?')) {
    const success = await jobService.deleteJob(id);
    if (success) jobs.value = jobs.value.filter(j => j.id !== id);
  }
}

function formatDate(dateString: string) {
  const date = new Date(dateString);
  return new Intl.DateTimeFormat('en-GB', {
    day: '2-digit',
    month: '2-digit',
  }).format(date);
}

onMounted(async () => {
  try {
    loading = true;
    jobs.value = await jobService.getAllJobs();
  } catch (err) {
    alert(err);
    jobs.value = [];
  } finally {
    loading = false;
  }
})
</script>
