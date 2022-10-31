import { GameList } from "../game/game-list";

export interface Genre {
    id : number,
    name : string,
    description : string,
    games : GameList[]
}