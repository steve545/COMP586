import { Component, OnInit } from '@angular/core';
import { BooksService } from '../books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {
  public books = [];
  message;

  constructor(private _booksservice: BooksService) {
    this.message = 'Protected endpoint!';
  }

  ngOnInit() {
    this._booksservice.getBooks().subscribe(data => this.books = data);
  }
}
