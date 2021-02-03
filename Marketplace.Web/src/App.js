import './App.css';
import React from "react";
import { Box, AppBar, Tabs, Tab } from '@material-ui/core';
import TitleSearch from './Pages/TitleView';
import About from './Pages/About';

//https://material-ui.com/components/tabs/
function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box p={3}>
          {children}
        </Box>
      )}
    </div>
  );
}

function tabProperties(index) {
  return {
    id: `simple-tab-${index}`,
    'aria-controls': `simple-tabpanel-${index}`,
  };
}

function App() {
  const [value, setValue] = React.useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
      <div className="App">
        <AppBar position="static">
          <Tabs value={value} onChange={handleChange} aria-label="simple tabs example">
            <Tab label="Titles" {...tabProperties(0)} />
            <Tab label="About" {...tabProperties(1)} />
          </Tabs>
        </AppBar>
        <TabPanel value={value} index={0}>
          <TitleSearch />
        </TabPanel>
        <TabPanel value={value} index={1}>
          <About />
        </TabPanel>
      </div>
  );
}

export default App;
