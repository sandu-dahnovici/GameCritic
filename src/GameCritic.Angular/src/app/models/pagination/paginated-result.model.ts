import { MatPaginator } from "@angular/material/paginator";
import { Filter } from "./filter.model";

export class PaginatedRequest {
  pageIndex: number;
  pageSize: number;
  columnNameForSorting: string;
  sortDirection: string;
  filter: Filter;

  constructor(paginator: MatPaginator, sort: string, direction: string, filter: Filter) {
    this.pageIndex = paginator.pageIndex;
    this.pageSize = paginator.pageSize;
    this.columnNameForSorting = sort;
    this.sortDirection = direction;
    this.filter = filter;
  }
}
