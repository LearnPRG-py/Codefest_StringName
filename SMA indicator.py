import pandas as pd
SMA = 0
totalprice = 0
def calculate_SMA(prices, periodOfTime, i):
    for i in prices:
        totalprice += prices[i]
    SMA = totalprice / periodOfTime
    return SMA

# Prices needs to be an array of all prices over period of time
# periodOfTime is the period of time
# i is the number of prices

# Output: SMA will be the Simple Moving Average
