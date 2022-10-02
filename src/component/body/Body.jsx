import { Paper, Typography } from '@mui/material'
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import PeopleIcon from '@mui/icons-material/People';
import DomainIcon from '@mui/icons-material/Domain';
function Body() {

    const [empData,setEmpData]=useState([])
    const [empData2,setEmpData2]=useState([])

    useEffect(()=>{
      axios.get("/employee")
      .then((res) => {
        setEmpData(res?.data?.employeeData)
        
      })
    },[])
    useEffect(()=>{
        axios.get("https://reqres.in/api/users?page=2")
        .then((res)=>setEmpData2(res.data.data))
    },[])
  return (
    <div  style={{display:"flex",width:"40%",justifyContent:"space-between",margin:"auto",marginTop:"50px"}}>
      <Paper sx={{width:"200px",textAlign:"center"}} elevation={10}>
        <Link to="/admin/employeeData" style={{textDecoration:"none"}}>
            <PeopleIcon sx={{marginTop:"10px"}}/>
        <Typography >
            
        Employee
        </Typography>
        <p style={{width:"40px",marginLeft:"85px",height:"30px",paddingTop:"10px",borderRadius:"50%" ,border:"1px solid green",textAlign:"center",backgroundColor:"blue",color:"white",textDecoration:"none"}}>{empData?.length}</p>
        </Link>
      </Paper >
      <Paper sx={{width:"200px",textAlign:"center"}} elevation={3}>
        <Link to="/admin/departmentData" style={{textDecoration:"none"}}>
            <DomainIcon sx={{marginTop:"10px"}}/>
        <Typography>
            
        Department
        </Typography>
        <p style={{width:"40px",marginLeft:"85px",height:"30px",paddingTop:"10px",borderRadius:"50%" ,border:"1px solid green",textAlign:"center",backgroundColor:"blue",color:"white",textDecoration:"none"}}>{empData2?.length}</p>
        </Link>
      </Paper >
      
    </div>
  )
}

export default Body
