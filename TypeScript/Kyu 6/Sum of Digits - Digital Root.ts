export const digitalRoot = (n:number):number => 
    n < 10 ? n : digitalRoot([...n.toString()].reduce((acc, digit) => acc + +digit, 0))


import {assert} from "chai";

describe("solution", () => {
  it('should work for fixed tests', () => {
    assert.equal(digitalRoot(16), 7);
    assert.equal(digitalRoot(456), 6 );
  });
});