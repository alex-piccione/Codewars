/* Should return ᐃ type:
  0 : if ᐃ cannot be made with given sides
  1 : acute ᐃ
  2 : right ᐃ
  3 : obtuse ᐃ
*/

function swap(sides, a,b)
{
    sides[a] = sides[a]+sides[b];
    sides[b] = sides[a]-sides[b];
    sides[a] = sides[a]-sides[b];
    return sides;
}

function sort(sides) 
{
    if(sides[0] > sides[1])
        swap(sides, 0, 1);
    if(sides[1] > sides[2])
    {
        swap(sides, 1, 2);
        if(sides[0] > sides[1])
            swap(sides, 0, 1);      
    }
    return sides;
}

function triangleType(a, b, c)
{
    var sides = sort([a,b,c]);
   
    if(sides[2] >= (sides[0] + sides[1]))
        return 0;
   
    var rightTest = sides[0]*sides[0] + sides[1]*sides[1] - sides[2]*sides[2];
    if(rightTest == 0) 
        return 2;

    var ab_angle_rad = Math.acos( rightTest / (2*sides[0] * sides[1]) ) ;    
    var ab_angle = ab_angle_rad*180.0 / Math.PI;
    if (ab_angle < 90)
        return 1;   
    else
        return 3;
}