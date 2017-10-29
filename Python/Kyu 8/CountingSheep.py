def count_sheeps(arrayOfSheeps):      
    return arrayOfSheeps.count()
    return len(list(filter(lambda x: x, arrayOfSheeps)))



# ---------------------------------------------------

def assert_equals(val_1, val_2, error):
    if val_1 != val_2:
        print(error)


array1 = [True,  True,  True,  False,
    True,  True,  True,  True ,
    True,  False, True,  False,
    True,  False, False, True ,
    True,  True,  True,  True ,
    False, False, True,  True ];

assert_equals(count_sheeps(array1), 17, "There are 17 sheeps in total, not %s" % count_sheeps(array1))

array1 = [True, False, None ];
assert_equals(count_sheeps(array1), 1, "There are 1 sheeps in total, not %s" % count_sheeps(array1))