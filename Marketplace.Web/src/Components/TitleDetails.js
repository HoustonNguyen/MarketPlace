import {
  Grid,
  LinearProgress,
  makeStyles,
  Paper,
  TextField,
} from "@material-ui/core";
import { useEffect, useState } from "react";
import TitleService from "../Services/TitleService";
import Accordion from "@material-ui/core/Accordion";
import AccordionSummary from "@material-ui/core/AccordionSummary";
import AccordionDetails from "@material-ui/core/AccordionDetails";
import Typography from "@material-ui/core/Typography";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import DetailsTable from "./DetailsTable";

const useStyles = makeStyles({
  bold: {
    fontWeight: 700,
  },
  accordianHeader: {
    backgroundColor: "cornflowerblue",
  },
  accordianContent: {
    backgroundColor: "white",
  }
});

const awardColumns = [
  { field: "awardName", headerName: "Name" },
  { field: "awardCompany", headerName: "Served By" },
  { field: "awardWon", headerName: "Status" },
  { field: "awardYear", headerName: "Year" },
];

const participantColumns = [
  { field: "name", headerName: "Name" },
  { field: "roleType", headerName: "Role" },
  { field: "isOnScreen", headerName: "On Screen" },
  { field: "isKey", headerName: "Is Key" },
];

export default function TitleDetails(props) {
  const classes = useStyles();
  const { titleId } = props;
  const [title, setTitle] = useState({});
  const [showLoadingBar, setShowLoadingBar] = useState(true);

  useEffect(() => {
    setShowLoadingBar(true);
    if (titleId) {
      TitleService.get(titleId).then((response) => {
        setTitle(response.data);
        setShowLoadingBar(false);
      });
    }
  }, [titleId]);

  const parseGenres = (title) => {
    if (!title.genres) {
      return "";
    }

    let genres = title.genres
      .map((g) => g.name)
      .reduce((a, b) => {
        return `${a}, ${b}`;
      });

    return genres;
  };

  const parseOtherNames = (title) => {
    if (!title.otherNames) {
      return "";
    }

    let otherNames = title.otherNames
      .map((on) => on.titleName)
      .reduce((a, b) => {
        return `${a}, ${b}`;
      });

    return otherNames;
  };

  return (
    <Paper elevation={3}>
      {showLoadingBar ? <LinearProgress /> : null}
      <Grid container spacing={0}>
        <Grid item xs={6}>
          <Typography className={classes.bold}>
            {title.titleName}{" "}
            {title.releaseYear ? `(${title.releaseYear})` : ""}
          </Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>
            Date Processed: {new Date(title.processedDateTimeUtc).toString()}{" "}
            {/* Convert this time to local machine time */}
          </Typography>
        </Grid>
        <Grid item xs={12}>
          <p className={classes.bold}>Summary</p>
          {title.storyLines
            ? title.storyLines.map((s) => (
                <Accordion key={s.id} className={classes.accordianHeader}>
                  <AccordionSummary
                    className={classes.accordianHeader}
                    expandIcon={<ExpandMoreIcon />}
                  >
                    <Typography noWrap>
                      {s.type}&nbsp;{`(${s.language})`}
                    </Typography>
                  </AccordionSummary>
                  <AccordionDetails className={classes.accordianContent}>
                    <Typography>{s.description}</Typography>
                  </AccordionDetails>
                </Accordion>
              ))
            : ""}
        </Grid>
        <Grid item xs={12}>
          <TextField
            fullWidth
            label="Genres"
            multiline
            rowsMax={4}
            value={title.genres ? parseGenres(title) : ""}
          />
        </Grid>
        <Grid item xs={12}>
          {/* TODO A textfield is not appropriate because there is other metadata that we want to show and allow users to edit */}
          <TextField
            fullWidth
            label="Other Names"
            multiline
            rowsMax={4}
            value={title.otherNames ? parseOtherNames(title) : ""}
          />
        </Grid>
        <Grid item xs={6}>
          <Typography className={classes.bold}>Credits</Typography>
          {title.credits && title.credits.length > 0 ? (
            <DetailsTable
              rowData={title.credits}
              columnData={participantColumns}
            ></DetailsTable>
          ) : (
            <p>No Credits</p>
          )}
        </Grid>
        <Grid item xs={6}>
          <Typography className={classes.bold}>Awards</Typography>
          {title.awards && title.awards.length > 0 ? (
            <DetailsTable
              rowData={title.awards}
              columnData={awardColumns}
            ></DetailsTable>
          ) : (
            <p>No Awards</p>
          )}
        </Grid>
      </Grid>
    </Paper>
  );
}
