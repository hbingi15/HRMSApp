import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import Slide from '@mui/material/Slide';
import { styled } from '@mui/material/styles';
import { tableCellClasses } from '@mui/material/TableCell';

import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';



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

const Transition = React.forwardRef(function Transition(props, ref) {
  return <Slide direction="up" ref={ref} {...props} />;
});

export default function EmployeeDilogbox({open,handleClose,singleData}) {
  // const [open, setOpen] = React.useState(false);

  // const handleClickOpen = () => {
  //   setOpen(true);
  // };

  // const handleClose = () => {
  //   setOpen(false);
  // };

  return (
    <div>
      
      <Dialog
        open={open}
        TransitionComponent={Transition}
        keepMounted
        onClose={handleClose}
        aria-describedby="alert-dialog-slide-description"
       
      >
       
        <DialogContent>
          
 <TableContainer component={Paper}>
          <Table sx={{ minWidth: 700, textAlign: "center" }} aria-label="customized table">
            <TableHead>
              <TableRow >
              
              <StyledTableCell align="center">First Name</StyledTableCell>
              <StyledTableCell align="center">LastName</StyledTableCell>
              <StyledTableCell align="center">User Level</StyledTableCell>
              <StyledTableCell align="center">Join Date</StyledTableCell>
              <StyledTableCell align="center"> User Name</StyledTableCell>
              <StyledTableCell align="center"> normalizedUserName</StyledTableCell>
              <StyledTableCell align="center"> email</StyledTableCell>
              <StyledTableCell align="center"> normalizedEmail</StyledTableCell>
              <StyledTableCell align="center"> emailConfirmed</StyledTableCell>
              <StyledTableCell align="center"> phoneNumber</StyledTableCell>
              <StyledTableCell align="center"> phoneNumberConfirmed</StyledTableCell>
              <StyledTableCell align="center"> twoFactorEnabled</StyledTableCell>
              <StyledTableCell align="center"> lockoutEnd</StyledTableCell>
              <StyledTableCell align="center"> lockoutEnabled</StyledTableCell>
              <StyledTableCell align="center"> accessFailedCount</StyledTableCell>

             
           
           

              </TableRow>
            </TableHead>
            <TableBody>
              {singleData.map((row) => (
                <StyledTableRow  key={row.empl_id}>
                 
                 
                  <StyledTableCell align="center">{row.firstName}</StyledTableCell>
                  <StyledTableCell align="center">{row.lastName}</StyledTableCell>
                  <StyledTableCell align="center">{row.userLevel}</StyledTableCell>
                  <StyledTableCell align="center">{row.joinDate}</StyledTableCell>
                  <StyledTableCell align="center">{row.userName}</StyledTableCell>
                  <StyledTableCell align="center">{row.normalizedUserName}</StyledTableCell>
                  <StyledTableCell align="center">{row.email}</StyledTableCell>
                  <StyledTableCell align="center">{row.normalizedEmail
                  }</StyledTableCell>
                  <StyledTableCell align="center">{row.emailConfirmed
                  }</StyledTableCell>
                  <StyledTableCell align="center">{row.phoneNumber}</StyledTableCell>
                  <StyledTableCell align="center">{row.phoneNumberConfirmed
                  }</StyledTableCell>

                  <StyledTableCell align="center">{row.twoFactorEnabled}</StyledTableCell>
                  <StyledTableCell align="center">{row.lockoutEnd}</StyledTableCell>
                  <StyledTableCell align="center">{row.lockoutEnabled
                  }</StyledTableCell>
                  <StyledTableCell align="center">{row.accessFailedCount
                  }</StyledTableCell>
                 


                </StyledTableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>CLOSE</Button>
         
        </DialogActions>
      </Dialog>
    </div>
  );
}
