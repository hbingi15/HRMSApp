import React from 'react';
import { useAuth0 } from '@auth0/auth0-react';
import { Button } from '@mui/material';
import { Link } from 'react-router-dom';

const Logout = () => {
  const { logout, isAuthenticated } = useAuth0();

  return (
    isAuthenticated && (
      <div style={{ display: "grid", }}>
        <Button sx={{ color: "black" }} onClick={() => logout()}>
          Log Out
        </Button>

        <Link to="/profile" style={{ textDecoration: "none" }}>

          <Button sx={{ color: "black", textAlign: "left" }}>
            Profile
          </Button>
        </Link>
      </div>
    )
  )
}

export default Logout