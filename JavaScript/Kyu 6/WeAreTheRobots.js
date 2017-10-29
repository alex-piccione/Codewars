const automatikRegex = /automatik/i;
const mechanikRegex = /mechanik/i;
// the robot has this shape: {leg}{body}{eye}{body}{eye}{body}{leg}
// eye: it is a "0"
// body: it is composed by 2 occurence of one of these: |};&#[]/><()*
// leg: it can be one of these: abcdefghijklmnopqrstuvwxyz
// => d[(0)(0)]b 
const robotRegex = /[\w][^\w\s]{2}0[^\w\s]{2}0[^\w\s]{2}[\w]/ig; 

function countRobots(phrases)
{                       
    let automatik = 0, mechanik = 0;

    for(let phrase of phrases)
    {
        var isAutomatik = phrase.match(automatikRegex);
        var isMechanik = !isAutomatik && phrase.match(mechanikRegex);

        if (isAutomatik || isMechanik)
        {               
            var robots = (phrase.match(robotRegex) || []).length;

            if (isAutomatik)
                automatik += robots;
            else
                mechanik += robots;
        }               
    }
    return [`${automatik} robots functioning automatik`, `${mechanik} robots dancing mechanik`];
}


Test = {
    assertSimilar: function( result, expected,) {
       if(result[0] != expected[0] || result[1] != expected[1]) 
        console.error(". Expected: " + expected + ", result: " + result);
    }
}



var a = []
Test.assertSimilar(countRobots(a), ["0 robots functioning automatik", "0 robots dancing mechanik"])

var a = ["We're functioning automatik","And we are dancing mechanik"]
Test.assertSimilar(countRobots(a), ["0 robots functioning automatik", "0 robots dancing mechanik"])

var a = ["We're functioning automatik d[(0)(0)]b","And we are dancing mechanik d[(0)(0)]b d[(0)(0)]b"]
Test.assertSimilar(countRobots(a), ["1 robots functioning automatik", "2 robots dancing mechanik"])

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
