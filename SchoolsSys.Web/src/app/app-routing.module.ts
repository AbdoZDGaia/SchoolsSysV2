import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddStudentComponent } from './components/students/add-student/add-student.component';
import { StudentDetailsComponent } from './components/students/student-details/student-details.component';
import { StudentsListComponent } from './components/shared/students-list/students-list.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'students/list', pathMatch: 'full' },
  { path: 'students/list', component: StudentsListComponent },
  { path: 'students/details/:id', component: StudentDetailsComponent },
  { path: 'students/add', component: AddStudentComponent },
  { path: '404', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
