import { UserList } from "../user/user-list";

export interface Review {
    id: number,
    mark: number,
    comment?: number,
    creationDate: Date,
    user : UserList,
}