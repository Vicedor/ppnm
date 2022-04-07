#python3

from scipy import integrate
import math

i = 0
j = 0


def sqrtx(x):
    global i
    i += 1
    return 1/math.sqrt(x)


def lnxsqrtx(x):
    global j
    j += 1
    return math.log(x)/math.sqrt(x)


def main():
    a = 0
    b = 1
    res1 = integrate.quad(sqrtx, a, b, epsabs=0.001, epsrel=0.001)
    res2 = integrate.quad(lnxsqrtx, a, b)
    print("Using python and scipy's quad function:")
    print(f"int_0^1 dx 1/sqrt(x) = {res1[0]} with {i} calls to the function.")
    print(f"int_0^1 dx ln(x)/sqrt(x) = {res2[0]} with {j} calls to the function")


if __name__ == "__main__":
    main()


