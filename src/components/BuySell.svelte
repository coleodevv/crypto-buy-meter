<script>
  let rotationDegree = "-50deg";
  let isbuy = false;



  function selectDegrees(isbuy) {
    if (isbuy) {
      rotationDegree = "50deg";
    } else {
      rotationDegree = "-50deg";
    }
  }

function setIsBuy(somedata) {
    if(somedata == true)  {
        //  then set isbuy to true
    }else {
        //  then set isbuy to false
    }
}

</script>

<div id="container">
  <div id="divme">
    <div id="roundtop">
      <div id="anchorsquare">
        <div id="arrowcontainer" style="--rotate:{rotationDegree}">
          <div id="arrow"></div>
        </div>
      </div>
    </div>
    <div id="bottomline"></div>
  </div>
  <div id="divme"></div>
  <div id="divme"></div>
  <div id="divme"></div>
  <button>click me to change the odds</button>
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
    background-color: red;
    border-radius: 10rem 10rem 0 0;
  }
  #anchorsquare {
    width: 25px;
    height: 25px;
    background-color: rgb(204, 75, 255);
    position: relative;
    bottom: 300px;
    top: 83.5%;
    right: -50%;
    transform: translateX(-50%);
  }
  #arrowcontainer {
    position: relative;
    bottom: 6rem;
    background-color: green;
    display: flex;
    justify-content: center;
    /* SWITCH ROTATION HERE */
    rotate: var(--rotate);
    transform-origin: bottom;
  }
  #arrow {
    width: 10px;
    height: 7rem;
    background-color: chocolate;
    position: relative;
    transform: rotate(0.5turn);
  }
</style>
