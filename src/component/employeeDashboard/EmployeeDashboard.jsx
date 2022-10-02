import { Grid, Paper, Typography } from '@mui/material'
import React from 'react'
import { EmployeeCharts } from '../charts/EmployeeCharts'
import { LeavesGraph } from '../charts/LeavesGraph'

function EmployeeDashboard() {
    return (
        <Paper sx={{ marginTop: "10px" }} >
            <Paper sx={{ textAlign: "center", padding: "10px", backgroundColor: "#1976d2", color: "white" }}>Employee Dashboard</Paper>

            <Grid sx={{ textAlign: "center", padding: "50px" }} container spacing={2}>
                <Grid item xs={4}>

                    <Paper sx={{ paddingBottom: "10px" }} elevation={10} >
                        <Typography sx={{ marginTop: "20px" }}>No of leaves</Typography>
                        <Typography sx={{ marginBottom: "20px", color: "red", fontWeight: 100 }}>Current Month</Typography>
                        <h1 style={{ width: "40px", height: "40px", marginBottom: "10px", borderRadius: "50%", backgroundColor: "blue", color: "white", textAlign: "center", margin: "auto" }}>10</h1>


                    </Paper>
                </Grid>
                <Grid item xs={4}>

                    <Paper sx={{ paddingBottom: "10px" }} elevation={10} >
                        <Typography sx={{ marginTop: "20px" }}>No of Paid leaves</Typography>
                        <Typography sx={{ marginBottom: "20px", color: "red", fontWeight: 100 }}>Since Joining</Typography>
                        <h1 style={{ width: "40px", height: "40px", marginBottom: "10px", borderRadius: "50%", backgroundColor: "blue", color: "white", textAlign: "center", margin: "auto" }}>5</h1>


                    </Paper>
                </Grid>
                <Grid item xs={4}>
                    <Paper sx={{ paddingBottom: "10px" }} elevation={10} >
                        <Typography sx={{ marginTop: "20px" }}>No of Permission</Typography>
                        <Typography sx={{ marginBottom: "20px", color: "red", fontWeight: 100 }}>Current Month</Typography>
                        <h1 style={{ width: "40px", height: "40px", marginBottom: "10px", borderRadius: "50%", backgroundColor: "blue", color: "white", textAlign: "center", margin: "auto" }}>10</h1>


                    </Paper>
                </Grid>
                <Grid item xs={4}>
                    <Paper sx={{ paddingBottom: "10px" }} elevation={10} >
                        <Typography sx={{ marginTop: "20px" }}>No of Earned Leaves</Typography>
                        <Typography sx={{ marginBottom: "20px", color: "red", fontWeight: 100 }}>Current Month</Typography>
                        <h1 style={{ width: "40px", height: "40px", marginBottom: "10px", borderRadius: "50%", backgroundColor: "blue", color: "white", textAlign: "center", margin: "auto" }}>10</h1>


                    </Paper>
                </Grid>
                <Grid item xs={4}>
                    <Paper sx={{ paddingBottom: "10px" }} elevation={10} >
                        <Typography sx={{ marginTop: "20px" }}>Average Punchin Time</Typography>
                        <Typography sx={{ marginBottom: "20px", color: "red", fontWeight: 100 }}>Current Month</Typography>
                        <h1 style={{ width: "40px", height: "40px", marginBottom: "10px", borderRadius: "50%", backgroundColor: "blue", color: "white", textAlign: "center", margin: "auto" }}>10</h1>


                    </Paper>
                </Grid>
                <Grid item xs={4}>
                    <Paper sx={{ paddingBottom: "10px" }} elevation={10} >
                        <Typography sx={{ marginTop: "20px" }}>Average Punch Out time</Typography>
                        <Typography sx={{ marginBottom: "20px", color: "red", fontWeight: 100 }}>Current Month</Typography>
                        <h1 style={{ width: "40px", height: "40px", marginBottom: "10px", borderRadius: "50%", backgroundColor: "blue", color: "white", textAlign: "center", margin: "auto" }}>10</h1>


                    </Paper>
                </Grid>
                <Grid item xs={6}>
                    <Paper elevation={10}>

                        <EmployeeCharts />
                    </Paper>

                </Grid>
                <Grid item xs={6}>
                    <Paper elevation={10}>

                        <LeavesGraph />
                    </Paper>


                </Grid>
            </Grid>


        </Paper>
    )
}

export default EmployeeDashboard
