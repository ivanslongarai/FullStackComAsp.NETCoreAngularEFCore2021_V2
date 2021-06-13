import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker'; 
import { defineLocale} from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale'; 

import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip'
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { NavComponent } from './shared/nav/nav.component';
import { TitleComponent } from './shared/title/title.component';

import { EventsComponent } from './components/events/events.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventDetailComponent } from './components/events/event-detail/event-detail.component';
import { EventListComponent } from './components/events/event-list/event-list.component';
import { UserComponent } from './components/user/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

import { EventService } from './services/event.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [	
    AppComponent,
    EventsComponent,
    SpeakersComponent,
    NavComponent,
    DateTimeFormatPipe,
    TitleComponent,
    ContactsComponent,
    ProfileComponent,
    DashboardComponent,
    EventDetailComponent,
    EventListComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
   ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,    
    TooltipModule.forRoot(),
    CollapseModule.forRoot(),
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    MatToolbarModule,
    MatProgressSpinnerModule,
    MatButtonModule,     
    BsDatepickerModule.forRoot(),   
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true
    }),  
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  providers: [EventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
