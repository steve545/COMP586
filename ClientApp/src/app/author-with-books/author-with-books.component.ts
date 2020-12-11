import { Component, OnInit, Input } from '@angular/core';
import { AuthorwithbooksService } from '../authorwithbooks.service';
import { AuthorsService } from '../authors.service';
import { IAuthorWithBooks } from '../authorwithbooks';
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
    this._sharedService.getSelectedId().subscribe((selectedId) => { console.log(selectedId); this.authorId = selectedId });
    console.log(this.authorId);
    console.log("using authorwithbooksservice");

    this._authorwithbooksService.getAuthorWithBooks(this.authorId).subscribe(data => this.authorWithBooks = data);
  }

}
