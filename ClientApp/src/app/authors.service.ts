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
    console.log(id);
    this.selectedId.next(id)
  }//changes the id in the author service, so now use the author service in awb to get the
  //authorid and send that id to the controller call

  getAuthors(): Observable<IAuthor[]> {
    return this.http.get<IAuthor[]>('api/authors');
  }
}
