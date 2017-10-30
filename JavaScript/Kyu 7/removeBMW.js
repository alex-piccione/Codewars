function removeBMW(str){    
    if(typeof(str) !== "string")
        throw Error("This program only works for text.");
    return str.replace(/[bmw]+/ig, "");
}

//------------------------------------------------------------

Test = {
    assertEquals: function( result, expected) {
        if(result != expected) console.error(". Expected: " + expected + ", result: " + result);
    },
    expectError: function(message, action) {
        try {
            action()
        }
        catch (err) {
            return;
        }
        console.error(message);
    }
}
    
Test.assertEquals(removeBMW("bmwvolvoBMW"), "volvo");
Test.assertEquals(removeBMW("bbmmww"), "");
Test.expectError("It should throw an error when an array is sent as an argument", function(){ removeBMW([]) });
Test.expectError("It should throw an error when pass number 2", function() {removeBMW(2)});