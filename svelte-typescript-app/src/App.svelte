<script lang="ts">
  import { setContext } from "svelte";
  import { axiosInstance, axiosKey } from "./services/axiosService";
  import { authServicekey, createAuthService } from "./services/authService";
  import LogIn from "./LogIn.svelte";
  import Signup from "./Signup.svelte";
  import { apiKey, Api} from "./services/api";
  setContext(axiosKey, axiosInstance);
  setContext(authServicekey, undefined);
  setContext(authServicekey, createAuthService(axiosInstance));
  setContext(apiKey, new Api(axiosInstance) );//TODO: config
</script>

<style>
  main {
    text-align: center;
    padding: 1em;
    max-width: 240px;
    margin: 0 auto;
  }

  h1 {
    color: #ff3e00;
    text-transform: uppercase;
    font-size: 4em;
    font-weight: 100;
  }

  @media (min-width: 640px) {
    main {
      max-width: none;
    }
  }
</style>

<main>
  <LogIn />
  <Signup />
</main>
