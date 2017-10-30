def excluding_vat_price(price, vat=15):
    try:
        return round(price/(1+vat/100.), 2)        
    except:
        return -1


def assert_equals (result, expected):
    if result != expected:
        print(f"Fail. Expected: ${expected}, result: ${result}.")

assert_equals(excluding_vat_price(230.00), 200.00)
assert_equals(excluding_vat_price(123), 106.96)
