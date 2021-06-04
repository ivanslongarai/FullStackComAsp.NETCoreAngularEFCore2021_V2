import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  
  public events: any = [];
  public filteredEvents: any = [];

  public imgWidth: number = 150;
  public imgMargin: number = 2;
  public showImages: boolean = false;
  private _filterBy: string = '';

  public get filterBy(): string {
    return this._filterBy;
  }
  
  public set filterBy(value: string) {
    this._filterBy = value;
    this.filteredEvents = (this.filterBy ? this.filterEvents(this.filterBy) : this.events);
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents() {
    this.http.get(`https://localhost:5001/api/Events`).subscribe(
      (response) => {
        this.events = response; 
        this.filteredEvents = response
      },
      (error) => console.log(error)
    );
  }

  filterEvents(filterBy : string) : any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (e: { subject: string; local: string }) => 
        e.subject.toLocaleLowerCase().indexOf(filterBy) !== -1 || 
        e.local.toLocaleLowerCase().indexOf(filterBy) !== -1
      );    
  }

}
