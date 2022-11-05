import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateGame } from 'src/app/models/game/create-game';
import { Game } from 'src/app/models/game/game';
import { UpdateGame } from 'src/app/models/game/update-game';
import { GenreList } from 'src/app/models/genre/genre-list';
import { Publisher } from 'src/app/models/publisher/publisher';
import { PublisherList } from 'src/app/models/publisher/publisher-list';
import { GameService } from 'src/app/services/game.service';
import { GenreService } from 'src/app/services/genre.service';
import { PublisherService } from 'src/app/services/publisher.service';

@Component({
  selector: 'app-edit-game',
  templateUrl: './edit-game.component.html',
  styleUrls: ['./edit-game.component.css']
})
export class EditGameComponent implements OnInit {
  public id!: number;
  public pageTitle: string;
  public publishers: PublisherList[];
  public genres: GenreList[];
  public gameForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private gameService: GameService,
    private publisherService: PublisherService,
    private genreService: GenreService,
  ) { }

  ngOnInit() {
    let objectId!: number;
    this.route.params.subscribe(params => {
      objectId = +params['id'];
      if (objectId === 0) {
        this.pageTitle = 'Add Game:';
      } else {
        this.getGame(objectId);
        this.pageTitle = 'Edit Game:';
        this.id = objectId;
      }
    });

    this.gameForm = this.formBuilder.group({
      id: [objectId, [Validators.required]],
      title: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      summary: [null, [Validators.minLength(50), Validators.maxLength(2000), Validators.required]],
      price: [null, [Validators.required, Validators.min(10), Validators.max(300)]],
      releaseDate: [null, [Validators.required, this.validDate]],
      playtime: [null],
      publisherId: [null, [Validators.required]],
      genresId: [null],
    });
    this.getAllPublishers();
    this.getAllGenres();
  }

  getAllPublishers(): void {
    this.publisherService.getAllPublishers().subscribe((publishers: PublisherList[]) => {
      this.publishers = publishers;
    });
  }

  getAllGenres(): void {
    this.genreService.getAllGenres().subscribe((genre: GenreList[]) => {
      this.genres = genre;
    });
  }

  getGame(id: number): void {
    this.gameService.getGameById(id.toString()).subscribe((game: Game) => {
      this.gameForm.controls['title'].setValue(game.title);
      this.gameForm.controls['price'].setValue(game.price);
      this.gameForm.controls['summary'].setValue(game.summary);
      this.gameForm.controls['id'].setValue(game.id);
      this.gameForm.controls['releaseDate'].setValue(game.releaseDate);
      this.gameForm.controls['playtime'].setValue(game.playtime);
      this.gameForm.controls['publisherId'].setValue(game.publisher.id);
      let arr: Array<number> = [];
      for (let genre of game.genres) arr.push(genre.id);
      this.gameForm.controls['genresId'].setValue(arr);
    });
  }

  saveGame(): void {
    if (this.gameForm.dirty && this.gameForm.valid) {
      let gameToSave: UpdateGame;
      gameToSave = {
        ...this.gameForm.value
      };
      console.log(gameToSave);

      this.gameService.saveGame(gameToSave).subscribe(
        () => this.onSaveComplete()
      );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.gameForm.reset();
    this.router.navigate(['/games']);
  }

  validDate(control: AbstractControl): ValidationErrors | null {
    const value = control.value as Date;
    if (value == null) return null;
    const min = new Date(2000, 2, 2).getTime();
    const max = new Date().getTime();
    if (new Date(value).getTime() < min || new Date(value).getTime() > max) {
      return { validDate: true };
    }
    return null;
  }

  get releaseDate() {
    return this.gameForm.get('releaseDate');
  }

  get summary() {
    return this.gameForm.get('summary');
  }

  get publisherId() {
    return this.gameForm.get('publisherId');
  }

}
