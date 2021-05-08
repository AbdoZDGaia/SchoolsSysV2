import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AddStudentComponent } from './components/students/add-student/add-student.component';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MapComponent } from './components/shared/map/map.component';
import { UploadComponent } from './components/shared/upload/upload.component';
import { DigitOnlyModule } from '@uiowa/digit-only';
import { AngularFileUploaderModule } from "angular-file-uploader";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { StudentsListComponent } from './components/shared/students-list/students-list.component';
import { StudentCardComponent } from './components/students/student-card/student-card.component';
import { StudentFilterComponent } from './components/students/student-filter/student-filter.component';
import { StudentDetailsComponent } from './components/students/student-details/student-details.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component'


@NgModule({
  declarations: [
    AppComponent,
    AddStudentComponent,
    MapComponent,
    UploadComponent,
    StudentsListComponent,
    StudentCardComponent,
    StudentFilterComponent,
    StudentDetailsComponent,
    NotFoundComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    BrowserAnimationsModule,
    AngularFileUploaderModule,
    ToastrModule.forRoot(),
    DigitOnlyModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
