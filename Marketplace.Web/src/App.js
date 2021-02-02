import './App.css';
import { makeStyles } from '@material-ui/core/styles';
import { AppBar, IconButton, Typography, Toolbar, Menu, MenuItem } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link as RouterLink
} from "react-router-dom";
import TitleSearch from './Pages/TitleView';
import About from './Pages/About';
import { useState } from 'react';
import { AccountCircle } from '@material-ui/icons';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
}));

function App() {
  const [profileMenu, setProfileMenu] = useState();

  const classes = useStyles();
  return (
    <Router>
      <div className="App">
        <AppBar position="static">
          <Toolbar>
            <IconButton edge="start" className={classes.menuButton} color="inherit" aria-label="menu">
              <MenuIcon />
            </IconButton>
            <Menu
              id="profile-menu"
              open={Boolean(profileMenu)}
              anchorEl={profileMenu}
              onClose={() => setProfileMenu(null)}
              disableAutoFocusItem
            >
              <MenuItem
                component={RouterLink}
                onClick={() => setProfileMenu(null)}
                to="/About"
              >
                <AccountCircle /> Change Password
              </MenuItem>
              <MenuItem
                component={RouterLink}
                onClick={() => setProfileMenu(null)}
                to="/Home"
              >
                <AccountCircle /> Edit Profile
              </MenuItem>
            </Menu>
            <Typography variant="h6" className={classes.title}>
              Main
            </Typography>
            {/* <Button color="inherit">Login</Button> */}
          </Toolbar>
        </AppBar>
        <Switch>
          <Route path="/about">
            <About />
          </Route>
          <Route path="/">
            <TitleSearch />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
