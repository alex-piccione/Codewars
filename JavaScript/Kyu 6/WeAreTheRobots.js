function countRobots(a)
{                       
    var automatikRegex = /automatik/i;
    var mechanikRegex = /mechanik/i;
    var robotRegex = createRobotRegex();

    var automatik = 0;
    var mechanik = 0;

    for (var x=0; x<a.length; x++)
    {
        var phrase = a[x];
        var isAutomatik = phrase.match(automatikRegex); // automatikRegex.IsMatch(phrase);
        var isMechanik = !isAutomatik && phrase.match(mechanikRegex); //  !isAutomatik && mechanikRegex.IsMatch(phrase);

        if (isAutomatik || isMechanik)
        {               
            var matches = phrase.match(robotRegex);
            var robots = matches != null ? matches.length : 0; // robotRegex.Matches(phrase).Count;

            if (isAutomatik)
                automatik += robots;
            else
                mechanik += robots;
        }               
    }

    return [automatik + " robots functioning automatik", mechanik + " robots dancing mechanik"];
}

function createRobotRegex()
{
    // the robot has this shape: {leg}{body}{eye}{body}{eye}{body}{leg}
    // eye: it is a "0"
    // body: it is composed by 2 occurence of one of these: |};&#[]/><()*
    // leg: it can be one of these: abcdefghijklmnopqrstuvwxyz
    var leg = "[\w]";
    var body = "[^\w\s]{2}";
    //return RegExp(leg + body + "0" + body + "0" + body + leg);
    return /[\w][^\w\s]{2}0[^\w\s]{2}0[^\w\s]{2}[\w]/ig;
}

function countMatches(text, regex) {
    var m = text.match(regex);
    return (m != null);
}

Test = {
    assertSimilar: function( result, expected,) {
       if(result[0] != expected[0] || result[1] != expected[1]) 
        console.error(". Expected: " + expected + ", result: " + result);
    }
}


//Test.describe("Basic tests",_=> {
    var a = []
    Test.assertSimilar(countRobots(a), ["0 robots functioning automatik", "0 robots dancing mechanik"])
    
    var a = ["We're functioning automatik","And we are dancing mechanik"]
    Test.assertSimilar(countRobots(a), ["0 robots functioning automatik", "0 robots dancing mechanik"])
    
    var a = ["We're functioning automatik d[(0)(0)]b","And we are dancing mechanik d[(0)(0)]b d[(0)(0)]b"]
    Test.assertSimilar(countRobots(a), ["1 robots functioning automatik", "2 robots dancing mechanik"])
    return
    var a = ["d[(0)(0)]b We're functioning automatik d[(0)(0)]b","And we are d[(0)(0)]b dancing mechanik d[(0)(0)]b d[(0)(0)]b"]
    Test.assertSimilar(countRobots(a), ["2 robots functioning automatik", "3 robots dancing mechanik"])
    var a = ["d[(0)(0)}b We're functioning automatik D[(0)(0)]b","And we are d[(0)(0}]b dancing mechanik d[(0)(0)]b c[(0)(0)]b"]
    Test.assertSimilar(countRobots(a), ["2 robots functioning automatik", "3 robots dancing mechanik"])
    var a = ["d*(0)(0)}b We're functioning e(<0/>0]#m Automatik Roboter0%1 D[(0)(0)]b","And we are d[(0)(0}]b dancing mechanik d[(0)(0)]b c[(0)(0)]b"]
    Test.assertSimilar(countRobots(a), ["3 robots functioning automatik", "3 robots dancing mechanik"])
    var a = ["d*(0)(0)}b We're functioning d>[0;;0&&f automatik D[(0)(0)]b", 'and m><0(;0[;a we dancing are Mechanic']
    Test.assertSimilar(countRobots(a), ["3 robots functioning automatik", "0 robots dancing mechanik"])
    var a =["We're charging our battery","And now we're full of energy","We are the robots","We're functioning automatik",
        "And we are dancing mechanik","We are the robotororo robots","Ja tvoi sluga","Ja tvoi Rabotnik robotnik",
        "We are programmed just to do","anything you want us to","we are the robots","We're functioning Automatic",
        "and we are dancing Mechanic","we are the robots","Ja tvoi sluga","Ja tvoi Rabotnik robotnik",
        "We are the robots","d*(0)(0)}b We're functioning automatik D[(0)(0)]b",
        "And we are d[(0)(0}]b dancing mechanik Roboter0%1 d[(0)(0)]b c[(0)(0)]b"]
    
    Test.assertSimilar(countRobots(a), ["2 robots functioning automatik", "3 robots dancing mechanik"])
    var a = ["d (0)(0)}b We're functioning &>[0;;0&&f automatik D[(0 (0)]b", "and m><0(;0 ;a we dancing are Mechanic"]
    Test.assertSimilar(countRobots(a), ["0 robots functioning automatik", "0 robots dancing mechanik"])
//});