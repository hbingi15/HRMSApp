import { Alert, Button, FormControl, Grid, InputLabel, MenuItem, Paper, Select, TextField} from '@mui/material'
import { Box } from '@mui/system';
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
// import AlertDialogSlide from '../dialogueBox/AlertDialogue';

function Signup() {

    const [open, setOpen] = React.useState(false);
    const [msg, setMsg] = useState()

    const navigate = useNavigate();
    const init = {
        fname: "",
        lname: "",
        email: "",
        password: "",
        userType: "admin"
    };
    const [user, setUser] = useState(init)

    const handleChange = (e) => {
        const { name, value } = e.target
        setUser({ ...user, [name]: value })
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        const { fname, lname, email, password, userType } = user;

        fetch("http://localhost:5000/register", {
            method: "POST",
            crossDomain: true,
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
                "Access-Control-Allow-Origin": "*",
            },
            body: JSON.stringify({
                fname,
                email,
                lname,

                password,
                userType
            }),
        })
            .then((res) => res.json())
            .then((data) => {
                setMsg(data?.msg);
                setOpen(true)
            });
        if (!fname || !lname || !email || !password || !userType) {
            alert("please fill all the details")
        } else {

            navigate("/login")
        }


    }
    const handleLogin = () => {
        navigate("/login")

    }
    console.log(msg)
    return (
        <Paper sx={{ margin: "50px", width: "800px", height: "500px" }} elevation={3}>

            <Paper sx={{ textAlign: "center", padding: "10px", backgroundColor: "#1976d2", color: "white" }} elevation={3}>REGISTERATION</Paper>
            <div style={{ display: "flex", width: "80%", margin: "auto" }}>

                <Grid container spacing={2} sx={{ margin: "20px", }}>
                    <Grid item xs={12}>
                        <TextField onChange={handleChange}
                            name="fname"
                            value={user.fname}
                            label={"First Name"} />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField onChange={handleChange} name="lname"
                            value={user.lname}

                            label={"Last Name"} />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField onChange={handleChange} name="email"
                            value={user.email}

                            label={"Email"} />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField onChange={handleChange} name="password"
                            value={user.password}
                            type="password"
                            label={"Password"} />
                    </Grid>
                    <Grid item xs={12}>
                        <Box sx={{ width: 212 }}>
                            <FormControl fullWidth>
                                <InputLabel id="demo-simple-select-label">Type</InputLabel>
                                <Select
                                    labelId="demo-simple-select-label"
                                    id="demo-simple-select"
                                    value={user.userType}
                                    label="userType"
                                    name="userType"
                                    onChange={handleChange}
                                >
                                    <MenuItem value={"admin"}>Admin</MenuItem>
                                    <MenuItem value={"emp"}>Employee</MenuItem>

                                </Select>
                            </FormControl>
                        </Box>
                    </Grid>


                </Grid>

                <div sx={{ marginTop: "50px" }}>
                    <img width={"400px"} src="https://img.freepik.com/free-vector/sign-up-concept-illustration_114360-7885.jpg?w=2000" alt='img' />
                </div>
            </div>
            <div style={{display:"flex"}}>
                <Grid sx={{ width: "20%", marginLeft:"170px" }}>


                    <Button

                        onClick={handleSubmit} sx={{ marginBottom: "50px",marginRight:"100px"  }} variant='contained'>Register</Button>
                </Grid>
                <Grid sx={{ margin: "auto", display: "flex", width: "60%", color: "green" }}>

                    {/* <Typography sx={{ marginTop: "8px" }}>Already Have An Account?</Typography> */}
                    <Button

                        onClick={handleLogin} sx={{ marginBottom: "50px", marginLeft: "80px" }} variant='contained'> Admin Login</Button>
                </Grid>
                <Grid sx={{ margin: "auto", display: "flex", width: "60%", color: "green" }}>

                    {/* <Typography sx={{ marginTop: "8px" }}>Already Have An Account?</Typography> */}
                    <Button

                        onClick={handleLogin} sx={{ marginBottom: "50px", marginLeft: "10px" }} variant='contained'>Employee Login</Button>
                </Grid>
            </div>

            {open ? <Alert severity="success">{msg}</Alert> : null}

        </Paper >
    )
}

export default Signup
