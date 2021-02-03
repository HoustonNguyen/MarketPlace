import { TextField, FormControlLabel, Switch, Grid } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles((theme) => ({
  searchOptionSwitch: {
    paddingLeft: 15
  }
}));

export default function SearchControl(props) {
  const classes = useStyles();
  return (
    <Grid container direction="row" justify="flex-start" alignItems="center">
      <Grid item>
        <TextField
          id="outlined-basic"
          label="Search"
          variant="outlined"
          value={props.searchTerm}
          onChange={props.searchTermChanged}
        />
      </Grid>
      <Grid item>
        <FormControlLabel
          className={classes.searchOptionSwitch}
          control={
            <Switch
              checked={props.enableCaseSensitivity}
              onChange={props.enableCaseSensitivityChanged}
              color="primary"
            />
          }
          label="Case-Sensitive"
        />
      </Grid>
      <Grid item>
        <FormControlLabel
          control={
            <Switch
              checked={props.enableContains}
              onChange={props.enableContainsChanged}
              color="primary"
            />
          }
          label="Contains"
        />
      </Grid>
    </Grid>
  );
}
