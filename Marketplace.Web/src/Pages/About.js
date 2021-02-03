import { Paper, Typography } from "@material-ui/core";

export default function About() {
    return (
        <Paper elevation={3}>
            <Typography variant="h4"  gutterBottom>About</Typography>
            <Typography>
                This is a simple single page, React-based web application that communictaes with a RESTFul API in order to retrieve some information
                that is stored in a database.
            </Typography>
            <Typography>
                The tech-stack involves, as mentioned, a React-based front-end, a .NET Core API backend, and MS SQLExpress as data storage.
            </Typography>
        </Paper>
    );
}