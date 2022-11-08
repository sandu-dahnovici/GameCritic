import { PublisherList } from "../publisher/publisher-list";
import { GenreList } from "../genre/genre-list";
import { GameAwardList } from "../ranking/game-award-list";

export interface Game {
    id: number,
    title: string,
    releaseDate: Date,
    summary: string,
    imageName: string,
    price: number,
    playtime: number,
    score: number,
    publisher: PublisherList,
    awards: GameAwardList[],
    genres: GenreList[]
}