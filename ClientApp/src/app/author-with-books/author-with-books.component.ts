import { Component, OnInit } from '@angular/core';
import { AuthorsService } from '../authors.service';

@Component({
  selector: 'app-author-with-books',
  templateUrl: './author-with-books.component.html',
  styleUrls: ['./author-with-books.component.css']
})
export class AuthorWithBooksComponent implements OnInit {

  public authors = [];

  constructor(private _authorservice: AuthorsService) { }

  ngOnInit() {
    this._authorservice.getAuthors().subscribe(data => this.authors = data);
  }

}
