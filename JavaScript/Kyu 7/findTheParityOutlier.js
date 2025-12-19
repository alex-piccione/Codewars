var ODD = 1, EVEN = 0;

function getKind(n) { 
    return (n % 2 == 0) ? EVEN : ODD; 
}

function findOutlier(integers) {

  var previous_Kind = null;
  var previous_N = null;
  for(var x = 0; x<integers.length; x++) {
      var this_N = integers[x];
      var this_Kind = getKind(this_N);
      if(previous_Kind != null && this_Kind != previous_Kind){
        if(x==1) {
            if(this_Kind == getKind(integers[2]))
                return previous_N;
            else
                return this_N;
        }
        return this_N;
    }
          
    previous_Kind = this_Kind;
    previous_N = this_N;
  }    
}

Test = {
    assertEquals: function( result, expected) {
       if(result != expected) console.error(". Expected: " + expected + ", result: " + result);
    }
}


Test.assertEquals(findOutlier([0, 1, 2]), 1)
Test.assertEquals(findOutlier([1, 2, 3]), 2)
Test.assertEquals(findOutlier([2,6,8,10,3]), 3)
Test.assertEquals(findOutlier([0,0,3,0,0]), 3)
Test.assertEquals(findOutlier([1,1,0,1,1]), 0)