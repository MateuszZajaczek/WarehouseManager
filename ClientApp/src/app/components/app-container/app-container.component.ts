import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-container',
  templateUrl: './app-container.component.html',
  styleUrls: ['./app-container.component.css']
})
export class AppContainer implements OnInit {
  title = 'Warehouse Manager v1.0';
  items: any;

  constructor(private http: HttpClient) { }


  ngOnInit(): void {
    this.http.get('https://localhost:7025/item').subscribe({
      next: response => this.items = response,
      error: error => console.log(error),
      complete: () => console.log('request has completed')
    })
  }

}
