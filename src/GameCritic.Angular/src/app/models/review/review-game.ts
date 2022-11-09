import { GameList } from "../game/game-list";

export interface ReviewGame {
    id: number,
    mark: number,
    comment?: number,
    creationDate: Date,
    game : GameList,
}