export interface JobApplication {
  id?: string
  company: string
  title: string
  stage: 'applied' | 'interviewing' | 'offer' | 'rejected'
  appliedOn: string
  followUpDate: string
  notes?: string
}
