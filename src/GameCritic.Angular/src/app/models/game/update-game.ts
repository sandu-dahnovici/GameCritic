export interface UpdateGame {
    id?: number,
    title: string,
    releaseDate: Date,
    summary: string,
    price: number,
    playtime?: number,
    publisherId: number,
    genresId: number[],
}