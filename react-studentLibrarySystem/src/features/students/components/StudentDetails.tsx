import { Student } from "../types/Student";

interface Props {
  student: Student;
}

function StudentDetails({ student }: Props) {
  return (
    <div className="card p-3">
      <h5 className="mb-3">Student Details</h5>

      <div className="row">
        <div className="col-md-6">
          <p><strong>ID:</strong> {student.id}</p>
          <p>
            <strong>Name:</strong> {student.firstName} {student.lastName}
          </p>
        </div>

        <div className="col-md-6">
          <p><strong>Email:</strong> {student.email}</p>
          <p><strong>Phone:</strong> {student.phoneNumber ?? "N/A"}</p>
          <p><strong>Grade Level:</strong> {student.gradeLevel}</p>
        </div>
      </div>
    </div>
  );
}

export default StudentDetails;
