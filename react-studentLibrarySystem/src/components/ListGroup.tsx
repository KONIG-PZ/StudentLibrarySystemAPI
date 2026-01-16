import { useState } from "react";

interface Props {
    items: string[];
    heading: string;
    onSelectItem: (item: string) => void;
}

function ListGroup({items, heading, onSelectItem}: Props) {
    const [selectedIndex, setselectedIndex] = useState(-1);

    const handleClick = (item: string, index: number) => {
        setselectedIndex(index);
        onSelectItem(item);
    }

  return (
    <>
    <h1>{heading}</h1>
    <div className="d-grid gap-2">
        {items.map((item, index) => (
            <button 
             className={
                selectedIndex === index 
                ? "btn btn-primary" 
                : "btn btn-outline-primary"
            }
             key={item}
             onClick={() => handleClick(item, index)}
             >
            {item}
            </button>
        ))}
    </div>
    </>
  );
}
export default ListGroup;