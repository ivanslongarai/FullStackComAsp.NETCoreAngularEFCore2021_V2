import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '@app/services/event.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { Event } from '@app/models/Event';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss'],
})
export class EventDetailComponent implements OnInit {
  form!: FormGroup;
  event!: Event;
  stateSave = 'post';

  constructor(
    private fb: FormBuilder,
    private localService: BsLocaleService,
    private router: ActivatedRoute,
    private eventService: EventService,
    private toastr: ToastrService
  ) {
    this.localService.use('pt-br');
  }

  get f(): any {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      isAnimated: true,
      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      containerClass: 'theme-default',
      showWeekNumbers: false,
    };
  }

  ngOnInit() {
    this.loadEvent();
    this.validation();
  }

  private validation(): void {
    this.form = this.fb.group({
      subject: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
      local: ['', Validators.required],
      date: ['', Validators.required],
      amountOfPeople: [
        '',
        [Validators.required, Validators.min(1), Validators.max(120000)],
      ],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      imageUrl: ['', Validators.required],
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(field: FormControl): any {
    return { 'is-invalid': field.errors && field.touched };
  }

  public loadEvent(): void {
    const eventIdParam = this.router.snapshot.paramMap.get('id');

    if (eventIdParam !== null) {
      this.stateSave = 'put';
      console.log(this.stateSave);
      this.eventService.getEventById(+eventIdParam).subscribe({
        next: (_event: Event) => {
          this.event = { ..._event };
          this.form.patchValue(this.event);
        },
        error: (error: any) => {
          this.toastr.error('Erro ao Carregar Evento');
        },
        complete: () => {},
      });
    } else {
      this.stateSave = 'post';
    }     
  }

  public saveEvent(): void {
    if (this.form.valid) {
      if (this.stateSave == 'post') {
        this.event = { ...this.form.value };
        this.eventService['post'](this.event).subscribe(
          () => this.toastr.success('Evento Salvo com Sucesso'),
          () => this.toastr.error('Erro ao Salvar Evento'),
          () => {}
        );
      }
      else
        if (this.stateSave == 'put') {
          this.event = {id: this.event.id,  ...this.form.value };
          this.eventService['put'](this.event).subscribe(
            () => this.toastr.success('Evento Salvo com Sucesso'),
            () => this.toastr.error('Erro ao Salvar Evento'),
            () => {}
          );
        }
    } else this.toastr.error('Não foi possível salvar o Evento, verifique os dados digitados');
  }
}
