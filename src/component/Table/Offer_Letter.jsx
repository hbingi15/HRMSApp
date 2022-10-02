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
import OfferletterDilogbox from '../dialogueBox/OfferletterDilogbox';





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



function Offer_Letter() {
    const [empData, setEmpData] = useState([])
    const [singleData, setSingleData] = useState([])
    const [open, setOpen] = React.useState(false);

    useEffect(() => {
        axios.get("http://localhost:5028/EmployeeOfferLetterControllerr/V1/AllEmployeeOfferLetter")
            .then((res) => setEmpData(res.data))
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
        <div style={{ display: "flex", width: "100%" }}>
            {/* this is sidebar */}

            <div style={{ display: "flex", justifyContent: "space-between", width: "100%" }}>


                <Paper sx={{ minWidth: 240, height: 580, textAlign: "center" }} elevation={4}>
                    <FormControl sx={{ width: "180px", marginTop: "20px", }}>
                        <InputLabel id="demo-simple-select-label">Select</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            // value={select}
                            label="select"
                        // onChange={handleChange}

                        >

                            <Link to="/employeeData" style={{ textDecoration: "none" }}>
                                <MenuItem value={"Employees"}>Employees </MenuItem>
                            </Link>
                            <Link to="/departmentData" style={{ textDecoration: "none" }}>
                                <MenuItem value={"Department"}>Department</MenuItem>
                            </Link>
                            <Link to="/Induction" style={{ textDecoration: "none" }}>
                                <MenuItem value={"Induction"}>Induction</MenuItem>
                            </Link>
                            <Link to="/offerletter" style={{ textDecoration: "none" }}>
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

            </div>
            {/* this is INDUCTION TABLE */}

            <div style={{ textAlign: "center", marginRight: "200px" }}>

                <Paper sx={{ minWidth: 240, textAlign: "center" }} elevation={10}>
                    <h1>OFFER LETTER </h1>

                </Paper >
                <div>
                    <Button sx={{ marginBottom: "10px", width: "70px", marginLeft: " 600px" }}
                        variant="contained" elevation={10}> ADD </Button>
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700, textAlign: "center" }} aria-label="customized table">
                        <TableHead>
                            <TableRow >
                                <StyledTableCell align="center"> eofr_ref_id </StyledTableCell>
                                <StyledTableCell align="center"> eofr_cand_id </StyledTableCell>
                                <StyledTableCell align="center"> eofr_offerdat</StyledTableCell>
                                <StyledTableCell align="center">eofr_offeredjob</StyledTableCell>
                                <StyledTableCell align="center">eofr_reportingdate </StyledTableCell>
                                <StyledTableCell align="center">eofr_status</StyledTableCell>

                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {empData.map((row) => (
                                <StyledTableRow onClick={() => handleClick(row)} key={row.id}>
                                    <StyledTableCell align="center" component="th" scope="row" >
                                        {row.eofr_ref_id}
                                    </StyledTableCell>


                                    <StyledTableCell align="center">{row.eofr_cand_id}</StyledTableCell>
                                    <StyledTableCell align="center">{row.eofr_offerdat}</StyledTableCell>
                                    <StyledTableCell align="center">{row.eofr_offeredjob}</StyledTableCell>
                                    <StyledTableCell align="center">{row.eofr_reportingdate}</StyledTableCell>
                                    <StyledTableCell align="center">{row.eofr_status}</StyledTableCell>


                                </StyledTableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
                <OfferletterDilogbox open={open} handleClose={handleClose} singleData={singleData} />
            </div>
        </div>
    )
}

export default Offer_Letter



