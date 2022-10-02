import { Alert, Button, FormControl, Grid, InputLabel, MenuItem, Select, TextField } from '@mui/material'
import { Box } from '@mui/system'
import axios from 'axios'
import React, { useState } from 'react'
import { useDispatch, useSelector } from "react-redux"
import { useNavigate } from 'react-router-dom'
import { changeStatusOfEmployeeForm } from '../redux/action'
function EditEmployee({ editData }) {
  const data = useSelector((state) => state?.employeeData?.employeeData?.data)
  const status = useSelector((state) => state?.employeeData?.edit)
  const[formStatus,setFormStatus]=useState(false)
  // console.log(status)
  const navigate = useNavigate()
  const dispatch=useDispatch()

  //initial state
  const init = {
    empl_photo:"",
    empl_id:"",
    empl_altemail: "",
    empl_firstname: "",
    empl_lastname: "",
    empl_surname: "",
    empl_rmanager_empl_id: "",
    empl_hr_empl_id: 2,
    empl_jbgr_id: "",
    empl_joindate: "",
    empl_dob: "",
    empl_designation: "",
    empl_offemail: "",
    empl_pemail: "",
    empl_mobile: "",
    empl_altemail: "",
    empl_bloodgroup: "",
    empl_gender: "",
    empl_luudate: "",
    empl_luuser: "",
    empl_address: "",
    empl_fathername: "",
    empl_status: '',
    password: ""
  }

  //if status =>from redux is true then add redux stored data in input otherwise add initial state from above
  const [input, setInput] = useState(status ? data : init)


  const handleChange = (e) => {
    const { name, value } = e.target
    setInput({ ...input, [name]: value })

  }
  //function to add data
  const handleSubmit = () => {
    const { 
      empl_id,
      empl_altemail,
      empl_photo,
      empl_firstname,
      empl_lastname,
      empl_surname,
      empl_rmanager_empl_id,
      empl_hr_empl_id,
      empl_jbgr_id,
      empl_joindate,
      empl_dob,
      empl_designation,
      empl_offemail,
      empl_pemail,
      empl_mobile,

      empl_bloodgroup,
      empl_gender,
      empl_luudate,
      empl_luuser,
      empl_address,
      empl_fathername,
      empl_status,
      password } = input

//api to post data(add new data)
    axios.post("/employee/addEmployee", {
empl_id,
empl_photo,
      empl_firstname,
      empl_lastname,
      empl_surname,
      empl_rmanager_empl_id,
      empl_hr_empl_id,
      empl_jbgr_id,
      empl_joindate,
      empl_dob,
      empl_designation,
      empl_offemail,
      empl_pemail,
      empl_mobile,
      empl_altemail,
      empl_bloodgroup,
      empl_gender,
      empl_luudate,
      empl_luuser,
      empl_address,
      empl_fathername,
      empl_status,
      password,
    })
    .then((res) => {

      if (res.status === 201) {
        
        setFormStatus(false)
        alert(res?.data?.message)
        navigate("/employeeData")

      }else{
        alert("some error is there!")
      }


    })

  }

  //function to update data
  function handleUpdate() {


    const { empl_altemail,
      empl_photo,
      empl_firstname,
      empl_lastname,
      empl_surname,
      empl_rmanager_empl_id,
      empl_hr_empl_id,
      empl_jbgr_id,
      empl_joindate,
      empl_dob,
      empl_designation,
      empl_offemail,
      empl_pemail,
      empl_mobile,

      empl_bloodgroup,
      empl_gender,
      empl_luudate,
      empl_luuser,
      empl_address,
      empl_fathername,
      empl_status,
      password } = input

//api to update
    axios.put(`/employee/${data?._id}`, {
      empl_photo,
      empl_firstname,
      empl_lastname,
      empl_surname,
      empl_rmanager_empl_id,
      empl_hr_empl_id,
      empl_jbgr_id,
      empl_joindate,
      empl_dob,
      empl_designation,
      empl_offemail,
      empl_pemail,
      empl_mobile,
      empl_altemail,
      empl_bloodgroup,
      empl_gender,
      empl_luudate,
      empl_luuser,
      empl_address,
      empl_fathername,
      empl_status,
      password,
    })
      .then((res) => {

        if (res.status === 200) {
          alert(res?.data?.msg)
          navigate("/employeeData")

        }else{
          alert("some error is there!")
        }


      })

  }

  return (
    <div>
      <form>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_id" label="Employee ID" value={input.empl_id} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_altemail" label="Alternate Email" value={input.empl_altemail} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_photo" label="Employee Photo" value={input.empl_photo} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_firstname" label="First Name" value={input.empl_firstname} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_lastname" label="Last Name" value={input.empl_lastname} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_surname" label="Surname" value={input.empl_surname} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_rmanager_empl_id" label="Manager Employee ID" value={input.empl_rmanager_empl_id} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_hr_empl_id" label="HR Email ID" value={input.empl_hr_empl_id} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_jbgr_id" label="JBGR ID" value={input.empl_jbgr_id} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_joindate" label="Joining Date" value={input.empl_joindate} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_dob" label="Date Of Birth" value={input.empl_dob} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_designation" label="Designation" value={input.empl_designation} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_offemail" label="Office Email" value={input.empl_offemail} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_pemail" label="Personal Email" value={input.empl_pemail} />
          </Grid>
        
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_mobile" label="Mobile" type="number" value={input.empl_mobile} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_bloodgroup" label="Blood Group" value={input.empl_bloodgroup} />
          </Grid>
          <Grid item xs={4}>
            {/* <Box sx={{ minWidth: 80 }}>
      <FormControl sx={{width:"220px"}}>
        <InputLabel id="demo-simple-select-label">Gender</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={input.empl_gender}
          label="Gender"
          onChange={handleChange}
        >
          <MenuItem value="M">Male</MenuItem>
          <MenuItem value="F">Female</MenuItem>
          <MenuItem value="O">Other</MenuItem>
        </Select>
      </FormControl>
    </Box> */}
            <TextField onChange={handleChange} name="empl_gender" label="Gender" value={input.empl_gender} />

          </Grid>

          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_luudate" label="Last Updated" value={input.empl_luudate} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_luuser" label="Last Updated User" value={input.empl_luuser} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_address" label="Address" value={input.empl_address} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_fathername" label="Father Name" value={input.empl_fathername} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="empl_status" label="status" value={input.empl_status} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="password" label="Password" type="password" value={input.password} />
          </Grid>
        </Grid>
      </form>
      {status ? <Button variant="contained" onClick={handleUpdate}>UPDATE</Button> : <Button variant="contained" onClick={handleSubmit}>ADD</Button>}

    </div>
  )
}

export default EditEmployee
