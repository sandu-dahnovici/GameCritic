import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { merge } from 'rxjs';
import { Filter } from 'src/app/models/pagination/filter.model';
import { PagedResult } from 'src/app/models/pagination/paged-result.model';
import { PaginatedRequest } from 'src/app/models/pagination/paginated-result.model';
import { PublisherList } from 'src/app/models/publisher/publisher-list';
import { PublisherService } from 'src/app/services/publisher.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';
import { SearchBarComponent } from '../../shared/search-bar/search-bar.component';

@Component({
  selector: 'app-publishers-search-page',
  templateUrl: './publishers-search-page.component.html',
  styleUrls: ['./publishers-search-page.component.css']
})
export class PublishersSearchPageComponent implements OnInit {

  pagedPublishers?: PagedResult<PublisherList>;
  displayedColumns: Array<string> = ['name', 'country', 'foundationYear', 'id'];
  dataSource: MatTableDataSource<PublisherList>;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  @ViewChild(SearchBarComponent) sc: SearchBarComponent;

  filter!: Filter;
  constructor(private publisherService: PublisherService, public dialog: MatDialog,
    public snackBar: MatSnackBar) { }

  ngOnInit(): void {
    if (this.publisherService.search.redirected) {
      this.loadGamesFromApi(this.publisherService.search.text);
    }
    else {
      this.loadGamesFromApi();
    }
  }

  ngAfterViewInit(): void {
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
      this.loadGamesFromApi();
    });
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
          path: 'name',
          value: value,
        }
      };
    } else {
      this.filter = {
        path: 'name',
        value: value,
      }
      let toSort = this.sort.active ?? '';
      let direction = this.sort.direction ?? '';
      paginatedRequest = new PaginatedRequest(this.paginator, toSort, direction, this.filter);
    }
    this.publisherService.getPublishersPaged(paginatedRequest)
      .subscribe((pagedPubs: PagedResult<PublisherList>) => {
        this.pagedPublishers = pagedPubs;
        this.dataSource = new MatTableDataSource(pagedPubs.items);
      });
  }

  openDialogForDeleting(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Dialog', message: 'Are you sure to delete this publisher?' }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.publisherService.deletePublisher(id).subscribe(
          () => {
            this.loadGamesFromApi();
            this.snackBar.open('The publisher has been deleted successfully.', 'Close', {
              duration: 1500
            });
          }
        );
      }
    });
  }

  isAdmin() {

  }

  paginatedSearch(text: string) {
    this.paginator.firstPage();
    this.loadGamesFromApi(text);
  }
}
