import { PublisherList } from "../publisher/publisher-list";
import { Review } from "../review/review";
import { GenreList } from "../genre/genre-list";
import { GameAwardList } from "../game-award/game-award-list";

export interface Game {
    id: number,
    title: string,
    releaseDate: Date,
    summary: string,
    imageName: string,
    price: number,
    playtime?: number,
    score?: number,
    publisher: PublisherList,
    reviews: Review[],
    awards: GameAwardList[],
    genres: GenreList[]
}