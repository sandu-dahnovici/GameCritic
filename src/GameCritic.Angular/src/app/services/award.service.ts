import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Award } from '../models/award/award';
import { ErrorHandlingService } from './error-handling.service';

@Injectable({
    providedIn: 'root'
})
export class AwardService {

    private url = environment.apiUrl + 'awards/';

    constructor(private http: HttpClient,
        private errorHandling: ErrorHandlingService) { }

    getAwardById(id: string): Observable<Award> {
        return this.http.get<Award>(this.url + `${id}`)
            .pipe(catchError(this.errorHandling.handleError<Award>()));
    }
}
