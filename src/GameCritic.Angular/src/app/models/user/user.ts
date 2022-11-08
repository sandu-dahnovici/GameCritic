export interface User {
    id: number,
    username: string,
    email: string,
    registerDateTime: Date,
    role: string,
    token?: string,
}