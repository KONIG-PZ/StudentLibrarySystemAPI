import Button from "./Button";

function SideBar() {
  return (
    <div className="sidebar">
      <h2>SideBar Component</h2>
      <Button label="Click Me" onClick={() => alert("Button Clicked!")} />
      <br></br>
      <Button label="Click Me too" onClick={() => alert("Also Clicked!")} />
    </div>
  );
}
export default SideBar;
