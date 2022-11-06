import { Game } from "../game/game";

export interface Publisher {
    id: number,
    name: string,
    country: string,
    foundationYear: number,
    websiteURL: string,
    numberOfEmployees: number,
    games: Game[]
}