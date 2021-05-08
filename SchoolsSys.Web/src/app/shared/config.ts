export const config = {
  EndPoint: "http://localhost:55761/",
  // EndPoint: "http://localhost:1231/",
  // EndPoint: "https://localhost:44325/",
  Students: {
    AddStudentUrl: "api/students/CreateStudent",
    UploadImageUrl: "api/students/Upload",
    UploadFilesUrl: "api/students/UploadFiles",
  },
  Queries: {
    GetAllStudentsUrl: "api/Queries/GetAllStudents",
    GetStudentByIdUrl: "api/Queries/GetStudentById",
    GetAllGradesUrl: "api/Queries/GetAllGrades",
    GetAllClassesUrl: "api/Queries/GetAllClasses",
    GetClassesByGradeIdUrl: "api/Queries/GetClassesByGradeId",
  },
}
