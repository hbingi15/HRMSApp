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
import { FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { Link, useNavigate } from 'react-router-dom';
import "./Table.css"
import EmployeeDilogbox from '../dialogueBox/EmployeeDilogbox';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import AddIcon from '@mui/icons-material/Add';
import Check from '../user/Check';
import AddEmployeeForm from '../employeeForm/EditEmployeeForm';
import { changeStatusOfEmployeeForm, editEmployeeData } from '../redux/action';
import {useDispatch} from "react-redux"

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



function Employee() {
  const [empData, setEmpData] = useState([])
  const [singleData, setSingleData] = useState([])
  const [open, setOpen] = React.useState(false);
  const [editData,setEditData]=useState({})
  const [isEdit,setIsEdit]=useState(false);
const[deleted,setDeleted]=useState(false)
  const dispatch=useDispatch()
const navigate=useNavigate()


  const handleClick = (data) => {
    setSingleData([data])
    setOpen(true);
    console.log(setSingleData, "data")
  }
  const handleClose = () => {
    setOpen(false);
  };
  console.log(empData)


const handleEdit=(row)=>{
  setIsEdit(true)
setEditData(row)
const payload={
  data:row,
  edit:true,
  count:empData?.length

}
dispatch(editEmployeeData(payload))
navigate("/editEmployee")
}
function handleAdd(){
  dispatch(changeStatusOfEmployeeForm({status:false}))
navigate("/addempdata")

}
//for getting  table data
function getTableData(){
  axios.get("http://localhost:5028/AllUsers")
    .then((res) => {
      console.log(res)
      setEmpData(res?.data)
      
    })
    
}



//function to delete record
const handleDelete=(id)=>{
  axios.delete(`/employee/${id}`)
  .then((res)=>{
    if(res?.data?.status===200){
      alert(res?.data?.message)
      setDeleted(true)
    }else{
      alert(res?.data?.message)
    }
    // navigate("/employeeData")
    //calling delete function to show table again after deleting data
    getTableData()
  })
// console.log(editData)
}

//to show table data when page come forst time
useEffect(() => {
  getTableData()
}, [])
  return (
    <div style={{ display: "flex", width: "100%" }}>
      {/* this is sidebar */}

      <div style={{ display: "flex", justifyContent: "space-between", width: "100%",marginTop:"20px" }}>


        <Paper sx={{ minWidth: 180, height: 580, textAlign: "center" }} elevation={4}>
          <FormControl sx={{ width: "130px", marginTop: "20px", }}>
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

      <div style={{ textAlign: "center", marginRight: "200px",marginLeft:"20px" }}>

        <Paper sx={{ minWidth: 240, textAlign: "center" }} elevation={10}>
          <h1>EMPLOYEES TABLE</h1>

        </Paper >
        <div onClick={handleAdd}  style={{ textDecoration: "none" }}>
        <Paper sx={{textAlign:"center",border:"1px solid red",marginBottom:"10px",padding:"5px",width:"5%",backgroundColor:"#1976d2",color:"white"}} ><AddIcon/></Paper>
        </div>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 700, textAlign: "center" }} aria-label="customized table">
            <TableHead>
              <TableRow >
                <StyledTableCell align="center"> User Name</StyledTableCell>
              
                <StyledTableCell align="center">First Name</StyledTableCell>
                <StyledTableCell align="center">LastName</StyledTableCell>
                <StyledTableCell align="center">Join Date</StyledTableCell>

                <StyledTableCell align="center">Phone</StyledTableCell>
             
                <StyledTableCell align="center">Action</StyledTableCell>












              </TableRow>
            </TableHead>
            <TableBody>
              {empData.map((row) => (
                <StyledTableRow
                   key={row.empl_id}>


                  <StyledTableCell onClick={() => handleClick(row)} align="center">{row?.userName}</StyledTableCell>
                 
                  <StyledTableCell align="center">{row?.firstName}</StyledTableCell>

                  <StyledTableCell align="center">{row?.lastName}</StyledTableCell>
                  <StyledTableCell align="center">{row?.joinDate}</StyledTableCell>

                 
           
                  <StyledTableCell align="center">{row?.phoneNumber
                  }</StyledTableCell>

            
                  <StyledTableCell align="center" sx={{display:"flex"}}>
<div onClick={()=>handleEdit(row)}>

                    <EditIcon />
</div>
<div onClick={()=>handleDelete(row?._id)}>

                    <DeleteIcon/>
</div>
    </StyledTableCell>
                 

   


                </StyledTableRow>
                
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        <EmployeeDilogbox open={open} handleClose={handleClose} singleData={singleData} />
      </div>
    </div>
  )
}

export default Employee






