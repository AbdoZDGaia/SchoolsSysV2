import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentDTO } from 'src/app/models/students.model';
import { StudentsService } from 'src/app/services/students.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {

  studentId: number;
  studentDto: StudentDTO;

  constructor(private route: ActivatedRoute, private studentsService: StudentsService) { }

  ngOnInit(): void {
    this.studentId = this.route.snapshot.params['id'];
    this.studentsService.getStudentById(this.studentId).subscribe(
      result => { this.studentDto = result },
      err => { console.log(err) }
    );
  }

}
