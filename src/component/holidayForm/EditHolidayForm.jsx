import { Alert, Button, FormControl, Grid, InputLabel, MenuItem, Select, TextField } from '@mui/material'
import { Box } from '@mui/system'
import axios from 'axios'
import React, { useState } from 'react'
import { useDispatch, useSelector } from "react-redux"
import { useNavigate } from 'react-router-dom'
import { changeStatusOfEmployeeForm } from '../redux/action'
function EditHoliday() {
  const data = useSelector((state) => state?.holidayData?.holidayData?.data)
  const status = useSelector((state) => state?.holidayData?.edit)
  const[formStatus,setFormStatus]=useState(false)
  // console.log(status)
  const navigate = useNavigate()
  const dispatch=useDispatch()

  //initial state
  const init = {
    year_id:"",
    hday_date:"",
    hday_title: "",
    hday_type: "",
    
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
      hday_date,
      hday_title,
      year_id,
      hday_type,
    } = input

//api to post data(add new data)
    axios.post("/employee/addEmployee", {
hday_date,
year_id,
      hday_type,
     
      hday_title,
     
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

  //function to update data
  function handleUpdate() {


    const { hday_title,
        hday_date,
      year_id,
      hday_type,
     

     } = input

//api to update
    axios.put(`http://localhost:5028/Holyday/V1/UpdateHolyday`, {
      year_id,
      hday_type,
     
      hday_title,
      hday_date,
    })
      .then((res) => {

        if (res.status === 200 && res) {
          alert("Updated Successfully")
          navigate("/holiday")

        }else{
          alert("some error is there!")
        }


      })

  }

  function handleBack(){
    navigate("/holiday")

  }
  return (
    <div>
      <form>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="hday_date" label="Date" value={input.hday_date} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="hday_title" label="Title" value={input.hday_title} />
          </Grid>
          <Grid item xs={4}>
            <TextField disabled={status} onChange={handleChange} name="year_id" label="Year" value={input.year_id} />
          </Grid>
          <Grid item xs={4}>
          <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">Type</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={input.hday_type}
          name="hday_type"
        //   label="Age"
          onChange={handleChange}
        >
          <MenuItem  value="MAND">Mandatory</MenuItem>
          <MenuItem value="OPTN">Optional</MenuItem>
       
        </Select>
      </FormControl>
    </Box>
            {/* <TextField onChange={handleChange} name="hday_type" label="Type" value={input.hday_type} /> */}
          </Grid>
         
        </Grid>
      </form>
      {status ? <Button variant="contained" onClick={handleUpdate}>UPDATE</Button> : <Button variant="contained" onClick={handleSubmit}>ADD</Button>}
      <Button sx={{marginLeft:"20px"}} variant="contained" onClick={handleBack}>Back</Button>
    </div>
  )
}

export default EditHoliday
