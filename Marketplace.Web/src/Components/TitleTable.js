import React, { useState } from "react";
import {
  Table,
  TableBody,
  TableContainer,
  TableHead,
  TableRow,
  TableCell,
  Paper,
  TablePagination
} from "@material-ui/core";

const columns = [
  { field: "titleId", headerName: "ID" },
  { field: "titleName", headerName: "Title" },
  { field: "releaseYear", headerName: "Year" },
];

export default function TitleTable({ titles, titleId, selectionCallback }) {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);

  //https://material-ui.com/components/tables/
  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  const rowSelectionChanged = (row) => {
        selectionCallback(row.titleId);
  }

  return (
    <Paper elevation={3}>
      <TableContainer>
        <Table>
          <TableHead>
            <TableRow>
              {columns.map((c) => (
                <TableCell component="th" scope="row" key={c.field}>
                  <div>{c.headerName}</div>
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {titles
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((row) => (
                <TableRow key={row.titleId} onClick={() => { rowSelectionChanged(row); }} selected={ row.titleId === titleId }>
                  {columns.map((c) => (
                    <TableCell key={c.field} scope="row">
                      <div>{row[c.field]}</div>
                    </TableCell>
                  ))}
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        rowsPerPageOptions={[10, 25, 100]}
        component="div"
        count={titles.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onChangePage={handleChangePage}
        onChangeRowsPerPage={handleChangeRowsPerPage}
      />
    </Paper>
  );
}
