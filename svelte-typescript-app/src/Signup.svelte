<script lang="ts">
  import { getContext } from "svelte";
  import { apiKey, Api } from "./services/api";
  const api = getContext<Api>(apiKey);
  let username: string;
  let password: string;

  function signup() {
    return api.signup(username, password);
  }
</script>

<style>
</style>

<div>
  <h1>Create Account</h1>
  <label>Username <input type="text" bind:value={username} /></label>

  <label>Password <input type="password" bind:value={password} /></label>

  <button on:click={signup}>Create account</button>
</div>
