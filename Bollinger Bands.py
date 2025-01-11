# Aryan Add the Unity Pipelining here. The info needs to be in a file whose path is saved in "file_path"
file_path = 1 #Temporary, you will have to change.
SMA = 0
totalprice = 0

def calculate_SMA(prices, periodOfTime, i):
    for i in prices:
        totalprice += prices[i]
    SMA = totalprice / periodOfTime

SMA = calculate_SMA

def calculate_SD(price, periodOfTime, i):
    for u in price:
        ToBeSummed += (price - SMA)*(price - SMA)
    SD = (ToBeSummed / periodOfTime) * (-1/2)

SD = calculate_SD

def calculate_ub(price, periodOfTime, i):
    for i in price:
        ub = SMA + (SD * 2)
    
UB = calculate_ub

def calculate_lb(price, periodOfTime, i):
    for i in price:
        lb = SMA - (SD * 2)

LB = calculate_lb

#LB and UB will be plotted. UB -> Red, LB -> Green