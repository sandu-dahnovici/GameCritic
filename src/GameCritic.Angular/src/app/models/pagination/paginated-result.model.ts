import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { RequestFilters } from "./request-filters.model";

export class PaginatedRequest {
  pageIndex: number;
  pageSize: number;
  columnNameForSorting: string;
  sortDirection: string;
  requestFilters: RequestFilters;

  constructor(paginator: MatPaginator, sort: string, direction: string, filters: RequestFilters) {
    this.pageIndex = paginator.pageIndex;
    this.pageSize = paginator.pageSize;
    this.columnNameForSorting = sort;
    this.sortDirection = direction;
    this.requestFilters = filters;
  }
}
