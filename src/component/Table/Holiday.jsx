import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

import { Button, FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { Link } from 'react-router-dom';
import LeavesDilogbox from '../dialogueBox/LeavesDilogbox';





const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));



function Holiday() {
  const [empData, setEmpData] = useState([])
  const [singleData, setSingleData] = useState([])
  const [open, setOpen] = React.useState(false);

  useEffect(() => {
    axios.get("/holiday")
      .then((res) => setEmpData(res?.data?.holidayData))
  }, [])

  const handleClick = (data) => {
    setSingleData([data])
    setOpen(true);
    console.log(data, "data")
  }
  const handleClose = () => {
    setOpen(false);
  };
  console.log(empData)
  return (
  

      <div style={{ textAlign: "center", marginRight:"200px" }}>

        <Paper sx={{ minWidth: 240, textAlign: "center" }} elevation={10}>
          <h1>Holiday List</h1>

        </Paper >
       
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 700, textAlign: "center" }} aria-label="customized table">
            
            <TableHead>
              <TableRow >
                <StyledTableCell align="center"> Year</StyledTableCell>
                <StyledTableCell align="center"> Date</StyledTableCell>
                <StyledTableCell align="center">Title</StyledTableCell>
                <StyledTableCell align="center"> Type</StyledTableCell>
               
    

              </TableRow>
            </TableHead>
            <TableBody>
              {empData?.map((row) => (
                <StyledTableRow onClick={() => handleClick(row)} key={row.id}>
                 
                  <StyledTableCell align="center" component="th" scope="row">
                    {row?.year_id}
                  </StyledTableCell>
                  <StyledTableCell align="center">{row?.hday_date}</StyledTableCell>
                  <StyledTableCell align="center">{row?.hday_title}</StyledTableCell>
                  <StyledTableCell align="center">{row?.hday_type}</StyledTableCell>
                  

                </StyledTableRow>
                         
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        <LeavesDilogbox open={open} handleClose={handleClose} singleData={singleData} />
      </div>
   
  )
}



export default Holiday