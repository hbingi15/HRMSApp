import React from 'react'

function Check() {
function handleClick(){


    fetch("http://localhost:5028/Induction/V1/AddInduction", {
        method: "POST",
        crossDomain: true,
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json",
          "Access-Control-Allow-Origin": "*",
        },
        body: JSON.stringify({
            indc_id: "1",
            indc_emof_id: "1",
            indc_date:"2000",
            indc_processed_ausr_id: "1",
            indc_status: "Active"
          }),
      })
        .then((res) => res.json())
        .then((data) => {
          console.log(data);
        
        });
    

    }
  return (
    <div>
      <button onClick={handleClick}>submit</button>
    </div>
  )
}

export default Check
