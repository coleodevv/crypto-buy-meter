<script>
  import svelteLogo from "./assets/svelte.svg";
  import viteLogo from "/vite.svg";
  import Counter from "./lib/Counter.svelte";

  import BuySell from "./components/BuySell.svelte";
</script>

<main>
  <div id="mainContainer">
    <BuySell />
  </div>
</main>

<style>
  #mainContainer {
    width: 100vw;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: rgb(0, 0, 0);
  }
</style>
