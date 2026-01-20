import React from "react";

export interface StudentSeacrh {
    id: string;
    firstName: string;
    lastName: string;
    gradeLevel: string;
}

interface Props {
    search: StudentSeacrh;
    onChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
    onSearch: () => void;
    loading: boolean;
}

function StudentSearchForm({search, onChange, onSearch, loading}: Props) {
 return (
    <div className="card p-3 mb-4">
      <div className="row g-2">
        <div className="col-md-3">
          <input
            name="id"
            className="form-control"
            placeholder="Student ID (preferred)"
            value={search.id}
            onChange={onChange}
          />
        </div>

        <small className="text-muted">
          If ID is not found, search will use name and grade level.
        </small>

        <div className="col-md-3">
          <input
            name="firstName"
            className="form-control"
            placeholder="First Name"
            value={search.firstName}
            onChange={onChange}
          />
        </div>

        <div className="col-md-3">
          <input
            name="lastName"
            className="form-control"
            placeholder="Last Name"
            value={search.lastName}
            onChange={onChange}
          />
        </div>

        <div className="col-md-3">
          <input
            name="gradeLevel"
            type="number"
            className="form-control"
            placeholder="Grade Level"
            value={search.gradeLevel}
            onChange={onChange}
          />
        </div>
      </div>

      <button
        className="btn btn-primary mt-3"
        onClick={onSearch}
        disabled={loading}
      >
        {loading ? "Searching..." : "Search"}
      </button>
    </div>
  );
}

export default StudentSearchForm;