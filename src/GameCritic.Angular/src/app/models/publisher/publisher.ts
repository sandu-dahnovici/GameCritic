import { Game } from "../game/game";

export interface Publisher {
    name: string,
    country: string,
    foundationYear: number,
    websiteUrl: string,
    numberOfEmployees: number,
    games: Game[]
}