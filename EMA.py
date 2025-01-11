import random
test_data = [round(random.uniform(10, 100), 2) for _ in range(100)]
def mean(pastprices, length):
    sum = 0
    for i in range(length):
        sum = sum + pastprices[i]
    return sum / length
def emacalc(pastprices,length):
    days = len(pastprices)
    ema=[]
    for i in range(days-length+1):
        ema.append(0)
    ema[0] = (mean(pastprices,length))
    print(ema)
    multiplier = 2/(length+1)
    for i in range(1, days-length+1):
        print(i)
        ema[i] = (pastprices[i+4] - ema[i-1]) * multiplier + ema[i-1]
    return ema
print(emacalc(test_data, 5))
def MACDline(pastprices):
    Macdline=[]  
    for i in range(len(emacalc(pastprices, 26))):
        Macdline.append(emacalc(pastprices, 12)[i] - emacalc(pastprices, 26)[i])
    signaline = emacalc(Macdline, 9)
    return Macdline, signaline
print(MACDline(test_data))