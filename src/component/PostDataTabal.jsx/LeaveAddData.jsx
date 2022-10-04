import { Alert, Button, FormControl, Grid, InputLabel, MenuItem, Select, TextField } from '@mui/material'
import { Box } from '@mui/system'
import axios from 'axios'
import React, { useState } from 'react'
import { useDispatch, useSelector } from "react-redux"
import { useNavigate } from 'react-router-dom'
import { changeStatusOfEmployeeForm } from '../redux/action'
function AddLeave() {
  const data = useSelector((state) => state?.holidayData?.holidayData?.data)
  const status = useSelector((state) => state?.holidayData?.edit)
  const[formStatus,setFormStatus]=useState(false)
  // console.log(status)
  const navigate = useNavigate()
  const dispatch=useDispatch()

  //initial state
  const init = {
    empl_id:"",
    elrq_index:"",
    elrq_date: "",
    elrq_leavetype: "",
    elrq_reason: "",
    elrq_leavestdate: "",
    elrq_leaveenddate: "",
    elrq_approvedby: "",
    elrq_approvedremarks: "",
    elrq_aprvdleavestdate: "",
    elrq_aprvdleaveenddate: "",
    
  }

  //if status =>from redux is true then add redux stored data in input otherwise add initial state from above
  const [input, setInput] = useState(status ? data : init)


  const handleChange = (e) => {
    const { name, value } = e.target
    setInput({ ...input, [name]: value })
    console.log(name,value)

  }
  console.log(input)
  //function to add data
  const handleSubmit = () => {
    const { 
      elrq_index,
      elrq_date,
      empl_id,
      elrq_leavetype,
      elrq_reason,
      elrq_leavestdate,
      elrq_leaveenddate,
      elrq_approvedby,
      elrq_approvedremarks,
      elrq_aprvdleavestdate,
      elrq_aprvdleaveenddate
    } = input

//api to post data(add new data)
    axios.post("http://localhost:5028/EmpLeaveRequest/V1/AddEmployeeLeaveRequest", {
      elrq_index,
      elrq_date,
      empl_id,
      elrq_leavetype,
      elrq_reason,
      elrq_leavestdate,
      elrq_leaveenddate,
      elrq_approvedby,
      elrq_approvedremarks,
      elrq_aprvdleavestdate,
      elrq_aprvdleaveenddate
     
    })
    .then((res) => {

      if (res.status === 200) {
        
        setFormStatus(false)
        alert("Added successfully")
        navigate("/holiday")

      }else{
        alert("some error is there!")
      }


    })

  }

  

  function handleBack(){
    navigate("/Leaves")

  }
  return (
    <div>
      <form>
        <Grid container spacing={2}>
        <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="empl_id" label="Employee ID" value={input.empl_id} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_index" label="Index" value={input.elrq_index} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_date" label="Date" value={input.elrq_date} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_leavetype" label="Leave Type" value={input.elrq_leavetype} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_reason" label="Leave Reason" value={input.elrq_reason} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_leavestdate" label="Leave Start Date" value={input.elrq_leavestdate} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_leaveenddate" label="Leave End Date" value={input.elrq_leaveenddate} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_approvedby" label="Approved By" value={input.elrq_approvedby} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_approvedremarks" label="Approved Remarks" value={input.elrq_approvedremarks} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_aprvdleavestdate" label="Approved Leave  Start Date" value={input.elrq_aprvdleavestdate} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="elrq_aprvdleaveenddate" label="Approved Leave  End Date" value={input.elrq_aprvdleaveenddate} />
          </Grid>
       
          
        
         
        </Grid>
      </form>
      {status ? <Button variant="contained" onClick={handleUpdate}>UPDATE</Button> : <Button variant="contained" onClick={handleSubmit}>ADD</Button>}
      <Button sx={{marginLeft:"20px"}} variant="contained" onClick={handleBack}>Back</Button>
    </div>
  )
}

export default AddLeave
