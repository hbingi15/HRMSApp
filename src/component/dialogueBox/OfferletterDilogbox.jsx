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

export default function OfferletterDilogbox({open,handleClose,singleData}) {
  // const [open, setOpen] = React.useState(false);

  // const handleClickOpen = () => {
  //   setOpen(true);
  // };

  // const handleClose = () => {
  //   setOpen(false);
  // };

  return (
    <div>
      {/* <Button variant="outlined" onClick={handleClickOpen}>
        Slide in alert dialog
      </Button> */}
      <Dialog
        open={open}
        TransitionComponent={Transition}
        keepMounted
        onClose={handleClose}
        aria-describedby="alert-dialog-slide-description"
      >
        {/* <DialogTitle>{"Use Google's location service?"}</DialogTitle> */}
        <DialogContent>
          {/* <DialogContentText id="alert-dialog-slide-description">
            Let Google help apps determine location. This means sending anonymous
            location data to Google, even when no apps are running.
          </DialogContentText> */}
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
                            {singleData.map((row) => (
                                <StyledTableRow key={row.id}>
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
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>CLOSE</Button>
          {/* <Button onClick={handleClose}>Agree</Button> */}
        </DialogActions>
      </Dialog>
    </div>
  );
}
