import { Alert, Button, Grid, Paper, TextField } from "@mui/material";
import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { loggedUserData } from "../redux/action";

function Login({ type }) {
  const [open, setOpen] = React.useState(false);
  const [msg, setMsg] = useState();
  const [userData, setUserData] = useState();
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const init = {
    UserName: "",
    Password: "",
  };
  const [user, setUser] = useState(init);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const { UserName, Password } = user;

    fetch("http://localhost:5028/User/Login", {
      method: "POST",
      crossDomain: true,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        UserName,

        Password,
      }),
    })
      .then((res) => res.json())
      .then((data) => {
        console.log(data,"data")
        // setMsg(data?.msg);
        // setOpen(true);

        // dispatch(loggedUserData(data));
        // if (data?.data.userType === "admin") {
        //   navigate("/admin");
        // } else if (data?.data?.userType === "emp") {
        //   navigate("/employee");
        // }
      });
  };
  console.log(msg);
  return (
    <Paper
      sx={{
        margin: "50px",
        marginBottom: "-30px",
        width: "800px",
        height: "500px",
      }}
      elevation={3}
    >
      <Paper
        sx={{
          textAlign: "center",
          padding: "10px",
          backgroundColor: "#1976d2",
          color: "white",
        }}
        elevation={3}
      >
        {type}LOGIN
      </Paper>
      <div style={{ display: "flex", width: "80%", margin: "auto" }}>
        <Grid container spacing={2} sx={{ margin: "30px" }}>
          <Grid item xs={12}>
            <TextField
              onChange={handleChange}
              name="UserName"
              value={user.UserName}
              label={"UserName"}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              onChange={handleChange}
              name="Password"
              value={user.Password}
              type="Password"
              label={"Password"}
            />
          </Grid>
          <Grid item xs={12}>
            <Alert severity="success">{msg}</Alert>
          </Grid>
        </Grid>

        <div sx={{ marginTop: "50px" }}>
          <img
            width={"400px"}
            src="https://img.freepik.com/free-vector/mobile-login-concept-illustration_114360-83.jpg?w=2000"
            alt="img"
          />
        </div>
      </div>

      <Grid sx={{ marginLeft: "180px", display: "flex" }}>
        <Button
          onClick={handleSubmit}
          sx={{ marginBottom: "50px", marginRight: "50px" }}
          variant="contained"
        >
          Login
        </Button>

        <Link to="forgot-Password" style={{ textDecoration: "none" }}>
          <Button
            sx={{ marginBottom: "50px", width: "150%", marginLeft: "50px" }}
            variant="contained"
          >
            Change Password
          </Button>
        </Link>
      </Grid>
    </Paper>
  );
}

export default Login;
