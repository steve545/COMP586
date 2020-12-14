import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBookDetails } from './bookdetails';

@Injectable({
  providedIn: 'root'
})
export class BookdetailsService {

  constructor(private http: HttpClient) { }

  getBookDetails(id) {
    console.log('service');
    return this.http.get<IBookDetails>('api/books/' + id);
  }

}
