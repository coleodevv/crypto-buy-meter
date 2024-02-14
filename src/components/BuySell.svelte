<script>
  let rotationDegree = "-50deg";
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

<div id="container">
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
  <div id="divme"></div>
  <div id="divme"></div>
  <div id="divme"></div>
  <button on:click={() => setIsBuy(true)}>click me to change the odds</button>
</div>

<style>
  #container {
    height: 400px;
    width: 500px;
    border: 10px;
    border-style: solid;
    border-color: rgb(49, 255, 49);
  }
  #divme {
    /* border-style: solid; */
    border-color: rgb(49, 255, 49);
  }

  #roundtop {
    width: 300px;
    height: 150px;
    background-color: rgb(63, 114, 209);
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
    border-bottom: 25px solid red;
    position: relative;
    left: -10px;
    bottom: 20px;
  }
</style>
