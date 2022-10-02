import { Alert, Button, Grid,   Paper, TextField} from '@mui/material'

import React, { useState } from 'react'



function ForgotPassword() {

    const [open, setOpen] = React.useState(false);
    
    const [msg,setMsg]=useState()
    const init = {
       
        email: "",
       
       
    };
    const [user, setUser] = useState(init)

    const handleChange = (e) => {
        const { name, value } = e.target
        setUser({ ...user, [name]: value })
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        const { email } = user;
console.log(email)
        fetch("http://localhost:5000/forgot-password", {
            method: "POST",
            crossDomain: true,
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
                "Access-Control-Allow-Origin": "*",
            },
            body: JSON.stringify({
                
                email,
               

            
                
            }),
        })
            .then((res) => res.json())
            .then((data) => console.log(data));
      

    }

    return (
        <Paper sx={{ margin: "20px", height:"500px" }} elevation={3}>

            <Paper sx={{ textAlign: "center", padding: "10px", backgroundColor: "#1976d2", color: "white" }} elevation={3}>FORGOT PASSWORD</Paper>
            <div style={{ display: "flex", width: "100%", margin: "auto" }}>

                <Grid container spacing={2} sx={{ margin: "30px", }}>
                   
                    <Grid item xs={12}>
                        <TextField onChange={handleChange} name="email"
                            value={user.email}

                            label={"Email"} />
                    </Grid>
                   
                  


                </Grid>

                <div sx={{ marginTop: "50px" }}>
                    <img width={"400px"} src="https://img.freepik.com/free-vector/sign-up-concept-illustration_114360-7885.jpg?w=2000" alt='img' />
                </div>
            </div>
            <Grid sx={{ width: "20%", margin: "auto",display:"flex" }}>

            
                <Button
                
                onClick={handleSubmit} sx={{  marginBottom: "50px" }} variant='contained'>Submit</Button>
         
            </Grid>
           
            {open?<Alert severity="success">{msg}</Alert>:null}
            
        </Paper >
    )
}

export default ForgotPassword
