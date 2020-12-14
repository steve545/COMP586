import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAuthorWithBooks } from './authorwithbooks';

@Injectable({
  providedIn: 'root'
})
export class AuthorwithbooksService {

  constructor(private http: HttpClient) { }

  getAuthorWithBooks(id): Observable<IAuthorWithBooks[]> {
    return this.http.get<IAuthorWithBooks[]>('api/authorwithbooks/' + id);
  }

}
