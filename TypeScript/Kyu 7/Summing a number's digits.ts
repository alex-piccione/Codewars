export const sumDigits = (n: number):number => 
    [...Math.abs(n).toString()].reduce((acc, value) => acc + +value, 0)

// See https://www.chaijs.com for how to use Chai.
import { assert } from "chai";

describe("example", function() {
  it("test", function() {
    assert.equal(sumDigits(10), 1);
    assert.equal(sumDigits(99), 18);
    assert.equal(sumDigits(-32), 5);
  });
});