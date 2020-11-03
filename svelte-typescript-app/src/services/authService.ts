import { AuthService, IUserInfo } from "@signature/webfrontauth";
import type { AxiosInstance } from "axios";
import { readable } from "svelte/store";
export const authServicekey = {};
export function createAuthService(axios: AxiosInstance) {
    let authService = new AuthService({ //TODO: put this in a config.
        identityEndPoint: {
            disableSsl: true,
            hostname: 'localhost',
            port: 5000
        }
    }, axios);
    authService.refresh(true, true, true);
    return readable(authService, (set) => {
        const updater = (eventSource: AuthService<IUserInfo>) => set(eventSource);
        authService.addOnChange(updater);
        return () => {
            authService.removeOnChange(updater);
        }
    });
}
