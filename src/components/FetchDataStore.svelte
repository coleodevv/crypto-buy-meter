<!-- store to fetch all the application data -->
<script>
  export async function getMovingAverage(coin) {
    try {
      let uri = `http://localhost:5206/api/sma/${coin}`;
      const promiseResult = await fetch(uri);
      const jsObject = await promiseResult.json();
      return jsObject;
    } catch (error) {
        console.log("Unable to fetch:", error);
    }
  }

  export async function getPrice(coin) {
    try {
      let uri = `http://localhost:5206/api/symbolinfo/${coin}`;
      const promiseResult = await fetch(uri);
      const jsObject = await promiseResult.json();
      return jsObject;
    } catch (error) {
        console.log("Unable to fetch:", error);
    }
  }

</script>

