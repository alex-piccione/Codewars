function cakes(recipe, available) {

  let minQuantity = -1
  for (let ingredient in recipe) {
    if (!available[ingredient])
      return 0

    const quantity = Math.floor(available[ingredient] / recipe[ingredient]) 
    if (minQuantity == -1 || quantity < minQuantity)
      minQuantity = quantity
  }

  return minQuantity
}


const {assert} = require('chai');

describe('description example', function() {
  it('pass example tests', function() {
    let recipe = {flour: 500, sugar: 200, eggs: 1};
    let available = {flour: 1200, sugar: 1200, eggs: 5, milk: 200};
    assert.equal(cakes(recipe, available), 2);
    
    recipe = {apples: 3, flour: 300, sugar: 150, milk: 100, oil: 100};
    available = {sugar: 500, flour: 2000, milk: 2000};
    assert.equal(cakes(recipe, available), 0);
  });
});