import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAuthor } from '../author'
import { AuthorsService } from '../authors.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit{
  public authors=/*: IAuthor*/[];

  /*constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IAuthor[]>(baseUrl + 'api/authors').subscribe(result => {
      this.authors = result;
    }, error => console.error(error));
  }*/
  constructor(private _authorservice: AuthorsService) { }

  ngOnInit() {
    this._authorservice.getAuthors().subscribe(data => this.authors = data);
  }
}


