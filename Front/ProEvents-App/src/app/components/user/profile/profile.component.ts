import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  form!: FormGroup;
  
  get f() : any {
    return this.form.controls;
  }

  constructor(public fb : FormBuilder) { }

  ngOnInit() : void {
    this.validation();
  }

  private validation() : void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'confirmPassword')
    };

    this.form = this.fb.group({
      title: ['', Validators.required],
      firstName: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      jobPosition: ['', Validators.required],
      description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      password: ['', [ Validators.minLength(6), Validators.maxLength(10)]],
      confirmPassword: ['', [Validators.minLength(6), Validators.maxLength(10)]],
    }, formOptions)
  }

}
