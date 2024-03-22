<script>
  import { onMount } from "svelte";
  import FetchDataStore from "./FetchDataStore.svelte";

  let rotationDegree = "0deg";
  let isbuy = false;
  let buyOrSell = "Choose Crypto Ticker";
  let fetchDataStore;
  let closePrice;
  let sma100days;
  let inputCoinString;

  function calculateArrow(price, sma) {
    if (price > sma) {
      isbuy = true;
    } else {
      isbuy = false;
    }
    if (isbuy == true) {
      buyOrSell = inputCoinString + " IS A BUY";
    } else if (isbuy == false) {
      buyOrSell = inputCoinString + " IS A SELL";
    }
    console.log(`isbuy is set to ${isbuy}`);
    setArrowDirection();
  }

  function setArrowDirection() {
    if (isbuy) {
      rotationDegree = "50deg";
    } else {
      rotationDegree = "-50deg";
    }
  }
  function resetArrow() {
    rotationDegree = "0deg";
    buyOrSell = "Choose Crypto Ticker";
  }

  let stats = {};

  function displayStats(statsobj) {
    stats.open = statsobj.results[0].o;
    stats.close = statsobj.results[0].c;
    stats.priceHigh100days = statsobj.results[0].h;
    stats.priceLow100days = statsobj.results[0].l;
    stats.vwap = statsobj.results[0].vw;
    stats.volume = statsobj.results[0].v;
  }

  async function getMovingAverage(coin) {
    let result = await fetchDataStore.getMovingAverage(coin);
    sma100days = result.results.values[0].value;
    stats.sma100day = sma100days;
  }

  async function getPrice(coin) {
    let result = await fetchDataStore.getPrice(coin);
    closePrice = result.results[0].c;
    displayStats(result);
  }

  async function fetchWrapper(input) {
    await getMovingAverage(input);
    await getPrice(input);
    console.log("The current sma is " + sma100days);
    console.log("The current closeprice is " + closePrice);
    calculateArrow(closePrice, sma100days);
  }
</script>

<FetchDataStore bind:this={fetchDataStore} />

<div id="rootcontainer">
  <div id="divme">
    <div id="roundtop">
      <div id="anchorsquare">
        <div id="arrowcontainer" style="--rotate:{rotationDegree}">
          <div id="arrow">
            <div id="arrowhead"></div>
          </div>
        </div>
      </div>
    </div>
    <div id="bottomline"></div>
  </div>
  <div id="divme">
    <h1>{buyOrSell}</h1>
  </div>
  <h3 id="secretmessage">{inputCoinString} is bellow the 100 day moving average</h3>
  <div id="divme">
    <input
      placeholder="insert coin: ex. BTC"
      oninput="this.value = this.value.toUpperCase();"
      on:input={() => resetArrow()}
      bind:value={inputCoinString}
      type="text"
      id="userstockinput"
    />
  </div>
  <div id="statsbox">
    <h3>Ticker stats:</h3>
    {#each Object.entries(stats) as [type, data]}
      <h1 id="stat">{type.toLowerCase()} : {data}</h1>
    {/each}
  </div>
  <div id="divme">
    <button id="submitbutton" on:click={() => fetchWrapper(inputCoinString)}
      >SUBMIT</button
    >
  </div>
</div>

<style>
  #rootcontainer {
    border-style: solid;
    border-radius: 2rem;
    background-color: rgb(102, 102, 102);
  }
  #statsbox {
    width: 30rem;
    height: 20rem;
  }
  #stat {
    font-size: 1rem;
    font-weight: 400;
    display: flex;
    justify-content: flex-start;
  }
  #secretmessage {
    display: flex;
    justify-content: center;
    align-items: center;
    margin: 0px;
    padding: 0px;
  }
  #divme {
    border-radius: 5rem;
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 1rem;
  }
  #roundtop {
    width: 300px;
    height: 150px;
    background-color: rgb(216, 216, 216);
    border-radius: 10rem 10rem 0 0;
  }
  #anchorsquare {
    width: 35px;
    height: 35px;
    background-color: rgb(0, 0, 0);
    border-radius: 1rem 1rem 0 0;
    position: relative;
    bottom: 300px;
    top: 76.2%;
    right: -50%;
    transform: translateX(-50%);
  }
  #arrowcontainer {
    position: relative;
    bottom: 6rem;
    display: flex;
    justify-content: center;
    /* SWITCH ROTATION HERE */
    rotate: var(--rotate);
    transform-origin: bottom;
    transform: translateY(10%);
    transition: 400ms linear all;
  }
  #arrow {
    width: 10px;
    height: 7rem;
    background-color: rgb(0, 0, 0);
    justify-self: center;
  }
  #arrowhead {
    width: 0;
    height: 0;
    border-left: 15px solid transparent;
    border-right: 15px solid transparent;
    border-bottom: 25px solid rgb(61, 155, 24);
    position: relative;
    left: -10px;
    bottom: 20px;
  }
  #userstockinput {
    width: 50%;
    padding: 1rem;
  }
  #submitbutton {
    width: 62%;
    padding: 1rem;
  }
  #userstockinput {
    font-size: 12px;
  }
</style>
