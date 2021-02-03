import React, { useEffect, useState } from "react";
import {
  Fade,
  Grid,
  LinearProgress,
  Modal,
  Paper,
  Typography,
  Backdrop
} from "@material-ui/core";
import TitleService from "../Services/TitleService";
import StringHelpers from "../Helpers/StringHelpers";
import SearchControl from "../Components/SearchControl";
import TitleTable from "../Components/TitleTable";
import TitleDetails from "../Components/TitleDetails";
import Alert from '@material-ui/lab/Alert';
import { makeStyles } from "@material-ui/core/styles";
import { AlertTitle } from "@material-ui/lab";
import { useSelector, useDispatch } from 'react-redux';

const useStyles = makeStyles((theme) => ({
  modal: {
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  },
  paper: {
    backgroundColor: theme.palette.background.paper,
    border: "2px solid #000",
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
  },
}));

export default function TitleView() {
  const classes = useStyles();
  const [titles, setTitles] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [enableCaseSensitivity, setEnableCaseSensitivity] = useState(false);
  const [enableContains, setEnableContains] = useState(false);
  const [showLoadingBar, setShowLoadingBar] = useState(true);
  const [openErrorModal, setOpenErrorModal] = React.useState(false);
  const dispatch = useDispatch();
  const selectedTitleId = useSelector(state => state.selectedTitleId);

  //#region Event Handlers
  const searchTermChanged = (event) => {
    setSearchTerm(event.target.value);
  };

  const enableCaseSensitivityChanged = (event) => {
    setEnableCaseSensitivity(event.target.checked);
  };

  const enableContainsChanged = (event) => {
    setEnableContains(event.target.checked);
  };

  const handleErrorModalClose = () => {
    setOpenErrorModal(false);
  };
  //#endregion

  const errorOccured = e => {
    console.error(e);
    setOpenErrorModal(true);
  }

  useEffect(() => {
    const getAllTitles = () => {
      TitleService.getAll()
        .then((response) => {
          setTitles(response.data);
          setShowLoadingBar(false);
        })
        .catch((e) => {
            errorOccured(e);
        });
    };

    const searchTitles = () => {
      TitleService.findByTitle(searchTerm, {
        enableCaseSensitivity,
        enableContains,
      })
        .then((response) => {
          setTitles(response.data);
          setShowLoadingBar(false);
        })
        .catch((e) => {
          errorOccured(e);
        });
    };

    const retrieveTitles = () => {
      setShowLoadingBar(true);
      if (StringHelpers.isNullOrWhitespace(searchTerm)) {
        getAllTitles();
      } else {
        searchTitles();
      }
    };

    retrieveTitles();
  }, [searchTerm, enableCaseSensitivity, enableContains, dispatch]);

  return (
    <Paper className="title-view-container" elevation={3}>
      <Modal
        className={classes.modal}
        open={openErrorModal}
        onClose={handleErrorModalClose}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
          timeout: 500,
        }}
      >
        <Fade in={openErrorModal}>
            <Alert severity="error">
                <AlertTitle>Error</AlertTitle>
                There was a problem retrieving data from the server
            </Alert>
        </Fade>
      </Modal>
      <Grid container spacing={2} direction="row">
        <Grid item xs={12}>
          {/* TODO Probably a better way to set these properties. Possibly through a single object. */}
          <SearchControl
            searchTerm={searchTerm}
            enableCaseSensitivity={enableCaseSensitivity}
            searchTermChanged={searchTermChanged}
            enableCaseSensitivityChanged={enableCaseSensitivityChanged}
            enableContains={enableContains}
            enableContainsChanged={enableContainsChanged}
          />
        </Grid>
        <Grid item xs={3}>
          {showLoadingBar ? <LinearProgress /> : null}
          <TitleTable
            titles={titles}
          ></TitleTable>
        </Grid>
        <Grid item xs={9}>
          {!selectedTitleId ? (
            <Paper elevation={3}>
              <Typography>Please make a selection to view details</Typography>
            </Paper>
          ) : (
            <TitleDetails></TitleDetails>
          )}
        </Grid>
      </Grid>
    </Paper>
  );
}
