import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent implements OnInit {
  form!: FormGroup;

  constructor(private fb : FormBuilder) { }

  get f() : any {
    return this.form.controls;
  }

  ngOnInit() {
    this.validation();
  }

  private validation() : void {
    this.form = this.fb.group({
      subject: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      date: ['', Validators.required],
      amountOfPeople: ['', [Validators.required, Validators.min(1), Validators.max(120000)]],
      phone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      imageUrl: ['', Validators.required]
    })
  }

  public resetForm() : void {
    this.form.reset();
  }

}
