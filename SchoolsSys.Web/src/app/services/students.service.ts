import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { StudentDTO } from '../models/students.model';
import { config } from '../Shared/config';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  constructor(private http: HttpClient) { }

  addStudent(formData: StudentDTO): Observable<StudentDTO> {
    return this.http.post<StudentDTO>(config.EndPoint + config.Students.AddStudentUrl, formData);
  }

  getStudentById(studentId: number): Observable<StudentDTO> {
    return this.http.get<StudentDTO>(config.EndPoint + config.Queries.GetStudentByIdUrl + `?studentId=${studentId}`);
  }
}
