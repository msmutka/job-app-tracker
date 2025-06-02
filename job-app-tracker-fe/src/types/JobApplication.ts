export interface JobApplication {
  id?: number|null
  company: string
  title: string
  stage: 'applied' | 'interviewing' | 'offer' | 'rejected'
  appliedOn: string
  followUpDate: string
  notes?: string
}
