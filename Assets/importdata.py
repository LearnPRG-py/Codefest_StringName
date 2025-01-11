import pandas as pd
import UnityEngine
import clr
import numpy as np
from System.Collections.Generic import List
from System import Single
def to_unity_list(py_list):
    unity_list = List[Single]()
    for item in py_list:
        unity_list.Add(Single(float(item)))
    return unity_list
def clean_data(series):
    series = np.nan_to_num(pd.to_numeric(series, errors='coerce'), nan=0)
    return series
maincamera = UnityEngine.GameObject.Find("Main Camera")
slider_behaviour = maincamera.GetComponent("sliderbehaviour")
df = pd.read_csv("01-01-2016-TO-01-01-2017-HCLTECH-ALL-N.csv")
slider_behaviour.HCLopen=to_unity_list(clean_data(df["Open Price  "].to_list()))
slider_behaviour.HCLclose=to_unity_list(clean_data(df["Close Price  "].to_list()))
slider_behaviour.HCLhigh=to_unity_list(clean_data(df["High Price  "].to_list()))
slider_behaviour.HCLlow=to_unity_list(clean_data(df["Low Price  "].to_list()))
df = pd.read_csv("01-01-2016-TO-01-01-2017-TATASTEEL-ALL-N.csv")
slider_behaviour.TSopen=to_unity_list(clean_data(df["Open Price  "].to_list()))
slider_behaviour.TSclose=to_unity_list(clean_data(df["Close Price  "].to_list()))
slider_behaviour.TShigh=to_unity_list(clean_data(df["High Price  "].to_list()))
slider_behaviour.TSlow=to_unity_list(clean_data(df["Low Price  "].to_list()))
df = pd.read_csv("01-01-2016-TO-01-01-2017-WIPRO-ALL-N.csv")
slider_behaviour.WIPROopen=to_unity_list(clean_data(df["Open Price  "].to_list()))
slider_behaviour.WIPROclose=to_unity_list(clean_data(df["Close Price  "].to_list()))
slider_behaviour.WIPROhigh=to_unity_list(clean_data(df["High Price  "].to_list()))
slider_behaviour.WIPROlow=to_unity_list(clean_data(df["Low Price  "].to_list()))
