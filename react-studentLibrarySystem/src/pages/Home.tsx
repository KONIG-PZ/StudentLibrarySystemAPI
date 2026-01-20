import { useState } from "react";
import ListGroup from "../features/students/components/ListGroup";
import AddStudent from "./AddStudent";
import EditStudent from "./EditStudent";
import DeleteStudent from "./DeleteStudent";
import AllStudents from "./AllStudents";
import SelectStudent from "./SelectStudent";

function Home() {
  let items = ["Select Student","Add Student", "Edit Student", "Delete Student", "All Students"];
  const [currentPage, setCurrentPage] = useState("home");

  const handleSelectItem = (item: string) => {
    console.log(item);
    setCurrentPage(item);
  }

  // Show different page based on state
  const renderPage = () => {
    switch(currentPage) {
      case "Select Student":
        return <SelectStudent />;
      case "Add Student":
        return <AddStudent />;
      case "Edit Student":
        return <EditStudent />;
      case "Delete Student":
        return <DeleteStudent />;
      case "All Students":
        return <AllStudents />;
      default:
        return (
          <>
            <h2>Welcome to Student Library System</h2>
            <p>Select an option from the sidebar to get started.</p>
          </>
        );
    }
  }

  return (
    <div className="d-flex">
      {/* Sidebar */}
      <div
        className="bg-light p-3"
        style={{ width: "250px", minHeight: "100vh" }}
      >
        <ListGroup
          items={items}
          heading="Student Info"
          onSelectItem={handleSelectItem}
        />
      </div>

      {/* Main content */}
      <div className="flex-grow-1 p-4">
        {renderPage()}
      </div>
    </div>
  );
}

export default Home;