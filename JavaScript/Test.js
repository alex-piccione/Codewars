Test = {
    assertEquals: function( result, expected, error) {
       if(result != expected) console.error(error + ". Expected: " + expected + ", result: " + result);
    }
}