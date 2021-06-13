import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from '../models/Event';
import { take } from 'rxjs/operators';

@Injectable()

export class EventService {

  baseUrl = `https://localhost:5001/api/events`;

  constructor(private http: HttpClient) {}

  public getEvents() : Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl).pipe(take(1));
  }

  public getEventsBySubject(subject : string) : Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseUrl}/subject/${subject}`).pipe(take(1));
  }

  public getEventById(id : number) : Observable<Event> {
    return this.http.get<Event>(`${this.baseUrl}/id/${id}`)
  }  

  public post(event : Event) : Observable<Event> {
    return this.http.post<Event>(this.baseUrl, event).pipe(take(1));
  }  

  public put(event : Event) : Observable<Event> {
    return this.http.put<Event>(`${this.baseUrl}/${event.id}`, event).pipe(take(1));
  }  

  public deleteEvent(id: number) : Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(take(1));
  }    

}