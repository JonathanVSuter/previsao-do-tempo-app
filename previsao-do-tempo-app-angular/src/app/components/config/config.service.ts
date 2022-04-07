import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { RootObject } from 'src/app/services/Dtos/RootObject';

export interface Config {
  heroesUrl: string;
  textfile: string;
  date: any;
}

@Injectable()
export class ConfigService {
  configUrl = 'https://localhost:44335/previsaodotempo/BuscarDadosCidade?cidadeNome=Bal';

  constructor(private http: HttpClient) { }

  getConfig() {
    var c = this.http.get<RootObject>(this.configUrl)
    .pipe(
      retry(3), // retry a failed request up to 3 times
      catchError(this.handleError) // then handle the error
    );   
    return c;
  }

  getConfig_1() {
    var a = this.http.get<RootObject>(this.configUrl);
    return a;
  }

  getConfig_2() {
    // now returns an Observable of Config
    return this.http.get<RootObject>(this.configUrl);
  }

  getConfig_3() {
    return this.http.get<RootObject>(this.configUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  getConfigResponse(): Observable<HttpResponse<RootObject>> {
    return this.http.get<RootObject>(
      this.configUrl, { observe: 'response' });
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }

  makeIntentionalError() {
    return this.http.get('not/a/real/url')
      .pipe(
        catchError(this.handleError)
      );
  }

}
