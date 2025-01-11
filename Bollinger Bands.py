# Aryan Add the Unity Pipelining here. The info needs to be in a file whose path is saved in "file_path"
file_path = 1 #Temporary, you will have to change.
SMA = 0
totalprice = 0

def calculate_SMA(prices, periodOfTime, n):
    for i in range(n):
        totalprice += prices[i]
    SMA = totalprice / periodOfTime
    return SMA

SMA = calculate_SMA

def calculate_SD(price, periodOfTime, n):
    for i in range(n):
        ToBeSummed += (price - SMA)*(price - SMA)
    SD = (ToBeSummed / periodOfTime) * (-1/2)
    return SD

SD = calculate_SD

def calculate_ub(price, periodOfTime):
    ub = SMA + (SD * 2)
    return ub
    
UB = calculate_ub

def calculate_lb(price, periodOfTime):
    lb = SMA - (SD * 2)
    return lb

LB = calculate_lb

#LB and UB will be plotted. UB -> Red, LB -> Green