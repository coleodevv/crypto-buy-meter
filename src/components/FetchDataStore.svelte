<!-- store to fetch all the application data -->
<script>
  export async function getMovingAverage() {
    try {
      let uri = "http://localhost:5206/api/sma/btcusd";
      const promiseResult = await fetch(uri);
      const jsObject = await promiseResult.json();
      console.log(jsObject);
    } catch (error) {
        console.log("Unable to fetch:", error);
    }
  }

  export function sayHello() {
    console.log("Hello");
  }
</script>

<button on:click={()=>getMovingAverage()}>Fetch data</button>
<button on:click={()=>sayHello()}>Say hello</button>
