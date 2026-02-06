export function grabscrab(anagram: string, dictionary: string[]): string[] {

  const createCharMap = (word:string) => {
    const charMap = new Map<string, number>()
    for (const char of word) {
        const currentCount = charMap.get(char) ?? 0
        charMap.set(char, currentCount + 1)
    }
    return charMap
  }

  let mapsAreEqual = (mapA:Map<string, number>, mapB:Map<string, number>) => {
    if (mapA.size !== mapB.size) return false
    
    for (const char of mapA.keys())
        if (mapA.get(char) !== mapB.get(char))
            return false
        
    return true
  }    

  const mapOfAnagram = createCharMap(anagram)

  return dictionary.filter((word) => mapsAreEqual(mapOfAnagram, createCharMap(word)))
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