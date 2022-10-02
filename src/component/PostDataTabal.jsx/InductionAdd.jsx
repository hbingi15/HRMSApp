import { Button, Grid, TextField } from '@mui/material'
import axios from 'axios'
import React, { useState } from 'react'

function InductionAdd() {
  const init = {
    indc_id: "",
    indc_emof_id: "",
    indc_date: "2022-09-30T09:01:57.304Z",
    indc_processed_ausr_id: "",
    indc_status: ""
  }
  const [input, setInput] = useState(init)


  const handleChange = (e) => {
    const { name, value } = e.target
    setInput({ ...input, [name]: value })

  }


  function handlPost() {
    fetch("/induction/addInduction", {
      method: "POST",
      crossDomain: true,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        indc_id: input?.indc_id,
        indc_emof_id: input?.indc_emof_id,
        indc_date: input?.indc_date,
        indc_processed_ausr_id: input?.indc_processed_ausr_id,
        indc_status: input?.indc_status


      }),
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
      });






  }
  return (
    <div>InductionAdd
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="indc_id" label="indc_id" value={input?.indc_id} />
        </Grid>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="indc_emof_id" label="indc_emof_id" value={input?.indc_emof_id} />
        </Grid>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="indc_date" label="indc_date" value={input?.indc_date} />
        </Grid>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="indc_processed_ausr_id" label="indc_processed_ausr_id" value={input?.indc_processed_ausr_id} />
        </Grid>
        <Grid item xs={12}>
          <TextField onChange={handleChange} name="indc_status" label="indc_status" value={input?.indc_status} />
        </Grid>
      </Grid>
      <Button variant="contained" onClick={handlPost}  >Submit</Button>
    </div>
  )
}

export default InductionAdd