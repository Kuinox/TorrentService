<script lang="ts">
  import type { AuthService, IUserInfo } from "@signature/webfrontauth";

  import { getContext } from "svelte";
  import type { Readable } from "svelte/store";
  import { authServicekey } from "./services/authService";
  const authInstance = getContext<Readable<AuthService<IUserInfo>>>(
    authServicekey
  );
  let username: string;
  let password: string;

  async function login() {
    await $authInstance.basicLogin(username, password);
  }
</script>

<style>
</style>

<div>
  <h1>Log In</h1>
  <label>Username <input type="text" bind:value={username} /> </label>
  <label>Password <input type="password" bind:value={password} /></label>

  <button on:click={login}>Log In</button>
  {#if $authInstance !== undefined}
    <div>Hey, : {$authInstance.authenticationInfo.actualUser.userName}</div>
  {/if}
</div>
