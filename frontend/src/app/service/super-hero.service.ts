import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SuperHero } from '../model/superhero';

@Injectable({
  providedIn: 'root'
})

export class SuperHeroService {
  private apiUrl = 'http://localhost:5065';

  constructor(private http: HttpClient) { }

  addSuperHero(superhero: any) : Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/superhero`, superhero).pipe(
      catchError(this.handleError)
    );
  }
  updateSuperHero(superhero: any): Observable<any>{
    return this.http.put<any>(`${this.apiUrl}/superhero/${superhero.id}`, superhero).pipe(
      catchError(this.handleError)
    );
  }
  getSuperHeroById(id: string): Observable<SuperHero> {
    return this.http.get<SuperHero>(`${this.apiUrl}/superhero/${id}`).pipe(
      catchError(this.handleError)
    );
  }
  deleteSuperHeroById(id: string): Observable<SuperHero>{
    return this.http.delete<SuperHero>(`${this.apiUrl}/superhero/${id}`).pipe(
      catchError(this.handleError)
    );
  }
  getSuperPowers(): Observable<any[]>{
    return this.http.get<any[]>(`${this.apiUrl}/superpower`).pipe(
      catchError(this.handleError)
    );
  }
  getAllSuperHeroes(): Observable<SuperHero[]> {
    return this.http.get<SuperHero[]>(`${this.apiUrl}/superhero`).pipe(
      catchError(this.handleError)
    );
  }
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = error.error || `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
