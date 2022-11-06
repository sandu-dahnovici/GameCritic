import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarVerticalPosition } from "@angular/material/snack-bar";

@Injectable({
    providedIn: 'root'
})
export class SnackService {
    verticalPosition: MatSnackBarVerticalPosition = 'top';

    constructor(private _snackBar: MatSnackBar) { }

    openSnack(message: string, error: boolean = false) {
        this._snackBar.open(message, '', {
            verticalPosition: this.verticalPosition,
            duration: 1000,
            panelClass: error ? ['red-snackbar'] : ['green-snackbar']
        });
    }

}