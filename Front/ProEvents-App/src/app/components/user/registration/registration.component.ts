import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  form!: FormGroup;
  
  constructor(public fb : FormBuilder) { }

  get f() : any {
    return this.form.controls;
  }

  ngOnInit() {
    this.validation();
  }

  private validation() : void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'confirmPassword')
    };

    this.form = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(10)]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(10)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(10)]],
    }, formOptions)
  }
}
