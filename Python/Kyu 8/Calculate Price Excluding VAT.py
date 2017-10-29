VAT = 15.00
def excluding_vat_price(price):
    try:
        return round(price / (1+VAT/100.), 2) or -1
    except:
        return -3




def assert_equals (result, expected):
    if result != expected:
        print(f"Fail. Expected: ${expected}, result: ${result}.")



assert_equals(excluding_vat_price(230.00), 200.00)
assert_equals(excluding_vat_price(123), 106.96)