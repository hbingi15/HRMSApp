import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

import "./EmployeesSidebar.css"
// import { Box } from '@mui/system';
import Body from '../body/Body';
import { Paper } from '@mui/material';
import EmployeeDashboard from '../employeeDashboard/EmployeeDashboard';

export default function EmployeesSidebar() {
   
    //   };

    return (
        <div style={{display:"flex",justifyContent:"space-between",width:"100%"}}>

<Paper sx={{ minWidth: 240, height: 880, marginRight:2,textAlign:"center",marginTop:"10px" }}elevation={4}>
                <FormControl sx={{ width: "180px", marginTop: "20px",  }}>
                    <InputLabel id="demo-simple-select-label">Employees</InputLabel>
                    <Select
                      labelId="demo-simple-select-label"
                      id="demo-simple-select"
                      // value={select}
                      label="select"
                    >
                        <MenuItem value="Admin_text">
                            <em>None</em>
                        </MenuItem>
                        <MenuItem value={"Profile"}>Profile</MenuItem>
                        <MenuItem value={"Attendance"}>Attendance</MenuItem>
                        <MenuItem value={"Leaves"}>Leaves</MenuItem>
                        {/* <MenuItem value={30}>Thirty</MenuItem> */}
                    </Select>
                </FormControl>
                </Paper>
         <EmployeeDashboard/>
        </div>
    );
}
