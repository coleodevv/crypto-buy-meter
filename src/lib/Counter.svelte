<script>
  let count = 0;
  let userInputColor = "";

  // NEW COLOR THAT CHANGES
  let newColor = "#ff3e00";

  const increment = () => {
    count += 1;
  };
</script>

<button on:click={increment}>
  count is {count}
</button>


<!-- This section is where the change occurs -->
<div style="--fuck: {userInputColor}">
  <p>this text is gonna change color</p>
</div>
<input type="color" bind:value={newColor} style="height: 100px; width: 100px" />

<input bind:value={userInputColor} />
<button>the color you chose is: {userInputColor}</button>

<style>
  p {
    background-color: var(--fuck);
  }
</style>
