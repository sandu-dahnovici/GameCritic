import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Game } from 'src/app/models/game/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-upload-game-image',
  templateUrl: './upload-game-image.component.html',
  styleUrls: ['./upload-game-image.component.css']
})
export class UploadGameImageComponent implements OnInit {

  game!: Game;
  imageUrl: string | ArrayBuffer | null = 'assets/no-image.jpg';
  fileName = '';
  file: File;

  constructor(private gameService: GameService,
    private route: ActivatedRoute, public snackBar: MatSnackBar,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.gameService.getGameById(id.toString()).subscribe((game: Game) => {
        this.game = game;
      });
    })
  };

  getImageUrl(imageName: string) {
    if (imageName) {
      return this.gameService.getGameImageUrl(imageName);
    }
    return 'assets/no-image.jpg';
  }

  uploadFile() {
    let file = this.file;
    this.gameService
      .setGameImage(this.game.id, file)
      .subscribe((imageName: string) => {
        this.imageUrl = this.getImageUrl(imageName);
        this.snackBar.open(`The image has been uploaded successfully.\n
        Redirecting to '${this.game.title}' page`, 'Close', {
          duration: 2000,
        });
      });
    this.delay(2500).then(() => {
      this.router.navigate(['games/', this.game.id]);
    });
  }

  onChange(event: any) {
    this.file = event.target.files[0];
    if (event.target.files && event.target.files[0]) {
      const file = event.target.files[0];

      const reader = new FileReader();
      reader.onload = e => this.imageUrl = reader.result;

      reader.readAsDataURL(file);
    }
  }


  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
}
