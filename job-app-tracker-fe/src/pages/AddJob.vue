<template>
  <div class="container mt-4">
    <h2>Add Job</h2>
    <form @submit.prevent="submit">
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
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import type { JobApplication } from '@/types/JobApplication'
import { addJob } from '@/services/jobService'

const router = useRouter()

const job = ref<JobApplication>({
  company: '',
  title: '',
  stage: 'applied',
  appliedOn: new Date().toISOString().slice(0, 10),
  followUpDate: new Date().toISOString().slice(0, 10),
  notes: '',
})

async function submit() {
  await addJob(job.value)
  router.push('/')
}
</script>
