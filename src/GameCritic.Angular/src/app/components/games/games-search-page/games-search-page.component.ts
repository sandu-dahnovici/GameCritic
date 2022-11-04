import { AfterContentInit, AfterViewChecked, AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TitleStrategy } from '@angular/router';
import { filter, merge } from 'rxjs';
import { GameList } from 'src/app/models/game/game-list';
import { PagedResult } from 'src/app/models/pagination/paged-result.model';
import { PaginatedRequest } from 'src/app/models/pagination/paginated-result.model';
import { RequestFilters } from 'src/app/models/pagination/request-filters.model';
import { GameService } from 'src/app/services/game.service';
import { SearchBarComponent } from '../search-bar/search-bar.component';

@Component({
  selector: 'app-games-search-page',
  templateUrl: './games-search-page.component.html',
  styleUrls: ['./games-search-page.component.css']
})
export class GamesSearchPageComponent implements OnInit, AfterViewInit {
  pagedGames?: PagedResult<GameList>;
  displayedColumns: Array<string> = ['title', 'releaseDate', 'price', 'score', 'id'];
  dataSource: MatTableDataSource<GameList>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(SearchBarComponent) sc: SearchBarComponent;

  requestFilters!: RequestFilters;
  constructor(private gameService: GameService, public dialog: MatDialog,
    public snackBar: MatSnackBar) { }

  ngOnInit(): void {
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
        columnNameForSorting: 'title',
        sortDirection: 'asc',
        requestFilters: {
          logicalOperator: 1,
          filters: [{
            path: 'title',
            value: value,
          }]
        }
      };
    } else {
      this.requestFilters = {
        logicalOperator: 1,
        filters: [{
          path: 'title',
          value: value,
        }]
      }
      paginatedRequest = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
    }
    this.gameService.getGamesPaged(paginatedRequest)
      .subscribe((pagedGames: PagedResult<GameList>) => {
        this.pagedGames = pagedGames;
        this.dataSource = new MatTableDataSource(pagedGames.items);
      });
  }

  openDialogForDeleting(id: number) {
    // const dialogRef = this.dialog.open(ConfirmDialogComponent, {
    //   data: { title: 'Dialog', message: 'Are you sure to delete this item?' }
    // });
    // dialogRef.disableClose = true;

    // dialogRef.afterClosed().subscribe(result => {
    //   if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
    //     this.bookService.deleteBook(id).subscribe(
    //       () => {
    //         this.loadBooksFromApi();

    //         this.snackBar.open('The item has been deleted successfully.', 'Close', {
    //           duration: 1500
    //         });
    //       }
    //     );
    //   }
    // });
  }

  isAdmin() {

  }

  paginatedSearch(text: string) {
    this.paginator.firstPage();
    this.loadGamesFromApi(text);
  }
}
