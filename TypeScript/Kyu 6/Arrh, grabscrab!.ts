export function grabscrab(anagram: string, dictionary: string[]): string[] {
  const createList = (word:string) => [...word].sort().join("")
  const anagramList = createList(anagram)
  return dictionary.filter((word) => anagramList === createList(word))
}


import { assert } from "chai"
//import { grabscrab } from "./solution";

describe("grabscrab", function() {
  it("should pass sample test cases", function() {
    assert.deepEqual(grabscrab("trisf", ["first"]), ["first"], "Should have found 'first'")
    assert.deepEqual(grabscrab("oob", ["bob", "baobab"]), [], "Should not have found anything")
    assert.deepEqual(grabscrab("ainstuomn", ["mountains", "hills", "mesa"]), ["mountains"], "Should have found 'mountains'")
    assert.deepEqual(grabscrab("oolp", ["donkey", "pool", "horse", "loop"]), ["pool", "loop"], "Should have found 'pool' and 'loop'")
    assert.deepEqual(grabscrab("ortsp", ["sport", "parrot", "ports", "matey"]), ["sport", "ports"], "Should have found 'sport' and 'ports'")
    assert.deepEqual(grabscrab("ourf", ["one","two","three"]), [], "Should not have found anything")
  })
})