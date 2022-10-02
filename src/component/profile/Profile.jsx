import { useAuth0 } from '@auth0/auth0-react';
import { Button, Paper, TextField } from '@mui/material';
import { useState } from 'react';

const Profile = () => {
    const { user, isAuthenticated } = useAuth0();

    const [userData, setUserData] = useState(user)

    const handleChange = (e) => {
        setUserData(e.target.value)
    }
    return (
        isAuthenticated && (
            <Paper sx={{height:"430px", width: "30%",textAlign:"center", marginTop:10}} elevation={10} className='column'>
                <div style={{ width: "30%", margin: "auto" ,padding:"20px" }}>

                    {user?.picture && <img style={{ borderRadius: "50%" }} src={user.picture} alt={user?.name} />}
                </div>
                {/* <h2>{user?.name}</h2> */}
                <label>Name</label>
                <br /><TextField name="name" value={userData.nickname} />
                <br />
                <br></br>
                <label>Email</label>
                <br></br>
                <TextField name="email" value={userData.name} onChange={handleChange} />
                <br></br>
                <br></br>
                <Button sx={{backgroundColor:"ButtonShadow",marginBottom:"10px"}} elevation={10}>Edit Profile</Button>

                {/* <ul>
                    {Object.keys(user).map((objKey, i) => <li key={i}>{objKey}: {user[objKey]} </li>)}
                </ul> */}
            </Paper>
        )
    )
}

export default Profile