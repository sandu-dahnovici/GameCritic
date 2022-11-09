import { LoginUser } from "./login-user";

export interface RegisterUser extends LoginUser{
    username: string,
}