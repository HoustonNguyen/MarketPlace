import React, { useEffect, useState } from "react";
import { Table, TableBody, TableContainer, TableHead, TableRow, Paper, TableCell } from "@material-ui/core";
import TitleService from "../Services/TitleService";

export default function TitleView() {
    const [titles, setTitles] = useState([]);

    const getAllTitles = () => {
        TitleService.getAll()
          .then(response => {
            setTitles(response.data);
            console.log(response.data);
          })
          .catch(e => {
            console.error(e);
          });
      };

    useEffect(() => {
        getAllTitles();
      }, [])

    return (
        <TableContainer>  
            <Table stickyHeader aria-label="sticky table">
                <TableHead>
                    <TableRow>
                        <TableCell key="titleId">ID</TableCell>
                        <TableCell key="titleName">Name</TableCell>
                    </TableRow>
                </TableHead>
            </Table>
            <TableBody>
                {titles.map((row) => (
                    <TableRow key={row.titleId}>
                        <TableCell key="titleId" component="th" scope="row">{row.titleId}</TableCell>
                        <TableCell key="titleName" align="right">{row.titleName}</TableCell>
                    </TableRow>
                ))}
            </TableBody>
        </TableContainer>
    );
}