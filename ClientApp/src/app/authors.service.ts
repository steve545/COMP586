import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAuthor } from './author';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  constructor(private http: HttpClient) { }

  getAuthors(): Observable<IAuthor[]> {
    return this.http.get<IAuthor[]>('api/authors');
  }
}
