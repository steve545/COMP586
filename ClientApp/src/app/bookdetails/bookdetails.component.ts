import { Component, OnInit } from '@angular/core';
import { BookdetailsService } from '../bookdetails.service';
import { BooksService } from '../books.service';
import { HttpClient } from '@angular/common/http';




@Component({
  selector: 'app-bookdetails',
  templateUrl: './bookdetails.component.html',
  styleUrls: ['./bookdetails.component.css']
})
export class BookdetailsComponent implements OnInit {

  public bookDetails = [];

  bookId: number;

  constructor(public _theSharedService: BooksService, private http: HttpClient, public _bookdetailsService: BookdetailsService) { console.log('constructor'); }


  ngOnInit(): void {
    console.log('ngoninit');
    this._theSharedService.getSelectedId().subscribe((selectedId) => { this.bookId = selectedId });
    console.log(this.bookId);
    this._bookdetailsService.getBookDetails(this.bookId).subscribe(data => this.bookDetails.push(data));
    console.log(this.bookDetails);

  }
}
