import { Component, OnInit } from '@angular/core';
import { AuthorwithbooksService } from '../authorwithbooks.service';
import { AuthorsService } from '../authors.service';
import { HttpClient } from '@angular/common/http';




@Component({
  selector: 'app-author-with-books',
  templateUrl: './author-with-books.component.html',
  styleUrls: ['./author-with-books.component.css']
})
export class AuthorWithBooksComponent implements OnInit {

  public authorWithBooks = [];
  authorId: number;

  constructor(public _sharedService: AuthorsService, private http: HttpClient, public _authorwithbooksService: AuthorwithbooksService) { }


  ngOnInit(): void {
    this._sharedService.getSelectedId().subscribe((selectedId) => {  this.authorId = selectedId });

    this._authorwithbooksService.getAuthorWithBooks(this.authorId).subscribe(data => this.authorWithBooks = data);
  }

}
