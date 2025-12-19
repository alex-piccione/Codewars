function number9(n)
{
    const digits = n.toString()
    let counter = 0    

    for (let position=0; position<digits.length; position++)
    {       
        let digit = parseInt(digits[position])
        if (digit != 0) {
            let zeros = digits.length-1-position
            counter += digit * zeros * Math.pow(10, zeros-1);

            if (digit == 9) 
                counter += parseInt(+digits.substr(position+1)) + 1    
        }        
    }
   
    return counter
}


/* brute force count */
function count9(n){
    var counter = 0;
    for(var x=0; x<=n; x++)
        counter += _get9(x)
    return counter;
}

function _get9(n){
    var count = 0;
    var s = n.toString();
    for(var x=0; x<s.length; x++)
        if (s[x] == '9')
            count++;
    return count;
}


//return number9(9)
//return number9(929)
//return number9(10000000000)

for (let number of [1, 9, 500, 800, 900, 123, 923, 993, 929, 1959, 565754, 10000000000])
    console.log(`for ${number} expected is ${count9(number)}, result is ${number9(number)}`)

// why 10000000000 value is not printed out ?!

console.log(`${number9(10000000000)}`)