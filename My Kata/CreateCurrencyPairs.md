# Create Currency Pairs

## Definition

You are parsing a cryptocurrencies web site.
You want to create currency pairs like AAA/BBB.
You can load the list of Currencies from the web page.
In the list of pairs you want only the pair in one direction, for example AAA/BBB but not BBB/AAA.
The direction is defined by a priority of currencies (a list). The currency that came first should be in the left part of the pair. In absence of at least one currency of the pair in the priority list both the direction are valid for that pair.



## Tests

### 1 (no priority)
input { currencies: ["AAA", "BBB", "CCC"], priority: "" }
outputs = ["AAA/BBB" or "BBB/AAA", "AAA/CCC" or "CCC/AAA", "BBB/CCC" or "CCC/BBB"]

### 2 (null currency, no priority)
input = { currencies: ["AAA", "BBB", ""], priority: [] }
outputs = ["AAA/BBB" or "BBB/AAA"]

### 3 (priority)
input = []
outputs = []

### 4 (wrong priority)
input { currencies: ["AAA", "BBB", "CCC"], priority: "AAA, DDD" }

### 5 (double priority)
input { currencies: ["AAA", "BBB"], priority: "AAA, BBB, AAA" }


# Use cases 

- The list can be empty

- A currency can appear more times

