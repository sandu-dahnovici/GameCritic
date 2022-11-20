import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { GameList } from 'src/app/models/game/game-list';
import { Filter } from 'src/app/models/pagination/filter.model';
import { PagedResult } from 'src/app/models/pagination/paged-result.model';
import { PaginatedRequest } from 'src/app/models/pagination/paginated-result.model';
import { GameService } from 'src/app/services/game.service';
import { UserService } from 'src/app/services/user.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';
import { SearchBarComponent } from '../../shared/search-bar/search-bar.component';

@Component({
  selector: 'app-games-search-page',
  templateUrl: './games-search-page.component.html',
  styleUrls: ['./games-search-page.component.css']
})
export class GamesSearchPageComponent implements OnInit, AfterViewInit {
  pagedGames?: PagedResult<GameList>;
  displayedColumns: Array<string> = ['title', 'score', 'price', 'releaseDate', 'id'];
  dataSource: MatTableDataSource<GameList>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(SearchBarComponent) sc: SearchBarComponent;

  filter!: Filter;

  constructor(private gameService: GameService, public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private userService: UserService) { }

  ngOnInit(): void {
    if (!this.isAdmin()) this.displayedColumns.pop();
    if (this.gameService.search.redirected) {
      this.loadGamesFromApi(this.gameService.search.text);
    }
    else {
      this.loadGamesFromApi();
    }
  }

  ngAfterViewInit(): void {
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    if (this.gameService.search.redirected) {
      this.gameService.search.redirected = false;
      merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
        this.loadGamesFromApi(this.gameService.search.text);
      });
      this.sc.text = this.gameService.search.text;
    }
    else {
      merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
        this.loadGamesFromApi();
      });
    }
  }

  loadGamesFromApi(text?: string) {
    let paginatedRequest: PaginatedRequest;
    let value: string;
    if (text === undefined || text === null) value = '';
    else value = text;
    if (this.sc !== undefined && this.sc.text !== undefined) value = this.sc.text;
    if (this.paginator === undefined) {
      paginatedRequest = {
        pageIndex: 0,
        pageSize: 5,
        columnNameForSorting: '',
        sortDirection: '',
        filter: {
          path: 'title',
          value: value,
        }
      }
    } else {
      this.filter = {
        path: 'title',
        value: value,
      }
      let toSort = this.sort.active ?? '';
      let direction = this.sort.direction ?? '';
      paginatedRequest = new PaginatedRequest(this.paginator, toSort, direction, this.filter);
    }
    this.gameService.getGamesPaged(paginatedRequest)
      .subscribe((pagedGames: PagedResult<GameList>) => {
        this.pagedGames = pagedGames;
        this.dataSource = new MatTableDataSource(pagedGames.items);
      });
  }

  openDialogForDeleting(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Dialog', message: 'Are you sure to delete this game?' }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.gameService.deleteGame(id).subscribe(
          () => {
            this.loadGamesFromApi();
            this.snackBar.open('The game has been deleted successfully.', 'Close', {
              duration: 1500
            });
          }
        );
      }
    });
  }

  isAdmin() {
    return this.userService.isAdmin();
  }

  paginatedSearch(text: string) {
    this.paginator.firstPage();
    this.loadGamesFromApi(text);
  }
}
