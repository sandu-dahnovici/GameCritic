import { AwardGameList } from "../ranking/award-game-list";

export interface Award {
    id: number,
    title: string,
    year: number,
    games: AwardGameList[]
}