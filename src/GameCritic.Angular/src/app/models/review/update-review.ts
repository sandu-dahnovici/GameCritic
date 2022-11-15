export interface UpdateReview {
    id?: number,
    mark: number,
    comment?: number,
    creationDate: Date,
    userId? : number,
    gameId?: number
}