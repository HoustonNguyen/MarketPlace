import http from "../http-common";

const getAll = () => {
  return http.get("/Title/GetTitles");
};

const get = id => {
  return http.get(`/Title/GetTitle?id=${id}`);
};

const findByTitle = (searchTerm, options) => {
  let caseSensitivityParam = (options.enableCaseSensitivity ? `&caseSensitive=${options.enableCaseSensitivity}` : "");
  let containsParam = (options.enableContains ? `&contains=${options.enableContains}` : "");
  return http.get(`/Title/Search?searchTerm=${searchTerm}${caseSensitivityParam}${containsParam}`);
};

const exportedFunctions = {
  getAll,
  get,
  findByTitle
}

export default exportedFunctions;