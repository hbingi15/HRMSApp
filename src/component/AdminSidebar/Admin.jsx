import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
// import { border, color } from '@mui/system';
import "./Admin.css"
import { Paper } from '@mui/material';
import Body from '../body/Body';
import { Link } from 'react-router-dom';

export default function Admin() {
   

    return (

<div style={{display:"flex",justifyContent:"space-between",width:"100%"}}>


<Paper sx={{ minWidth: 240, height: 580, marginLeft:1 ,textAlign:"center" }}elevation={4}>
                <FormControl sx={{ width: "180px", marginTop: "20px",  }}>
          <InputLabel id="demo-simple-select-label">Select</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            // value={select}
            label="select"
            // onChange={handleChange}
            
          >
      
             <Link to="/employeeData" style={{textDecoration:"none"}}>
                       <MenuItem value={"Employees"}>Employees </MenuItem>
             </Link>
             <Link to="/departmentData" style={{textDecoration:"none"}}>
             <MenuItem value={"Department"}>Department</MenuItem>
             </Link>
             <Link to="/Induction" style={{textDecoration:"none"}}>
             <MenuItem value={"Induction"}>Induction</MenuItem>
             </Link>
             <Link to="/offerletter" style={{textDecoration:"none"}}>
             <MenuItem value={"Offer Letter"}>Offer Letter</MenuItem>
             </Link>
             <Link to="/Leaves" style={{ textDecoration: "none" }}>
              <MenuItem value={"Leaves"}>Leaves</MenuItem>

              </Link>
                       
                      
                       <MenuItem value={"Attendance"}>Attendance</MenuItem>
                       {/* <MenuItem value={30}>Thirty</MenuItem> */}
            
          </Select>
        </FormControl>
      </Paper>
      <Body/>
</div>
    );
}
