import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import { Link } from 'react-router-dom';
import Body from '../body/Body';
import { Paper } from '@mui/material';

export default function SideBar() {
    const [select, setSelect] = React.useState('');

    const handleChange = (event) => {
        setSelect(event.target.value);
    };

    console.log(select)
    return (
        <div style={{ display: "flex", justifyContent: "space-between", width: "100%" }}>

            {/* {select==="admin"?<Admin/>:select==="emp"?<EmployeesSidebar/>: */}
            <Paper sx={{ minWidth: 240, height: 570,  textAlign: "center" }} elevation={10}>
                <FormControl sx={{ width: "180px", marginTop: "20px", }}>
                    <InputLabel id="demo-simple-select-label">Select</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={select}
                        label="select"
                        onChange={handleChange}

                    >
                        <Link to="/admin" style={{ textDecoration: "none", color: "black" }}>
                            <MenuItem value={"admin"}>
                                Admin
                            </MenuItem>
                        </Link>
                        <Link to="/employee" style={{ textDecoration: "none", color: "black" }}>
                            <MenuItem value={"emp"}>
                                Employee</MenuItem>
                        </Link>

                    </Select>
                </FormControl>
            </Paper>
            <Body />
            {/* } */}
        </div>

    );
}
