import http from "../http-common";

const getAll = () => {
  return http.get("/Title");
};

const get = id => {
  return http.get(`/Title/${id}`);
};

const findByTitle = title => {
  return http.get(`/Title/Search?title=${title}`);
};

export default {
  getAll,
  get,
  findByTitle
};