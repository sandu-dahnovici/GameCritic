import { User } from "../user/user";

export interface Review {
    id: number,
    mark: number,
    comment?: number,
    creationDate: Date,
    user : User
}