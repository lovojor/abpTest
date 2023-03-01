

export interface Sendgrid  {
    from: string,
    to: string,
    message: string
}

export interface ResponseSendgrid {
    send: boolean
}