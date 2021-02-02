import axios from "axios";
//Defines the base URL that all services will hit
export default axios.create({
  baseURL: "https://localhost:44356/",
  headers: {
    "Content-type": "application/json"
  }
});