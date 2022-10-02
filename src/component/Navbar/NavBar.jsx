import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import HomeIcon from '@mui/icons-material/Home';
import { Link } from 'react-router-dom';

import User from '../user/User';
export default function NavBar() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
            
          >
           
<Link to="/"  style={{textDecoration:"none",color:"white"}}>

            <HomeIcon  />
</Link>
           
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1,textAlign:"center" }}>
          Human Resource Management System
          </Typography>
         
          <User />
        
        </Toolbar>
      </AppBar>
    </Box>
  );
}
