def tenkasen(highest_high9, lowest_low9):
    return (highest_high9+lowest_low9)/2
def kijunsen(highest_high26, lowest_low26):
    return (highest_high26+lowest_low26)/2
def senkounspanA(highest_high9, lowest_low9, highest_high26, lowest_low26):
    return (tenkasen(highest_high9, lowest_low9)+kijunsen(highest_high26, lowest_low26))/2
def senkounspanB(highest_high52, lowest_low52):
    return (highest_high52+lowest_low52)/2
def chikouspan(closingprice26):
    return closingprice26