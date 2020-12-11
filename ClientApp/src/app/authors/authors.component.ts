import { Component, OnInit, Output } from '@angular/core';
import { AuthorsService } from '../authors.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent {
  public authors = [];
  authorId: number;

  constructor(private _authorservice: AuthorsService) { }

  ngOnInit() {
    this._authorservice.getAuthors().subscribe(data => this.authors = data);
  }
  newId(authorId:number) {
    console.log(authorId);
    this._authorservice.changeId(authorId)
  }
}


