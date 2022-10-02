import { Button, Grid, TextField } from '@mui/material'
import axios from 'axios'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'

function LeaveAddData() {
    const navigate=useNavigate()
  const init = {
    empl_id: "",
    year_id: "",
    eolv_date: "2022-09-30",
    eolv_leavetype: "",
   
  }
  const [input, setInput] = useState(init)


  const handleChange = (e) => {
    const { name, value } = e.target
    setInput({ ...input, [name]: value })

  }


  function handlPost() {
    fetch("/leave/addLeave", {
      method: "POST",
      crossDomain: true,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        empl_id: input?.empl_id,
        year_id: input?.year_id,
        eolv_date: input?.eolv_date,
        eolv_leavetype: input?.eolv_leavetype,
       


      }),
    })
      .then((res) => res.json())
      .then((data) => {
        if(data?.status===201){
            alert(data?.message)
            
        }else{
            alert(data?.message)
        }
       navigate("/Leaves")
      });






  }
  return (
    <div>InductionAdd
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="empl_id" label="empl_id" value={input?.empl_id} />
        </Grid>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="year_id" label="year_id" value={input?.year_id} />
        </Grid>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="eolv_date" label="eolv_date" value={input?.eolv_date} />
        </Grid>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="eolv_leavetype" label="eolv_leavetype" value={input?.eolv_leavetype} />
        </Grid>
      
      </Grid>
      <Button variant="contained" onClick={handlPost}  >Submit</Button>
    </div>
  )
}

export default LeaveAddData