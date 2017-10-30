function excludingVatPrice(price){
    return price != null ? Math.round((price/1.15)*100)/100 : -1
}


const excludingVatPrice = (price) => price != null ? Math.round((price/1.15)*100)/100 : -1

// others solutions
excludingVatPrice = p => p === null ? -1 : +(p / 1.15).toFixed(2);



  //---------------------------------------------------------

Test.describe('Fixed Tests', _ => {
    Test.it("Test", __ => {
        Test.assertSimilar(excludingVatPrice(230), 200.00);
        Test.assertSimilar(excludingVatPrice(123), 106.96);
    });
});