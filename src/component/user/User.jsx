import { useAuth0 } from '@auth0/auth0-react'
import { Avatar, Box, IconButton, Menu, MenuItem, Tooltip, Typography } from '@mui/material'
import React from 'react'
import { Link } from 'react-router-dom';
// import { Link } from 'react-router-dom'



function User() {


  const [anchorElUser, setAnchorElUser] = React.useState(null);


  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };



  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };
  const { user } = useAuth0();

  return (
    <div>
      <Box sx={{ flexGrow: 0 }}>
        <Tooltip title="Open settings">
          <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
            <Avatar alt="user" src={user?.picture} />
          </IconButton>
        </Tooltip>
        <Menu
          sx={{ mt: '45px' }}
          id="menu-appbar"
          anchorEl={anchorElUser}
          anchorOrigin={{
            vertical: 'top',
            horizontal: 'right',

          }}
          keepMounted
          transformOrigin={{
            vertical: 'top',
            horizontal: 'right',
          }}
          open={Boolean(anchorElUser)}
          onClose={handleCloseUserMenu}
        >

          <Link to="Profile" style={{ textDecoration: "none" }}>
            <MenuItem onClick={handleCloseUserMenu}>
              <Typography >
                PROFILE
              </Typography>



        </MenuItem>
          </Link>
        <Link to="Signup" style={{ textDecoration: "none" }}>
          <MenuItem onClick={handleCloseUserMenu}>
            <Typography>LOGOUT</Typography>

          </MenuItem>
        </Link>

      </Menu>
    </Box>
    </div >
  )
}

export default User
