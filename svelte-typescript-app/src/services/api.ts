import type { AxiosInstance } from "axios";
import { debug } from "svelte/internal";

export class Api {
    private _axios: AxiosInstance;
    public constructor(_axios: AxiosInstance) {
        this._axios = _axios;
    }

    async signup(username: string, password: string) {
        const res = await this._axios.post(`api/signup?username=${username}&password=${password}`);
        if (res.status != 200) throw new Error(); //TODO: better error handling.
    }
}

export const apiKey = {};
