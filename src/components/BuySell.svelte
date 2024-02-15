<script>
  let rotationDegree = "0deg";
  let isbuy = false;

  function setDegrees(isbuy) {
    if (isbuy) {
      rotationDegree = "50deg";
    } else {
      rotationDegree = "-50deg";
    }
  }

  function setIsBuy(somedata) {
    if (somedata == true) {
      //  then set isbuy to true
      isbuy = true;
      setDegrees(isbuy);
    } else {
      //  then set isbuy to false
      isbuy = false;
    }
  }
</script>

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
    <h1>NEUTRAL</h1>
  </div>
  <div id="divme">
    <input placeholder="stock symbol here ex. AAPL" oninput="let p = this.selectionStart; this.value = this.value.toUpperCase();this.setSelectionRange(p, p);" type="text" id="userstockinput" />
  </div>
  <div id="divme">
    <button id="submitbutton" on:click={() => setIsBuy(true)}>SUBMIT</button>
  </div>
</div>

<style>
  #rootcontainer {
    border-style: solid;
    border-radius: 2rem;
    background-color: rgb(102, 102, 102);
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
  #userstockinput
{
    font-size:12px;
}
</style>
