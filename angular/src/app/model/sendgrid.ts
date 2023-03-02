

export interface Sendgrid  {
    from: string,
    to: string,
    message: string
}

export interface ResponseSendgrid {
    send: boolean
}

export interface emailing {
    "smtpHost": string,
    "smtpPort": number,
    "smtpUserName": string,
    "smtpPassword": string,
    "smtpDomain": string,
    "smtpEnableSsl": true,
    "smtpUseDefaultCredentials": true,
    "defaultFromAddress": string,
    "defaultFromDisplayName": string
}