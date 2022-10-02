// import { useAuth0 } from '@auth0/auth0-react';
import { Button, Grid, Paper, TextField } from "@mui/material";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { updateUserDetails } from "../redux/action";
import axios from "axios";
// import { useState } from 'react';

const Profile = () => {
  // const callAbout = async () => {
  //   try {
  //     const res = await fetch("/user/about", {
  //       method: "GET",
  //       headers: {
  //         Accept: "application/json",
  //         "Content-Type": "application/json",
  //       },
  //       credentials: "include",
  //     });

  //     const data = await res.json();
  //     console.log(data);
  //     // setuserdata(data);

  //     if (!res.status === 200) {
  //       const error = new Error(res.error);
  //       throw error;
  //     }
  //   } catch (err) {
  //     console.log(err);
  //   }
  // };

  // useEffect(() => {
  //   callAbout();
  // }, []);
  const dispatch = useDispatch();
  const userData = useSelector(
    (state) => state?.loggedInData?.LoggedUserData?.LoggedUserData
  );
  const status = useSelector((state) => state?.loggedInData?.status);
  console.log(status);
  const [userDataInput, setUserDataInput] = useState(userData);
  const [edit, setEdit] = useState(status);
  
  const handleChange = (e) => {
    const { name, value } = e.target;
    setUserDataInput({ ...userDataInput, [name]: value });
  };

  function handleUserEdit() {
    fetch(`/user/${userDataInput?._id}`, {
      method: "PUT",
      crossDomain: true,
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        email: userDataInput?.email,
        password: userDataInput?.password,
        fname: userDataInput?.fname,
        lname: userDataInput?.lname,
        offEmail: userDataInput?.offEmail,
        addr: userDataInput?.addr,
        mobile: userDataInput?.mobile,
        userType: userDataInput?.userType,
        dob: userDataInput?.dob,
      }),
    })
      .then((res) => res.json())
      .then((data) => {
        alert(data?.msg);
      });
    // dispatch(updateUserDetails(userDataInput));
  }
  // console.log(userData);

  return (
    <Paper
      sx={{
        width: "30%",
        textAlign: "center",
        marginTop: 10,
        paddingBottom: "20px",
      }}
      elevation={10}
      className="column"
    >
      <Grid container sx={{ marginTop: "20px" }} spacing={2}>
        <Grid item xs={12}>
          <img width="100px" src={userDataInput?.image} alt="image" />
        </Grid>

        <Grid item xs={6}>
          <TextField
            label={"First Name"}
            name="fname"
            value={userDataInput?.fname}
            onChange={handleChange}
            disabled
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label={"Last Name"}
            name="lname"
            value={userDataInput?.lname}
            onChange={handleChange}

            disabled
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label={"Email"}
            name="email"
            value={userDataInput?.email}
            onChange={handleChange}

            disabled
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label={"Office Email"}
            name="offEmail"
            value={userDataInput?.offEmail}
            onChange={handleChange}

            disabled
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label={"Mobile No"}
            name="mobile"
            value={userDataInput?.mobile}
            onChange={handleChange}

            // disabled={!edit}
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label={"Address"}
            name="addr"
            value={userDataInput?.addr}
            onChange={handleChange}

            // disabled={!edit}
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label={"Password"}
            name="password"
            type="password"
            value={userDataInput?.password}
            onChange={handleChange}

            // disabled={!edit}
          />
        </Grid>
      </Grid>
      <Button onClick={handleUserEdit} variant="contained">
        Edit
      </Button>
    </Paper>
  );
};

export default Profile;
