import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { GenreList } from 'src/app/models/genre/genre-list';
import { GenreService } from 'src/app/services/genre.service';
import { UserService } from 'src/app/services/user.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  username: string | undefined;
  genres: GenreList[] = [];
  constructor(private genreService: GenreService, private userService: UserService,
    private router: Router,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.genreService.getAllGenres().subscribe((list) => {
      this.genres = list;
    });

    this.username = this.userService.getUsername();
  }

  isAuthenticated() {
    return this.userService.isUser() || this.isAdmin();
  }

  isAdmin() {
    return this.userService.isAdmin();
  }

  logOutUser(): void {
    this.userService.logoutUser();
    this.router.navigate(['/']).then(() => {
      window.location.reload();
    });
  }

  public openDialogForLogOut() {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Dialog', message: 'Are you sure to log out?' }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM)
        this.logOutUser();
    });
  }

}
