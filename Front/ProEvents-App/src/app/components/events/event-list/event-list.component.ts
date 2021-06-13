import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

import { EventService } from '@app/services/event.service';
import { Event } from '@app/models/Event';
import { LoadingService } from '@app/services/loading.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss'],
})
export class EventListComponent implements OnInit {
  public modalRef!: BsModalRef;
  public events: Event[] = [];
  public filteredEvents: Event[] = [];

  loading$ = this.loader.loading$;

  public imgWidth = 150;
  public imgMargin = 2;
  public eventId!: number;

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
    private eventService: EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    public loader: LoadingService,
    private router: Router
  ) {}

  public ngOnInit(): void {
    this.getEvents();
    this.loader.show();
  }

  public getEvents(): void {
    this.eventService.getEvents().subscribe({
      next: (ev: Event[]) => {
        this.events = ev;
        this.filteredEvents = ev;
      },
      error: (error: any) => {
        console.log(error);
        this.loader.hide();
        this.toastr.error('Erro ao carregar os eventos');
      },
      complete: () => {
        setTimeout(() => {
          this.loader.hide();
        }, 500);
      },
    });
  }

  public filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (e: Event) =>
        e.subject.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        e.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  public setImageVisibility(): void {
    this.privateShowImage = !this.privateShowImage;
  }

  public getImageVisibility(): boolean {
    return this.privateShowImage;
  }

  public openModal(pEvent: any, template: TemplateRef<any>, eventId: number) {
    this.eventId = eventId;
    pEvent.stopPropagation();
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public confirmDelete(): void {
    this.modalRef.hide();
    this.eventService.deleteEvent(this.eventId).subscribe(
      (result: any) => {
        if ((result.message = 'Deleted')) {
          console.log(result);
          this.toastr.success('Evento excluído com sucesso', 'Informação');
          this.getEvents();
        }
      },
      (error) => {
        this.toastr.error('Erro ao excluir Evento');
      },
      () => {}
    );
  }

  public declineDelete(): void {
    this.modalRef.hide();
    this.toastr.warning('Exclusão cancelada', 'Informação');
  }

  public eventDetail(id: number) {
    this.router.navigate([`events/detail/${id}`]);
  }
}
