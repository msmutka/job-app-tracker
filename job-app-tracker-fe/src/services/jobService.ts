import type { JobApplication } from './../types/JobApplication'

const API_BASE = 'http://localhost:5158/JobApplications'

export async function getAllJobs(): Promise<JobApplication[]> {
  const res = await fetch(API_BASE)
  return await res.json()
}

export async function addJob(job: JobApplication) {
  console.log(job);
  console.log(JSON.stringify(job))
  
  return fetch(API_BASE, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(job)
  })
}
