import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent {
  public authors: Author[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Author[]>(baseUrl + 'api/authors').subscribe(result => {
      this.authors = result;
    }, error => console.error(error));
  }
}

interface Author {
  authorId: number,
  name: string
}

