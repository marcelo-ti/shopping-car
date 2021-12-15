import { throwError } from 'rxjs'

export const handleError = (err) => {
  let errorMessage: string
  if (err.error instanceof ErrorEvent) {
    errorMessage = `An error occurred: ${err.error.message}`
  } else {
    errorMessage = `Backend returned code ${err.status}: ${err.body.error}`
  }
  console.error(err)
  return throwError(errorMessage)
}
