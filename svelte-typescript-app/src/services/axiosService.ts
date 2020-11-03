import axios from "axios";

export const axiosKey = {};

const inst = axios.create({
    baseURL: "http://localhost:5000" //TODO: put this in a config.
});
inst.interceptors.request.use((config) => {
    config.headers["Access-Control-Allow-Origin"] = "*";
    return config;
})
export const axiosInstance = inst;
