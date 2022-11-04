import {MatPaginator} from "@angular/material/paginator";

export class PaginatedRequestNoFilters {
  pageIndex: number;
  pageSize: number;
  columnNameForSorting: string;
  sortDirection: string;

  constructor(paginator: MatPaginator) {
    this.pageIndex = paginator.pageIndex;
    this.pageSize = paginator.pageSize;
    this.columnNameForSorting = "title";
    this.sortDirection = "DESC";
  }
}
