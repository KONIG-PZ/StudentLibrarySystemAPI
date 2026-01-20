import { useState } from "react";
import StudentSearchForm, {
  StudentSeacrh,
} from "../features/students/components/StudentSearchForm";
import StudentDetails from "../features/students/components/StudentDetails";
import { Student } from "../features/students/types/Student";

    const BACKEND_URL =
      import.meta.env.VITE_BACKEND_URL ?? "https://localhost:7231";

    function SelectStudent() {
      const [search, setSearch] = useState<StudentSeacrh>({
        id: "",
        firstName: "",
        lastName: "",
        gradeLevel: "",
      });

      const [student, setStudent] = useState<Student | null>(null);
      const [loading, setLoading] = useState<boolean>(false);
      const [error, setError] = useState<string>("");

      function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
        const { name, value } = e.target;
        setSearch((prev) => ({ ...prev, [name]: value }));
      }

     async function fetchStudent(): Promise<void> {
      try {
        setLoading(true);
        setError("");
        setStudent(null);


        if (
          !search.id.trim() &&
          !search.firstName.trim() &&
          !search.lastName.trim() &&
          !search.gradeLevel.trim()
        ) {
          setError("Please enter ID or student details");
          setLoading(false);
          return;
        }


        if (search.id.trim()) {
          const response = await fetch(
            `${BACKEND_URL}/api/Student/${search.id}`
          );

          if (response.ok) {
            const data: Student = await response.json();
            setStudent(data);
            return; 
          }
        }


        const response = await fetch(`${BACKEND_URL}/api/Student`);

        if (!response.ok) {
          throw new Error("Failed to fetch students");
        }

        const students: Student[] = await response.json();

        const matchedStudent = students.find((s) => {
          const matchesFirstName =
            !search.firstName.trim() ||
            s.firstName.toLowerCase().includes(search.firstName.toLowerCase());

          const matchesLastName =
            !search.lastName.trim() ||
            s.lastName.toLowerCase().includes(search.lastName.toLowerCase());

          const matchesGrade =
            !search.gradeLevel.trim() ||
            s.gradeLevel === Number(search.gradeLevel);

          return matchesFirstName && matchesLastName && matchesGrade;
        });

        if (!matchedStudent) {
          throw new Error("Student not found");
        }

        setStudent(matchedStudent);
      } catch (err: unknown) {
        setError(err instanceof Error ? err.message : "Something went wrong");
      } finally {
        setLoading(false);
      }
    }



    return (
      <div className="container mt-4">
        <h2 className="mb-3">Select Student</h2>

        <StudentSearchForm
          search={search}
          onChange={handleChange}
          onSearch={fetchStudent}
          loading={loading}
        />

        {error && <div className="alert alert-danger">{error}</div>}

        {student && <StudentDetails student={student} />}
      </div>
    );
}

export default SelectStudent;
