<template>
  <div class="container mt-4">
    <h2>Add Job</h2>
    <form @submit.prevent="submit" v-if="!loading">
      <div class="mb-3">
        <label class="form-label">Company</label>
        <input class="form-control" v-model="job.company" required />
      </div>

      <div class="mb-3">
        <label class="form-label">Title</label>
        <input class="form-control" v-model="job.title" required />
      </div>

      <div class="mb-3">
        <label class="form-label">Stage</label>
        <select class="form-select" v-model="job.stage">
          <option>applied</option>
          <option>interviewing</option>
          <option>offer</option>
          <option>rejected</option>
        </select>
      </div>

      <div class="mb-3">
        <label class="form-label">Applied Date</label>
        <input class="form-control" type="date" v-model="job.appliedOn" required />
      </div>

      <div class="mb-3">
        <label class="form-label">Notes</label>
        <textarea class="form-control" v-model="job.notes" />
      </div>

      <button class="btn btn-success">Submit</button>
      <router-link class="btn btn-secondary ms-2" to="/">Cancel</router-link>
    </form>
    <div v-if="loading" class="position-absolute top-0 start-0 w-100 h-100 d-flex justify-content-center align-items-center bg-white bg-opacity-75">
      <div class="spinner-border text-primary" role="status">
        <span class="visually-hidden">Loading...</span>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import type { JobApplication } from '../types/JobApplication'
import * as jobService from '../services/jobService'

const router = useRouter()
const route = useRoute();

const isEdit = ref(false);
let loading = ref(false);
const jobId = ref<string | undefined>();

const job = ref<JobApplication>({
  id: undefined,
  company: '',
  title: '',
  stage: 'applied',
  appliedOn: new Date().toISOString().slice(0, 10),
  followUpDate: new Date().toISOString().slice(0, 10),
  notes: '',
})

async function submit() {
  let success = false;

  if (isEdit.value && jobId.value !== null) {
    success = await jobService.updateJob({ ...job.value, id: jobId.value });
  } else {
    success = await jobService.addJob({ ...job.value, id: undefined});
  }

  if (success) router.push('/');
  else alert('Failed to save job');
}

onMounted(async () => {  
  if (route.params.id) {
    isEdit.value = true;
    loading.value = true;
    jobId.value = String(route.params.id);

    try {
      var res = await jobService.getJob(jobId.value)

      Object.assign(job.value, res)
    } catch (err) {
      alert(err)
    } finally {
      loading.value = false
    }
  }
});
</script>
