import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from '../models/Event';

@Injectable()

export class EventService {

  baseUrl = `https://localhost:5001/api/events`;

  constructor(private http: HttpClient) {}

  public getEvents() : Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl);
  }

  public getEventsBySubject(subject : string) : Observable<Event[]> {
    return this.http.get<Event[]>(`${this.baseUrl}/subject/${subject}`);
  }

  public getEventById(id : number) : Observable<Event> {
    return this.http.get<Event>(`${this.baseUrl}/id/${id}`);
  }  

}