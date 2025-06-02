import type { JobApplication } from './../types/JobApplication'

const API_BASE = 'http://localhost:5158/JobApplications'

export async function getAllJobs(): Promise<JobApplication[]> {
  const res = await fetch(API_BASE)
  return await res.json()
}

export async function getJob (id: string): Promise<JobApplication> {
  console.log(id);
  
  const res = await fetch(`${API_BASE}/${id}`);
  return await res.json()
}

export async function addJob(job: JobApplication): Promise<boolean> {
  var res = await fetch(API_BASE, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(job)
  })

  return res.ok
}

export async function updateJob(job: JobApplication): Promise<boolean> {
  const res = await fetch(`${API_BASE}/${job.id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(job),
  });
  return res.ok;
}

export async function deleteJob(id: string): Promise<boolean> {
  const res = await fetch(`${API_BASE}/${id}`, {
    method: 'DELETE',
  });
  return res.ok;
}
