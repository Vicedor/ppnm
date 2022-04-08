#python3

from scipy import integrate
import numpy as np

i = 0
j = 0


def sqrtx(x):
    global i
    i += 1
    return 1/np.sqrt(x)


def lnxsqrtx(x):
    global j
    j += 1
    return np.log(x)/np.sqrt(x)


def main():
    a = 0
    b = 1
    res1 = integrate.quadrature(sqrtx, a, b, tol=0.001, rtol=0.001)
    res2 = integrate.quadrature(lnxsqrtx, a, b, tol=0.001, rtol=0.001)
    print("Using python and scipy's quad function:")
    print(f"int_0^1 dx 1/sqrt(x) = {res1} with {i} calls to the function.")
    print(f"int_0^1 dx ln(x)/sqrt(x) = {res2} with {j} calls to the function")


if __name__ == "__main__":
    main()


