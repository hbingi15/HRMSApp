import { useAuth0 } from '@auth0/auth0-react'
import { Button } from '@mui/material'
import React from 'react'

function Login() {
  const { loginWithRedirect, isAuthenticated } = useAuth0()
  return (
    !isAuthenticated &&
    <div style={{display:"flex",justifyContent:"center",marginTop:"20%" }}>

      <Button variant='contained' sx={{ color: "black" }} onClick={() => loginWithRedirect()}>
        LOGIN
      </Button>

     
    </div>

  )
}

export default Login
