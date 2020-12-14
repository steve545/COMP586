import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IBooks } from './book';

@Injectable({
  providedIn: 'root'
})

@Injectable()
export class BooksService {

  constructor(private http: HttpClient) { }

  selectedId = new BehaviorSubject<number>(1);

  getSelectedId() {
    return this.selectedId.asObservable();
  }

  changeId(id: number) {
    this.selectedId.next(id)
  }

  getBooks(): Observable<IBooks[]> {
    return this.http.get<IBooks[]>('api/books');
  }
}
