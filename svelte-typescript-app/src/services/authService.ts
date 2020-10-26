import type { AuthService } from "@signature/webfrontauth";

export const authServicekey = {};

let instance: AuthService | undefined;
let promise: Promise<AuthService> | undefined;

export async function initialize(): Promise<AuthService> {
    if (instance !== undefined) return instance;
    if (promise !== undefined) return promise;
    promise = initializeInternal();
    return promise;
}

async function initializeInternal(): Promise<AuthService> {

}
