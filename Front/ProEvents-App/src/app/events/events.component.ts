import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

import { EventService } from '../services/event.service';
import { Event } from '../models/Event';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public modalRef!: BsModalRef;
  public events: Event[] = [];
  public filteredEvents: Event[] = [];

  public imgWidth = 150;
  public imgMargin = 2;
  
  private privateShowImage = false;
  private filteredBy = '';

  public get filterBy(): string {
    return this.filteredBy;
  }

  public set filterBy(value: string) {
    this.filteredBy = value;
    this.filteredEvents = this.filterBy
      ? this.filterEvents(this.filterBy)
      : this.events;
  }

  constructor(
      private eventService : EventService, 
      private modalService : BsModalService, 
      private toastr: ToastrService) {

  }

  public ngOnInit(): void {
    this.getEvents();
  }

  public getEvents() : void {
    this.eventService.getEvents().subscribe(
      {
        next: (ev : Event[]) => 
        {
          this.events = ev;
          this.filteredEvents = ev;
        },
        error: (error : any) => console.log(error)
      }
    );
  }

  public filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (e : Event) =>
        e.subject.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        e.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  public setImageVisibility() : void {
    this.privateShowImage = !this.privateShowImage;
  }

  public getImageVisibility() : boolean {
    return this.privateShowImage;
  }

  public openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  public confirmDelete(): void {
    this.modalRef.hide();   
    this.toastr.success("Evento excluído com sucesso", "Informação");
  }
 
  public declineDelete(): void {
    this.modalRef.hide();
    this.toastr.warning("Exclusão cancelada", "Informação");
  }
  
}  
