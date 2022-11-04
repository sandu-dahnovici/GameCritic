import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { Game } from "src/app/models/game/game";
import { GameService } from "src/app/services/game.service";


@Injectable({ providedIn: 'root' })
export class GamePageResolver implements Resolve<Game> {
  constructor(private service: GameService) { }
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<Game> | Promise<Game> | Game {
    return this.service.getGameById(route.paramMap.get('id') as string);
  }
}