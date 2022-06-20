#python3

from scipy import integrate
import numpy as np

i = 0
j = 0
k = 0


def gauss(x):
    global i
    i += 1
    return np.exp(-x**2) 


def xinv(x):
    global j
    j += 1
    return 1/x**2


def xsqrd(x):
    global k
    k += 1
    return 1/(1+x**2)


def main():
    res1, err1 = integrate.quad(gauss, -np.inf, np.inf, epsabs=0.001, epsrel=0.001)
    res2, err2 = integrate.quad(xinv, 1, np.inf, epsabs=0.001, epsrel=0.001)
    res3, err3 = integrate.quad(xsqrd, -np.inf, 0, epsabs=0.001, epsrel=0.001)
    print("Using python and scipy's quad function:")
    print(f"int_-inf^inf e^(-x^2) dx = {res1} with error {err1} and {i} calls to the function.")
    print(f"int_1^inf 1/x^2 dx = {res2} with error {err2} and {j} calls to the function")
    print(f"int_-inf^0 1/(1+x^2) dx = {res3} with error {err3} and {k} calls to the function")


if __name__ == "__main__":
    main()


