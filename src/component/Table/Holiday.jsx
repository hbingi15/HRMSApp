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
import EditIcon from '@mui/icons-material/Edit';
import { Button, FormControl, InputLabel, MenuItem, Select, TablePagination } from '@mui/material';
import { Link, useNavigate } from 'react-router-dom';
import LeavesDilogbox from '../dialogueBox/LeavesDilogbox';
import AddIcon from '@mui/icons-material/Add';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { changeStatusOfHolidayForm, editHolidayData } from '../redux/action';
import { useDispatch } from 'react-redux';



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
  const [holidayData, setHolidayData] = useState([])
  const [singleData, setSingleData] = useState([])
  const [open, setOpen] = React.useState(false);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const [page, setPage] = React.useState(0);
  const [isEdit,setIsEdit]=useState(false);
  const [editData,setEditData]=useState({})
const dispatch=useDispatch();
const navigate=useNavigate()
  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };
  useEffect(() => {
    axios.get("http://localhost:5028/Holyday/V1/AllHolydays")
      .then((res) => setHolidayData(res?.data))
  }, [])

  const handleClick = (data) => {
    setSingleData([data])
    setOpen(true);
    console.log(data, "data")
  }
  const handleClose = () => {
    setOpen(false);
  };
  console.log(holidayData)


  const handleEdit=(row)=>{
    setIsEdit(true)
  setEditData(row)
  const payload={
    data:row,
    edit:true,
    count:holidayData?.length
  
  }
  dispatch(editHolidayData(payload))
  navigate("/editHoliday")
  }
  function handleAdd(){
    dispatch(changeStatusOfHolidayForm({status:false}))
  navigate("/editHoliday")
  
  }

  
  return (
  

      <div style={{ textAlign: "center", marginRight:"200px" }}>

        <Paper sx={{ minWidth: 240, textAlign: "center" }} elevation={10}>
          <h1>Holiday List</h1>

        </Paper >
       
       <div style={{marginBottom:"10px",display:"flex",justifyContent:"space-between"}}>
       <Link to="/employeeData" style={{ textDecoration: "none" }}>
                <Button  variant="contained" ><ArrowBackIcon/> </Button >
              </Link>
      
                <Button onClick={handleAdd} variant="contained" ><AddIcon/> </Button >
           
       </div>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 700, textAlign: "center" }} aria-label="customized table">
            
            <TableHead>
              <TableRow >
                <StyledTableCell align="center"> Year</StyledTableCell>
                <StyledTableCell align="center"> Date</StyledTableCell>
                <StyledTableCell align="center">Title</StyledTableCell>
                <StyledTableCell align="center"> Type</StyledTableCell>
                <StyledTableCell align="center"> Action</StyledTableCell>
               
    

              </TableRow>
            </TableHead>
            <TableBody>
              {holidayData?.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)?.map((row) => (
                <StyledTableRow  key={row.id}>
                 
                  <StyledTableCell onClick={() => handleClick(row)} align="center" component="th" scope="row">
                    {row?.year_id}
                  </StyledTableCell>
                  <StyledTableCell align="center">{row?.hday_date}</StyledTableCell>
                  <StyledTableCell align="center">{row?.hday_title}</StyledTableCell>
                  <StyledTableCell align="center">{row?.hday_type}</StyledTableCell>
                  <StyledTableCell align="center" onClick={()=>handleEdit(row)}><EditIcon/></StyledTableCell>
                  

                </StyledTableRow>
                         
              ))}
            </TableBody>
          </Table>
        </TableContainer>

        <TablePagination
          rowsPerPageOptions={[5, 10, 25]}
          component="div"
          count={holidayData.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
        <LeavesDilogbox open={open} handleClose={handleClose} singleData={singleData} />
      </div>
   
  )
}



export default Holiday