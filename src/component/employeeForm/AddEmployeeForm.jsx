import { Alert, Button, FormControl, Grid, InputLabel, MenuItem, Select, TextField } from '@mui/material'
import { Box } from '@mui/system'
import axios from 'axios'
import React, { useState } from 'react'
import { useDispatch, useSelector } from "react-redux"
import { useNavigate } from 'react-router-dom'
import { changeStatusOfEmployeeForm } from '../redux/action'

import validator from 'validator'
function AddEmployeeForm({ editData }) {
  const data = useSelector((state) => state?.employeeData?.employeeData?.data)
  const status = useSelector((state) => state?.employeeData?.edit)
  const[formStatus,setFormStatus]=useState(false)
  // console.log(status)
  const navigate = useNavigate()
  const dispatch=useDispatch()
  const [errorMessage, setErrorMessage] = useState('')



  //initial state
  const init = {
    userName:"",
    firstName:"",
    lastName: "",
    surName: "",
    joinDate: "",
    dob: "",
    designation: "",
    personalEmail: "",
    address: "",

    fatherName: "",
    gender: "",
    password: "",
    phoneNumber: ""
  }

  //if status =>from redux is true then add redux stored data in input otherwise add initial state from above
  const [input, setInput] = useState(status ? data : init)


  const handleChange = (e) => {
    const { name, value } = e.target

    
    

    setInput({ ...input, [name]: value })
    if(name==="password"){
        if (validator.isStrongPassword(e.target.value , {
            minLength: 8, minLowercase: 1,
            minUppercase: 1, minNumbers: 1, minSymbols: 1
          })) {
            setErrorMessage('Valid Password')
          } else {
            setErrorMessage('Password Should Contain At leaset 1 number,1special charac.1 uppercase,1lowercase')
          }
    }
  


  }
  //function to add data
  const handleSubmit = () => {
    const { 

        userName,
        firstName,
        lastName,
        surName,
        joinDate,
        dob,
        designation,
        personalEmail,
        address,
    
        fatherName,
        gender,
        password,
        phoneNumber
      } = input

//api to post data(add new data)
    axios.post("http://localhost:5028/Create/User", {

        userName,
        firstName,
        lastName,
        surName,
        joinDate,
        dob,
        designation,
        personalEmail,
        address,
    
        fatherName,
        gender,
        password,
        phoneNumber
    })
    .then((res) => {

      if (res.status === 200) {
        
        setFormStatus(false)
        alert(res?.data)
        console.log(res)
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
            <TextField onChange={handleChange} name="userName" label="User Name" value={input.userName} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="firstName" label="First Name" value={input.firstName} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="lastName" label="Last Name" value={input.lastName} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="surName" label="Surname" value={input.surName} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="joinDate" label="Join Date" value={input.joinDate} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="dob" label="Date Of Birth" value={input.dob} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="designation" label="Designation" value={input.designation} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="personalEmail" label="Personal Email ID" value={input.personalEmail} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="address" label="Address" value={input.address} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="fatherName" label="Father Name" value={input.fatherName} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="gender" label="Gender" value={input.gender} />
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="password" label="Password" value={input.password} />
            <br/>
            {errorMessage === '' ? null :
        <span style={{
          fontWeight: 'bold',
          color: 'red',
        }}>{errorMessage}</span>}
          </Grid>
          <Grid item xs={4}>
            <TextField onChange={handleChange} name="phoneNumber" label="Phone Number" value={input.phoneNumber} />
          </Grid>
        </Grid>
      </form>
       <Button variant="contained" onClick={handleSubmit}>SUBMIT</Button> 

    </div>
  )
}

export default AddEmployeeForm
