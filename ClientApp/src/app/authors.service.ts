import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IAuthor } from './author';

@Injectable({
  providedIn: 'root'
})

@Injectable()
export class AuthorsService {

  constructor(private http: HttpClient) { }

  selectedId = new BehaviorSubject<number>(1);

  getSelectedId() {
    return this.selectedId.asObservable();
  }

  changeId(id: number) {
    this.selectedId.next(id)
  }

  getAuthors(): Observable<IAuthor[]> {
    return this.http.get<IAuthor[]>('api/authors');
  }
}
