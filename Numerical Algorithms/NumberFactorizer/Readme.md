# Number Factorizer

The goal of this algorithm is to find prime factors of a positive integer.

## Steps

1. Define a list for stroing prime factors.
2. If an input number is less than 2, terminate the function. Because, prime numbers start at 2.
3. The only even prime number is 2. Define a loop and keep dividing by 2 until the remainder is 0. At each division add 2 to the list.
4. Define the next prime number as 3. At this point next prime numbers will be odd only, which means we can add 2 at each step of the future loop.
5. Define the upper bound for the future loop as square root of the input number. The prime factors start to repeat themselves in backwards after this threshold.
6. Define a loop that will be executed until the next prime number variable defined at the step 4 will be less than the upper bound defined in the latter step.
7. In the loop keep dividing by the next prime number variable, only if the remainder equals to zero. At each division add the next prime number's variable to the list.
8. If the remainder from the previous step is not 0, then increment the next prime number variable by 2. And repeat the step 7.
