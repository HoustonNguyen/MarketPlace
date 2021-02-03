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
import { useSelector,useDispatch } from 'react-redux';

const columns = [
  { field: "titleId", headerName: "ID" },
  { field: "titleName", headerName: "Title" },
  { field: "releaseYear", headerName: "Year" },
];

export default function TitleTable({ titles }) {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);

  //Local state for the input
  const [selectedTitleIdLocal, setSelectedTitleIdLocal] = useState(useSelector(state => state.selectedTitleId));

  //Use for all the dispatch actions
  const dispatch = useDispatch()

  //https://material-ui.com/components/tables/
  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
    setSelectedTitleIdLocal(null);
    dispatch({type:'UNSET_SELECTED_TITLE_ID'});
  };

  const rowSelectionChanged = (row) => {
    setSelectedTitleIdLocal(row.titleId);
    dispatch({type:'SET_SELECTED_TITLE_ID', payload: row.titleId});
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
                <TableRow key={row.titleId} onClick={() => { rowSelectionChanged(row); }} selected={ row.titleId === selectedTitleIdLocal }>
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
