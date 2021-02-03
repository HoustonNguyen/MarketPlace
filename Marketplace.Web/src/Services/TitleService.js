import http from "../http-common";

const getAll = () => {
  return http.get("/Title/GetTitles");
};

const get = id => {
  return http.get(`/Title/GetTitle?id=${id}`);
};

const findByTitle = (searchTerm, options) => {
  return http.get(`/Title/Search`, {
    params: {
      "SearchTerm": searchTerm,
      "CaseSensitive": options.enableCaseSensitivity,
      "Contains": options.enableContains
    }
  });
};

const exportedFunctions = {
  getAll,
  get,
  findByTitle
}

export default exportedFunctions;